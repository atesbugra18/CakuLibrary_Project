using Bogus;
using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsKitap
{
    public partial class KitapSilGuncelle : Form
    {
        public KitapSilGuncelle()
        {
            InitializeComponent();
        }
        bool onkapaktetiklendi = false;
        bool arkakapaktetiklendi = false;
        string kitapKodu;
        string oncekiKitapAdi = null;
        bool degisiklikkaydedildi = false;
        private async void KitapSilGuncelle_Load(object sender, EventArgs e)
        {
            btnclose.BringToFront();
            btngizle.BringToFront();
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            await ListeyiDoldur();
        }
        private async Task ListeyiDoldur()
        {
            string query = "Select KitapAdi from Kitaplar";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    string kitapadi = reader["KitapAdi"].ToString();
                    lboxkitaplar.Items.Add(kitapadi);
                }
            });
        }

        private async void lboxkitaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = @"SELECT k.KitapAdi,y.YazarAdi + ' ' + y.YazarSoyadi AS YazarAdSoyad,k.SayfaSayisi,k.CiltNo,k.OnkapakUrl,k.ArkaKapakUrl,kat.KategoriAdi FROM Kitaplar k JOIN Yazarlar y ON k.YazarId = y.YazarId JOIN Kategoriler kat ON k.KategoriId = kat.KategoriId";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    string kitapadi = reader["KitapAdi"].ToString();
                    string Yazaradi = reader["YazarAdSoyad"].ToString();
                    string sayfasayisi = reader["SayfaSayisi"].ToString();
                    string ciltno = reader["CiltNo"].ToString();
                    string onkapakurl = reader["OnkapakUrl"].ToString();
                    string arkapakurl = reader["ArkaKapakUrl"].ToString();
                    string kategoriadi = reader["KategoriAdi"].ToString();
                    txtkitapadi.Text = kitapadi;
                    for (int i = 0; i < cbyazaradi.Items.Count; i++)
                    {
                        if (cbyazaradi.Items[i].ToString() == Yazaradi)
                        {
                            cbyazaradi.SelectedIndex = i;
                            break;
                        }
                    }
                    for (int i = 0; i < cbkategori.Items.Count; i++)
                    {
                        if (cbkategori.Items[i].ToString() == kategoriadi)
                        {
                            cbkategori.SelectedIndex = i;
                            break;
                        }
                    }
                    txtsayfasayisi.Text = sayfasayisi;
                    txtciltno.Text = ciltno;
                    await ResimleriCek(onkapakurl,arkapakurl);
                }
            });
        }
        private async Task ResimleriCek(string onurl,string arkaurl)
        {
            string onkapakurl = "https://drive.google.com/uc?id=" + onurl;
            string arkapakurl = "https://drive.google.com/uc?id=" + arkaurl;
            try
            {
                using (var client = new HttpClient())
                {
                    var onkapakResponse = await client.GetAsync(onkapakurl);
                    if (onkapakResponse.IsSuccessStatusCode)
                    {
                        var onkapakStream = await onkapakResponse.Content.ReadAsStreamAsync();
                        pictureonkapak.Image = Image.FromStream(onkapakStream);
                    }
                    else
                    {
                        MessageBox.Show("On Kapak Resmi Yüklenemedi.");
                    }
                    var arkapakResponse = await client.GetAsync(arkapakurl);
                    if (arkapakResponse.IsSuccessStatusCode)
                    {
                        var arkapakStream = await arkapakResponse.Content.ReadAsStreamAsync();
                        picturearkakapak.Image = Image.FromStream(arkapakStream);
                    }
                    else
                    {
                        MessageBox.Show("Arka Kapak Resmi Yüklenemedi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yükleme hatası: " + ex.Message);
            }
        }

        private void cboxkitapadi_CheckedChanged(object sender, EventArgs e)
        {
            txtkitapadi.ReadOnly = !cboxkitapadi.Checked;
        }

        private void cboxyazaradi_CheckedChanged(object sender, EventArgs e)
        {
            cbyazaradi.SelectedIndex = -1;
        }

        private void cboxsayfasayisi_CheckedChanged(object sender, EventArgs e)
        {
            txtsayfasayisi.ReadOnly = !cboxsayfasayisi.Checked;
        }

        private void cboxciltno_CheckedChanged(object sender, EventArgs e)
        {
            txtciltno.ReadOnly = !cboxciltno.Checked;
        }

        private void cboxstoksayisi_CheckedChanged(object sender, EventArgs e)
        {
            txtstoksayisi.ReadOnly = !cboxstoksayisi.Checked;
        }

        private void cboxonkapak_CheckedChanged(object sender, EventArgs e)
        {
            btnonkapak.Enabled = cboxonkapak.Checked;
        }

        private void cboxarkakapak_CheckedChanged(object sender, EventArgs e)
        {
            btnonkapak.Enabled = cboxonkapak.Checked;
        }

        private void cboxhangikategori_CheckedChanged(object sender, EventArgs e)
        {
            cbkategori.SelectedIndex = -1;
        }

        private void btnonkapak_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                onkapaktetiklendi = true;
                KodOlustur();
                pictureonkapak.BackgroundImage = Image.FromFile(ofd.FileName);
                pictureonkapak.Visible = true;
            }
        }

        private void btnarkakapak_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                arkakapaktetiklendi = true;
                KodOlustur();
                picturearkakapak.BackgroundImage = Image.FromFile(ofd.FileName);
                picturearkakapak.Visible = true;
            }
        }
        private void KodOlustur()
        {
            degisiklikkaydedildi = false;
            string suankiKitapAdi = txtkitapadi.Text;
            if (kitapKodu != null && suankiKitapAdi == oncekiKitapAdi)
            {
                return;
            }
            else
            {
                Faker faker = new Faker();
                int karakterSayisi = faker.Random.Int(6, 18);
                kitapKodu = faker.Random.AlphaNumeric(karakterSayisi);
                oncekiKitapAdi = suankiKitapAdi;
            }
        }

        private async void btndegistir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Değişiklikleri kaydetmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "UPDATE Kitaplar SET KitapAdi = @kitapadi, YazarId = (SELECT YazarId FROM Yazarlar WHERE YazarAdi + ' ' + YazarSoyadi = @yazaradi), SayfaSayisi = @sayfasayisi, CiltNo = @ciltno, OnkapakUrl = @onkapakurl, ArkaKapakUrl = @arkakapakurl, KategoriId = (SELECT KategoriId FROM Kategoriler WHERE KategoriAdi = @kategoriadi) WHERE KitapAdi = @oncekiKitapadi";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kitapadi", txtkitapadi.Text);
                    cmd.Parameters.AddWithValue("@yazaradi", cbyazaradi.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@sayfasayisi", txtsayfasayisi.Text);
                    cmd.Parameters.AddWithValue("@ciltno", txtciltno.Text);
                    cmd.Parameters.AddWithValue("@onkapakurl", kitapKodu);
                    cmd.Parameters.AddWithValue("@arkakapakurl", kitapKodu);
                    cmd.Parameters.AddWithValue("@kategoriadi", cbkategori.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@oncekiKitapAdi", oncekiKitapAdi);
                    await cmd.ExecuteNonQueryAsync();
                });
                degisiklikkaydedildi = true;
                MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Değişiklikler kaydedilmedi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                string query = "DELETE FROM Kitaplar WHERE KitapAdi = @kitapadi";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kitapadi", txtkitapadi.Text);
                    await cmd.ExecuteNonQueryAsync();
                });
                degisiklikkaydedildi = true;
                MessageBox.Show("Silme işlemi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemi iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
