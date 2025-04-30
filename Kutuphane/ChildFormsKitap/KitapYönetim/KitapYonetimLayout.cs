using Kutuphane.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsKitap.KitapYönetim
{
    public partial class KitapYonetimLayout : UserControl
    {
        public KitapYonetimLayout()
        {
            InitializeComponent();
        }
        #region Genel Yönetim
        public string gonderilenistek { get; set; }
        public string kitapadi { get; set; } 
        public string yazaradisoyadi { get; set; }
        public string kategorisi { get; set; }
        public string sayfasayisi { get; set; }
        public string stoksayisi { get; set; }
        public string ciltnosu { get; set; }
        List<string> kitaplar = new List<string>();
        bool onkapakdegistirildi = false;
        bool arkakapakdegistirildi = false;
        private async void KitapYonetimLayout_Load(object sender, EventArgs e)
        {
            await KategorileriGetir();
            await YazarlarıGetir();
            await KitaplariGetir();
            if (gonderilenistek=="Ekle")
            {
                panelsilduzenle.Visible = false;
                piconekle.BackgroundImage = Image.FromFile("Images\\kitaponsayfa.png");
                picarkaekle.BackgroundImage = Image.FromFile("Images\\kitaparkasayfa.png");
                lbldurum.Text = "Kitap Ekle";
            }
            else
            {
                lbldurum.Text = "Kitap Sil/Düzenle";
                panelekle.Visible = false;
                txtkitapadisil.Text = kitapadi;
                txtsayfasil.Text = sayfasayisi;
                txtciltsil.Text = ciltnosu;
                txtstoksil.Text = stoksayisi;
                int yazar=cyazarsil.Items.IndexOf(yazaradisoyadi);
                int kategori=ckategorisil.Items.IndexOf(kategorisi);
                cyazarsil.SelectedIndex = yazar;
                ckategorisil.SelectedIndex = kategori;
            }
        }
        private async Task KitaplariGetir()
        {

            string query = "SELECT Kitaplar.KitapId,Kitaplar.KitapAdi,Yazarlar.YazarAdi+' '+Yazarlar.YazarSoyadi as 'YazarAdiSoyadi',Kategoriler.KategoriAdi,Kitaplar.SayfaSayisi,KitapStoklari.StokSayisi from Kitaplar,Yazarlar,Kategoriler,KitapStoklari where Kitaplar.YazarId=Yazarlar.YazarId and Kitaplar.KategoriId=Kategoriler.KategoriId and Kitaplar.KitapId=KitapStoklari.KitapId";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int kitapid = reader.GetInt32(0);
                        string kitapadi = reader.GetString(1);
                        string yazari = reader.GetString(2);
                        string kategorisi = reader.GetString(3);
                        int sayfasayisi = reader.GetInt32(4);
                        int stoksayisi = reader.GetInt32(5);
                        string kitapbilgileri = $"{kitapid}+{kitapadi}+{yazari}+{kategorisi}+{sayfasayisi}+{stoksayisi}";
                        kitaplar.Add(kitapbilgileri);
                    }
                }
            });
        }
        private async Task KategorileriGetir()
        {
            string query = "SELECT KategoriId,KategoriAdi from Kategoriler";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int kategoriid = reader.GetInt32(0);
                        string kategoriadi = reader.GetString(1);
                        ckategoriadiekle.Items.Add(kategoriadi);
                        ckategorisil.Items.Add(kategoriadi);
                    }
                }
            });
        }
        private async Task YazarlarıGetir()
        {
            string query = "SELECT YazarId,YazarAdi+' '+YazarSoyadi as 'YazarAdiSoyadi' from Yazarlar";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int yazarid = reader.GetInt32(0);
                        string yazaradisoyadi = reader.GetString(1);
                        cyazaradisoyadi.Items.Add(yazaradisoyadi);
                        cyazarsil.Items.Add(yazaradisoyadi);
                    }
                }
            });
        }
        #endregion

        #region Ekle
        private void btnyazarekle_Click(object sender, EventArgs e)
        {
            string kitapadi = txtkitapadi.Text;
            string yazaradi = cyazaradisoyadi.SelectedItem.ToString();
            string kategoriadi = ckategoriadiekle.SelectedItem.ToString();
            string sayfasayisi = txtsayfasayisiekle.Text;
            string stoksayisi = txtstoksayisiekle.Text;
            string ciltnosu = txtciltnoekle.Text;
            string kitapbilgileri = $"{kitapadi}+{yazaradi}+{kategoriadi}+{sayfasayisi}+{stoksayisi}+{ciltnosu}";
            if (!kitaplar.Contains(kitapbilgileri))
            {
                string query;
                if (onkapakdegistirildi&&arkakapakdegistirildi)
                {
                   query = "INSERT INTO Kitaplar (KitapAdi,YazarId,KategoriId,SayfaSayisi,ciltno,Onkapakurl,Arkakapakurl) VALUES (@kitapadi,@yazarid,@kategoriid,@sayfasayisi,@ciltno,@onkapakurl,@arkakapakurl)";
                }
                else if (onkapakdegistirildi)
                {
                    query = "INSERT INTO Kitaplar (KitapAdi,YazarId,KategoriId,SayfaSayisi,ciltno,Onkapakurl) VALUES (@kitapadi,@yazarid,@kategoriid,@sayfasayisi,@ciltno,@onkapakurl)";
                }
                else if (arkakapakdegistirildi)
                {
                    query = "INSERT INTO Kitaplar (KitapAdi,YazarId,KategoriId,SayfaSayisi,ciltno,Arkakapakurl) VALUES (@kitapadi,@yazarid,@kategoriid,@sayfasayisi,@ciltno,@arkakapakurl)";
                }
                else
                {
                    query = "INSERT INTO Kitaplar (KitapAdi,YazarId,KategoriId,SayfaSayisi,Ciltno) values (@kitapadi,@yazarid,@kategoriid,@sayfasayisi,@ciltno,@arkaplanurl)";
                }
            }
        }
        private void btnonkapakekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                piconekle.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                onkapakdegistirildi = true;
            }
        }

        private void btnarkakapakekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picarkaekle.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                arkakapakdegistirildi = true;
            }
        }
        #endregion

    }
}
