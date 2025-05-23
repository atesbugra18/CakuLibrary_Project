using Kutuphane;
using Kutuphane.Utils;
using KutuphaneMvc1.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
namespace KutuphaneMvc1.Controllers
{
    public class BildirimlervsController : Controller
    {
        // GET: Bildirimlervs
        static string aktifBaglanti;
        static string resimyolu;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Notifications()
        {
            var connStr = DatabaseHelper.GetActiveConnectionString();
            var model = new BildirimVs();
            const string sql = @"SELECT BildirimId, Mesaj, Baslik, Tarih, Okundu 
                         FROM Bildirimler WHERE KullaniciId = @KullaniciId";
            using (var con = new SqlConnection(connStr))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciId", Session["KullaniciId"]);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            model.Bildirimler.Add(new Bildirim
                            {
                                BildirimId = rdr.GetInt32(0),
                                BildirimBasligi = rdr["Baslik"]?.ToString(),
                                BildirimMesaji = rdr["Mesaj"]?.ToString(),
                                BildirimTarih = rdr.GetDateTime(3).Date,
                                BildirimTuru = "Kisisel"
                            });
                        }
                    }
                }
            }
            string jsonDir = Server.MapPath(PathHelper.Mesajlar);
            foreach (var file in Directory.EnumerateFiles(jsonDir, "*.json"))
            {
                try
                {
                    var json = System.IO.File.ReadAllText(file);
                    var jm = JsonConvert.DeserializeObject<BildirimModell>(json);
                    if (jm == null) continue;
                    _ = DateTime.TryParse(jm.BildirimTarihi?.ToString(), out var tarih); // güvenli parse
                    model.Bildirimler.Add(new Bildirim
                    {
                        BildirimId = jm.BildirimID,
                        BildirimBasligi = jm.BildirimBaslik,
                        BildirimMesaji = jm.BildirimIcerik,
                        BildirimTarih = tarih,
                        BildirimTuru = "Sistem"
                    });
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"JSON okuma hatası: {file}\n{ex}");
                }
            }
            model.Bildirimler = model.Bildirimler
                                .OrderByDescending(b => b.BildirimTarih)
                                .ToList();
            return View(model);
        }
        public ActionResult Messages()
        {
            aktifBaglanti = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();
            BildirimVs b = new BildirimVs();
            string query2 = "SELECT KullaniciSistem.KullaniciId as 'GorevliId',KullaniciSistem.KullaniciAdi, Rolu, KullaniciBilgileri.ProfilFotoUrl FROM KullaniciSistem JOIN KullaniciBilgileri ON KullaniciSistem.KullaniciId = KullaniciBilgileri.KullaniciId WHERE KullaniciSistem.Rolu IN ('Admin', 'Görevli');";
            using (SqlConnection con = new SqlConnection(aktifBaglanti))
            {
                con.Open();
                using (SqlCommand cmd2 = new SqlCommand(query2, con))
                {
                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            GorevliKullanici gorevli = new GorevliKullanici
                            {
                                KullaniciId = Convert.ToInt32(reader2["GorevliId"]),
                                KullaniciAdi = reader2["KullaniciAdi"].ToString(),
                                KullaniciResmi = PathHelper.ProfilPicture + "/" + reader2["ProfilFotoUrl"].ToString(),
                                Rolü = reader2["Rolu"].ToString()
                            };
                            b.Gorevliler.Add(gorevli);
                        }
                    }
                }
            }
            return View(b);
        }
        [HttpPost]
        public ActionResult UserDetail(int userid, string username, string userimage)
        {
            aktifBaglanti = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();
            BildirimVs b = new BildirimVs();
            string query3 = "SELECT Gonderen.KullaniciAdi AS 'Gönderen Adı',Alici.KullaniciAdi AS 'Alıcı Adı',Mesajlasmalar.Mesaj,Mesajlasmalar.TarihSaat FROM Mesajlasmalar JOIN KullaniciSistem AS Gonderen ON Mesajlasmalar.GonderenId = Gonderen.KullaniciId  JOIN KullaniciSistem AS Alici ON Mesajlasmalar.AliciId = Alici.KullaniciId WHERE (Mesajlasmalar.GonderenId = @gonderenId AND Mesajlasmalar.AliciId = @aliciId)OR(Mesajlasmalar.GonderenId = @aliciId AND Mesajlasmalar.AliciId = @gonderenId) ORDER BY Mesajlasmalar.TarihSaat ASC;";
            using (SqlConnection con = new SqlConnection(aktifBaglanti))
            {
                con.Open();
                using (SqlCommand cmd3 = new SqlCommand(query3, con))
                {
                    cmd3.Parameters.AddWithValue("@gonderenId", Session["KullaniciId"]);
                    cmd3.Parameters.AddWithValue("@aliciId", userid);
                    using (SqlDataReader reader3 = cmd3.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            Mesajlasmalar mesajlasmalar = new Mesajlasmalar
                            {
                                MesajıAtanınAdı = reader3["Gönderen Adı"].ToString(),
                                Mesaj = reader3["Mesaj"].ToString(),
                                TarihSaat = Convert.ToDateTime(reader3["TarihSaat"])
                            };
                            b.Mesajlasmalar.Add(mesajlasmalar);
                        }
                    }
                }
            }
            ViewBag.UserId = userid;
            ViewBag.UserName = username;
            ViewBag.UserImage = userimage;
            resimyolu = userimage;
            return View(b);
        }
        string tempmesaj;
        [HttpPost]
        public ActionResult MesajGonder(int alici, string aliciadi, string mesajicerik, string gonderenadi)
        {
            if (tempmesaj != mesajicerik)
            {
                aktifBaglanti = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();
                string query = "Insert Into Mesajlasmalar(GonderenId,AliciId,Mesaj,TarihSaat) values (@gonid,@alid,@mes,@ts)";
                DateTime mesajzamani = DateTime.Now;
                string formatli = mesajzamani.ToString("yyyy-MM-dd HH:mm:ss.fff");
                using (SqlConnection con = new SqlConnection(aktifBaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@gonid", Session["KullaniciId"]);
                        cmd.Parameters.AddWithValue("@alid", alici);
                        cmd.Parameters.AddWithValue("@mes", mesajicerik);
                        cmd.Parameters.AddWithValue("@ts", formatli);
                        cmd.ExecuteNonQuery();
                    }
                }
                tempmesaj = mesajicerik;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        private class AIRequest
        {
            public string model { get; set; }
            public AIMessage[] messages { get; set; }
            public double temperature { get; set; }
            public int max_tokens { get; set; }
            public bool stream { get; set; }
        }

        private class AIMessage
        {
            public string role { get; set; }
            public string content { get; set; }
        }
        static readonly string apikey = "AIzaSyDTTH3hnYxyDvQlphtJeD1p95dr6gQT7hc"; // <--- GÜVENLİK RİSKİ!
        static readonly string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={apikey}";


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> YapayZekayaGonder(string prompt)
        {
            #region Lm Studio
            //string prompt2 = ;
            //var httpClient = new HttpClient();
            //var requestUri = "http://192.168.1.100:1234/v1/chat/completions";
            //var requestBody = new
            //{
            //    model = "mistral-7b-instruct-v0.3",
            //    messages = new[]
            //    {
            //        new { role = "user", content = prompt }
            //    },
            //    temperature = 0.3,
            //    stream=false,
            //    max_tokens=6500
            //};
            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await httpClient.PostAsync(requestUri, content);
            //if (response.IsSuccessStatusCode)
            //{
            //    var responseContent = await response.Content.ReadAsStringAsync();
            //    var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);
            //    var message = responseObject.choices[0].message.content.ToString();
            //    return message;
            //}
            //else
            //{
            //    return Content("Hata");
            //}
            #endregion
            #region Api for gemini
            aktifBaglanti = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();

            if (string.IsNullOrWhiteSpace(prompt))
            {
                return Content("Lütfen geçerli bir mesaj giriniz.");
            }

            // Kitap önerisi için prompt'u zenginleştirme
            if (prompt.Contains("Benim için bir kitap öner."))
            {
                prompt += "\nKullanıcının Daha Önce Okumuş Olduğu Kitaplar ve bu kitapların bilgileri aşağıdadır. Bu bilgilere göre ve kullanıcının okuma geçmişine uygun, daha önce okumadığı bir kitap önerisinde bulun. Önerini sadece kitap adı, yazar ve kısa bir açıklama şeklinde yap.\n";
                string query = @"SELECT Kitaplar.KitapAdi, 
                                        Yazarlar.YazarAdi + ' ' + Yazarlar.YazarSoyadi AS yazaradisoyadi, 
                                        Kategoriler.KategoriAdi 
                                 FROM Kitaplar
                                 JOIN Yazarlar ON Kitaplar.YazarId = Yazarlar.YazarId
                                 JOIN Kategoriler ON Kitaplar.KategoriId = Kategoriler.KategoriId
                                 JOIN OduncAlma ON OduncAlma.KitapId = Kitaplar.KitapId
                                 WHERE OduncAlma.KullaniciId = @KullaniciId";

                using (SqlConnection con = new SqlConnection(aktifBaglanti))
                {
                    try
                    {
                        await con.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Session["KullaniciId"] null ise DBNull.Value kullan
                            cmd.Parameters.AddWithValue("@KullaniciId", Session["KullaniciId"] ?? (object)DBNull.Value);
                            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                            {
                                bool hasRows = false;
                                while (await reader.ReadAsync())
                                {
                                    hasRows = true;
                                    string kitapadi = reader["KitapAdi"]?.ToString() ?? "Bilinmiyor";
                                    string yazaradisoyadi = reader["yazaradisoyadi"]?.ToString() ?? "Bilinmiyor";
                                    string kategoriadi = reader["KategoriAdi"]?.ToString() ?? "Bilinmiyor";
                                    prompt += $"Kitap Adı: {kitapadi}, Yazar: {yazaradisoyadi}, Kategori: {kategoriadi}\n";
                                }
                                if (!hasRows)
                                {
                                    prompt += "Kullanıcının daha önce okuduğu bir kitap bulunamadı.\n";
                                }
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Veritabanı Hatası (Prompt Zenginleştirme): {sqlEx.ToString()}");
                        // Kullanıcıya hata göstermek yerine prompt'u zenginleştirmeden devam edebilir
                        // veya bir hata mesajı dönebilirsiniz. Şimdilik sadece logluyoruz.
                        prompt += "Kullanıcının okuma geçmişi alınırken bir sorun oluştu.\n";
                    }
                    // `con` bloğu sonunda otomatik olarak kapanacaktır.
                }
            }

            try
            {
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            role = "user", // "role" alanı eklendi
                            parts = new[]
                            {
                                new { text = prompt }
                            }
                        }
                    },
                    // İsteğe bağlı: API'nin davranışını daha iyi kontrol etmek için
                    // generationConfig = new { temperature = 0.7, maxOutputTokens = 1000 /*, vb. */ },
                    // safetySettings = new [] {
                    //    new { category = "HARM_CATEGORY_SEXUALLY_EXPLICIT", threshold = "BLOCK_NONE" },
                    //    // Diğer güvenlik ayarları eklenebilir
                    // }
                };

                string jsonBody = JsonConvert.SerializeObject(requestBody);
                System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Gönderilecek JSON: {jsonBody}");

                using (var client = new HttpClient())
                {
                    // Timeout süresi ekleyebilirsiniz, varsayılan 100 saniyedir.
                    // client.Timeout = TimeSpan.FromSeconds(30); 

                    var requestContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = null;
                    string responseString = null;

                    try
                    {
                        response = await client.PostAsync(endpoint, requestContent);
                        responseString = await response.Content.ReadAsStringAsync();

                        System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] API Yanıt Durum Kodu: {response.StatusCode}");
                        System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Alınan Ham API Yanıtı: {responseString}");

                        if (response.IsSuccessStatusCode)
                        {
                            try
                            {
                                var jsonResponse = JObject.Parse(responseString);
                                var text = jsonResponse["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                                if (text != null)
                                {
                                    // Başarılı yanıtı ve prompt'u kaydet
                                    await KaydetMesaj(Session["KullaniciId"], prompt, text);
                                    return Content(text);
                                }
                                else
                                {
                                    // Yanıt başarılı (200 OK) ama beklenen 'text' alanı bulunamadı.
                                    System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] API yanıtı başarılı (200 OK) ancak 'text' alanı bulunamadı. Yanıt: {responseString}");
                                    return Content("API'den yanıt alındı ancak içerik ayrıştırılamadı. Lütfen logları kontrol edin.");
                                }
                            }
                            catch (JsonReaderException jsonEx)
                            {
                                // API'den 200 OK geldi ama yanıt JSON değilse veya bozuksa.
                                System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] JSON Parse Hatası (Yanıt 200 OK olmasına rağmen): {jsonEx.ToString()}");
                                return Content($"API'den gelen yanıt JSON formatında değil veya bozuk (Durum Kodu: {response.StatusCode}). Lütfen logları kontrol edin. Hata: {jsonEx.Message}. Ham Yanıt: {responseString}");
                            }
                        }
                        else // response.IsSuccessStatusCode == false
                        {
                            string errorMessage = $"API Hatası: {response.StatusCode}.";
                            try
                            {
                                // API'den gelen hata mesajı da JSON formatında olabilir.
                                var errorJson = JObject.Parse(responseString);
                                errorMessage += $" Mesaj: {errorJson?["error"]?["message"]?.ToString() ?? responseString}";
                            }
                            catch (JsonReaderException)
                            {
                                // Hata yanıtı JSON değilse, ham yanıtı kullan.
                                errorMessage += $" Detay: {responseString}";
                            }
                            System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {errorMessage}");
                            return Content(errorMessage);
                        }
                    }
                    catch (HttpRequestException httpEx)
                    {
                        // Ağ veya DNS sorunları gibi HTTP isteği gönderilirken oluşan hatalar.
                        System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] HTTP İstek Hatası (client.PostAsync): {httpEx.ToString()}");
                        return Content("🚨 API'ye ulaşırken bir bağlantı hatası oluştu: " + httpEx.Message);
                    }
                    catch (TaskCanceledException tcEx) // HttpClient timeout için
                    {
                        System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] İstek zaman aşımına uğradı: {tcEx.ToString()}");
                        return Content("🚨 API isteği zaman aşımına uğradı.");
                    }
                    finally
                    {
                        response?.Dispose(); // HttpResponseMessage'ı dispose et.
                    }
                }
            }
            catch (JsonException jsonEx) // JsonConvert.SerializeObject(requestBody) için
            {
                System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] İstek JSON'u oluşturulurken hata: {jsonEx.ToString()}");
                return Content("İstek oluşturulurken bir JSON hatası oluştu: " + jsonEx.Message);
            }
            catch (Exception ex) // Beklenmeyen diğer tüm hatalar için genel bir catch.
            {
                System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Genel bir hata oluştu (YapayZekayaGonder ana try-catch): {ex.ToString()}");
                // Kullanıcıya çok detaylı hata mesajları göstermek yerine genel bir mesaj verilebilir.
                return Content("Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin veya sistem yöneticisine başvurun.");
            }
            #endregion
            //return Content("İşlem tamamlandı.");
        }

        private async Task KaydetMesaj(object kullaniciIdObj, string prompt, string yanit)
        {
            // kullaniciIdObj'nin DBNull olup olmadığını kontrol et veya int'e çevir.
            int? kullaniciId = null;
            if (kullaniciIdObj != null && kullaniciIdObj != DBNull.Value)
            {
                if (int.TryParse(kullaniciIdObj.ToString(), out int id))
                {
                    kullaniciId = id;
                }
            }

            // aktifBaglanti burada tekrar alınabilir veya sınıf seviyesinde tutulabilir.
            // Ancak her seferinde almak daha stateless bir yapı sağlar.
            string baglantiStr = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();
            string query = @"INSERT INTO YapayZekaMesajlasmalari 
                             (KullaniciId, Tarih, Mesaj, Prompt) 
                             VALUES (@kId, @ts, @mes, @prmt)";
            try
            {
                using (var con = new SqlConnection(baglantiStr))
                {
                    await con.OpenAsync();
                    using (var cmd = new SqlCommand(query, con))
                    {
                        // Eğer KullaniciId null ise DBNull.Value olarak ata
                        cmd.Parameters.AddWithValue("@kId", kullaniciId.HasValue ? (object)kullaniciId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@ts", DateTime.Now);
                        cmd.Parameters.AddWithValue("@mes", yanit ?? string.Empty); // Yanıt null ise boş string kaydet
                        cmd.Parameters.AddWithValue("@prmt", prompt ?? string.Empty); // Prompt null ise boş string kaydet
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] YapayZekaMesajı Kaydetme Hatası: {sqlEx.ToString()}");
                // Bu hata kullanıcıya yansıtılmamalı, sadece loglanmalı.
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] YapayZekaMesajı Kaydetme Genel Hatası: {ex.ToString()}");
            }
        }

        // ... (Sınıfın diğer metotları) ...
    }
}