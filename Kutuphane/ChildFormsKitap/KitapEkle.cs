using Bogus;
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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
     // bool onkapaktetiklendi = false;
     // bool arkakapaktetiklendi = false;
        string kitapKodu = null;
        string oncekiKitapAdi = null;
        private void btnclose_Click(object sender, EventArgs e)
        {

        }

        private void btnonkapak_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //onkapaktetiklendi = true;
                KodOlustur();
            }
        }

        private void btnarkakapak_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //arkakapaktetiklendi = true;
                KodOlustur();
            }
        }
        private void KodOlustur()
        {
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
        private void btnkitabiekle_Click(object sender, EventArgs e)
        {
            string kitapadi = txtkitapadi.Text;
            string yazaradi = cbyazaradi.Text;
            string sayfasayisi = txtsayfasayisi.Text;
            string ciltno = txtciltno.Text;
            int stoksayisi = Convert.ToInt32(txtstoksayisi.Text);
            //string onkapakurl, arkakapakurl;
            string kategori = cbkategori.Text;
        }
    }
}
