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
    public partial class KategorileriListele : Form
    {
        public KategorileriListele()
        {
            InitializeComponent();
        }

        private async void KategorileriListele_Load(object sender, EventArgs e)
        {
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            btnclose.BringToFront();
            btngizle.BringToFront();
            await listeyidoldur();
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            timerclose.Start();
        }

        private async void timerclose_Tick(object sender, EventArgs e)
        {
            //// // await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this, false);
        }

        private async void btngizle_Click(object sender, EventArgs e)
        {
            //// // await CloseHelper.HideButtonAnimation(sender, e, btngizle, this);
        }
    }
}
