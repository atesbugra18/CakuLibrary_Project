using Bogus.DataSets;
using FontAwesome.Sharp;
using Google.Apis.Drive.v3.Data;
using Kutuphane.ChildFormsKitap;
using Kutuphane.ChildFormsKitap.YazarYonetim;
using Kutuphane.ChildFormsKitap.KategoriYonetim;
using Kutuphane.ChildFormsKitap.KitapYönetim;
using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Kutuphane.ChildFormsKullanici;

namespace Kutuphane
{
    public partial class Home : Form
    {
        Panel aktifPanel = null;
        bool panelAciliyor = false;
        int animasyonHizi = 10;
        DialogResult res;
        string kalansure = "Oturumun Kapanmasına Kalan Süre: ";
        int rotate = 0;
        TimeSpan sure;
        public static string kullaniciadi = "";
        public static bool admin = true;
        public Home()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void Nokta();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void MesajGonder(System.IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void panelheader_MouseDown(object sender, MouseEventArgs e)
        {
            Nokta();
            MesajGonder(this.Handle, 0x112, 0xf012, 0);
        }

        private async void HomeDesignerUi_Load(object sender, EventArgs e)
        {
            piclogo.BackgroundImage = Image.FromFile("Images\\BaskLogo280x100.png");
            panelebeveyn.BackgroundImage = Image.FromFile("Images\\BaskLogo1104x804.png");
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
            sure = new TimeSpan(1, 0, 0);
            if (kullaniciadi.Contains("@"))
            {
                string query = "SELECT KullaniciId FROM KullaniciBilgileri WHERE Email = @kullaniciadi";
                int kullaniciıd = 0;
                string query2 = "SELECT KullaniciAdi FROM KullaniciSistem WHERE KullaniciId = @kullaniciId";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                    object result = await cmd.ExecuteScalarAsync();
                    if (result != null)
                    {
                        kullaniciıd = Convert.ToInt32(result);
                    }
                });
                await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", kullaniciıd);
                    object result = await cmd.ExecuteScalarAsync();
                    if (result != null)
                    {
                        kullaniciadi = result.ToString();
                        btnkullanicinfo.Text = kullaniciadi;
                        await ResimUrlBul(kullaniciadi);
                    }
                });
            }
            else if (kullaniciadi.All(char.IsDigit) && kullaniciadi.Length == 11)
            {
                string query = "SELECT KullaniciId from KullaniciBilgileri where Tc=@Tc";
                int kullaniciId = 0;
                string query2 = "SELECT KullaniciAdi FROM KullaniciSistem WHERE KullaniciId = @kullaniciId";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@Tc", kullaniciadi);
                    object result = await cmd.ExecuteScalarAsync();
                    if (result != null)
                    {
                        kullaniciId = Convert.ToInt32(result);
                    }
                });
                await DatabaseHelper.DatabaseQueryAsync(query2,async cmd=>
                {
                    cmd.Parameters.AddWithValue("@kullaniciId",kullaniciId);
                    object result =await cmd.ExecuteScalarAsync();
                    if (result != null) 
                    {
                        kullaniciadi = result.ToString();
                        btnkullanicinfo.Text = kullaniciadi;
                        await ResimUrlBul(kullaniciadi);
                    }
                });
            }
            else
            {
                btnkullanicinfo.Text = kullaniciadi;
                await ResimUrlBul(kullaniciadi);
            }
        }
        private async Task ResimUrlBul(string kullaniciadi)
        {
            int kullaniciId = 0;
            string query1 = "SELECT KullaniciId FROM KullaniciSistem WHERE KullaniciAdi = @kullaniciadi";
            string query2 = "SELECT ProfilFotoUrl FROM KullaniciBilgileri WHERE KullaniciId = @kullaniciId";
            await DatabaseHelper.DatabaseQueryAsync(query1, async cmd =>
            {
                cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                object result1 = await cmd.ExecuteScalarAsync();
                if (result1 != null)
                {
                    kullaniciId = Convert.ToInt32(result1);
                }
            });
            if (kullaniciId > 0)
            {
                await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    object result2 = await cmd.ExecuteScalarAsync();
                    if (result2 != null && result2 != DBNull.Value)
                    {
                        string url = result2.ToString();
                        await LoadImageFromUrl(url);
                    }
                });
            }
            else
            {
                MessageBox.Show("Kullanıcı ID'si bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadImageFromUrl(string url)
        {
            try
            {
                if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    url = $"https://drive.google.com/uc?export=view&id={url}";
                }
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = await webClient.DownloadDataTaskAsync(url);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picKullanici.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (WebException wex) when ((wex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Belirtilen URL'de resim bulunamadı.", "Resim Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnkitapislemlerimenu_Click(object sender, EventArgs e)
        {
            PaneliAcKapat(panelkitapislemleri);
        }
        private void btnkullaniciislemleri_Click(object sender, EventArgs e)
        {
            PaneliAcKapat(panelkullaniciislemleri);
        }

        private void btnanalizveistatistik_Click(object sender, EventArgs e)
        {
            PaneliAcKapat(panelanaliz);
        }

        private void btnodemeislemleri_Click(object sender, EventArgs e)
        {
            PaneliAcKapat(panelodeme);
        }
        private void PaneliAcKapat(Panel panel)
        {
            if (timerbutonlar.Enabled)
            {
                return;
            }
            else
            {
                aktifPanel = panel;
                panelAciliyor = !(panel.Visible && panel.Height > 0);
                if (panelAciliyor)
                {
                    aktifPanel.Height = 0;
                    aktifPanel.Visible = true;
                }
                timerbutonlar.Start();
            }
        }

        private void timerbutonlar_Tick(object sender, EventArgs e)
        {
            if (aktifPanel == null)
            {
                timerbutonlar.Stop();
                return;
            }
            int maxHeight = aktifPanel.PreferredSize.Height;
            if (panelAciliyor)
            {
                aktifPanel.Height += animasyonHizi;
                if (aktifPanel.Height >= maxHeight)
                {
                    aktifPanel.Height = maxHeight;
                    timerbutonlar.Stop();
                    aktifPanel = null;
                }
            }
            else
            {
                aktifPanel.Height -= animasyonHizi;
                if (aktifPanel.Height <= 0)
                {
                    aktifPanel.Height = 0;
                    aktifPanel.Visible = false;
                    timerbutonlar.Stop();
                    aktifPanel = null;
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            res = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Devam Etmek İstiyor Musunuz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnbig_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnkitapyonetim_MouseEnter(object sender, EventArgs e)
        {
            if (sender is IconButton btn)
            {
                btn.ImageAlign = ContentAlignment.MiddleRight;
                btn.IconColor = Color.Red;
                btn.Refresh();
            }
        }

        private void btnodeme_MouseLeave(object sender, EventArgs e)
        {
            if (sender is IconButton btn)
            {
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.IconColor = Color.Gainsboro;
                btn.Refresh();
            }
        }

        private void tarihsaat_Tick(object sender, EventArgs e)
        {
            lbltarihsaat.Text = DateTime.Now.ToString("yy/MM/dd-HH:mm:ss");
            sure = sure.Subtract(new TimeSpan(0, 0, 1));
            btnkalansure.Text = kalansure + sure.ToString("mm\\:ss");
            if (sure.TotalMinutes == 14 && sure.Seconds == 59)
            {
                DialogResult result = MessageBox.Show("Oturum süreniz dolmak üzere. Devam etmek istiyor musunuz?", "Oturum Süresi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    sure = new TimeSpan(1, 0, 0);
                }
            }
            if (sure.TotalSeconds <= 15 && sure.TotalSeconds > 0)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            if (sure.TotalSeconds <= 0)
            {
                tarihsaat.Stop();
                MessageBox.Show("Oturum süresi doldu, sistemden çıkış yapılıyor.", "Oturum Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }


        private void btnkalansure_Click(object sender, EventArgs e)
        {
        }

        private void HomeButton_MouseEnter(object sender, EventArgs e)
        {
            HomeButton.ForeColor = Color.Red;
            HomeButton.IconColor = Color.Red;
        }

        private void HomeButton_MouseLeave(object sender, EventArgs e)
        {
            HomeButton.ForeColor = Color.Gainsboro;
            HomeButton.IconColor = Color.Gainsboro;
        }

        private void btnkitapyonetim_Click(object sender, EventArgs e)
        {
            KitapYonetim ui = new KitapYonetim();
            FormHelper formHelper = new FormHelper(ui.Name);
        }

        private void btnkategoriyonetim_Click(object sender, EventArgs e)
        {
            KategoriYonetimDesignerUi ui = new KategoriYonetimDesignerUi();
            FormHelper formHelper = new FormHelper(ui.Name);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {

        }

        private void btnyazaryonetim_Click(object sender, EventArgs e)
        {
            YazarYonetim ui = new YazarYonetim();
            FormHelper formHelper = new FormHelper(ui.Name);
        }

        private void btnkullanicilar_Click(object sender, EventArgs e)
        {
            KullaniciYönetimi ui = new KullaniciYönetimi();
            FormHelper formHelper = new FormHelper(ui.Name);
        }
    }
}
