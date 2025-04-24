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
        public YazarSilDuzenle()
        {
            InitializeComponent();
        }
        string eskiadi;
        bool degisiklikkaydedildi;

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
            string query = "SELECT YazarAdi,YazarSoyadi FROM Yazarlar";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string yazaradi = reader["YazarAdi"].ToString();
                        string yazarsoyadi = reader["YazarSoyadi"].ToString();
                        lboxyazarlar.Items.Add(yazaradi + " " + yazarsoyadi);
                    }
                }
            });
        }

        private async void timerclose_Tick(object sender, EventArgs e)
        {
            if (!degisiklikkaydedildi)
            {
                await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this, false);
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

        private void lboxyazarlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[]yazarbilgileri= lboxyazarlar.SelectedItem.ToString().Split(' ');
            string yazaradi,yazarsoyadi;
            if (yazarbilgileri.Length>2)
            {
                yazaradi = yazarbilgileri[0]+yazarbilgileri[1];
                yazarsoyadi = yazarbilgileri[2];
            }
            else
            {
                yazaradi = yazarbilgileri[0];
                yazarsoyadi = yazarbilgileri[1];
            }
            txtyazaradi.Text = yazaradi;
            txtyazarsoyadi.Text = yazarsoyadi;
            eskiadi = lboxyazarlar.SelectedItem.ToString();
            if (degisiklikkaydedildi)
            {
                degisiklikkaydedildi = false;
            }
        }

        private void chkYazarsoyadi_CheckedChanged(object sender, EventArgs e)
        {
            txtyazarsoyadi.ReadOnly = !chkYazarsoyadi.Checked;
        }

        private void chkYazaradi_CheckedChanged(object sender, EventArgs e)
        {
            txtyazaradi.ReadOnly = !chkYazaradi.Checked;
        }

        private async void btndegistir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtyazaradi.Text))
            {
                MessageBox.Show("Lütfen bir yazar adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (chkYazaradi.Checked && eskiadi != txtyazaradi.Text)
                {
                    string query = "UPDATE Yazarlar SET YazarAdi = @yazaradi WHERE YazarAdi = @eskiadi";
                    await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                    {
                        cmd.Parameters.AddWithValue("@yazaradi", txtyazaradi.Text);
                        cmd.Parameters.AddWithValue("@eskiadi", eskiadi);
                        await cmd.ExecuteNonQueryAsync();
                    });
                    degisiklikkaydedildi = true;
                    await ListeyiDoldur();
                }
                else
                {
                    if (chkYazaradi.Checked)
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
            if (string.IsNullOrEmpty(txtyazaradi.Text))
            {
                MessageBox.Show("Lütfen bir yazar adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "DELETE FROM Yazarlar WHERE YazarAdi = @kategoriadi";
                await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                {
                    cmd.Parameters.AddWithValue("@yazaradi", txtyazaradi.Text);
                    await cmd.ExecuteNonQueryAsync();
                });
                degisiklikkaydedildi = true;
                MessageBox.Show("Silme işlemi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ListeyiDoldur();
            }
        }
        private void txtyazaradi_TextChanged(object sender, EventArgs e)
        {
            degisiklikkaydedildi = false;
        }

        private void txtyazarsoyadi_TextChanged(object sender, EventArgs e)
        {
            degisiklikkaydedildi = false;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            timerclose.Start();
        }
    }
}
