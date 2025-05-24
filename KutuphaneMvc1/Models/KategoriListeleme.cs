using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneMvc1.Models
{
    public class KategoriListeleme
    {
        public string SecilenKategori { get; set; } 
        public int SecilenKategoriKitapSayisi { get; set; }
        public int SecilenKategoriOduncSayisi { get; set; }
        public string SecilenKategoriKapakResmi { get; set; }
        public List<KategoriyeaitKitaplar> Kitaplar { get; set; } = new List<KategoriyeaitKitaplar>();

    }
    public class KategoriyeaitKitaplar
    {
        public int kitapId { get; set; }    
        public string KitapAdi { get; set; }
        public string YazarAdi { get; set; }
        public string YazarSoyadi { get; set; }
        public int SayfaSayisi { get; set; }
        public string KapakResmi { get; set; }
        public int MevcutStok { get; set; }
        public int OduncSayisi { get; set; }
    }
}