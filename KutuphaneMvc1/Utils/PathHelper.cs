using System;
using System.IO;
using System.Web.Hosting;

namespace Kutuphane.Utils
{
    public static class PathHelper
    {
        private const string Anaklasor = "/OrtakNesneler";
        public static string Mesajlar => Anaklasor + "/MESSAGES";
        public static string OnKapak => Anaklasor + "/BFP";
        public static string Category => Anaklasor + "/CATEGORY";
        public static string ProfilPicture => Anaklasor + "/PP";
        public static string CSV => Anaklasor + "/CSV";
    }
}
