using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.Utils;

namespace Kutuphane.ChildFormsKitap
{
    public partial class KategoriSilDuzenle : Form
    {
        public KategoriSilDuzenle()
        {
            InitializeComponent();
        }
        string eskiadi;
        bool degisiklikkaydedildi;
        private async void KategoriSilDuzenle_Load(object sender, EventArgs e)
        {
            btnclose.BringToFront();
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            await ListeyiDoldur();
        }

        private void lboxkategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKategoriadi.Text = lboxkategori.SelectedItem.ToString();
            eskiadi = lboxkategori.SelectedItem.ToString();
            if (degisiklikkaydedildi)
            {
                degisiklikkaydedildi = false;
            }
        }

        private async void btndegistir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKategoriadi.Text))
            {
                MessageBox.Show("Lütfen bir kategori adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (chkKategoriadi.Checked && eskiadi != txtKategoriadi.Text)
                {
                    string query = "UPDATE Kategoriler SET KategoriAdi = @kategoriadi WHERE KategoriAdi = @eskiadi";
                    await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                    {
                        cmd.Parameters.AddWithValue("@kategoriadi", txtKategoriadi.Text);
                        cmd.Parameters.AddWithValue("@eskiadi", eskiadi);
                        await cmd.ExecuteNonQueryAsync();
                    });
                    degisiklikkaydedildi = true;
                    await ListeyiDoldur();
                }
                else
                {
                    if (chkKategoriadi.Checked)
                    {
                        MessageBox.Show("Eski Ad Yenisiyle aynı olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen işlemi tamamlamak için işlemi doğrulayın(check)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private async void btnsil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKategoriadi.Text))
            {
                MessageBox.Show("Lütfen bir kategori adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "DELETE FROM Kategoriler WHERE KategoriAdi = @kategoriadi";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@kategoriadi", txtKategoriadi.Text);
                    await cmd.ExecuteNonQueryAsync();
                });
                degisiklikkaydedildi = true;
                MessageBox.Show("Silme işlemi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ListeyiDoldur();
            }
        }
        private async Task ListeyiDoldur()
        {
            lboxkategori.Items.Clear();
            string query = "SELECT KategoriAdi FROM Kategoriler";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string kategoriadi = reader["KategoriAdi"].ToString();
                        lboxkategori.Items.Add(kategoriadi);
                    }
                }
            });
        }
        private void chkKategoriadi_CheckedChanged(object sender, EventArgs e)
        {
            txtKategoriadi.ReadOnly = !chkKategoriadi.Checked;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            timerclose.Start();
        }

        private async void timerclose_Tick(object sender, EventArgs e)
        {
            if (!degisiklikkaydedildi)
            {
                await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this,false);
            }
            else
            {
                await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this, true);
            }
        }

        private async void btngizle_Click(object sender, EventArgs e)
        {
            await GizleHelper.HideButtonAnimation(sender, e, btngizle, this);
        }

        private void txtKategoriadi_TextChanged(object sender, EventArgs e)
        {
            degisiklikkaydedildi = false;
        }
    }
}
