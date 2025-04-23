using Bogus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class SifremiUnuttum: Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        private string BaglantıV = ConfigurationManager.ConnectionStrings["BaglantıV"].ConnectionString;
        private string BaglantıSefa = ConfigurationManager.ConnectionStrings["BaglantıSefa"].ConnectionString;
        private bool secilen = false;
        private static string mailadresi;
        private int dogrulamaKodu;
        private bool progress = false;
        TimeSpan sure = new TimeSpan(0, 3, 0);
        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("Images\\Icons\\SifremiUnuttumicon.ico");
            ControlleriAyarla();
        }
        private void ControlleriAyarla()
        {
            ReaLTaiizor.Controls.MetroLabel[] lbls = {lbladsoyad,lbladsoyadinfo,lblbilgilendirme,lblerisimyok,lblinfo,lblkaraktersayisi,lblkullanıcıadı,lblkullanıcıadıinfo,lblsure,lblswitch,lblyenikodiste};
            ReaLTaiizor.Controls.AloneTextBox[] txts = {txtarama,txtkodgiris };
            ReaLTaiizor.Controls.ParrotSuperButton[] btns = { btnara,btndogrulamakoduiste,btnkodkontrol};
            ReaLTaiizor.Controls.CyberGroupBox[] grps = {grpara,grpbilgi,grpkod };
            foreach (var item in lbls)
            {
                item.ForeColor = Color.White;
            }
            foreach (var item in txts)
            {
                item.ForeColor = Color.White;
                item.TB.BackColor = Color.FromArgb(37, 52, 68);
            }
            foreach (var item in btns)
            {
                item.TextColor = Color.Black;
                item.HoverTextColor = Color.Black;
                item.SelectedTextColor = Color.Red;
                item.BackgroundColor = Color.DeepSkyBlue;
                item.HoverBackgroundColor = Color.White;
                item.SelectedBackColor = Color.Red;
                if (item.Name=="btnara")
                {
                    item.ButtonImage = Image.FromFile("Images\\ara.png");
                }
                else if (item.Name=="btndogrulamakoduiste")
                {
                    item.ButtonImage = Image.FromFile("Images\\email.png");
                }
                else
                {
                    item.ButtonImage = Image.FromFile("Images\\kilitac.png");
                }
            }
            resim1.BackColor = Color.Transparent;
            resim1.NormalColor = Color.Transparent;
            resim1.HoverColor = Color.Transparent;
            resim1.DisabledBorderColor = Color.Transparent;
            resim1.HoverBorderColor = Color.Transparent;
            resim1.NormalBorderColor = Color.Transparent;
            resim1.PressBorderColor = Color.Transparent;
            resim1.Visible = false;
            
            this.Size = new Size(670, 133);
        }

        private void txtarama_TextChanged(object sender, EventArgs e)
        {
            lblkaraktersayisi.Text = txtarama.Text.Length.ToString();
        }

        private void swkullanıcıbul_Click(object sender, EventArgs e)
        {
            if (!secilen)
            {
                secilen = true;
                lblbilgilendirme.Text = "Lütfen e-mail adresinizi giriniz";
                txtarama.Text = "";
                txtarama.MaxLength = 50;
                txtarama.Focus();
                txtarama.Select();
            }
            else
            {
                secilen = false;
                lblbilgilendirme.Text = "Lütfen 11 Haneli Tc Kimlik Numaranızı Giriniz";
                txtarama.Text = "";
                txtarama.MaxLength = 11;
                txtarama.Focus();
                txtarama.Select();
            }
        }

        private async void btnara_Click(object sender, EventArgs e)
        {
            string gbil = txtarama.Text;
            if (String.IsNullOrEmpty(gbil))
            {
                MessageBox.Show("Lütfen hesabınızı bulabilmek Tc kimlik numaranızı ya da mail adresinizi giriniz.", "Geçersiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool Mailmi = gbil.Contains("@gmail.com") || gbil.Contains("@hotmail.com") || gbil.Contains("@outlook.com") || gbil.Contains("@icloud.com");
            string sorgu = Mailmi ? "Select * from KullaniciBilgileri where Email=@gbil" : "Select * from KullaniciBilgileri where Tc=@gbil";

            await Task.Run(() =>
            {
                ExecuteWithFallback(sorgu, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@gbil", gbil);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            MessageBox.Show($"{gbil} olarak girilen kullanıcıya ait veriler bulundu aşağıda bilgiler gösterildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Invoke(new Action(() => this.Size = new Size(670, 450)));
                            await HesapBilgileriniGetir(gbil, !Mailmi);
                        }
                        else
                        {
                            MessageBox.Show("Böyle bir kullanıcı bulunamadı.");
                        }
                    }
                });
            });
        }
        private async Task HesapBilgileriniGetir(string input, bool isTc)
        {
            string query = "SELECT Email, KullaniciBilgileri.KullaniciId, Ad, Soyad, KullaniciSistem.KullaniciAdi " +
                           "FROM KullaniciBilgileri INNER JOIN KullaniciSistem ON KullaniciBilgileri.KullaniciId = KullaniciSistem.KullaniciId " +
                           (isTc ? "WHERE KullaniciBilgileri.TC=@input" : "WHERE KullaniciBilgileri.Email=@input");

            await Task.Run(() =>
            {
                ExecuteWithFallback(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@input", input);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            lbladsoyadinfo.Invoke(new Action(() => lbladsoyadinfo.Text = reader["Ad"] + " " + reader["Soyad"]));
                            lblkullanıcıadıinfo.Invoke(new Action(() => lblkullanıcıadıinfo.Text = reader["KullaniciAdi"].ToString()));
                            mailadresi = reader["Email"].ToString();
                            await KullaniciProfilResmiGetir(reader["KullaniciId"].ToString());
                        }
                    }
                });
            });
        }
        private async Task KullaniciProfilResmiGetir(string kullaniciId)
        {
            string query = "SELECT ProfilFotoUrl FROM KullaniciBilgileri WHERE KullaniciId = @kullaniciId";

            await Task.Run(() =>
            {
                ExecuteWithFallback(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    object result = await cmd.ExecuteScalarAsync();
                    if (result != null)
                    {
                        string imageUrl = $"https://drive.google.com/uc?export=download&id={result}";
                        await LoadImageFromUrl(imageUrl);
                    }
                });
            });
        }
        private async Task LoadImageFromUrl(string url)
        {
            try
            {
                prbarresimyukle.Visible = true;
                prbarresimyukle.AnimationSpeed = 50;
                Task progressTask = Task.Run(async () =>
                {
                    while (progress)
                    {
                        prbarresimyukle.Invoke(new Action(() =>
                        {
                            Random rnd = new Random();
                            prbarresimyukle.Percentage += rnd.Next(15,35);
                            if (prbarresimyukle.Percentage>=100)
                            {
                                prbarresimyukle.Percentage=100;
                            }
                        }));
                        await Task.Delay(1000);
                    }
                });
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = await webClient.DownloadDataTaskAsync(url);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        resim1.Visible = true;
                        resim1.Image = Image.FromStream(ms);
                    }
                }
                progress = false;
                await progressTask;
                prbarresimyukle.Visible = false;
                btndogrulamakoduiste.Enabled = true;
                dogrulamaKodu = new Faker().Random.Number(100000, 999999);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btndogrulamakoduiste_Click(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            prbargizleme.Visible = true;
            prbargizleme.Percentage += 20;
            grpkod.Visible = true;
            if (String.IsNullOrEmpty(mailadresi))
            {
                MessageBox.Show("Mail adresi bulunamadı");
            }
            string htmlMessage = $"<p>Sayın Kullanıcımız,</p><p>BASK Kütüphane Sistemine kayıtlı olan hesabınız için şifre yenileme isteği gönderildi.</p><p>İşleme devam etmek için doğrulama kodunuz;<br> <strong>{dogrulamaKodu}</strong><br><br></p><p>Eğer bu işlemi siz başlatmadıysanız, lütfen hemen adminlerimizle iletişime geçerek önlem alınız.</p><p>Herhangi bir sorunuz olursa, bize ulaşmaktan çekinmeyin.</p><p>İyi günler dileriz,<br>BASK Kütüphane Sistemi Ekibi</p>";
            await MailGonder(mailadresi, "Doğrulama Kodu", htmlMessage);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sure = sure.Subtract(TimeSpan.FromSeconds(1));
            lblsure.Text = sure.ToString(@"mm\:ss");
            if (sure.TotalSeconds <= 0)
            {
                timer1.Stop();
                lblsure.Text = "00:00";
                lblsure.Visible = false;
                lblyenikodiste.Visible = true;
            }
        }
        private async Task MailGonder(string toEmail, string subject, string body)
        {
            try
            {
                prbargizleme.Percentage += 24;
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
                        smtpClient.Send(mailMessage);
                    }
                }
                DialogResult result=MessageBox.Show("E-posta başarıyla gönderildi.","Mesaj Gönderildi",MessageBoxButtons.OK);
                if (result==DialogResult.OK)
                {
                    prbargizleme.Percentage += 18;
                    await Task.Delay(100);
                    prbargizleme.Percentage += 18;
                    timer1.Start();
                    prbargizleme.Visible = false;
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

        private void lblerisimyok_Click(object sender, EventArgs e)
        {
            string email = "kutuphaneproje18@gmail.com";
            string subject = "Hesabıma Erişimim Yok";
            string body = "Sevgili Kullanıcımız,\n\n" +
                "E-posta hesabınıza erişiminiz olmadığı için şifrenizi yenilemek üzere bu maili gönderiyorsunuz.\n\n" +
                "Lütfen aşağıdaki bilgileri doldurup bu e-postayı admin hesabına gönderin:\n\n" +
                "<b>Kullanıcı Adı: [Kullanıcı Adınızı Girin]\r\n" +
                "TC Kimlik Numarası: [TC Kimlik Numaranızı Girin]\r\n" +
                "Yeni İletişim E-posta Adresi: [Yeni E-posta Adresinizi Girin]\r\n\n</b>" +
                "Bu bilgileri sağladıktan sonra, şifrenizi sıfırlama işlemi için gerekli adımları size ileteceğiz.\n\n" +
                "Teşekkürler,\n" +
                "BASK Destek Ekibi\r\n\r\n";
            string mailto = $"mailto:{email}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
            Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });

        }

        private async void lblyenikodiste_Click(object sender, EventArgs e)
        {
            dogrulamaKodu = new Faker().Random.Number(100000, 999999);
            string htmlMessage = $"<p>Sayın Kullanıcımız,</p><p>BASK Kütüphane Sistemine kayıtlı olan hesabınız için şifre yenileme isteği gönderildi.</p><p>İşleme devam etmek için doğrulama kodunuz: <strong>{dogrulamaKodu}</strong></p><p>Eğer bu işlemi siz başlatmadıysanız, lütfen hemen adminlerimizle iletişime geçerek önlem alınız.</p><p>Herhangi bir sorunuz olursa, bize ulaşmaktan çekinmeyin.</p><p>İyi günler dileriz,<br>BASK Kütüphane Sistemi Ekibi</p>";
            await MailGonder(mailadresi, "Doğrulama Kodu", htmlMessage);
            sure = new TimeSpan(0, 3, 0);
            timer1.Start();
            lblsure.Visible = true;
            lblyenikodiste.Visible = false;
        }

        private async void btnkodkontrol_Click(object sender, EventArgs e)
        {
            int girilenkod = int.Parse(txtkodgiris.Text);
            if (girilenkod == dogrulamaKodu)
            {
                SifreYenile yenile = new SifreYenile();
                string query = "SELECT KullaniciId FROM KullaniciBilgileri WHERE Email=@mailadresi";

                ExecuteWithFallback(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@mailadresi", mailadresi);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        SifreYenile.KullaniciId = (int)result;
                        SifreYenile.kullaniciAdi = lblkullanıcıadıinfo.Text;
                        SifreYenile.adsoyad = lbladsoyadinfo.Text;
                    }
                });

                await Task.Delay(500);
                yenile.Show();
            }
            else
            {
                MessageBox.Show("Doğrulama kodu hatalı, lütfen tekrar deneyin.");
            }
        }

        private void SifremiUnuttum_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form[] acikformlar = Application.OpenForms.Cast<Form>().ToArray();
            foreach (var item in acikformlar)
            {
                if (item.Name == "Form1")
                {
                    item.Show();
                }
            }
        }
        private void ExecuteWithFallback(string query, Action<SqlCommand> commandAction)
        {
            string[] connections = { BaglantıV, BaglantıSefa };
            Exception lastException = null;

            foreach (var connectionString in connections)
            {
                try
                {
                    using (var conn = new SqlConnection(connectionString))
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        commandAction(cmd);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lastException = ex; 
                }
            }
            MessageBox.Show($"Her iki veritabanına bağlanılamadı. Hata: {lastException?.Message}", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
