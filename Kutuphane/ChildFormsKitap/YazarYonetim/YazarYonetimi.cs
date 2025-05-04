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

namespace Kutuphane.ChildFormsKitap.YazarYonetim
{
    public partial class YazarYonetimi : Form
    {
        public YazarYonetimi()
        {
            InitializeComponent();
        }
        string aktifbaglanti;
        private void YazarYonetimi_Load(object sender, EventArgs e)
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
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void ListeyiDoldur()
        {
            string query = "SELECT * FROM Yazarlar";
            using (SqlConnection con=new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand(query,con))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            if (txtara.Text.All(char.IsDigit))
            {
                string aranan = txtara.Text.TrimStart().TrimEnd();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["yazarid"].Value.ToString().Contains(aranan))
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
                    if (row.Cells["yazaradi"].Value.ToString().ToUpper().Contains(aranan.ToUpper()) || row.Cells["yazarsoyadi"].Value.ToString().ToUpper().Contains(aranan.ToUpper()))
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

        private void btnyazarekle_Click(object sender, EventArgs e)
        {
            panelcocuk.BringToFront();
            panelkontroller.SendToBack();
            panelcocuk.Dock= DockStyle.Fill;
            panelcocuk.Visible = true;
            YazarYonetimLayout Control = new YazarYonetimLayout();
            Control.gonderilenistek = "Ekle";
            Control.Dock = DockStyle.Fill;
            panelcocuk.Controls.Add(Control);
            Control.BringToFront();
        }

        private void btnyazarsilduzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                panelcocuk.BringToFront();
                panelkontroller.SendToBack();
                panelcocuk.Dock = DockStyle.Fill;
                panelcocuk.Visible=true;
                YazarYonetimLayout Control = new YazarYonetimLayout();
                Control.gonderilenistek = "Sil&Düzenle";
                Control.yazaradi = dataGridView1.SelectedRows[0].Cells["yazaradi"].Value.ToString();
                Control.yazarsoyadi = dataGridView1.SelectedRows[0].Cells["yazarsoyadi"].Value.ToString();
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
