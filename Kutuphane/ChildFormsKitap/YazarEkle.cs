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
    public partial class YazarEkle : Form
    {
        public YazarEkle()
        {
            InitializeComponent();
        }

        private async void YazarEkle_Load(object sender, EventArgs e)
        {
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btnclose.BringToFront();
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            btngizle.BringToFront();
            await ListeyiDoldur();
        }
        private async Task ListeyiDoldur()
        {
            lboxyazarekle.Items.Clear();
            string query = "SELECT YazarAdi,YazarSoyadi FROM Yazarlar";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string yazaradi = reader["YazarAdi"].ToString();
                        string yazarsoyadi = reader["YazarSoyadi"].ToString();
                        lboxyazarekle.Items.Add(yazaradi + " " + yazarsoyadi);
                    }
                }
            });
        }

        private async void btnyazarekle_Click(object sender, EventArgs e)
        {
            string yazaradi = txtyazaradi.Text;
            string yazarsoyadi = txtyazarsoyadi.Text;
            if (string.IsNullOrEmpty(yazaradi) || string.IsNullOrEmpty(yazarsoyadi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }
            else
            {
                bool yazarVarMi = false;    
                for (int i = 0; i < lboxyazarekle.Items.Count; i++)
                {
                    if (lboxyazarekle.Items[i].ToString() == yazaradi+" "+yazarsoyadi)
                    {
                        yazarVarMi = true;
                        break;
                    }
                }
                if (yazarVarMi)
                {
                    lblinfo.Text = "Bu yazar zaten mevcut";
                }
                else
                {
                    await DatabaseHelper.DatabaseQueryAsync("INSERT INTO Yazarlar (YazarAdi, YazarSoyadi) VALUES (@yazaradi, @yazarsoyadi)", async cmd =>
                    {
                        cmd.Parameters.AddWithValue("@yazaradi", yazaradi);
                        cmd.Parameters.AddWithValue("@yazarsoyadi", yazarsoyadi);
                        await cmd.ExecuteNonQueryAsync();
                    });
                    lblinfo.Text = $"Yazar sisteme başarıyla eklendi.";
                }
            }
            await ListeyiDoldur();
            lblinfo.Visible = true;
        }

        private async void btngizle_Click(object sender, EventArgs e)
        {
            await GizleHelper.HideButtonAnimation(sender, e, btngizle, this);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            timerclose.Start();
        }

        private async void timerclose_Tick(object sender, EventArgs e)
        {
            await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this, false);
        }
    }
}
