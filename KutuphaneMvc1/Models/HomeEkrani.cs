using KutuphaneMvc1.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace KutuphaneMvc1.Models
{
    public class HomeEkrani
    {
        public int AktifSayi { get; set; }
        public int KitapSayi { get; set; }
        public int KullaniciSayi { get; set; }
        public int CezaTutari { get; set; }

        public List<Kitap> SonEklenenKitaplar { get; set; } = new List<Kitap>();
    }
}