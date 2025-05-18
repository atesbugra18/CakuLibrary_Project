using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneMvc1.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int SayfaSayisi { get; set; }
        public string KapakResmi { get; set; }
        public string YazarAdi { get; set; }
        public string YazarSoyadi { get; set; }
        public string Kategori { get; set; }
        public int MevcutStok { get; set; }

    }
}