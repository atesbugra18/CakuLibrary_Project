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
using System.Windows.Forms.Automation;

namespace Kutuphane.ChildFormsKitap.YazarYonetim
{
    public partial class YazarYonetimLayout : UserControl
    {
        public YazarYonetimLayout()
        {
            InitializeComponent();
        }
        public string yazaradi { get; set; }
        public string yazarsoyadi { get; set; }
        public string gonderilenistek { get; set; }
        List<string> yazarlar = new List<string>();
        string aktifbaglanti;
        #region Genel
        private void btniptal_Click(object sender, EventArgs e)
        {
            btnclose_Click(sender, e);
        }

        private async void YazarYonetimLayout_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            if (gonderilenistek == "Sil&Düzenle")
            {
                lbldurum.Text = "Kategoriyi Sil Ya Da Düzenle";
                txtyazaryeniad.Text = yazaradi;
                txtyazarsoyadiyeni.Text = yazarsoyadi;
                panelsilduzenle.Visible = true;
            }
            else if (gonderilenistek == "Ekle")
            {
                lbldurum.Text = "Yeni Kategori Ekle";
                panelekle.Visible = true;
                panelsilduzenle.Visible = false;
            }
            await MevcutYazarlarıGetir();
        }
        private async Task MevcutYazarlarıGetir()
        {
            string query = "SELECT YazarAdi,YazarSoyadi from Yazarlar";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        string yazaradi = reader.GetString(1).ToString();
                        string yazarsoyadi = reader.GetString(2).ToString();
                        yazarlar.Add($"{yazaradi} {yazarsoyadi}");
                    }
                }
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Form parentForm = this.FindForm();
                if (parentForm is YazarYonetimi mainForm)
                {
                    _ = mainForm.CloseEdildi();
                }
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
                this.Dispose();
            }
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
        #endregion
        #region Ekle
        private void btnyazarekle_Click(object sender, EventArgs e)
        {
            string Yazaradi = txtyazaradi.Text.TrimStart().TrimEnd().ToUpper();
            string Yazarsoyadi = txtyazarsoyadi.Text.TrimStart().TrimEnd().ToUpper();
            if (string.IsNullOrEmpty(Yazaradi) && string.IsNullOrEmpty(Yazarsoyadi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }
            else
            {
                if (yazarlar.Contains($"{Yazaradi} {Yazarsoyadi}"))
                {
                    MessageBox.Show("Bu yazar zaten mevcut.");
                    return;
                }
                else
                {
                    string query = "INSERT INTO Yazarlar (YazarAdi, YazarSoyadi) VALUES (@yazaradi, @yazarsoyadi)";
                    using (SqlConnection con=new SqlConnection(aktifbaglanti))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@yazaradi", Yazaradi);
                            cmd.Parameters.AddWithValue("@yazarsoyadi", Yazarsoyadi);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"{Yazaradi} {Yazarsoyadi} adlı yazar sisteme eklendi", "Başarılı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Bu yazar mevcut değil, ekleniyor...");
                }
            }
        }
        #endregion
        #region Sil&Düzenle
        private async void btnsil_Click(object sender, EventArgs e)
        {
            string Yazaradi = txtyazaryeniad.Text.TrimStart().TrimEnd().ToUpper();
            string Yazarsoyadi = txtyazarsoyadiyeni.Text.TrimStart().TrimEnd().ToUpper();
            if (string.IsNullOrEmpty(Yazaradi) && string.IsNullOrEmpty(Yazarsoyadi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }
            else if (Yazaradi == yazaradi || Yazarsoyadi == yazarsoyadi)
            {
                string query = "DELETE FROM Yazarlar WHERE YazarAdi = @yazaradi AND YazarSoyadi = @yazarsoyadi";
                using (SqlConnection con=new SqlConnection(aktifbaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd=new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@yazaradi", Yazaradi);
                        cmd.Parameters.AddWithValue("@yazarsoyadi", Yazarsoyadi);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Yazar sistemden silindi.", "Başarılı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Yazar Bilgileri Değiştirildikten Sonra Silme İşlemi Yapılamaz.");
            }
        }

        private async void btndegistir_Click(object sender, EventArgs e)
        {
            string Yazaradi = txtyazaryeniad.Text.TrimStart().TrimEnd().ToUpper();
            string Yazarsoyadi = txtyazarsoyadiyeni.Text.TrimStart().TrimEnd().ToUpper();
            if (string.IsNullOrEmpty(Yazaradi) && string.IsNullOrEmpty(Yazarsoyadi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }
            else if (Yazaradi != yazaradi || Yazarsoyadi != yazarsoyadi)
            {
                string query = "UPDATE Yazarlar SET YazarAdi = @yazaradi, YazarSoyadi = @yazarsoyadi WHERE YazarAdi = @eskiYazaradi AND YazarSoyadi = @eskiYazarsoyadi";
                using (SqlConnection con=new SqlConnection(aktifbaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd=new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@yazaradi",Yazaradi);
                        cmd.Parameters.AddWithValue("@yazarsoyadi",Yazarsoyadi);
                        cmd.Parameters.AddWithValue("@eskiYazaradi", yazaradi);
                        cmd.Parameters.AddWithValue("@eskiYazarsoyadi", yazarsoyadi);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Yazar Bilgileri Değiştirildi.");
            }
            else
            {
                MessageBox.Show("Hiç bir değişiklik yapılmamış");
            }
        }
        #endregion
    }
}
