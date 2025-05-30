﻿using KutuphaneMvc1.Models;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Web.Services.Description;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.SqlServer.Server;
using Kutuphane.Utils;
using KutuphaneMvc1.Utils;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Net;

public class LoginController : Controller
{
    private static readonly string BaglantıV = ConfigurationManager.ConnectionStrings["BaglantıV"].ConnectionString;
    private static readonly string BaglantıSefa = ConfigurationManager.ConnectionStrings["BaglantıSefa"].ConnectionString;
    static string aktifbaglanti;
    public async Task<ActionResult> Index()
    {
        aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
        await CsvHelper.ExportAsync();
        if (aktifbaglanti == null)
        {

        }
        return View();
    }
    public ActionResult ForgotPassword()
    {
        return View();
    }
    #region Login
    [HttpPost]
    public async Task<ActionResult> Login(LogRegViewModel model)
    {
        string username = model.LogKullaniciAdi;
        string enteredPassword = model.LogSifre;
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredPassword))
        {
            TempData["ErrorMessage"] = "Lütfen tüm alanları doldurun.";
            return RedirectToAction("Index");
        }

        string query;
        if (username.Contains("@"))
        {
            query = @"SELECT
                              ks.KullaniciId,
                              ks ks.Sifre,
                              ks.Salt,
                              ks.Rolu,
                              kb.Email,
                              kb.Ad + ' ' + kb.Soyad AS 'adisoyadi',
                              kb.ProfilFotoUrl
                            FROM
                              KullaniciSistem ks
                              INNER JOIN KullaniciBilgileri kb ON ks.KullaniciId = kb.KullaniciId
                            WHERE
                              kb.Email = @username;";
        }
        else if (username.Length == 11 && username.All(char.IsDigit))
        {
            query = @"SELECT
                              ks.KullaniciId,
                              ks.Sifre,
                              ks.Salt,
                              ks.Rolu,
                              kb.TC,
                              kb.Ad + ' ' + kb.Soyad AS 'adisoyadi',
                              kb.ProfilFotoUrl
                            FROM
                              KullaniciSistem ks
                              INNER JOIN KullaniciBilgileri kb ON ks.KullaniciId = kb.KullaniciId
                            WHERE
                              kb.TC = @username;";
        }
        else
        {
            username = username.ToUpper();
            query = @"SELECT
                              ks.KullaniciId,
                              ks.Kullaniciadi,
                              ks.Sifre,
                              ks.Salt,
                              ks.Rolu,
                              kb.Ad + ' ' + kb.Soyad AS 'adisoyadi',
                              kb.ProfilFotoUrl
                            FROM
                              KullaniciSistem ks
                              INNER JOIN KullaniciBilgileri kb ON ks.KullaniciId = kb.KullaniciId
                            WHERE
                              ks.KullaniciAdi = @username;";
        }
        bool isAuthenticated = await KontrolEtVeOturumuAc(username, enteredPassword, query);
        if (isAuthenticated)
        {
            TempData["Message"] = "Giriş başarılı!";
            TempData["IsSuccess"] = true;
            return RedirectToAction("Index", "Result");
        }
        else
        {
            TempData["Message"] = "Giriş başarısız!";
            TempData["IsSuccess"] = false;
            return RedirectToAction("Index", "Result");
        }
    }

    public async Task<bool> KontrolEtVeOturumuAc(string username, string enteredPassword, string query)
    {
        bool isAuthenticated = false;
        using (SqlConnection con = new SqlConnection(aktifbaglanti))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (!await reader.ReadAsync())
                    {
                        TempData["ErrorMessage"] = "Kullanıcı bulunamadı!";
                        return false;
                    }
                    string adisoyadi = reader["adisoyadi"].ToString();
                    string storedHash = reader["Sifre"].ToString();
                    string storedSalt = reader["Salt"].ToString();
                    string role = reader["Rolu"].ToString();
                    int userId = Convert.ToInt32(reader["KullaniciId"]);
                    bool isAdmin = role == "Admin";
                    bool isYetkili = isAdmin || role == "Görevli";
                    string ipAddress = GetIPAddress();

                    if (VerifyPassword(enteredPassword, storedHash, storedSalt))
                    {
                        Session.Timeout = 120;
                        Session["KullaniciId"] = userId;
                        Session["KullaniciAdi"] = username;
                        Session["AdSoyad"] = adisoyadi;
                        Session["Rolu"] = role;
                        Session["isAdmin"] = isAdmin;
                        Session["isYetkili"] = isYetkili;
                        string ProfilFotoYol = PathHelper.ProfilPicture + "\\" + reader["ProfilFotoUrl"].ToString();
                        Session["ProfilResmi"] = ProfilFotoYol;
                        await GirisGonderAsync(userId, isAdmin, ipAddress, true);
                        isAuthenticated = true;
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı.";
                        await GirisGonderAsync(userId, isAdmin, ipAddress, false);
                    }
                }
            }
        }
        return isAuthenticated;
    }

    private string GetIPAddress()
    {
        return System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                              .AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                              .ToString() ?? "127.0.0.1";
    }

    private async Task GirisGonderAsync(int KullaniciId, bool isAdmin, string ipAddress, bool isSuccess)
    {
        string query = @"INSERT INTO
                          LoginLoglar(
                            KullaniciId,
                            AdminMi,
                            IPAddress,
                            BasariliMi,
                            Tarih,
                            Saat
                          )
                        VALUES
                          (
                            @KullaniciId,
                            @AdminMi,
                            @IPAddress,
                            @BasariliMi,
                            @Tarih,
                            @Saat
                          );";
        bool basarili = await LogGonderAsync(BaglantıV, query, KullaniciId, isAdmin, ipAddress, isSuccess);
        if (!basarili)
        {
            basarili = await LogGonderAsync(BaglantıSefa, query, KullaniciId, isAdmin, ipAddress, isSuccess);
            if (!basarili)
            {
                TempData["ErrorMessage"] = "Mesaj istenilen veritabanlarına yazılamadı.";
            }
        }
    }

    private async Task<bool> LogGonderAsync(string connectionString, string query, int KullaniciId, bool isAdmin, string ipAddress, bool isSuccess)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciId", KullaniciId);
                    cmd.Parameters.AddWithValue("@AdminMi", isAdmin);
                    cmd.Parameters.AddWithValue("@IPAddress", ipAddress);
                    cmd.Parameters.AddWithValue("@BasariliMi", isSuccess);
                    cmd.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Saat", DateTime.Now.ToString("HH:mm:ss"));
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
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
    #endregion
    #region Register
    [HttpPost]
    public async Task<ActionResult> Register(LogRegViewModel model)
    {
        if (string.IsNullOrEmpty(model.RegKullaniciAdi) ||
            string.IsNullOrEmpty(model.TcKimlikNo) ||
            model.TcKimlikNo.Length < 11 ||
            string.IsNullOrEmpty(model.Ad) ||
            string.IsNullOrEmpty(model.Soyad) ||
            string.IsNullOrEmpty(model.Email) ||
            string.IsNullOrEmpty(model.RegSifre) ||
            string.IsNullOrEmpty(model.RegSifreTekrar))
        {
            TempData["ErrorMessage"] = "Lütfen tüm alanları doldurun.";
            return RedirectToAction("Index");
        }

        if (model.RegSifre != model.RegSifreTekrar)
        {
            TempData["ErrorMessage"] = "Şifreler eşleşmiyor.";
            return RedirectToAction("Index");
        }

        HashPassword(model.RegSifre, out string hashedPassword, out string salt);
        int kullaniciId = 0;
        string query1 = @"INSERT INTO
                            KullaniciBilgileri(Ad, Soyad, Tc, Email) OUTPUT INSERTED.KullaniciId
                          VALUES
                            (@ad, @soyad, @tc, @email)";
        string query2 = @"INSERT INTO
                            KullaniciSistem(KullaniciId, KullaniciAdi, Sifre, Salt)
                          VALUES
                            (@kullaniciid, @kullaniciadi, @sifre, @salt)";
        using (SqlConnection con = new SqlConnection(aktifbaglanti))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query1, con))
            {
                cmd.Parameters.AddWithValue("@ad", model.Ad);
                cmd.Parameters.AddWithValue("@soyad", model.Soyad);
                cmd.Parameters.AddWithValue("@tc", model.TcKimlikNo);
                cmd.Parameters.AddWithValue("@email", model.Email);
                object result = await cmd.ExecuteScalarAsync();
                if (result != null)
                {
                    kullaniciId = Convert.ToInt32(result);
                }
            }
            if (kullaniciId == 0)
            {
                TempData["ErrorMessage"] = "Kullanıcı bilgileri kaydedilemedi.";
                return RedirectToAction("Index");
            }
            else
            {
                using (SqlCommand cmd2 = new SqlCommand(query2, con))
                {
                    cmd2.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                    cmd2.Parameters.AddWithValue("@kullaniciadi", model.RegKullaniciAdi);
                    cmd2.Parameters.AddWithValue("@sifre", hashedPassword);
                    cmd2.Parameters.AddWithValue("@salt", salt);
                    int ks2=cmd2.ExecuteNonQuery();
                    if (ks2>0)
                    {
                        TempData["Message"] = "Kayıt başarılı!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Bir Hata Meydana Geldi!";
                        return RedirectToAction("Index");
                    }
                }
            }
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
    #endregion
}
