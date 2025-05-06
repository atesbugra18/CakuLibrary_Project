using Kutuphane.ChildFormsKitap.KitapYönetim;
using Kutuphane.ChildFormsKitap.YazarYonetim;
using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsKitap
{
    public partial class KitapYonetim : Form
    {
        public KitapYonetim()
        {
            InitializeComponent();
        }
        Panel aktifPanel = null;
        bool panelAciliyor = false;
        int animasyonHizi = 10;
        string aktifbaglanti;
        private async void KitapYonetim_Load(object sender, EventArgs e)
        {
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
            await ListeyiDoldur();
            await KategorileriDoldur();
        }
        public async Task CloseEdildi()
        {
            panelcocuk.Visible = false;
            panelkontroller.Visible = true;
            await ListeyiDoldur();
            await KategorileriDoldur();
        }
        private Task ListeyiDoldur()
        {
            string query = "SELECT Kitaplar.KitapId,Kitaplar.KitapAdi,Yazarlar.YazarAdi+' '+Yazarlar.YazarSoyadi as 'YazarAdiSoyadi',Kategoriler.KategoriAdi,Kitaplar.SayfaSayisi,KitapStoklari.StokSayisi from Kitaplar,Yazarlar,Kategoriler,KitapStoklari where Kitaplar.YazarId=Yazarlar.YazarId and Kitaplar.KategoriId=Kategoriler.KategoriId and Kitaplar.KitapId=KitapStoklari.KitapId";
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
            return Task.CompletedTask;
        }
        private Task KategorileriDoldur()
        {
            string query = "Select KategoriAdi from kategoriler";
            using (SqlConnection con=new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand(query,con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    clistkategori.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        string kategoriadi = row["KategoriAdi"].ToString();
                        clistkategori.Items.Add(kategoriadi);
                    }
                }
            }
            return Task.CompletedTask;
        }

        private void kitapislemleri_MouseEnter(object sender, EventArgs e)
        {
            kitapislemleri.ForeColor = Color.Red;
            kitapislemleri.IconColor = Color.Red;
        }

        private void kitapislemleri_MouseLeave(object sender, EventArgs e)
        {
            kitapislemleri.ForeColor = Color.Gainsboro;
            kitapislemleri.IconColor = Color.Gainsboro;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }

        private void txtstoksayisi_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }

        private void cboxstoksayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }

        private void clistkategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void FiltreUygula()
        {
            dataGridView1.ClearSelection();
            int sayfasayisi = int.TryParse(txtsayfasayisi.Text, out int parsedSayfaSayisi) ? parsedSayfaSayisi : 0;
            int stoksayisi = cboxstoksayisi.SelectedItem != null ? int.Parse(cboxstoksayisi.SelectedItem.ToString()) : 0;
            List<string> seciliKategoriler = clistkategori.CheckedItems.Cast<string>().ToList();
            string kategoriadi = clistkategori.SelectedItem != null ? clistkategori.SelectedItem.ToString() : string.Empty;
            string aranan = txtara.Text.Trim();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool visible = true;
                if (aranan.All(char.IsDigit))
                {
                    visible &= row.Cells["kitapid"].Value.ToString().Contains(aranan);
                }
                else
                {
                    visible &= row.Cells["KitapAdi"].Value.ToString().IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0
                            || row.Cells["yazaradisoyadi"].Value.ToString().IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                if (sayfasayisi > 0)
                {
                    visible &= int.TryParse(row.Cells["sayfasayisi"].Value.ToString(), out int sayfa) && sayfa >= sayfasayisi;
                }
                if (stoksayisi > 0)
                {
                    visible &= int.TryParse(row.Cells["stoksayisi"].Value.ToString(), out int stok) && stok == stoksayisi;
                }
                if (seciliKategoriler.Count > 0)
                {
                    string kategori = row.Cells["kategoriadi"].Value.ToString();
                    bool kategoriUygun = false;
                    foreach (var item in seciliKategoriler)
                    {
                        if (kategori == item.ToString())
                        {
                            kategoriUygun = true;
                            break;
                        }
                    }
                    visible &= kategoriUygun;
                }
                if (row != dataGridView1.CurrentRow)
                {
                    row.Visible = visible;
                }
            }
        }
        private void btnfiltrele_Click(object sender, EventArgs e)
        {
            PaneliAcKapat(panelfiltre);
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
        private void btnfiltreleritemizle_Click(object sender, EventArgs e)
        {
            txtara.Clear();
            txtsayfasayisi.Clear();
            cboxstoksayisi.SelectedIndex = -1;
            for (int i = 0; i < clistkategori.Items.Count; i++)
            {
                clistkategori.SetItemChecked(i, false);
            }
            FiltreUygula();
        }

        private void btnkitapekle_Click(object sender, EventArgs e)
        {
            panelkontroller.Visible = false;
            KitapYonetimLayout Control = new KitapYonetimLayout();
            Control.gonderilenistek = "Ekle";
            Control.Dock = DockStyle.Fill;
            panelcocuk.Controls.Add(Control);
            Control.BringToFront();
        }

        private void btnkitapsilduzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                panelkontroller.Visible = false;
                KitapYonetimLayout Control = new KitapYonetimLayout();
                Control.gonderilenistek = "Sil&Düzenle";
                Control.kitapadi = dataGridView1.SelectedRows[0].Cells["KitapAdi"].Value.ToString();
                Control.yazaradisoyadi = dataGridView1.SelectedRows[0].Cells["yazaradisoyadi"].Value.ToString();
                Control.kategorisi = dataGridView1.SelectedRows[0].Cells["kategoriadi"].Value.ToString();
                Control.sayfasayisi = dataGridView1.SelectedRows[0].Cells["sayfasayisi"].Value.ToString();
                Control.stoksayisi = dataGridView1.SelectedRows[0].Cells["stoksayisi"].Value.ToString();
                Control.ciltnosu = dataGridView1.SelectedRows[0].Cells["ciltnosu"].Value.ToString();
                Control.Dock = DockStyle.Fill;
                panelcocuk.Controls.Add(Control);
                Control.BringToFront();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtstoksayisi_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
