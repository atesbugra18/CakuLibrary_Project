using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using Kutuphane.Utils;
using System.Data.SqlClient;

namespace KutuphaneMvc1.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private static Random random = new Random();
        static string aktifbaglanti;
        // GET: ForgotPassword
        public ActionResult Index()
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {

            }
            ViewBag.Step = 1;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Index(string email)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {

            }
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Message = "Lütfen e-posta adresinizi girin.";
                ViewBag.Step = 1;
                return View();
            }
            bool emailExists = await CheckEmailInDatabaseAsync(email);
            if (!emailExists)
            {
                ViewBag.Message = "Bu e-posta adresi sistemde kayıtlı değil.";
                ViewBag.Step = 1;
                return View();
            }
            int verificationCode = random.Next(100000, 999999);
            Session["VerificationCode"] = verificationCode;
            Session["UserEmail"] = email;

            string htmlMessage = $"<p>Sayın Kullanıcımız,</p><p>BASK Kütüphane Sistemine kayıtlı olan hesabınız için şifre yenileme isteği gönderildi.</p><p>İşleme devam etmek için doğrulama kodunuz;<br> <strong>{verificationCode}</strong><br><br></p><p>Eğer bu işlemi siz başlatmadıysanız, lütfen hemen adminlerimizle iletişime geçerek önlem alınız.</p><p>Herhangi bir sorunuz olursa, bize ulaşmaktan çekinmeyin.</p><p>İyi günler dileriz,<br>BASK Kütüphane Sistemi Ekibi</p>";

            bool emailSent = await SendVerificationEmailAsync(email, "Doğrulama Kodu", htmlMessage);

            if (!emailSent)
            {
                ViewBag.Message = "E-posta gönderilirken bir hata oluştu.";
                ViewBag.Step = 1;
                return View();
            }

            ViewBag.Step = 2;
            return View();
        }

        [HttpPost]
        public ActionResult VerifyCode(string code)
        {
            if (Session["VerificationCode"] == null || Session["UserEmail"] == null)
            {
                ViewBag.Message = "Oturum süresi doldu.";
                ViewBag.Step = 1;
                return View("Index");
            }

            if (code == Session["VerificationCode"].ToString())
            {
                ViewBag.Step = 3;
            }
            else
            {
                ViewBag.Step = 2;
                ViewBag.Message = "Doğrulama kodu hatalı.";
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult ResetPassword(string newPassword, string confirmPassword)
        {
            if (Session["UserEmail"] == null)
            {
                ViewBag.Message = "Oturum süresi doldu.";
                ViewBag.Step = 1;
                return RedirectToAction("Index");
            }
            if (newPassword != confirmPassword)
            {
                ViewBag.Step = 3;
                ViewBag.Message = "Şifreler uyuşmuyor.";
                return View("Index");
            }
            if (!IsPasswordStrong(newPassword))
            {
                ViewBag.Step = 3;
                ViewBag.Message = "Şifre güçlü değil. Şifre en az 8 karakter uzunluğunda olmalı, bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.";
                return View("Index");
            }
            string email = Session["UserEmail"].ToString();
            string query = "UPDATE KullaniciBilgileri SET Sifre = @Password WHERE Email = @Email";
            HashPassword(newPassword, out string hashedPassword, out string salt);
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@Email", email);
                    int ks = cmd.ExecuteNonQuery();
                    if (ks == 0)
                    {
                        ViewBag.Message = "Şifre güncellenirken bir hata oluştu.";
                        ViewBag.Step = 3;
                        return View("Index");
                    }
                    Session.Clear();
                }
            }
            ViewBag.Message = "Şifre başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        private bool IsPasswordStrong(string password)
        {
            if (password.Length < 8)
                return false;
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                if (char.IsLower(c)) hasLowerCase = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (!char.IsLetterOrDigit(c)) hasSpecialChar = true;
            }
            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }

        private async Task<bool> CheckEmailInDatabaseAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            string query = "SELECT Email FROM KullaniciBilgileri WHERE Email = @Email";
            bool emailExists = false;
            using (SqlConnection con=new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    var reader = await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        emailExists = true;
                    }
                }
            }
            return emailExists;
        }

        private async Task<bool> SendVerificationEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("kutuphaneproje18@gmail.com", "jnzcrprgmzyjgezl");
                    smtpClient.EnableSsl = true;
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("kutuphaneproje18@gmail.com");
                        mailMessage.To.Add(toEmail);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }
                return true;
            }
            catch (SmtpException smtpEx)
            {
                System.Diagnostics.Debug.WriteLine("SMTP Hatası: " + smtpEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("E-posta gönderilirken hata oluştu: " + ex.Message);
                return false;
            }
        }

        private void HashPassword(string password, out string hashedPassword, out string salt)
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
}
