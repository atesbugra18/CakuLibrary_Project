using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Bogus;
using Kutuphane.Utils;
using System.Security.Cryptography;

namespace Kutuphane
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
        private void SifremiUnuttumDesignerUi_Load(object sender, EventArgs e)
        {
            picturearkaplan.ImageLocation = "Images\\sifremiunuttum.png";
            picturearkaplan.Load();
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
            picturesendmail.BackgroundImage = Image.FromFile("Images\\sendmail.png");
            btnclose.Parent = picturearkaplan;
            btnbig.Parent = picturearkaplan;
            btnhide.Parent = picturearkaplan;
            lblinfo.BackColor = Color.FromArgb(50, 0, 0, 0);
            lblerisimimyok.BackColor = Color.FromArgb(50, 0, 0, 0);
            lblsendcode.BackColor = Color.FromArgb(150, 0, 0, 0);
            panelasama2.Parent = picturearkaplan;
            panelislem1.Parent = picturearkaplan;
            lblanlik.BackColor = Color.FromArgb(50, 0, 0, 0);
            lblbaslik.BackColor = Color.FromArgb(50, 0, 0, 0);
            lblsifrelereslesiyor.BackColor = Color.FromArgb(50, 0, 0, 0);
            lblinfo.Parent = panelislem1;
            lblsifremiunuttum.Parent = panelislem1;
        }
        string mailadresi;
        int dogrulamaKodu;
        Faker faker = new Faker();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void Nokta();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void MesajGonder(System.IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void panelarkaplan_MouseDown(object sender, MouseEventArgs e)
        {
            Nokta();
            MesajGonder(this.Handle, 0x112, 0xf012, 0);
        }
        #region KullaniciyiBulma
        private void txtmailgiris_TextChanged(object sender, EventArgs e)
        {
            if (txtmailgiris.Text.Contains("@gmail.com") || txtmailgiris.Text.Contains("@outlook.com") || txtmailgiris.Text.Contains("@icloud.com") || txtmailgiris.Text.Contains("@hotmail.com"))
            {
                btnonay.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
                btnonay.IconColor = Color.Green;
            }
            else
            {
                btnonay.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
                btnonay.IconColor = Color.Red;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Form[] openforms = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form form in openforms)
            {
                if (form.Name == "LoginDesignerUi")
                {
                    Login giris = (Login)form;
                    giris.Show();
                }
            }
            this.Close();
        }

        private void btnbig_Click(object sender, EventArgs e)
        {

        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void btndevam_Click(object sender, EventArgs e)
        {
            if (btnonay.IconChar == FontAwesome.Sharp.IconChar.CircleCheck)
            {
                mailadresi = txtmailgiris.Text;
                if (!string.IsNullOrEmpty(mailadresi))
                {
                    string query = "SELECT Email From KullaniciBilgileri Where @Email=Email";
                    await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                    {
                        cmd.Parameters.AddWithValue("@Email", mailadresi);
                        var reader = await cmd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                string email = reader["Email"].ToString();
                                if (email == mailadresi)
                                {
                                    MessageBox.Show("Mail adresi sistemde kayıtlıdır. Doğrulama kodu gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    panelasama1.BackColor = Color.GreenYellow;
                                    panelislem2.Visible = true;
                                    btndogrulamakoduiste_Click(sender, e);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu mail adresi sistemde kayıtlı değildir.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    });
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir mail adresi giriniz.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private async void btndogrulamakoduiste_Click(object sender, EventArgs e)
        {
            await Task.Delay(1200);
            if (String.IsNullOrEmpty(mailadresi))
            {
                MessageBox.Show("Mail adresi bulunamadı");
            }
            dogrulamaKodu = faker.Random.Int(100000, 999999);
            string htmlMessage = $"<p>Sayın Kullanıcımız,</p><p>BASK Kütüphane Sistemine kayıtlı olan hesabınız için şifre yenileme isteği gönderildi.</p><p>İşleme devam etmek için doğrulama kodunuz;<br> <strong>{dogrulamaKodu}</strong><br><br></p><p>Eğer bu işlemi siz başlatmadıysanız, lütfen hemen adminlerimizle iletişime geçerek önlem alınız.</p><p>Herhangi bir sorunuz olursa, bize ulaşmaktan çekinmeyin.</p><p>İyi günler dileriz,<br>BASK Kütüphane Sistemi Ekibi</p>";
            await MailGonder(mailadresi, "Doğrulama Kodu", htmlMessage);
        }
        private async Task MailGonder(string toEmail, string subject, string body)
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
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show("SMTP Hatası: " + smtpEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilirken hata oluştu: " + ex.Message);
            }
        }
        private void lblerisimimyok_Click(object sender, EventArgs e)
        {
            string email = "kutuphaneproje18@gmail.com";
            string subject = "Hesabıma Erişimim Yok";
            string body = "Sevgili Kullanıcımız,\n\n" +
                "E-posta hesabınıza erişiminiz olmadığı için şifrenizi yenilemek üzere bu maili gönderiyorsunuz.\n\n" +
                "Lütfen aşağıdaki bilgileri doldurup bu e-postayı admin hesabına gönderin:\n\n" +
                "Kullanıcı Adı: [Kullanıcı Adınızı Girin]\r\n" +
                "TC Kimlik Numarası: [TC Kimlik Numaranızı Girin]\r\n" +
                "Yeni İletişim E-posta Adresi: [Yeni E-posta Adresinizi Girin]\r\n\n</b>" +
                "Bu bilgileri sağladıktan sonra, şifrenizi sıfırlama işlemi için gerekli adımları size ileteceğiz.\n\n" +
                "Teşekkürler,\n" +
                "BASK Destek Ekibi\r\n\r\n";
            string mailto = $"mailto:{email}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
            Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
        }
        #endregion
        #region KodKontrolAlanı
        private void kodnumber1_TextChanged(object sender, EventArgs e)
        {
            if (kodnumber1.Text.Length == 1)
            {
                kodnumber2.Focus();
            }
        }

        private void kodnumber2_TextChanged(object sender, EventArgs e)
        {
            if (kodnumber2.Text.Length == 1)
            {
                kodnumber3.Focus();
            }
        }

        private void kodnumber3_TextChanged(object sender, EventArgs e)
        {
            if (kodnumber3.Text.Length == 1)
            {
                kodnumber4.Focus();
            }
        }

        private void kodnumber4_TextChanged(object sender, EventArgs e)
        {
            if (kodnumber4.Text.Length == 1)
            {
                kodnumber5.Focus();
            }
        }

        private void kodnumber5_TextChanged(object sender, EventArgs e)
        {
            if (kodnumber5.Text.Length == 1)
            {
                kodnumber6.Focus();
            }
        }
        private void btndevamet2_Click(object sender, EventArgs e)
        {
            string kod = kodnumber1.Text + kodnumber2.Text + kodnumber3.Text + kodnumber4.Text + kodnumber5.Text + kodnumber6.Text;
            int girilenkod = int.Parse(kod);
            if (girilenkod == dogrulamaKodu)
            {
                MessageBox.Show("Doğrulama kodu doğru. Şifre yenileme işleminize devam edebilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelasama2.BackColor = Color.GreenYellow;
                panelislem3.Visible = true;
            }
            else
            {
                MessageBox.Show("Doğrulama kodu hatalı. Lütfen tekrar deneyin.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        #endregion

        #region YeniŞifreAlanı

        

        private void txtyenisifre_TextChanged(object sender, EventArgs e)
        {
            panelsifreinfo.Visible = true;
            btntekrargostergizle.Visible = true;
            int level = 0;
            if (txtyenisifre.Text.Length >= 8)
            {
                cbox8karakter.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
                cbox8karakter.IconColor = Color.Green;
                cbox8karakter.ForeColor = Color.Green;
                level += 1;
            }
            else
            {
                cbox8karakter.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
                cbox8karakter.IconColor = Color.Red;
                cbox8karakter.ForeColor = Color.Red;
                level -= 1;
            }
            if (txtyenisifre.Text.Any(char.IsDigit))
            {
                cboxsayisal.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
                cboxsayisal.IconColor = Color.Green;
                cboxsayisal.ForeColor = Color.Green;
                level += 1;
            }
            else
            {
                cboxsayisal.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
                cboxsayisal.IconColor = Color.Red;
                cboxsayisal.ForeColor = Color.Red;
                level -= 1;
            }
            if (txtyenisifre.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                cboxozel.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
                cboxozel.IconColor = Color.Green;
                cboxozel.ForeColor = Color.Green;
                level += 1;
            }
            else
            {
                cboxozel.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
                cboxozel.IconColor = Color.Red;
                cboxozel.ForeColor = Color.Red;
                level -= 1;
            }
            switch (level)
            {
                case 0:
                    lblanlik.Text = "Zayıf";
                    lblanlik.ForeColor = Color.Red;
                    break;
                case 1:
                    lblanlik.Text = "Orta";
                    lblanlik.ForeColor = Color.Orange;
                    break;
                case 2:
                    lblanlik.Text = "İyi";
                    lblanlik.ForeColor = Color.Green;
                    break;
                case 3:
                    lblanlik.Text = "Güçlü";
                    lblanlik.ForeColor = Color.Green;
                    break;
                default:
                    lblanlik.Text = "Zayıf";
                    lblanlik.ForeColor = Color.Red;
                    break;
            }
        }

        private void txtsifretekrar_TextChanged(object sender, EventArgs e)
        {
            lblsifrelereslesiyor.Visible = true;
            if (txtyenisifre.Text != txtsifretekrar.Text)
            {
                lblsifrelereslesiyor.Text = "Şifreler Eşleşmiyor";
                lblsifrelereslesiyor.ForeColor = Color.Red;
            }
            else
            {
                lblsifrelereslesiyor.Text = "Şifreler Eşleşiyor";
                lblsifrelereslesiyor.ForeColor = Color.Green;
            }
        }

        private void btnsifregostergizle_Click(object sender, EventArgs e)
        {
            txtyenisifre.PasswordChar = txtyenisifre.PasswordChar == '\0' ? '*' : '\0';
            btnsifregostergizle.IconChar = txtyenisifre.PasswordChar == '\0' ? FontAwesome.Sharp.IconChar.Eye : FontAwesome.Sharp.IconChar.EyeSlash;
        }

        private void btntekrargostergizle_Click(object sender, EventArgs e)
        {
            txtsifretekrar.PasswordChar = txtsifretekrar.PasswordChar == '\0' ? '*' : '\0';
            btnsifregostergizle.IconChar = txtsifretekrar.PasswordChar == '\0' ? FontAwesome.Sharp.IconChar.Eye : FontAwesome.Sharp.IconChar.EyeSlash;
        }

        private async void btnsifremidegistir_Click(object sender, EventArgs e)
        {
            if (btnsifremidegistir.Text!="Ana Sayfaya Dön")
            {
                if (lblanlik.ForeColor == Color.Green)
                {
                    if (lblsifrelereslesiyor.ForeColor == Color.Green)
                    {
                        string sifre = txtyenisifre.Text;
                        int kullaniciıd = 0;
                        HashPassword(sifre, out string hashedPassword, out string salt);
                        string query1 = "Select KullaniciId from KullaniciBilgileri where Email=@Email";
                        string query2 = "Update KullaniciSistem set Sifre=@Sifre, Salt=@Salt where KullaniciId=@KullaniciId";
                        await DatabaseHelper.DatabaseQueryAsync(query1, async cmd =>
                        {
                            cmd.Parameters.AddWithValue("@Email", mailadresi);
                            var reader = await cmd.ExecuteReaderAsync();
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                {
                                    kullaniciıd = Convert.ToInt32(reader["KullaniciId"]);
                                }
                            }
                        });
                        if (kullaniciıd != 0)
                        {
                            await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
                            {
                                cmd.Parameters.AddWithValue("@KullaniciId", kullaniciıd);
                                cmd.Parameters.AddWithValue("@Sifre", hashedPassword);
                                cmd.Parameters.AddWithValue("@Salt", salt);
                                await cmd.ExecuteNonQueryAsync();
                            });
                            MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            panelasama3.BackColor = Color.GreenYellow;
                            btnsifremidegistir.Text = "Ana Sayfaya Dön";
                            btnsifremidegistir.IconChar = FontAwesome.Sharp.IconChar.Home;
                            btnsifremidegistir.IconColor = Color.White;
                        }
                        else
                        {
                            MessageBox.Show("Şifre Değiştirilirken bir hata meydana geldi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Eşleşmiyor Lütfen Girilen Şifreleri Kontrol Ettikten Sonra Tekrar Deneyiniz.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Daha Güçlü Bir Şifre Giriniz.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                Form[]openforms = Application.OpenForms.Cast<Form>().ToArray();
                foreach (Form form in openforms)
                {
                    if (form.Name == "LoginDesignerUi")
                    {
                        Login giris = (Login)form;
                        giris.Show();
                    }
                    else
                    {
                        form.Close();
                    }
                }
            }
        }
        //Eski Şifrenin Kontrolü Eklenecek
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
}
