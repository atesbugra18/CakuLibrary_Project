using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneMvc1.Models
{
    public class DetayliKitapBilgileri
    {
        public int Id { get; set; }
        public string Adi { get; set; }     
        public int SayfaSayisi { get; set; }
        public int CiltNo { get; set; }
        public string KapakResmi { get; set; }
        public string Ozet { get; set; }
        public string YazarAdi { get; set; }
        public string YazarSoyadi { get; set; }
        public string Kategori { get; set; }      
        public int MevcutStok { get; set; }
        public decimal Puani { get; set; } 
        public DateTime enyakinteslim { get; set; }
        public int PopulerlikSırası { get; set; }
        public DateTime tarih { get; set; }
    }
    public class Kategoriler
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public int KitapSayisi { get; set; }
        public int OduncSayisi { get; set; }
        public string KapakResmi { get; set; }

    }
    public class SistemdekiKitaplar
    {
        public List<DetayliKitapBilgileri> Kitaplar { get; set; }=new List<DetayliKitapBilgileri>();
        public List<Kategoriler> SistemdekiKategoriler { get; set; } = new List<Kategoriler>(); 
    }
}