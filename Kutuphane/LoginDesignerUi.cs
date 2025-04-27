using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;

namespace Kutuphane
{
    public partial class LoginDesignerUi : Form
    {
        public LoginDesignerUi()
        {
            InitializeComponent();
        }
        private static readonly string BaglantıV = ConfigurationManager.ConnectionStrings["BaglantıV"].ConnectionString;
        private static readonly string BaglantıSefa = ConfigurationManager.ConnectionStrings["BaglantıSefa"].ConnectionString;
        private void LoginDesignerUi_Load(object sender, EventArgs e)
        {
            picturearkaplan.ImageLocation = "Images\\gif3.gif";
            picturearkaplan.Load();
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
            btnclose.Parent = picturearkaplan;
            btnbig.Parent = picturearkaplan;
            btnhide.Parent = picturearkaplan;
            lbllogin.Parent = picturearkaplan;
            lblkullanıcıadı.Parent=picturearkaplan;
            lblsifre.Parent = picturearkaplan;
            lblsifremiunuttum.Parent = picturearkaplan;
            txtkullanici_Leave(sender, e);

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void Nokta();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void MesajGonder(System.IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void panelarkaplan_MouseDown(object sender, MouseEventArgs e)
        {
            Nokta();
            MesajGonder(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbig_Click(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void btnoturumac_Click(object sender, EventArgs e)
        {
            string username = txtkullanici.Text;
            string enteredPassword = txtsifre.Text;
            string query;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (username.Contains("@"))
            {
                query = "SELECT ks.KullaniciId, ks.Sifre, ks.Salt, ks.Rolu, kb.Email " +
                        "FROM KullaniciSistem ks " +
                        "INNER JOIN KullaniciBilgileri kb ON ks.KullaniciId = kb.KullaniciId " +
                        "WHERE kb.Email = @username";
            }
            else if (username.Length == 11 && username.All(char.IsDigit))
            {
                query = "SELECT ks.KullaniciId, ks.Sifre, ks.Salt, ks.Rolu, kb.TC " +
                        "FROM KullaniciSistem ks " +
                        "INNER JOIN KullaniciBilgileri kb ON ks.KullaniciId = kb.KullaniciId " +
                        "WHERE kb.TC = @username";
            }
            else
            {
                username=username.ToUpper();
                query = "SELECT KullaniciId, Sifre, Salt, Rolu " +
                        "FROM KullaniciSistem " +
                        "WHERE KullaniciAdi = @username";
            }
            await KontrolEtVeOturumuAc(username, enteredPassword, query);
        }
        private async Task KontrolEtVeOturumuAc(string username, string enteredPassword, string query)
        {
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                cmd.Parameters.AddWithValue("@username", username);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (!await reader.ReadAsync())
                    {
                        await LogVeUyar(0, false, "Kullanıcı bulunamadı!");
                        return;
                    }
                    string storedHash = reader["Sifre"].ToString();
                    string storedSalt = reader["Salt"].ToString();
                    string role = reader["Rolu"].ToString();
                    int userId = Convert.ToInt32(reader["KullaniciId"]);
                    bool isAdmin = role == "Admin";
                    bool isYetkili = isAdmin || role == "Görevli";
                    string ipAddress = GetIPAddress();
                    if (VerifyPassword(enteredPassword, storedHash, storedSalt))
                    {
                        if (isYetkili)
                        {
                            HomeDesignerUi.kullaniciadi = username;
                            HomeDesignerUi.admin = isAdmin;
                            HomeDesignerUi home =new HomeDesignerUi();
                            home.Show();
                            this.Hide();
                            await GirisGonderAsync(userId, isAdmin, ipAddress, true);
                        }
                        else
                        {
                            MessageBox.Show("Bu panele erişim yetkiniz yok!", "Yetkisiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        await GirisGonderAsync(userId, isAdmin, ipAddress, false);
                        MessageBox.Show("Şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });
        }

        private void btnsifregostergizle_Click(object sender, EventArgs e)
        {
            txtsifre.PasswordChar = txtsifre.PasswordChar == '\0' ? '*' : '\0';
            btnsifregostergizle.IconChar = txtsifre.PasswordChar == '\0' ? FontAwesome.Sharp.IconChar.Eye : FontAwesome.Sharp.IconChar.EyeSlash;
        }

        private void lblsifremiunuttum_Click(object sender, EventArgs e)
        {
            SifremiUnuttumDesignerUi ui=new SifremiUnuttumDesignerUi();
            this.WindowState = FormWindowState.Minimized;
            ui.Show();
        }

        private void txtkullanici_Enter(object sender, EventArgs e)
        {
            if (txtkullanici.Text == "Kullanıcı Adı, Tc Kimlik No ya da Mail Adresinizi Giriniz.")
            {
                txtkullanici.Text = "";
                txtkullanici.ForeColor = Color.Black;
            }
        }

        private void txtkullanici_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtkullanici.Text))
            {
                txtkullanici.Text = "Kullanıcı Adı, Tc Kimlik No ya da Mail Adresinizi Giriniz.";
                txtkullanici.ForeColor = Color.Gray;
            }
        }
        private string GetIPAddress()
        {
            return System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                                  .AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                                  .ToString() ?? "127.0.0.1";
        }

        private async Task LogVeUyar(int KullaniciId, bool isAdmin, string message)
        {
            string ipAddress = GetIPAddress();
            await GirisGonderAsync(KullaniciId, isAdmin, ipAddress, false);
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task GirisGonderAsync(int KullaniciId, bool isAdmin, string ipAddress, bool isSuccess)
        {
            string query = "INSERT INTO LoginLoglar (KullaniciId, AdminMi, IPAddress, BasariliMi, Tarih, Saat) " +
                           "VALUES (@KullaniciId, @AdminMi, @IPAddress, @BasariliMi, @Tarih, @Saat)";
            bool basarili = await LogGonderAsync(BaglantıV, query, KullaniciId, isAdmin, ipAddress, isSuccess);
            if (!basarili)
            {
                basarili = await LogGonderAsync(BaglantıSefa, query, KullaniciId, isAdmin, ipAddress, isSuccess);
                if (!basarili)
                {
                    MessageBox.Show("Mesaj istenilen veritabanlarına yazılamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
