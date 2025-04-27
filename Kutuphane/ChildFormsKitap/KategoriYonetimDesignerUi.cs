using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.ChildFormsKitap.KategoriYonetim;

namespace Kutuphane.ChildFormsKitap
{
    public partial class KategoriYonetimDesignerUi : Form
    {
        public KategoriYonetimDesignerUi()
        {
            InitializeComponent();
        }

        private void btnfiltrele_Click(object sender, EventArgs e)
        {
            panelfiltre.Visible = !panelfiltre.Visible;
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            panelara.Visible =!panelara.Visible;
        }

        private void btnarat_Click(object sender, EventArgs e)
        {
            string aranan = txtara.Text.TrimStart().TrimEnd();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["kategoriadi"].Value.ToString().ToUpper().Contains(aranan))
                {
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    break;
                }
            }
        }

        private async void KategoriYonetimDesignerUi_Load(object sender, EventArgs e)
        {
            await ListeyiDoldur();
        }
        private async Task ListeyiDoldur()
        {
            dataGridView1.Rows.Clear();
            string query= "SELECT * FROM Kategoriler";
            await DatabaseHelper.DatabaseQueryAsync(query,async cmd=>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int kategoriId = reader.GetInt32(0);
                        string kategoriAdi = reader.GetString(1);
                        dataGridView1.Rows.Add(kategoriId, kategoriAdi);
                    }
                }
            });
        }

        private void kategoriislemleri_MouseEnter(object sender, EventArgs e)
        {
            kategoriislemleri.ForeColor = Color.Red;
            kategoriislemleri.IconColor = Color.Red;
        }

        private void kategoriislemleri_MouseLeave(object sender, EventArgs e)
        {
            kategoriislemleri.ForeColor = Color.Gainsboro;
            kategoriislemleri.IconColor = Color.Gainsboro;
        }

        private void btnkategoriekle_Click(object sender, EventArgs e)
        {
            KategoriLayoutDesignerUi kategoriLayoutDesignerUi = new KategoriLayoutDesignerUi();
            kategoriLayoutDesignerUi.gonderilenistek = "Ekle";
            kategoriLayoutDesignerUi.ShowDialog();
        }

        private void btnkategorisilduzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                KategoriLayoutDesignerUi kategoriLayoutDesignerUi = new KategoriLayoutDesignerUi();
                kategoriLayoutDesignerUi.kategoriadi = dataGridView1.SelectedRows[0].Cells["kategoriadi"].Value.ToString();
                kategoriLayoutDesignerUi.gonderilenistek = "Sil&Düzenle";
                kategoriLayoutDesignerUi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
