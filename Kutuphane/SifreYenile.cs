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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class SifreYenile : Form
    {
        public static int KullaniciId;
        public static string kullaniciAdi;
        public static string adsoyad;
        bool sifre1gosteriliyor = false;
        bool sifre2gosteriliyor = false;
        bool progress = false;
        private string BaglantıV = ConfigurationManager.ConnectionStrings["BaglantıV"].ConnectionString;
        private string BaglantıSefa = ConfigurationManager.ConnectionStrings["BaglantıSefa"].ConnectionString;
        public SifreYenile()
        {
            InitializeComponent();
        }

        private async void SifreYenile_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("Images\\Icons\\sifreyenileicon.ico");
            ControlleriAyarla();
            string ıd = KullaniciId.ToString();
            await KullaniciProfilResmiGetir(ıd);
            SifreYenile_Shown(sender, e);
        }

        private void ControlleriAyarla()
        {
            btnsifre.ButtonImage = Image.FromFile("Images\\gorunmez.png");
            btnsifre2.ButtonImage = Image.FromFile("Images\\gorunmez.png");
            btnislemitamamla.TextColor = Color.Black;
            btnislemitamamla.HoverTextColor = Color.Black;
            btnislemitamamla.SelectedTextColor = Color.Red;
            btnislemitamamla.BackgroundColor = Color.DeepSkyBlue;
            btnislemitamamla.HoverBackgroundColor = Color.White;
            btnislemitamamla.SelectedBackColor = Color.Red;
            btnislemitamamla.ButtonImage = Image.FromFile("Images\\keys.png");
            lblkullanıcıadıinfo.ForeColor = Color.White;
            lbladsoyadinfo.ForeColor = Color.White;
            lbladsoyadinfo.Text = adsoyad;
            lblkullanıcıadıinfo.Text = kullaniciAdi;
        }

        private void SifreYenile_Shown(object sender, EventArgs e)
        {
            Form[] acikformlar = Application.OpenForms.Cast<Form>().ToArray();
            foreach (var item in acikformlar)
            {
                if (item.Name == "SifremiUnuttum")
                {
                    item.Opacity = 0;
                }
                else if (item.Name == "Form1")
                {
                    item.Hide();
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

        private async void btnislemitamamla_Click(object sender, EventArgs e)
        {
            string girilensifre1 = txtsifre.Text;
            string girilensifre2 = txtsifretekrar.Text;
            if (girilensifre1 == girilensifre2)
            {
                if (girilensifre1.Length >= 8)
                {
                    string hashedPassword, salt;
                    HashPassword(girilensifre1, out hashedPassword, out salt);
                    string query = "UPDATE KullaniciSistem SET Sifre = @sifre, Salt = @salt WHERE KullaniciId = @kullaniciId";

                    await DatabaseQueryAsync(query, async cmd =>
                    {
                        cmd.Parameters.AddWithValue("@sifre", hashedPassword);
                        cmd.Parameters.AddWithValue("@salt", salt);
                        cmd.Parameters.AddWithValue("@kullaniciId", KullaniciId);
                        await cmd.ExecuteNonQueryAsync();
                    });

                    MessageBox.Show("Şifreniz başarıyla değiştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Şifreniz en az 8 karakter olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Girilen şifreler uyuşmuyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsifre_Click(object sender, EventArgs e)
        {
            sifre1gosteriliyor = !sifre1gosteriliyor;
            btnsifre.ButtonImage = Image.FromFile(
                sifre1gosteriliyor ? "Images\\gorunur.png" : "Images\\gorunmez.png"
            );
            txtsifre.UseSystemPasswordChar = !sifre1gosteriliyor;
        }

        private void btnsifre2_Click(object sender, EventArgs e)
        {
            sifre2gosteriliyor = !sifre2gosteriliyor;
            btnsifre2.ButtonImage = Image.FromFile(
                sifre2gosteriliyor ? "Images\\gorunur.png" : "Images\\gorunmez.png"
            );
            txtsifretekrar.UseSystemPasswordChar = !sifre2gosteriliyor;
        }

        private async Task KullaniciProfilResmiGetir(string kullaniciId)
        {
            string query = "SELECT ProfilFotoUrl FROM KullaniciBilgileri WHERE KullaniciId = @kullaniciId";
            await DatabaseQueryAsync(query, async cmd =>
            {
                cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        string profilFotoUrl = reader["ProfilFotoUrl"].ToString();
                        if (!string.IsNullOrEmpty(profilFotoUrl))
                        {
                            await LoadImageFromUrl(profilFotoUrl);
                        }
                        else
                        {
                            MessageBox.Show("Profil fotoğrafı bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcıya ait profil fotoğrafı bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            });
        }

        private async Task LoadImageFromUrl(string url)
        {
            try
            {
                if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    url = $"https://drive.google.com/uc?export=view&id={url}";
                }
                else if (url.Contains("lorem.ipsum"))
                {

                }
                progress = true;
                prbarresimyukle.Visible = true;
                prbarresimyukle.AnimationSpeed = 50;
                prbarresimyukle.Percentage = 0; 
                var progressTask = Task.Run(async () =>
                {
                    Random rnd = new Random();
                    while (progress)
                    {
                        prbarresimyukle.Invoke(new Action(() =>
                        {
                            prbarresimyukle.Percentage += rnd.Next(15, 35);
                            if (prbarresimyukle.Percentage >= 100)
                            {
                                prbarresimyukle.Percentage = 100;
                                progress = false;
                            }
                        }));
                        await Task.Delay(1000);
                    }
                });
                using (WebClient webClient = new WebClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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
            }
            catch (WebException wex) when ((wex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                progress = false;
                prbarresimyukle.Visible = false;
                MessageBox.Show("Belirtilen URL'de resim bulunamadı.", "Resim Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                progress = false;
                prbarresimyukle.Visible = false;
                MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SifreYenile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form[] acikformlar = Application.OpenForms.Cast<Form>().ToArray();
            foreach (var item in acikformlar)
            {
                if (item.Name == "SifremiUnuttum")
                {
                    item.Close();
                }
                else if (item.Name == "Form1")
                {
                    item.Show();
                }
            }
        }

        private async Task DatabaseQueryAsync(string query, Func<SqlCommand, Task> commandAction)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BaglantıV))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        await commandAction(cmd);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(BaglantıSefa))
                    {
                        await con.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            await commandAction(cmd);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Veritabanına bağlanılamadı.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
