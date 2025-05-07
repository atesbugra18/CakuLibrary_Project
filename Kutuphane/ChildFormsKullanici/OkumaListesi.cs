using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsKullanici
{
    public partial class OkumaListesi : Form
    {
        public OkumaListesi()
        {
            InitializeComponent();
        }

        private void OkumaListesi_Load(object sender, EventArgs e)
        {

        }
        //query="select OduncAlma.IslemId,KullaniciSistem.KullaniciAdi as 'Okuyanın Adı',Kitaplar.KitapAdi,OduncAlma.BaslangicTarihi,OduncAlma.BitisTarihi,OduncAlma.TeslimTarihi,OduncAlma.Durum,KullaniciSistem.KullaniciAdi as 'Teslim Alan Kişi'
        //from KullaniciSistem, Kitaplar, OduncAlma where Kitaplar.KitapId=OduncAlma.KitapId and KullaniciSistem.KullaniciId= OduncAlma.KullaniciId and KullaniciSistem.KullaniciId= OduncAlma.TeslimAlanId"
    }
}
