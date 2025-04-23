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
    public partial class SifreYenile: Form
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
                else if (item.Name=="Form1")
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

                    await ExecuteWithFallbackAsync(query, async cmd =>
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
            txtsifretekrar.UseSystemPasswordChar =!sifre2gosteriliyor;
        }
        private async Task KullaniciProfilResmiGetir(string kullaniciId)
        {
            string query = "SELECT ProfilFotoUrl FROM KullaniciBilgileri WHERE KullaniciId = @kullaniciId";

            await ExecuteWithFallbackAsync(query, async cmd =>
            {
                cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                object result = await cmd.ExecuteScalarAsync();
                if (result != null)
                {
                    string imageUrl = $"https://drive.google.com/uc?export=download&id={result}";
                    await LoadImageFromUrl(imageUrl);
                }
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
                            prbarresimyukle.Percentage += rnd.Next(15, 35);
                            if (prbarresimyukle.Percentage >= 100)
                            {
                                prbarresimyukle.Percentage = 100;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			MessageBox.Show($"Her iki veritabanına bağlanılamadı: {lastException.Message}", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
        private async Task ExecuteWithFallbackAsync(string query, Func<SqlCommand, Task> commandAction)
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
                        await conn.OpenAsync();
                        await commandAction(cmd);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
            }
            MessageBox.Show($"Her iki veritabanına bağlanılamadı: {lastException?.Message}", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

	}
}
