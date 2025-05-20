using Kutuphane.Utils;
using KutuphaneMvc1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            aktifBaglanti = Kutuphane.Utils.DatabaseHelper.GetActiveConnectionString();
            BildirimVs b = new BildirimVs();
            string query = "Select BildirimId,Mesaj,Baslik,Tarih,Okundu from Bildirimler where KullaniciId=@KullaniciId";
            string query2 = "SELECT KullaniciSistem.KullaniciId as 'GorevliId',KullaniciSistem.KullaniciAdi, Rolu, KullaniciBilgileri.ProfilFotoUrl FROM KullaniciSistem JOIN KullaniciBilgileri ON KullaniciSistem.KullaniciId = KullaniciBilgileri.KullaniciId WHERE KullaniciSistem.Rolu IN ('Admin', 'Görevli');";
            string query3 = "SELECT Gonderen.KullaniciAdi AS 'Gönderen Adı', Alici.KullaniciAdi AS 'Alıcı Adı', Mesajlasmalar.Mesaj, Mesajlasmalar.TarihSaat FROM  Mesajlasmalar JOIN KullaniciSistem AS Gonderen ON Mesajlasmalar.GonderenId = Gonderen.KullaniciId JOIN KullaniciSistem AS Alici ON Mesajlasmalar.AliciId = Alici.KullaniciId WHERE Mesajlasmalar.GonderenId = @KullaniciId OR Mesajlasmalar.AliciId = @KullaniciId ORDER BY Mesajlasmalar.TarihSaat ASC;";
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
            return View();
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
    }
}