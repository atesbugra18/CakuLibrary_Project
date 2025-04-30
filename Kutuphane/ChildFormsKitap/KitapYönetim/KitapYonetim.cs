using Kutuphane.ChildFormsKitap.KitapYönetim;
using Kutuphane.ChildFormsKitap.YazarYonetim;
using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private async void KitapYonetim_Load(object sender, EventArgs e)
        {
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
        private async Task ListeyiDoldur()
        {
            string query = "SELECT Kitaplar.KitapId,Kitaplar.KitapAdi,Yazarlar.YazarAdi+' '+Yazarlar.YazarSoyadi as 'YazarAdiSoyadi',Kategoriler.KategoriAdi,Kitaplar.SayfaSayisi,KitapStoklari.StokSayisi from Kitaplar,Yazarlar,Kategoriler,KitapStoklari where Kitaplar.YazarId=Yazarlar.YazarId and Kitaplar.KategoriId=Kategoriler.KategoriId and Kitaplar.KitapId=KitapStoklari.KitapId";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int kitapid = reader.GetInt32(0);
                        string kitapadi = reader.GetString(1);
                        string yazari = reader.GetString(2);
                        string kategorisi = reader.GetString(3);
                        int sayfasayisi = reader.GetInt32(4);
                        int stoksayisi = reader.GetInt32(5);
                        dataGridView1.Rows.Add(kitapid, kitapadi, yazari, kategorisi, sayfasayisi, stoksayisi);
                    }
                }
            });
        }
        private async Task KategorileriDoldur()
        {
            string query = "Select KategoriAdi from kategoriler";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string kategoriadi = reader.GetString(0);
                        clistkategori.Items.Add(kategoriadi);
                    }
                }
            });
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                bool visible = true;
                string aranan = txtara.Text.Trim();
                if (!string.IsNullOrEmpty(aranan))
                {
                    if (aranan.All(char.IsDigit))
                    {
                        visible &= row.Cells["kitapid"].Value.ToString().Contains(aranan);
                    }
                    else
                    {
                        visible &= row.Cells["KitapAdi"].Value.ToString().IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0
                                || row.Cells["yazaradisoyadi"].Value.ToString().IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                }
                if (int.TryParse(txtstoksayisi.Text, out int sayfaFiltre))
                {
                    int sayfa = Convert.ToInt32(row.Cells["sayfasayisi"].Value);
                    visible &= sayfa >= sayfaFiltre;
                }
                if (int.TryParse(txtstoksayisi.Text, out int stokFiltre))
                {
                    int stok = Convert.ToInt32(row.Cells["stoksayisi"].Value);
                    visible &= stok >= stokFiltre;
                }
                if (clistkategori.CheckedItems.Count > 0)
                {
                    string kategori = row.Cells["kategoriadi"].Value.ToString();
                    bool kategoriUygun = false;

                    foreach (var item in clistkategori.CheckedItems)
                    {
                        if (kategori == item.ToString())
                        {
                            kategoriUygun = true;
                            break;
                        }
                    }
                    visible &= kategoriUygun;
                }
                row.Visible = visible;
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
            txtstoksayisi.Clear();
            cboxstoksayisi.SelectedIndex = -1;
            for (int i = 0; i < clistkategori.Items.Count; i++)
            {
                clistkategori.SetItemChecked(i,false);
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
    }
}
