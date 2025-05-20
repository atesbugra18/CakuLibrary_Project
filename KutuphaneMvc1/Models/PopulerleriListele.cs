using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace KutuphaneMvc1.Models
{
    public class PopulerleriListele
    {
        public List<TopKitaplar> Kitaplar { get; set; } = new List<TopKitaplar>();
        public List<TopKategoriler> Kategoriler { get; set; } = new List<TopKategoriler>();
        public List<TopYazarlar> Yazarlar { get; set; } = new List<TopYazarlar>();

    }
    public class TopKitaplar
    {
        public string KitapAdi { get; set; }
        public string YazarAdi { get; set; }
        public string KategoriAdi { get; set; }
        public string KapakResmi { get; set; }
        public int SayfaSayisi { get; set; }
        public int MevcutStok { get; set; }
        public int OduncSayisi { get; set; }
        public int Sıralaması { get; set; }
        public string KapakRenk { get; set; }
    }
    public class TopKategoriler
    {
        public string KategoriAdi { get; set; }
        public int KitapSayisi { get; set; }
        public int OduncSayisi { get; set; }
        public string KapakResmi { get; set; }
        public int Sıralaması { get; set; }
        public string KapakRenk { get; set; }
    }
    public class TopYazarlar
    {
        public int Sıralaması { get; set; }
        public string YazarAdi { get; set; }
        public int ToplamOkunmaSayisi { get; set; }
        public string FavoriKitabi { get; set; }
        public int FavoriKitapOkunmaSayisi { get; set; }
        public string KapakRenk { get; set; }

    }
}