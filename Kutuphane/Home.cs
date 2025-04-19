using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class Home: Form
    {
        string kalansure ="Oturumun Kapanmasına Kalan Süre ";
        int rotate = 0;
        TimeSpan sure;
        public static string kullaniciadi = "";
        public static bool admin = true;
        private readonly string baglanti = ConfigurationManager.ConnectionStrings["Baglantı"].ConnectionString;
        public Home()
        {
            InitializeComponent();
        }
        private async Task ResimUrlBul(string kullaniciadi)
        {
            int kullaniciId = 0;
            string query1 = "SELECT KullaniciId FROM KullaniciSistem WHERE KullaniciAdi = @kullaniciadi";
            string query2 = "SELECT ProfilFotoUrl FROM KullaniciBilgileri WHERE KullaniciId = @kullaniciId";
            using (SqlConnection connection = new SqlConnection(baglanti))
            {
                await connection.OpenAsync();
                using (SqlCommand command1 = new SqlCommand(query1, connection))
                {
                    command1.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                    object result1 = await command1.ExecuteScalarAsync();
                    if (result1 != null)
                    {
                        kullaniciId = Convert.ToInt32(result1);
                    }
                }
                if (kullaniciId > 0)
                {
                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                    {
                        command2.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        object result2 = await command2.ExecuteScalarAsync();
                        if (result2 != null)
                        {
                            string imageUrl = $"https://drive.google.com/uc?export=download&id={result2}";
                            await LoadImageFromUrl(imageUrl);
                        }
                    }
                }
            }
        }
        private async Task LoadImageFromUrl(string url)
        {
            await Task.Delay(100);
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = await webClient.DownloadDataTaskAsync(url);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        profilphotos.BackgroundImage = System.Drawing.Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void oturumtimer_Tick(object sender, EventArgs e)
        {
            sure = sure.Subtract(new TimeSpan(0, 0, 1));
            btnoturumsure.Text = kalansure + sure.ToString("mm\\:ss");
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
                oturumtimer.Stop();
                MessageBox.Show("Oturum süresi doldu, sistemden çıkış yapılıyor.", "Oturum Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void menutimer_Tick(object sender, EventArgs e)
        {
            btnmenu.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            btnmenu.Refresh();
            rotate += 90;
            if (rotate==(90*10))
            {
                menutimer.Stop();
                rotate = 0;
                PanelMenu.Visible = !PanelMenu.Visible;
                btnmenu.BringToFront();
                if (PanelMenu.Visible)
                {
                    durumcubugu.Location = new Point(350, 725);
                    durumcubugu.Size = new Size(950, 25);
                }
                else
                {
                    durumcubugu.Location = new Point(0, 725);
                    durumcubugu.Size = new Size(1300, 25);
                }
            }
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            ControlleriAyarla();
            sure = new TimeSpan(1, 0, 0);
            oturumtimer.Start();
            lblkullanici.Text = kullaniciadi;
            await ResimUrlBul(kullaniciadi);
        }
        private void ControlleriAyarla()
        {
            System.Windows.Forms.Control[] btns = {btnmenu,btnbackward,btnforward,btnclose };
            foreach(System.Windows.Forms.Control control in btns)
            {
                string yol = control.Name == "btnmenu" ? "Images\\menurgb.png" :
                             control.Name == "btnbackward" ? "Images\\backwardbutton.png" :
                             control.Name == "btnforward" ? "Images\\forwardbutton.png" :
                             control.Name == "btnclose" ? "Images\\closebutton.png" :
                             null;
                if (!String.IsNullOrEmpty(yol))
                {
                    control.BackgroundImage= Image.FromFile(yol);
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menutimer.Enabled = true;
            menutimer.Start();
        }

        private void Imlecustunde(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn)
            {
                btn.BackColor = Color.Black;
                btn.ForeColor = Color.White;
                btn.Cursor = Cursors.Hand;
                btn.Refresh();
            }
        }
        private void Imlecustundedegil(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.Cursor = Cursors.Hand;
                btn.Refresh();
            }
        }

        private void btnanabutonlar_Click(object sender, EventArgs e)
        {
            if (sender is Control btn)
            {
                void TogglePanel(Panel pnl, Size expandedSize)
                {
                    if (!pnl.Visible)
                    {
                        pnl.Visible = true;
                        pnl.Size = expandedSize;
                    }
                    else
                    {
                        pnl.Visible = false;
                    }
                }
                switch (btn.Name)
                {
                    case "btnkitapislemleri":
                        TogglePanel(PanelKitapIslemleri, new Size(310, 360));
                        break;
                    case "btnkullaniciislemleri":
                        TogglePanel(PanelKullanicislemleri, new Size(310, 200));
                        break;
                    case "btnanalizveistatistikislemleri":
                        TogglePanel(PanelAnalizveİstatistikİslemleri, new Size(310, 240));
                        break;
                    case "btnodemeislemleri":
                        TogglePanel(PanelOdemeIslemleri, new Size(310, 40));
                        break;
                }
            }
        }
        private void btnaltbutonlar_Click(object sender, EventArgs e)
        {
            if (sender is Control btn)
            {
                switch (btn.Name)
                {
                    case "btnkitapekle":
                        ChildFormsKitap.KitapEkle kitapEkle = new ChildFormsKitap.KitapEkle();
                        kitapEkle.MdiParent = this;
                        panel1.Controls.Add(kitapEkle);
                        kitapEkle.Show();
                        kitapEkle.BringToFront();
                        kitapEkle.Location = new Point(410, 120);
                        kitapEkle.Size = new Size(890,605);
                        break;
                    case "btnkitapsilguncelle":
                        break;
                    case "grbtnkitaplistele":
                        break;
                    case "btnkategoriekle":
                        break;
                    case "btnkategorisilguncelle":
                        break;
                    case "btnkategorilistele":
                        break;
                    case "btnyazarekle":
                        break;
                    case "btnyazarsilguncelle":
                        break;
                    case "btnyazarlistele":
                        break;
                    case "btnkullaniciekle":
                        break;
                    case "btnkullanicibilgilerinidegistir":
                        break;
                    case "btnkullanicilistele":
                        break;
                    case "btnokumalistesi":
                        break;
                    case "btnbildirimgonder":
                        break;
                    case "btnencokkitap":
                        break;
                    case "btnencokyazar":
                        break;
                    case "btnpopulerkategoriler":
                        break;
                    case "btnenaktif":
                        break;
                    case "btngecikenkitaplar":
                        break;
                    case "btnkullanimistatistikleri":
                        break;
                    case "btnodemeal":
                        break;
                    default:
                        break;
                }
            }
        }
        private void btnaltgrupbtn_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tarihsaat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
