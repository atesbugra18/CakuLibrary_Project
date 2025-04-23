using Kutuphane.Properties;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class Form1 : Form
    {
        bool sifregosteriliyor = false;
        static string KullaniciAdi;
        bool tc = false;
        private string BaglantıV = ConfigurationManager.ConnectionStrings["BaglantıV"].ConnectionString;
        private string BaglantıSefa=ConfigurationManager.ConnectionStrings["BaglantıSefa"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("Images\\Icons\\loginaccount.ico");
            ResmiAyarla();
            ButonlarıAyarla();
            Ac();
        }
        private void Ac()
        {
            Screen screen = Screen.FromControl(this);
            this.Location = new Point(
                (screen.WorkingArea.Width - this.Width) / 2,
                (screen.WorkingArea.Height - this.Height) / 2
            );

        }
        private void ResmiAyarla()
        {
            try
            {
                resim1.Image = Image.FromFile("Images\\seaccount.png");
                btnoturumac.ButtonImage = Image.FromFile("Images\\seaccount.png");
                btnsifre.ButtonImage = Image.FromFile("Images\\gorunmez.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            resim1.BackColor = Color.Transparent;
            resim1.NormalColor = Color.Transparent;
            resim1.HoverColor = Color.Transparent;
            resim1.DisabledBorderColor = Color.Transparent;
            resim1.HoverBorderColor = Color.Transparent;
            resim1.NormalBorderColor = Color.Transparent;
            resim1.PressBorderColor = Color.Transparent;
        }
        private void ButonlarıAyarla()
        {
            btnoturumac.TextColor = Color.Black;
            btnsifre.BackgroundColor = Color.Transparent;
            btnsifre.HoverBackgroundColor = Color.Transparent;
            btnsifre.ClickBackColor = Color.RoyalBlue;
            swkullanıcı.BackColor = Color.Transparent;
            txtsifre.UseSystemPasswordChar = true;
        }

        private void swkullanıcı_Click(object sender, EventArgs e)
        {
            if (!tc)
            {
                tc = true;
                lblkullanıcıadı.Text = "TC Kimlik No";
                txtkullanıcı.MaxLength = 11;
                txtkullanıcı.Text = "";
                txtkullanıcı.WatermarkText = "11 Haneli TC'nizi Giriniz...";
            }
            else
            {
                tc = false;
                lblkullanıcıadı.Text = "Kullanıcı Adı";
                txtkullanıcı.MaxLength = 50;
                txtkullanıcı.Text = "";
                txtkullanıcı.WatermarkText = "Kullanıcı Adınızı Giriniz...";
            }
        }

        private void btnsifre_Click(object sender, EventArgs e)
        {
            if (!sifregosteriliyor)
            {
                SifreGoster();
            }
            else
            {
                SifreGizle();
            }
        }
        private void SifreGoster()
        {
            btnsifre.ButtonImage = Image.FromFile(@"Images\Gorunur.png");
            txtsifre.UseSystemPasswordChar = false;
            sifregosteriliyor = true;
        }
        private void SifreGizle()
        {
            sifregosteriliyor = false;
            btnsifre.ButtonImage = Image.FromFile(@"Images\Gorunmez.png");
            txtsifre.UseSystemPasswordChar = true;
        }

        private void txtsifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               btnoturumac_Click(sender, e);
            }

        }

        private void btnoturumac_Click(object sender, EventArgs e)
        {
            string username = txtkullanıcı.Text.ToUpper();
            string enteredPassword = txtsifre.Text;
            string query;
            if (!tc)
            {
                query = "SELECT Sifre, Salt, Rolu FROM KullaniciSistem WHERE KullaniciAdi = @username";
            }
            else
            {
                query = "SELECT KullaniciSistem.Sifre, KullaniciSistem.Salt, KullaniciSistem.Rolu FROM KullaniciSistem,KullaniciBilgileri WHERE KullaniciBilgileri.Tc = @username";
            }
            KontrolEtVeOturumuAc(username, enteredPassword, query, tc);
        }
        private void KontrolEtVeOturumuAc(string username, string enteredPassword, string query, bool isTc)
        {
            ExecuteWithFallback(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@username", username);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader["Sifre"].ToString();
                        string storedSalt = reader["Salt"].ToString();
                        string role = reader["Rolu"].ToString();
                        bool isAdmin = role == "Admin";
                        string ipAddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString();

                        if (VerifyPassword(enteredPassword, storedHash, storedSalt))
                        {
                            if (isAdmin || role == "Görevli")
                            {
                                Home home = new Home();
                                KullaniciAdi = username;
                                Home.kullaniciadi = username;
                                Home.admin = isAdmin;
                                home.Show();
                                this.Hide();
                                GirisGonder(username, isAdmin, ipAddress, true);
                            }
                            else
                            {
                                MessageBox.Show("Bu panele erişim yetkiniz yok!", "Yetkisiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            GirisGonder(username, isAdmin, ipAddress, false);
                            MessageBox.Show("Şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string ipAddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString();
                        GirisGonder(username, false, ipAddress, false);
                        MessageBox.Show("Kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });
        }
        private void GirisGonder(string username, bool isAdmin, string ipAddress, bool isSuccess)
        {
            string query = "INSERT INTO LoginLoglar (KullaniciId, AdminMi, IPAddress, BasariliMi, Tarih, Saat) " +
                           "VALUES (@KullaniciId, @AdminMi, @IPAddress, @BasariliMi, @Tarih, @Saat)";
            ExecuteWithFallback(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@KullaniciId", username);
                cmd.Parameters.AddWithValue("@AdminMi", isAdmin);
                cmd.Parameters.AddWithValue("@IPAddress", ipAddress);
                cmd.Parameters.AddWithValue("@BasariliMi", isSuccess);
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Saat", DateTime.Now.ToString("HH:mm:ss"));
                cmd.ExecuteNonQuery();
            });
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

        private void lblunuttum_Click(object sender, EventArgs e)
        {
            SifremiUnuttum sifremiunuttum = new SifremiUnuttum();
            this.Hide();
            sifremiunuttum.ShowDialog();
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
    }
}
