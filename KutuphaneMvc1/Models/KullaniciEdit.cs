using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneMvc1.Models
{
    public class KullaniciEdit
    {
        [AllowHtml]
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tc { get; set; }
        public string CezaTutari { get; set; }
        public string Email { get; set; }
        [AllowHtml]
        public string Sifre { get; set; }
        [AllowHtml]
        public string Salt { get; set; }
        [AllowHtml]
        public string YeniSifre { get; set; }
        [AllowHtml]
        public string YeniSifreTekrar { get; set; }
        public string Rolu { get; set; }
        public int Sıralama { get; set; }
        public int OkunanKitapSayisi { get; set; }
        public int ToplamYorumSayisi { get; set; }
        public string UyeKademesi { get; set; }

    }
}