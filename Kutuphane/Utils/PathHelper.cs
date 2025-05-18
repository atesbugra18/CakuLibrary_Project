using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.Utils
{
    public static class PathHelper
    {
        public static string ProfilResimleri => Path.Combine(Application.StartupPath, @"..\..\..\KutuphaneMvc1\OrtakNesneler\PP");
        public static string OnKapakResimleri => Path.Combine(Application.StartupPath, @"..\..\..\KutuphaneMvc1\OrtakNesneler\BFP");
        public static string ArkaKapakResimleri => Path.Combine(Application.StartupPath, @"..\..\..\KutuphaneMvc1\OrtakNesneler\BBP");
        public static string Mesajlar => Path.Combine(Application.StartupPath, @"..\..\..\KutuphaneMvc1\OrtakNesneler\MESSAGES");
        public static string Kategoriler => Path.Combine(Application.StartupPath, @"..\..\..\KutuphaneMvc1\OrtakNesneler\CATEGORY");
    }
}
