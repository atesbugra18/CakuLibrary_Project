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

namespace Kutuphane.ChildFormsKitap.KategoriYonetim
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
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
        string aktifbaglanti;
        private void KategoriYonetimi_Load(object sender, EventArgs e)
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
            ListeyiDoldur();
        }
        private void ListeyiDoldur()
        {
            string query = "SELECT * FROM Kategoriler";
            using (SqlConnection con=new SqlConnection(aktifbaglanti))
            {
                using (SqlCommand cmd=new SqlCommand(query,con))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            if (txtara.Text.All(char.IsDigit))
            {
                string aranan = txtara.Text.TrimStart().TrimEnd();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["kategoriid"].Value.ToString().Contains(aranan))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                string aranan = txtara.Text.TrimStart().TrimEnd();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["kategoriadi"].Value.ToString().ToUpper().Contains(aranan.ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void kategorislemleri_MouseEnter(object sender, EventArgs e)
        {
            kategorislemleri.ForeColor = Color.Red;
            kategorislemleri.IconColor = Color.Red;
        }

        private void kategorislemleri_MouseLeave(object sender, EventArgs e)
        {
            kategorislemleri.ForeColor = Color.Gainsboro;
            kategorislemleri.IconColor = Color.Gainsboro;
        }
        //Kategori Ekle Sil Düzenle Test Edilecek + panel aç kapa düzgün çalışıyor mu bakılacak
        private void btnkategoriekle_Click(object sender, EventArgs e)
        {
            panelkontroller.Visible = false;
            panelcocuk.Visible = true;
            panelcocuk.Controls.Clear();
            panelcocuk.Dock = DockStyle.Fill;
            KategoriYonetimiLayout kategoriControl = new KategoriYonetimiLayout();
            kategoriControl.gonderilenistek = "Ekle";
            kategoriControl.Dock = DockStyle.Fill;
            panelcocuk.Controls.Add(kategoriControl);
            kategoriControl.BringToFront();
        }

        private void btnkategorisilduzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                panelkontroller.Visible = false;
                panelcocuk.Visible = true;
                panelcocuk.Controls.Clear();
                panelcocuk.Dock = DockStyle.Fill;
                KategoriYonetimiLayout kategoriControl = new KategoriYonetimiLayout();
                kategoriControl.gonderilenistek = "Sil&Düzenle";
                kategoriControl.kategoriadi = dataGridView1.SelectedRows[0].Cells["kategoriadi"].Value.ToString();
                kategoriControl.Dock = DockStyle.Fill;
                panelcocuk.Controls.Add(kategoriControl);
                kategoriControl.BringToFront();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
