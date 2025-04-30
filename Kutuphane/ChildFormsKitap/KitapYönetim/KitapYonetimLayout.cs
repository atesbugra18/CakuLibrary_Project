using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsKitap.KitapYönetim
{
    public partial class KitapYonetimLayout : UserControl
    {
        public KitapYonetimLayout()
        {
            InitializeComponent();
        }
        public string gonderilenistek { get; set; }
        public string kitapadi { get; set; } 
        public string yazaradisoyadi { get; set; }
        public string kategorisi { get; set; }
        public string sayfasayisi { get; set; }
        public string stoksayisi { get; set; }
        public string ciltnosu { get; set; }
    }
}
