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
    public partial class KitapSilGuncelle : Form
    {
        public KitapSilGuncelle()
        {
            InitializeComponent();
        }

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

        }
    }
}
