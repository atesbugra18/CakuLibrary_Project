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

namespace Kutuphane.ChildFormsKitap.KategoriYonetim
{
    public partial class KategoriYonetimiLayout : UserControl
    {
        public KategoriYonetimiLayout()
        {
            InitializeComponent();
        }
        public string kategoriadi { get; set; }
        public string gonderilenistek { get; set; }

        private void KategoriLayoutDesignerUi_Load(object sender, EventArgs e)
        {
            if (gonderilenistek == "Sil&Düzenle")
            {
                lbldurum.Text = "Kategoriyi Sil Ya Da Düzenle";
                txtyeniad.Text = kategoriadi;
                panelsilduzenle.Visible = true;
            }
            else if (gonderilenistek == "Ekle")
            {
                lbldurum.Text = "Yeni Kategori Ekle";
                panelkategoriekle.Visible = true;
            }
        }
        #region Genel
        private void btnKategori_MouseEnter(object sender, EventArgs e)
        {
            btnKategori.ForeColor = Color.Red;
            btnKategori.IconColor = Color.Red;
        }

        private void btnKategori_MouseLeave(object sender, EventArgs e)
        {
            btnKategori.ForeColor = Color.Gainsboro;
            btnKategori.IconColor = Color.Gainsboro;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Form parentForm = this.FindForm();
                if (parentForm is KategoriYonetimDesignerUi mainForm)
                {
                    mainForm.CloseEdildi();
                }
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
                this.Dispose();
            }
        }
        private void btniptal_Click(object sender, EventArgs e)
        {
            btnclose_Click(sender, e);
        }
        #endregion
        #region Kategori Ekle
        private async void btnekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtkategoriadi.Text))
            {
                MessageBox.Show("Lütfen Öncelikle Kategori Adını Girin.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtkategoriadi.Focus();
                return;
            }
            else
            {
                string kategoriadi = txtkategoriadi.Text.ToUpper().TrimStart().TrimEnd();
                List<string> kategoriListesi = new List<string>();
                string query = "SELECT kategoriadi FROM Kategoriler";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            kategoriListesi.Add(reader.GetString(0));
                        }
                    }
                });
                if (!kategoriListesi.Contains(kategoriadi))
                {
                    string query2 = "INSERT INTO Kategoriler (kategoriadi) VALUES (@kategoriadi)";
                    await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
                    {
                        cmd.Parameters.AddWithValue("@kategoriadi", kategoriadi);
                        await cmd.ExecuteNonQueryAsync();
                    });
                }
                else
                {
                    MessageBox.Show($"{kategoriadi} adlı kategori hali hazırda sistemde kayıtlıdır.", "Hatalı İstek", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
        #region Kategori Sil Ve Düzenle
        private async void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"{kategoriadi} adlı kategoriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                string query = "DELETE FROM Kategoriler WHERE kategoriadi=@kategoriadi";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kategoriadi", kategoriadi);
                    await cmd.ExecuteNonQueryAsync();
                });
            }
            else
            {
                DialogResult result = MessageBox.Show("Silme işlemi iptal edildi. Çıkmak İster Misiniz?", "İşlem İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Form parentForm = this.FindForm();
                    if (parentForm is KategoriYonetimDesignerUi mainForm)
                    {
                        mainForm.CloseEdildi();
                    }
                    if (this.Parent != null)
                    {
                        this.Parent.Controls.Remove(this);
                    }
                    this.Dispose();

                }
            }
        }

        private async void btndegistir_Click(object sender, EventArgs e)
        {
            if (kategoriadi != txtyeniad.Text)
            {
                string query = "UPDATE Kategoriler SET kategoriadi=@yeniad WHERE kategoriadi=@eskiad";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@yeniad", txtyeniad.Text.ToUpper().TrimStart().TrimEnd());
                    cmd.Parameters.AddWithValue("@eskiad", kategoriadi);
                    await cmd.ExecuteNonQueryAsync();
                });
                MessageBox.Show("Kategori Adı Başarıyla Güncellendi.", "Başarılı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form parentForm = this.FindForm();
                if (parentForm is KategoriYonetimDesignerUi mainForm)
                {
                    mainForm.CloseEdildi();
                }
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
                this.Dispose();
            }
        }
        #endregion
    }
}
