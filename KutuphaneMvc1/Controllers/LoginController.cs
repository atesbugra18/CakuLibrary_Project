using KutuphaneMvc1.Models;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using KutuphaneMvc1.Utils;
using System.IO;
using System.Web.Services.Description;

public class LoginController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Login(LogRegViewModel model)
    {
        string kullaniciıd = "0", role = "", storedSalt = "", storedHash = "";
        if (!string.IsNullOrEmpty(model.LogKullaniciAdi.ToUpper()) && !string.IsNullOrEmpty(model.LogSifre))
        {
            string query = "SELECT * FROM KullaniciSistem WHERE KullaniciAdi = @kullaniciadi";
            bool isAuthenticated = false;
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                cmd.Parameters.AddWithValue("@kullaniciadi", model.LogKullaniciAdi);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        storedHash = reader["Sifre"].ToString();
                        storedSalt = reader["Salt"].ToString();
                        role = reader["Rolu"].ToString();
                        kullaniciıd = reader["KullaniciID"].ToString();
                        if (VerifyPassword(model.LogSifre, storedHash, storedSalt))
                        {
                            isAuthenticated = true;
                        }
                        else
                        {
                        }
                    }
                    else
                    {

                    }
                }
            });
            if (isAuthenticated)
            {
                TempData["Message"] = "Giriş başarılı!";
                TempData["IsSuccess"] = true;
                return RedirectToAction("Index", "Result");
            }
            else
            {
                TempData["Message"] = "Kullanıcı adı veya şifre hatalı.";
                TempData["IsSuccess"] = false;
                return RedirectToAction("Index", "Result");
            }
        }
        else
        {
            TempData["Message"] = "Lütfen tüm alanları doldurun.";
            TempData["IsSuccess"] = false;
            return RedirectToAction("Index", "Result");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Register(LogRegViewModel model)
    {
        if (!string.IsNullOrEmpty(model.LogKullaniciAdi) && !string.IsNullOrEmpty(model.LogSifre))
        {
            string query = "SELECT * FROM KullaniciSistem WHERE KullaniciAdi = @kullaniciadi";
            bool isAuthenticated = false;
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                cmd.Parameters.AddWithValue("@kullaniciadi", model.LogKullaniciAdi);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader["Sifre"].ToString();
                        string storedSalt = reader["Salt"].ToString();
                        string role = reader["Rolu"].ToString();
                        string kullaniciıd = reader["KullaniciID"].ToString();
                        if (VerifyPassword(model.LogSifre, storedHash, storedSalt))
                        {
                            isAuthenticated = true;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                    }
                }
            });

            if (isAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
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
