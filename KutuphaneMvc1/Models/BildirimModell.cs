using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    public class BildirimModell
    {
        public int BildirimID { get; set; }
        public string BildirimBaslik { get; set; }
        public string BildirimKonu { get; set; }
        public string BildirimIcerik { get; set; }
        public string BildirimTarihi { get; set; }
    }
}
