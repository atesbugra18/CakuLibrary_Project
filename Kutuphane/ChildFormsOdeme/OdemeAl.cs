using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.Utils;

namespace Kutuphane.ChildFormsOdeme
{
    public partial class OdemeAl : Form
    {
        public OdemeAl()
        {
            InitializeComponent();
        }
        public Task CloseEdildi()
        {
            panelkontroller.Visible = true;
            panelcocuk.Visible = false;
            panelcocuk.SendToBack();
            panelkontroller.BringToFront();
            ListeyiDoldur();
            return Task.CompletedTask;
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string aktifbaglanti;
        public int adminid;
        private void OdemeAl_Load(object sender, EventArgs e)
        {
            KontrolleriBagla();
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            DatabaseHelper.GetActiveConnectionString();
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
            ListeyiDoldur();
        }
        private void KontrolleriBagla()
        {
            panelara.Parent = panelkontroller;
            panelara.Dock = DockStyle.Top;
            panelislemsecim.Parent = panelkontroller;
            panelislemsecim.Dock = DockStyle.Right;
            panelheader.Parent = panelkontroller;
            panelheader.Dock = DockStyle.Top;
            panelodemekismi.Parent = panelkontroller;
            panelodemekismi.Dock = DockStyle.Fill;
            panelkontroller.BringToFront();
            panelodemekismi.BringToFront();
        }
        private void ListeyiDoldur()
        {
            string query = "select KullaniciSistem.KullaniciAdi,KullaniciBilgileri.Ad+' '+KullaniciBilgileri.Soyad as 'adisoyadi',Cezalar.BorcTutari,Cezalar.OdemeDurumu,Cezalar.OdemeTarihi from KullaniciBilgileri,KullaniciSistem,Cezalar where Cezalar.KullaniciId=KullaniciSistem.KullaniciId and Cezalar.KullaniciId=KullaniciBilgileri.KullaniciId";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

        }
        private void btnodemeal_MouseEnter(object sender, EventArgs e)
        {
            btnodemeal.ForeColor = Color.Red;
            btnodemeal.IconColor = Color.Red;
        }

        private void btnodemeal_MouseLeave(object sender, EventArgs e)
        {
            btnodemeal.ForeColor = Color.Gainsboro;
            btnodemeal.IconColor = Color.Gainsboro;
        }

        private void btnnakit_Click(object sender, EventArgs e)
        {
            OdemeSecenekleri odeme = new OdemeSecenekleri();
            odeme.Odemesekli = "Nakit";
            if (dataGridView1.SelectedRows != null && dataGridView1.CurrentRow != null)
            {
                string odemeDurumu = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                if (odemeDurumu == "Ödenmedi")
                {
                    odeme.TahsilTarihi = DateTime.Now.ToString("dd/MM/yyyy");
                    odeme.BorcluAdSoyad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    odeme.BorcluKullanici = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    odeme.OdenenTutar = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    odeme.Parent = panelcocuk;
                    panelcocuk.Parent = this;
                    panelcocuk.BringToFront();
                    panelcocuk.Dock = DockStyle.Fill;
                    odeme.Show();
                    odeme.Dock = DockStyle.Fill;
                    odeme.BringToFront();
                }
                else
                {
                    MessageBox.Show("Bu borç zaten tahsil edilmiş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnkartlaode_Click(object sender, EventArgs e)
        {
            OdemeSecenekleri odeme = new OdemeSecenekleri();
            odeme.Odemesekli = "Kredi Kartı";
            if (dataGridView1.SelectedRows != null && dataGridView1.CurrentRow != null)
            {
                string odemeDurumu = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                if (odemeDurumu == "Ödenmedi")
                {
                    odeme.TahsilTarihi = DateTime.Now.ToString("dd/MM/yyyy");
                    odeme.BorcluAdSoyad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    odeme.BorcluKullanici = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    odeme.OdenenTutar = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    odeme.Parent = panelcocuk;
                    panelcocuk.Parent = this;
                    panelcocuk.BringToFront();
                    panelcocuk.Dock = DockStyle.Fill;
                    odeme.Show();
                    odeme.Dock = DockStyle.Fill;
                    odeme.BringToFront();
                }
                else
                {
                    MessageBox.Show("Bu borç zaten tahsil edilmiş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelislemsecim_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
