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
    public partial class KategoriYonetimiLayout : UserControl
    {
        public KategoriYonetimiLayout()
        {
            InitializeComponent();
        }
        public string kategoriadi { get; set; }
        public string gonderilenistek { get; set; }
        string aktifbaglanti;
        List<string> kategoriListesi = new List<string>();
        private async void KategoriLayoutDesignerUi_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            DatabaseHelper.GetActiveConnectionString();
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
            await MevcutKategoriler();
        }
        #region Genel
        private async Task MevcutKategoriler()
        {
            string kategoriadi = txtkategoriadi.Text.ToUpper().TrimStart().TrimEnd();
            string query = "SELECT kategoriadi FROM Kategoriler";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            kategoriListesi.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
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
                if (parentForm is KategoriYonetimi mainForm)
                {
                   _= mainForm.CloseEdildi();
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
        private void btnekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtkategoriadi.Text))
            {
                MessageBox.Show("Lütfen Öncelikle Kategori Adını Girin.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtkategoriadi.Focus();
                return;
            }
            else
            {
                string kategoriadiyeni = txtkategoriadi.Text.ToUpper().TrimStart().TrimEnd();
                if (!kategoriListesi.Contains(kategoriadiyeni))
                {
                    string query = "INSERT INTO Kategoriler (kategoriadi) VALUES (@kategoriadi)";
                    using (SqlConnection con=new SqlConnection(aktifbaglanti))
                    {
                        con.Open();
                        using (SqlCommand cmd=new SqlCommand(query,con))
                        {
                            cmd.Parameters.AddWithValue("@kategoriadi", kategoriadiyeni);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"{kategoriadiyeni} adlı Kategori Başarıyla Eklendi.", "Başarılı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"{kategoriadiyeni} adlı kategori hali hazırda sistemde kayıtlıdır.", "Hatalı İstek", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                using (SqlConnection con=new SqlConnection(aktifbaglanti))
                {
                    using (SqlCommand cmd=new SqlCommand(query,con))
                    {
                        await con.OpenAsync();
                        cmd.Parameters.AddWithValue("@kategoriadi",kategoriadi);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Silme işlemi iptal edildi. Çıkmak İster Misiniz?", "İşlem İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Form parentForm = this.FindForm();
                    if (parentForm is KategoriYonetimi mainForm)
                    {
                      _= mainForm.CloseEdildi();
                    }
                    if (this.Parent != null)
                    {
                        this.Parent.Controls.Remove(this);
                    }
                    this.Dispose();

                }
            }
        }

        private void btndegistir_Click(object sender, EventArgs e)
        {
            if (kategoriadi != txtyeniad.Text)
            {
                string query = "UPDATE Kategoriler SET kategoriadi=@yeniad WHERE kategoriadi=@eskiad";
                using (SqlConnection con=new SqlConnection(aktifbaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd=new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@yeniad", txtyeniad.Text.ToUpper().TrimStart().TrimEnd());
                        cmd.Parameters.AddWithValue("@eskiad", kategoriadi);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Kategori Adı Başarıyla Güncellendi.", "Başarılı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form parentForm = this.FindForm();
                if (parentForm is KategoriYonetimi mainForm)
                {
                   _= mainForm.CloseEdildi();
                }
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
                this.Dispose();
            }
        }
        #endregion

        private void btnKategori_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is KategoriYonetimi mainForm)
            {
                _ = mainForm.CloseEdildi();
            }
        }
    }
}