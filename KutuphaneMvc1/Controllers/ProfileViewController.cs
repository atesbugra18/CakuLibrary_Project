using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using Kutuphane.Utils;
using KutuphaneMvc1.Models;
using KutuphaneMvc1.Utils;

namespace KutuphaneMvc1.Controllers
{
    public class ProfileViewController : Controller
    {
        // GET: ProfileView
        public async Task<ActionResult> Index()
        {
            string query = "Select KullaniciSistem.*,KullaniciBilgileri.* from KullaniciSistem inner join KullaniciBilgileri on KullaniciSistem.KullaniciId=KullaniciBilgileri.KullaniciId where KullaniciSistem.KullaniciAdi=@Kullaniciadi";
            KullaniciEdit kullaniciEdit = null;

            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                cmd.Parameters.AddWithValue("@Kullaniciadi", Session["KullaniciAdi"]);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        kullaniciEdit = new KullaniciEdit
                        {
                            KullaniciAdi = reader["KullaniciAdi"].ToString(),
                            Ad = reader["Ad"].ToString(),
                            Soyad = reader["Soyad"].ToString(),
                            Tc = reader["Tc"].ToString(),
                            CezaTutari = reader["AktifCezaTutari"].ToString(),
                            Email = reader["Email"].ToString(),
                            Rolu = reader["Rolu"].ToString(),
                            Sifre = reader["Sifre"].ToString(),
                            Salt = reader["Salt"].ToString()
                        };
                    }
                }
            });
            int sıralaması = 0;
            string query2 = "SELECT SiraNo FROM (SELECT ROW_NUMBER() OVER (ORDER BY COUNT(o.KitapId) DESC) AS SiraNo, ku.KullaniciAdi, u.Ad + ' ' + u.Soyad AS UyeAdiSoyadi, u.Email, COUNT(o.KitapId) AS ToplamOdunc, MAX(o.TeslimTarihi) AS SonOduncTarihi FROM KullaniciBilgileri u INNER JOIN OduncAlma o ON u.KullaniciId = o.KullaniciId INNER JOIN KullaniciSistem ku ON u.KullaniciId = ku.KullaniciId GROUP BY u.Ad, u.Soyad, u.Email, ku.KullaniciAdi) AS Siralama WHERE KullaniciAdi = @KullaniciAdi";
            await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
            {
                cmd.Parameters.AddWithValue("@KullaniciAdi", Session["KullaniciAdi"]);
                object result = await cmd.ExecuteScalarAsync();
                if (result != null)
                {
                    sıralaması = Convert.ToInt32(result);
                    kullaniciEdit.Sıralama = sıralaması;
                }
            });
            string query3 = "SELECT COUNT(o.KitapId) AS OkunanKitapSayisi FROM OduncAlma o INNER JOIN KullaniciSistem ks ON o.KullaniciId = ks.KullaniciId WHERE ks.KullaniciAdi = @KullaniciAdi";
            await DatabaseHelper.DatabaseQueryAsync(query3, async cmd =>
            {
                cmd.Parameters.AddWithValue("@KullaniciAdi", Session["KullaniciAdi"]);
                object result = await cmd.ExecuteScalarAsync();
                if (result != null)
                {
                    kullaniciEdit.OkunanKitapSayisi = Convert.ToInt32(result);
                    int sayisaldeger = Convert.ToInt32(result);
                    if (sayisaldeger <= 10)
                    {
                        kullaniciEdit.UyeKademesi = "Yeni Yetme";
                    }
                    else if (sayisaldeger > 10 && sayisaldeger <= 25)
                    {
                        kullaniciEdit.UyeKademesi = "Gündelik Okuyucu";
                    }
                    else if (sayisaldeger > 25 && sayisaldeger <= 50)
                    {
                        kullaniciEdit.UyeKademesi = "Kitap Sevdalısı";
                    }
                    else if (sayisaldeger > 50 && sayisaldeger <= 100)
                    {
                        kullaniciEdit.UyeKademesi = "Kitap Kurdu";
                    }
                    else if (sayisaldeger > 100 && sayisaldeger <= 250)
                    {
                        kullaniciEdit.UyeKademesi = "Kurtların Kabusu";
                    }
                }
            });
            string query4 = "SELECT COUNT(y.KitapId) AS ToplamYorumSayisi FROM Yorumlar y INNER JOIN KullaniciSistem ks ON y.KullaniciId = ks.KullaniciId WHERE ks.KullaniciAdi = @KullaniciAdi";
            await DatabaseHelper.DatabaseQueryAsync(query4, async cmd =>
            {
                cmd.Parameters.AddWithValue("@KullaniciAdi", Session["KullaniciAdi"]);
                object result = await cmd.ExecuteScalarAsync();
                if (result != null)
                {
                    kullaniciEdit.ToplamYorumSayisi = Convert.ToInt32(result);
                }
            });
            return View(kullaniciEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Guncelle(KullaniciEdit model, HttpPostedFileBase file, string BilgileriGuncelle, string HesabıSil, string ResmiKaldir)
        {
            if (ResmiKaldir == "")
            {
                string defaultImage = "varsayilankullanici.png";
                Session["ProfilResmi"] = PathHelper.ProfilPicture + "\\" + defaultImage;
                TempData["ProfileImageMessage"] = "Profile image removed.";
                string query = "UPDATE KullaniciBilgileri SET ProfilFotoUrl = @ProfilResmi WHERE KullaniciId = @kullaniciId";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@ProfilResmi", defaultImage);
                    cmd.Parameters.AddWithValue("@kullaniciId", Session["KullaniciId"]);
                    await cmd.ExecuteNonQueryAsync();
                });
                return RedirectToAction("Index");
            }
            else if (BilgileriGuncelle == "BilgileriGuncelle")
            {
                string profileImagePath = Session["ProfilResmi"]?.ToString();
                bool sifreGuncellendi = false;
                if (!string.IsNullOrEmpty(model.Sifre) && !string.IsNullOrEmpty(model.YeniSifre) && !string.IsNullOrEmpty(model.YeniSifreTekrar))
                {
                    if (model.YeniSifre == model.YeniSifreTekrar)
                    {
                        string storedHash = null;
                        string storedSalt = null;
                        string queryGet = "SELECT Sifre, Salt FROM KullaniciSistem WHERE KullaniciId = @kullaniciId";
                        await DatabaseHelper.DatabaseQueryAsync(queryGet, async cmd =>
                        {
                            cmd.Parameters.AddWithValue("@kullaniciId", Session["KullaniciId"]);
                            using (var reader = await cmd.ExecuteReaderAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    storedHash = reader["Sifre"].ToString();
                                    storedSalt = reader["Salt"].ToString();
                                }
                            }
                        });
                        if (!string.IsNullOrEmpty(storedHash) && !string.IsNullOrEmpty(storedSalt) &&
                            VerifyPassword(model.Sifre, storedHash, storedSalt))
                        {
                            string newHash, newSalt;
                            HashPassword(model.YeniSifre, out newHash, out newSalt);
                            string queryUpdateSifre = "UPDATE KullaniciSistem SET Sifre=@Sifre, Salt=@Salt WHERE KullaniciId=@kullaniciId";
                            await DatabaseHelper.DatabaseQueryAsync(queryUpdateSifre, async cmd =>
                            {
                                cmd.Parameters.AddWithValue("@Sifre", newHash);
                                cmd.Parameters.AddWithValue("@Salt", newSalt);
                                cmd.Parameters.AddWithValue("@kullaniciId", Session["KullaniciId"]);
                                await cmd.ExecuteNonQueryAsync();
                            });
                            sifreGuncellendi = true;
                            TempData["PasswordUpdateMessage"] = "Şifre Başarıyla Güncellendi.";
                        }
                        else
                        {
                            TempData["PasswordUpdateError"] = "Eski Şifrenizi Yanlış Girdiniz.";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["PasswordUpdateError"] = "Yeni Şifreler Uyuşmuyor.";
                        return RedirectToAction("Index");
                    }
                }
                string query = "UPDATE KullaniciBilgileri SET Ad=@Ad, Soyad=@Soyad, Tc=@Tc, Email=@Email, ProfilFotoUrl=@ProfilResmi WHERE KullaniciId=@kullaniciId";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@Ad", model.Ad ?? "");
                    cmd.Parameters.AddWithValue("@Soyad", model.Soyad ?? "");
                    cmd.Parameters.AddWithValue("@Tc", model.Tc ?? "");
                    cmd.Parameters.AddWithValue("@Email", model.Email ?? "");
                    cmd.Parameters.AddWithValue("@ProfilResmi", profileImagePath ?? "");
                    cmd.Parameters.AddWithValue("@kullaniciId", Session["KullaniciId"]);
                    await cmd.ExecuteNonQueryAsync();
                });
                Session["ProfilResmi"] = PathHelper.ProfilPicture + "\\" + profileImagePath;
                TempData["ProfileUpdateMessage"] = "Profile information updated successfully.";
                return RedirectToAction("Index");
            }
            else if (HesabıSil == "HesabıSil")
            {
                string query = "UPDATE KullaniciSistem set AktifPasif=0 where kullaniciId=@kullaniciıd";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kullaniciıd", Session["KullaniciId"]);
                    await cmd.ExecuteNonQueryAsync();
                });
                Session.Clear();
                TempData["ProfileDeleteMessage"] = "Hesap Silme İşlemi Başarılı.";
                return RedirectToAction("Index", "Login");
            }
            else if (file != null && file.ContentLength > 0)
            {
                string ext = Path.GetExtension(file.FileName);
                string kullaniciAdi = model.KullaniciAdi ?? (Session["KullaniciAdi"]?.ToString() ?? Guid.NewGuid().ToString());
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    kullaniciAdi = kullaniciAdi.Replace(c, '_');
                }
                string fileName = kullaniciAdi + "_" + Guid.NewGuid().ToString("N") + ext;
                string folder = Server.MapPath("~/OrtakNesneler/PP/");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string fullPath = Path.Combine(folder, fileName);
                file.SaveAs(fullPath);
                string profileImagePath = fileName;
                string query = "UPDATE KullaniciBilgileri SET ProfilFotoUrl=@ProfilResmi WHERE KullaniciId=@kullaniciId";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@ProfilResmi", profileImagePath);
                    cmd.Parameters.AddWithValue("@kullaniciId", Session["KullaniciId"]);
                    await cmd.ExecuteNonQueryAsync();
                });
                Session["ProfilResmi"] = PathHelper.ProfilPicture + "\\" + profileImagePath;
                TempData["ProfileImageMessage"] = "Profile image updated successfully.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(enteredPassword + storedSalt);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string enteredHash = Convert.ToBase64String(hashBytes);
                return enteredHash == storedHash;
            }
        }
        public static void HashPassword(string password, out string hashedPassword, out string salt)
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                hashedPassword = Convert.ToBase64String(hashBytes);
            }
        }
        public ActionResult LogOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}