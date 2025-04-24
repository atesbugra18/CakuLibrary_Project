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
    public partial class MevcutKitaplariListele : Form
    {
        public MevcutKitaplariListele()
        {
            InitializeComponent();
        }
        string txt = "Görüntülenen Kitap Sayısı: ";
        private async void MevcutKitaplariListele_Load(object sender, EventArgs e)
        {
            btnclose.BringToFront();
            btngizle.BringToFront();
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            await TabloyaVeriyiCek();
            lblsayisi.Text = txt+tablo.Rows.Count.ToString();
        }
        private async Task TabloyaVeriyiCek()
        {
            string query = "SELECT K.KitapAdi AS 'kitapadi', Y.YazarAdi + ' ' + Y.YazarSoyadi AS 'yazaradisoyadi', Kat.KategoriAdi AS 'kategoriadi',  K.SayfaSayisi AS 'sayfasayisi',  K.CiltNo AS 'ciltno' from Kitaplar K join yazarlar y on k.yazarıd = y.yazarıd join kategoriler kat on K.kategoriıd=kat.kategoriıd";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    tablo.DataSource = dt;
                }
            });
        }

        private async void timerclose_Tick(object sender, EventArgs e)
        {
            await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this, false);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            timerclose.Start();
        }

        private async void btngizle_Click(object sender, EventArgs e)
        {
            await GizleHelper.HideButtonAnimation(sender, e, btngizle, this);
        }
    }
}
