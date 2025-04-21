using KutuphaneMvc1.Models;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;

public class LoginController : Controller
{
    private readonly string baglanti = ConfigurationManager.ConnectionStrings["Baglantı"].ConnectionString;

    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LogRegViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.LoginError = "Lütfen tüm alanları doldurun!";
            return View("Index", model);
        }

        using (var connection = new SqlConnection(baglanti))
        {
            try
            {
                await connection.OpenAsync();
                string query = "SELECT Sifre, Salt, Rolu FROM KullaniciSistem WHERE KullaniciAdi = @KullaniciAdi";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", model.LogKullaniciAdi);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string storedHash = reader["Sifre"].ToString();
                            string storedSalt = reader["Salt"].ToString();
                            string role = reader["Rolu"].ToString();

                            if (VerifyPassword(model.LogSifre, storedHash, storedSalt))
                            {
                                if (role == "Admin" || role == "Görevli")
                                {
                                    // Masaüstü uygulamasını başlat
                                    string exePath = Server.MapPath("~/bin/Kutuphane.exe"); 
                                    Process.Start(exePath);
                                    return Content("Masaüstü uygulaması başlatıldı.");
                                }
                                else
                                {
                                    Session["KullaniciAdi"] = model.LogKullaniciAdi;
                                    Session["Rol"] = role;
                                    return RedirectToAction("Index", "Home");
                                }
                            }
                            else
                            {
                                ViewBag.LoginError = "Şifre hatalı!";
                            }
                        }
                        else
                        {
                            ViewBag.LoginError = "Kullanıcı bulunamadı!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.LoginError = "Bir hata oluştu: " + ex.Message;
            }
        }

        return View("Index", model);
    }

    [HttpPost]
    public async Task<ActionResult> Register(LogRegViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.RegSifre != model.RegSifreTekrar)
            {
                ViewBag.RegisterError = "Şifreler eşleşmiyor!";
                return View("Index", model);
            }

            using (var connection = new System.Data.SqlClient.SqlConnection(baglanti))
            {
                try
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO Users (KullaniciAdi, TcKimlikNo, Ad, Soyad, Email, Sifre) " +
                                   "VALUES (@KullaniciAdi, @TcKimlikNo, @Ad, @Soyad, @Email, @Sifre)";
                    using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciAdi", model.RegKullaniciAdi);
                        command.Parameters.AddWithValue("@TcKimlikNo", model.TcKimlikNo);
                        command.Parameters.AddWithValue("@Ad", model.Ad);
                        command.Parameters.AddWithValue("@Soyad", model.Soyad);
                        command.Parameters.AddWithValue("@Email", model.Email);
                        command.Parameters.AddWithValue("@Sifre", model.RegSifre);
                        await command.ExecuteNonQueryAsync();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.RegisterError = "Bir hata oluştu: " + ex.Message;
                }
            }
        }
        else
        {
            ViewBag.RegisterError = "Lütfen tüm alanları doldurun!";
        }

        return View("Index", model);
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

}
