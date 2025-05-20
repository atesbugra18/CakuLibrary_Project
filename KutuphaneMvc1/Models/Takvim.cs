using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneMvc1.Models
{
    public class Takvim
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public DateTime SonTarih { get; set; }
    }
}