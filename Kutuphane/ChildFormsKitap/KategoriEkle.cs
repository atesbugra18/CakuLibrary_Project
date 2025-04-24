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
    public partial class KategoriEkle : Form
    {
        public KategoriEkle()
        {
            InitializeComponent();
        }
        bool degisiklikkaydedildi;
        private async void btngizle_Click(object sender, EventArgs e)
        {
            await GizleHelper.HideButtonAnimation(sender, e, btngizle, this);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            timerclose.Start();
        }

        private async void btnkategoriekle_Click(object sender, EventArgs e)
        {
            string kategoriadi = txtkategoriadi.Text;
            if (string.IsNullOrEmpty(kategoriadi))
            {
                MessageBox.Show("Lütfen bir kategori adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool varmi = false;
                int sırası = 0;
                foreach (var item in lboxkategori.Items)
                {
                    sırası++;
                    if (item.ToString() == kategoriadi)
                    {
                        varmi = true;
                        MessageBox.Show($"{kategoriadi} adlı kategori sistemde hali hazırda bulunmaktadır.{sırası+1} sıradadır.","Hatalı İşlem",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        lblinfo.Text = "Bu Kategori Zaten Var";
                        lblinfo.Visible = true;
                        break;
                    }
                }
                if (!varmi)
                {
                    string query = "INSERT INTO Kategoriler (KategoriAdi) VALUES (@kategoriadi)";
                    await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
                    {
                        cmd.Parameters.AddWithValue("@kategoriadi", kategoriadi);
                        await cmd.ExecuteNonQueryAsync();
                    });
                    MessageBox.Show($"{kategoriadi} adlı kategori başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblinfo.Text = $"{kategoriadi} Sisteme Eklendi";
                    lblinfo.Visible = true;
                    degisiklikkaydedildi = true;
                    await listeyidoldur();
                }
            }
        }
        private async Task listeyidoldur()
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
        private void txtkategoriadi_TextChanged(object sender, EventArgs e)
        {
            degisiklikkaydedildi = false;
        }

        private async void KategoriEkle_Load(object sender, EventArgs e)
        {
            btnclose.BringToFront();
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            await listeyidoldur();
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
    }
}
