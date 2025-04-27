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

namespace Kutuphane.ChildFormsKitap
{
    public partial class YazarSilDuzenle : Form
    {
        private string eskiAdiSoyadi;
        private bool degisiklikKaydedildi;

        public YazarSilDuzenle()
        {
            InitializeComponent();
        }

        private async void YazarSilDuzenle_Load(object sender, EventArgs e)
        {
            btnclose.BringToFront();
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            await ListeyiDoldur();
        }

        private async Task ListeyiDoldur()
        {
            lboxyazarlar.Items.Clear();
            string query = "SELECT YazarAdi, YazarSoyadi FROM Yazarlar";

            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string yazarAdi = reader["YazarAdi"].ToString();
                        string yazarSoyadi = reader["YazarSoyadi"].ToString();
                        lboxyazarlar.Items.Add($"{yazarAdi} {yazarSoyadi}");
                    }
                }
            });
        }

        private void lboxyazarlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxyazarlar.SelectedItem == null) return;

            string[] yazarBilgileri = lboxyazarlar.SelectedItem.ToString().Split(' ');
            if (yazarBilgileri.Length < 2) return;

            txtyazaradi.Text = yazarBilgileri[0];
            txtyazarsoyadi.Text = string.Join(" ", yazarBilgileri[1]);
            eskiAdiSoyadi = lboxyazarlar.SelectedItem.ToString();
            degisiklikKaydedildi = false;
        }

        private void chkYazaradi_CheckedChanged(object sender, EventArgs e)
        {
            txtyazaradi.ReadOnly = !chkYazaradi.Checked;
        }

        private void chkYazarsoyadi_CheckedChanged(object sender, EventArgs e)
        {
            txtyazarsoyadi.ReadOnly = !chkYazarsoyadi.Checked;
        }

        private async void btndegistir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtyazaradi.Text) || string.IsNullOrEmpty(txtyazarsoyadi.Text))
            {
                MessageBox.Show("Lütfen bir yazar adı ve soyadı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((chkYazaradi.Checked || chkYazarsoyadi.Checked) && eskiAdiSoyadi != $"{txtyazaradi.Text} {txtyazarsoyadi.Text}")
            {
                string query = "UPDATE Yazarlar SET YazarAdi = @yazaradi, YazarSoyadi = @yazarsoyadi WHERE YazarAdi + ' ' + YazarSoyadi = @eskiadi";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@yazaradi", txtyazaradi.Text);
                    cmd.Parameters.AddWithValue("@yazarsoyadi", txtyazarsoyadi.Text);
                    cmd.Parameters.AddWithValue("@eskiadi", eskiAdiSoyadi);
                    await cmd.ExecuteNonQueryAsync();
                });

                degisiklikKaydedildi = true;
                await ListeyiDoldur();
            }
            else
            {
                MessageBox.Show("Eski bilgiler yenisiyle aynı olamaz veya doğrulama yapılmadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnsil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtyazaradi.Text) || string.IsNullOrEmpty(txtyazarsoyadi.Text))
            {
                MessageBox.Show("Lütfen bir yazar adı ve soyadı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "DELETE FROM Yazarlar WHERE YazarAdi + ' ' + YazarSoyadi = @yazaradiSoyadi";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                cmd.Parameters.AddWithValue("@yazaradiSoyadi", $"{txtyazaradi.Text} {txtyazarsoyadi.Text}");
                await cmd.ExecuteNonQueryAsync();
            });

            degisiklikKaydedildi = true;
            MessageBox.Show("Silme işlemi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await ListeyiDoldur();
        }

        private void txtyazaradi_TextChanged(object sender, EventArgs e)
        {
            degisiklikKaydedildi = false;
        }

        private void txtyazarsoyadi_TextChanged(object sender, EventArgs e)
        {
            degisiklikKaydedildi = false;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            timerclose.Start();
        }

        private async void timerclose_Tick(object sender, EventArgs e)
        {
            // await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this, degisiklikKaydedildi);
        }

        private async void btngizle_Click(object sender, EventArgs e)
        {
            // // await CloseHelper.HideButtonAnimation(sender, e, btngizle, this);
        }
    }
}
