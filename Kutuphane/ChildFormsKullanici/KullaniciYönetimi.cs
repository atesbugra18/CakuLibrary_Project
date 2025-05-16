using Kutuphane.ChildFormsKitap.YazarYonetim;
using Kutuphane.Utils;
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

namespace Kutuphane.ChildFormsKullanici
{
    public partial class KullaniciYönetimi : Form
    {

        public KullaniciYönetimi()
        {
            InitializeComponent();
        }
        Panel aktifPanel = null;
        bool panelAciliyor = false;
        int animasyonHizi = 10;
        string aktifbaglanti;
        public static string rolune { get; set; }
        public async Task CloseEdildi()
        {
            panelkontroller.Visible = true;
            panelkontroller.BringToFront();
            await ListeyiDoldur();
        }
        private void btnkullaniciyonetim_MouseEnter(object sender, EventArgs e)
        {
            btnkullaniciyonetim.ForeColor = Color.Red;
            btnkullaniciyonetim.IconColor = Color.Red;
        }

        private void btnkullaniciyonetim_MouseLeave(object sender, EventArgs e)
        {
            btnkullaniciyonetim.ForeColor = Color.Gainsboro;
            btnkullaniciyonetim.IconColor = Color.Gainsboro;
        }

        private async void KullaniciYönetimi_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (string.IsNullOrEmpty(aktifbaglanti))
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            await ListeyiDoldur();
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
        }
        private async Task ListeyiDoldur()
        {
            string query = "SELECT KullaniciBilgileri.KullaniciId,KullaniciBilgileri.Ad+' '+KullaniciBilgileri.Soyad as 'adisoyadi',KullaniciBilgileri.TC,KullaniciBilgileri.Email,KullaniciSistem.KullaniciAdi,KullaniciSistem.Rolu,KullaniciSistem.AktifCezaTutari,KullaniciSistem.AktifPasif from KullaniciBilgileri,KullaniciSistem where KullaniciBilgileri.KullaniciId=KullaniciSistem.KullaniciId";
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
        private void btnkullanicikle_Click(object sender, EventArgs e)
        {
            KullaniciYonetimiLayout Control = new KullaniciYonetimiLayout();
            Control.gonderilenistek = "Ekle";
            Control.Dock = DockStyle.Fill;
            Control.gonderilenrol = rolune;
            panelebeveyn.Controls.Add(Control);
            Control.BringToFront();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnkullanicisil_Click(object sender, EventArgs e)
        {
            if (rolune == "Admin")
            {
                KullaniciYonetimiLayout Control = new KullaniciYonetimiLayout();
                Control.gonderilenistek = "Sil&Düzenle";
                string[] adisoyadi = dataGridView1.CurrentRow.Cells["adisoyadi"].Value.ToString().Split(' ');
                Control.gonderilenrol = rolune;
                Control.adi = string.Join(" ", adisoyadi.Take(adisoyadi.Length - 1));
                Control.soyadi = adisoyadi[adisoyadi.Length - 1];
                Control.tc = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
                Control.email = dataGridView1.CurrentRow.Cells["mail"].Value.ToString();
                Control.kullaniciadi = dataGridView1.CurrentRow.Cells["kullaniciadi"].Value.ToString();
                Control.rol = dataGridView1.CurrentRow.Cells["rolu"].Value.ToString();
                Control.Dock = DockStyle.Fill;
                panelebeveyn.Controls.Add(Control);
                Control.BringToFront();
            }
            else
            {
                MessageBox.Show("Bu panele erişmeye yetkiniz bulunmamaktadır.");
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
        private void crolu_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }

        private void caktifpasif_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void FiltreUygula()
        {
            //GÖZDEN GEÇİRİLECEK GEREKİRSE DEĞİŞTİRİLECEK
            bool visible = true;
            string aranan = "";
            string rolSecimi = "";
            string aktifSecimi = "";
            string minText = "";
            string maxText = "";
            Task.Run(() =>
            {
                List<DataGridViewRow> rows = null;
                Invoke(new Action(() =>
                {
                    rows = dataGridView1.Rows.Cast<DataGridViewRow>().ToList();
                }));

                foreach (DataGridViewRow row in rows)
                {
                    if (row.IsNewRow) continue;

                    Invoke(new Action(() =>
                    {
                        aranan = txtara.Text.Trim();
                        rolSecimi = crolu.SelectedItem?.ToString();
                        aktifSecimi = caktifpasif.SelectedItem?.ToString();
                        minText = txtmintutar.Text.Trim();
                        maxText = txtmaxtutar.Text.Trim();
                    }));

                    if (!string.IsNullOrEmpty(aranan))
                    {
                        if (aranan.All(char.IsDigit))
                        {
                            bool anyMatch = false;

                            if (row.Cells["kullaniciid"].Value?.ToString().Contains(aranan) == true)
                                anyMatch = true;

                            if (row.Cells["tc"].Value?.ToString().Contains(aranan) == true)
                                anyMatch = true;

                            visible &= anyMatch;
                        }
                        else
                        {
                            visible &= (
                                row.Cells["adisoyadi"].Value?.ToString().IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0
                                || row.Cells["kullaniciadi"].Value?.ToString().IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0
                                || row.Cells["mail"].Value?.ToString().IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0
                            );
                        }
                    }

                    if (!string.IsNullOrEmpty(rolSecimi))
                    {
                        visible &= row.Cells["rolu"].Value?.ToString().IndexOf(rolSecimi, StringComparison.OrdinalIgnoreCase) >= 0;
                    }

                    if (!string.IsNullOrEmpty(aktifSecimi))
                    {
                        visible &= row.Cells["aktifpasif"].Value?.ToString().IndexOf(aktifSecimi, StringComparison.OrdinalIgnoreCase) >= 0;
                    }

                    if (int.TryParse(minText, out int minTutar))
                    {
                        visible &= int.TryParse(row.Cells["aktiftutar"].Value?.ToString(), out int rowTutar) && rowTutar >= minTutar;
                    }

                    if (int.TryParse(maxText, out int maxTutar))
                    {
                        visible &= int.TryParse(row.Cells["aktiftutar"].Value?.ToString(), out int rowTutar) && rowTutar <= maxTutar;
                    }
                    BeginInvoke(new Action(() =>
                    {
                        row.Visible = visible;
                    }));
                }
            });
        }

        private void btnfiltreleritemizle_Click(object sender, EventArgs e)
        {
            txtara.Clear();
            txtmintutar.Clear();
            txtmaxtutar.Clear();
            crolu.SelectedIndex = -1;
            caktifpasif.SelectedIndex = -1;
            FiltreUygula();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }

        private void txtmintutar_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }

        private void txtmaxtutar_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
    }
}
