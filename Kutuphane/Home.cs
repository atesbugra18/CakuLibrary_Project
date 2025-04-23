using Bogus.DataSets;
using Microsoft.VisualBasic.ApplicationServices;
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.Utils;
namespace Kutuphane
{
    public partial class Home : Form
    {
        string kalansure = "Oturumun Kapanmasına Kalan Süre ";
        int rotate = 0;
        int rotateclose = 0;
        TimeSpan sure;
        public static string kullaniciadi = "";
        public static bool admin = true;
        public static Home Instance { get; private set; }
        private readonly string BaglantıV = ConfigurationManager.ConnectionStrings["BaglantıV"].ConnectionString;
        private readonly string BaglantıSefa = ConfigurationManager.ConnectionStrings["BaglantıSefa"].ConnectionString;
        Dictionary<Panel, (Size hedefBoyut, bool acikMi)> panelDurumlari = new Dictionary<Panel, (Size, bool)>();
        public Home()
        {
            InitializeComponent();
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
                        profilphotos.Image = Image.FromStream(ms);
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
            if (rotate == (90 * 10))
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
            PanelMenuButtons.MouseWheel += PanelMenuButtons_MouseWheel;
            lblkullanici.Text = kullaniciadi;
            await ResimUrlBul(kullaniciadi);
            Instance = this;
        }
        private void ControlleriAyarla()
        {
            System.Windows.Forms.Control[] btns = { btnmenu, btnbackward, btnforward, btnclose };
            foreach (System.Windows.Forms.Control control in btns)
            {
                string yol = control.Name == "btnmenu" ? "Images\\menurgb.png" :
                             control.Name == "btnbackward" ? "Images\\backwardbutton.png" :
                             control.Name == "btnforward" ? "Images\\forwardbutton.png" :
                             control.Name == "btnclose" ? "Images\\closebutton.png" :
                             null;
                if (!String.IsNullOrEmpty(yol))
                {
                    control.BackgroundImage = Image.FromFile(yol);
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
                Panel secilenPanel = null;
                Size hedefBoyut = Size.Empty;
                switch (btn.Name)
                {
                    case "btnkitapislemleri":
                        secilenPanel = PanelKitapIslemleri;
                        hedefBoyut = new Size(310, 360);
                        break;
                    case "btnkullaniciislemleri":
                        secilenPanel = PanelKullanicislemleri;
                        hedefBoyut = new Size(310, 200);
                        break;
                    case "btnanalizveistatistikislemleri":
                        secilenPanel = PanelAnalizveİstatistikİslemleri;
                        hedefBoyut = new Size(310, 240);
                        break;
                    case "btnodemeislemleri":
                        secilenPanel = PanelOdemeIslemleri;
                        hedefBoyut = new Size(310, 40);
                        break;
                }

                if (secilenPanel != null)
                {
                    bool yeniDurum = !(panelDurumlari.ContainsKey(secilenPanel) && panelDurumlari[secilenPanel].acikMi);
                    panelDurumlari[secilenPanel] = (hedefBoyut, yeniDurum);
                    panelAnimasyonTimer.Start();
                }
            }
        }
        private void PanelAnimasyonTimer_Tick(object sender, EventArgs e)
        {
            bool animasyonDevamEdiyor = false;
            foreach (var item in panelDurumlari)
            {
                Panel pnl = item.Key;
                Size hedef = item.Value.hedefBoyut;
                bool acikMi = item.Value.acikMi;
                int hedefY = acikMi ? hedef.Height : 0;
                int mevcutY = pnl.Height;
                int fark = hedefY - mevcutY;
                if (Math.Abs(fark) > 5)
                {
                    pnl.Height += fark / 5;
                    animasyonDevamEdiyor = true;
                }
                else
                {
                    pnl.Height = hedefY;
                }
                pnl.Visible = pnl.Height > 0;
            }
            if (!animasyonDevamEdiyor)
            {
                panelAnimasyonTimer.Stop();
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
                        kitapEkle.Size = new Size(875, 605);
                        break;
                    case "btnkitapsilguncelle":
                        break;
                    case "grbtnkitaplistele":
                        altbtnkitaplarilistele.Visible = !altbtnkitaplarilistele.Visible;
                        altbtnteslimlistele.Visible = !altbtnteslimlistele.Visible;
                        if (altbtnkitaplarilistele.Visible)
                        {
                            PanelKitapIslemleri.Size = new Size(310, 440);
                        }
                        else
                        {
                            PanelKitapIslemleri.Size = new Size(310, 360);
                        }
                        break;
                    case "btnkategoriekle":
                        break;
                    case "btnkategorisilguncelle":
                        ChildFormsKitap.KategoriSilDuzenle kategoriSilDuzenle = new ChildFormsKitap.KategoriSilDuzenle();
                        kategoriSilDuzenle.MdiParent = this;
                        panel1.Controls.Add(kategoriSilDuzenle);
                        kategoriSilDuzenle.Show();
                        kategoriSilDuzenle.BringToFront();
                        kategoriSilDuzenle.Location = new Point(410, 120);
                        kategoriSilDuzenle.Size = new Size(875, 605);
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
            closetimer.Start();
        }
        private void PanelMenuButtons_MouseWheel(object sender, MouseEventArgs e)
        {
            int newValue = PanelMenuButtons.VerticalScroll.Value - (e.Delta / 3);
            newValue = Math.Max(PanelMenuButtons.VerticalScroll.Minimum, Math.Min(PanelMenuButtons.VerticalScroll.Maximum, newValue));
            PanelMenuButtons.VerticalScroll.Value = newValue;
            PanelMenuButtons.Invalidate();
        }

        private async void closetimer_Tick(object sender, EventArgs e)
        {
           await CloseHelper.CloseButtonAnimation(sender, e, closetimer, btnclose,this);
        }
    }
}
