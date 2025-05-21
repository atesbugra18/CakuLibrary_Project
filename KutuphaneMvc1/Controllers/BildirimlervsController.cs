using Kutuphane.Utils;
using KutuphaneMvc1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
            aktifBaglanti = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();
            BildirimVs b = new BildirimVs();
            string query = "Select BildirimId,Mesaj,Baslik,Tarih,Okundu from Bildirimler where KullaniciId=@KullaniciId";
            using (SqlConnection con = new SqlConnection(aktifBaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciId", Session["KullaniciId"]);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bildirim bildirimler = new Bildirim
                            {
                                BildirimId = Convert.ToInt32(reader["BildirimId"]),
                                BildirimBasligi = reader["Baslik"].ToString(),
                                BildirimMesaji = reader["Mesaj"].ToString(),
                                BildirimTarih = Convert.ToDateTime(reader["Tarih"]).Date
                            };
                            b.Bildirimler.Add(bildirimler);
                        }
                    }
                }
            }
            return View(b);
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
                    cmd3.Parameters.AddWithValue("@aliciId",userid);
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
        // Helper classes for AIRequest and AIMessage
        private class AIRequest
        {
            public string model { get; set; }
            public AIMessage[] messages { get; set; }
            public double temperature { get; set; }
        }

        private class AIMessage
        {
            public string role { get; set; }
            public string content { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> YapayZekayaGonder(string prompt)
        {
            aktifBaglanti = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();
            if (prompt.Contains("Benim için bir kitap öner."))
            {
                prompt += "Kullanıcının Daha Önce Okumuş Olduğu Kitaplar\n";
                string query = "select Kitaplar.KitapAdi,Yazarlar.YazarAdi+' '+Yazarlar.YazarSoyadi as 'yazaradisoyadi',Kategoriler.KategoriAdi from Kitaplar,Yazarlar,Kategoriler,OduncAlma where Kitaplar.YazarId=Yazarlar.YazarId and kitaplar.KategoriId=kategoriler.KategoriId and OduncAlma.KullaniciId=@KullaniciId and OduncAlma.KitapId=Kitaplar.KitapId";
                using (SqlConnection con = new SqlConnection(aktifBaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd=new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciId", Session["KullaniciId"]);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string kitapadi = reader["KitapAdi"].ToString();
                                string yazaradisoyadi = reader["yazaradisoyadi"].ToString();
                                string kategoriadi = reader["KategoriAdi"].ToString();
                                prompt += $"Kitap Adı: {kitapadi}, Yazar: {yazaradisoyadi}, Kategori: {kategoriadi}\n";
                            }
                        }
                    }
                }
            }
            string csvPath = Server.MapPath("~/OrtakNesneler/CSV/kitaplar.csv");
            if (!string.IsNullOrWhiteSpace(csvPath) && System.IO.File.Exists(csvPath))
            {
                try
                {
                    var csvContent = System.IO.File.ReadAllText(csvPath, Encoding.UTF8);
                    prompt += $"\nCSV İçeriği:\n{csvContent}\n";
                }
                catch (Exception ex)
                {
                    return Content($"CSV dosyası okunamadı: {ex.Message}");
                }
            }
            if (string.IsNullOrWhiteSpace(prompt))
                return Content("Lütfen geçerli bir mesaj giriniz");
            try
            {
                var httpClient = new HttpClient();
                var requestUri = "http://127.0.0.1:1234/v1/chat/completions";
                var request = new AIRequest
                {
                    model = "mistral-7b-instruct-v0.2-turkish",
                    messages = new[] { new AIMessage { role = "user", content = prompt } },
                    temperature = 0.7
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(requestUri, content);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                dynamic responseData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseString);
                string yapayZekaMesaji = responseData.choices[0].message.content.ToString();
                await KaydetMesaj(Session["KullaniciId"], prompt, yapayZekaMesaji);
                return Content(yapayZekaMesaji);
            }
            catch (Exception ex)
            {
                return Content($"Hata oluştu: {ex.Message}");
            }
        }

        private async Task KaydetMesaj(object kullaniciId, string prompt, string yanit)
        {
            aktifBaglanti = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();
            string query = @"INSERT INTO YapayZekaMesajlasmalari 
                    (KullaniciId, Tarih, Mesaj, Prompt) 
                    VALUES (@gonid, @ts, @mes, @prmt)";
            using (var con = new SqlConnection(Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString()))
            {
                await con.OpenAsync();
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@gonid", kullaniciId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ts", DateTime.Now);
                    cmd.Parameters.AddWithValue("@mes", yanit);
                    cmd.Parameters.AddWithValue("@prmt", prompt);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}