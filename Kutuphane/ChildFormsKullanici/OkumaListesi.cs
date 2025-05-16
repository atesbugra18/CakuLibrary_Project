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

namespace Kutuphane.ChildFormsKullanici
{
    public partial class OkumaListesi : Form
    {
        public OkumaListesi()
        {
            InitializeComponent();
        }
        string aktifbaglanti;
        private void OkumaListesi_Load(object sender, EventArgs e)
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
            string query = "SELECT OduncAlma.IslemId,KS1.KullaniciAdi AS 'OkuyaninAdi',Kitaplar.KitapAdi,OduncAlma.BaslangicTarihi,OduncAlma.BitisTarihi,OduncAlma.TeslimTarihi,OduncAlma.Durum,KS2.KullaniciAdi AS 'TeslimAlanKisi' FROM  OduncAlma JOIN Kitaplar ON Kitaplar.KitapId = OduncAlma.KitapId JOIN KullaniciSistem KS1 ON KS1.KullaniciId = OduncAlma.KullaniciId LEFT JOIN KullaniciSistem KS2 ON KS2.KullaniciId = OduncAlma.TeslimAlanId";
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

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            string ara = txtara.Text;
            bool Visible = false;
            if (ara.All(char.IsDigit))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Visible &= row.Cells["IslemId"].Value.ToString().Contains(ara);
                    if (row != dataGridView1.CurrentRow)
                    {
                        row.Visible = Visible;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Visible &= row.Cells["OkuyaninAdi"].Value.ToString().Contains(ara)
                            || row.Cells["Kitabinadi"].Value.ToString().Contains(ara)
                            || row.Cells["TeslimAlaninAdi"].Value.ToString().Contains(ara);
                    if (row != dataGridView1.CurrentRow)
                    {
                        row.Visible = Visible;
                    }
                }

            }
        }

        private void btnokumalistesi_MouseEnter(object sender, EventArgs e)
        {
            btnokumalistesi.ForeColor = Color.Red;
            btnokumalistesi.IconColor = Color.Red;
        }

        private void btnokumalistesi_MouseLeave(object sender, EventArgs e)
        {
            btnokumalistesi.ForeColor = Color.Gainsboro;
            btnokumalistesi.IconColor = Color.Gainsboro;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
