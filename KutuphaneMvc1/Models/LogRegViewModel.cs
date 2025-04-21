using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneMvc1.Models
{
    public class LogRegViewModel
    {
        public string LogKullaniciAdi { get; set; }
        public string LogSifre { get; set; }
        public string RegKullaniciAdi { get; set; }
        public string RegSifre { get; set; }
        public string RegSifreTekrar { get; set; }
        public string Email { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcKimlikNo { get; set; }

    }
}