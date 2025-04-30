using Kutuphane.ChildFormsKitap.KategoriYonetim;
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

namespace Kutuphane.ChildFormsKitap.YazarYonetim
{
    public partial class YazarYonetim : Form
    {
        public YazarYonetim()
        {
            InitializeComponent();
        }

        private async void YazarYonetim_Load(object sender, EventArgs e)
        {
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
            await ListeyiDoldur();
        }
        public async Task CloseEdildi()
        {
            panelcocuk.Visible = false;
            await ListeyiDoldur();
        }
        private async Task ListeyiDoldur()
        {
            string query = "SELECT * FROM Yazarlar";
            await DatabaseHelper.DatabaseQueryAsync(query,async cmd=>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int yazarid = reader.GetInt32(0);
                        string yazaradi = reader.GetString(1);
                        string yazarsoyadi = reader.GetString(2);
                        dataGridView1.Rows.Add(yazarid, yazaradi,yazarsoyadi);
                    }
                }
            });
        }

        private void yazarislemleri_MouseEnter(object sender, EventArgs e)
        {
            yazarislemleri.ForeColor = Color.Red;
            yazarislemleri.IconColor = Color.Red;   
        }

        private void yazarislemleri_MouseLeave(object sender, EventArgs e)
        {
            yazarislemleri.ForeColor = Color.Gainsboro;
            yazarislemleri.IconColor = Color.Gainsboro;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbig_Click(object sender, EventArgs e)
        {

        }

        private void btnhide_Click(object sender, EventArgs e)
        {

        }

        private void btnfiltrele_Click(object sender, EventArgs e)
        {

        }

        private void btnara_Click(object sender, EventArgs e)
        {
            panelara.Visible = !panelara.Visible;
        }

        private void txtarama_TextChanged(object sender, EventArgs e)
        {
            if (txtarama.Text.All(char.IsDigit))
            {
                string aranan = txtarama.Text.TrimStart().TrimEnd();
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
                string aranan = txtarama.Text.TrimStart().TrimEnd();
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
