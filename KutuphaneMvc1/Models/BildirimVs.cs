using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneMvc1.Models
{
    public class BildirimVs
    {
        #region Mesajlaşmalar İçin
        public List<GorevliKullanici> Gorevliler { get; set; } = new List<GorevliKullanici>();
        public List<Mesajlasmalar> Mesajlasmalar { get; set; } = new List<Mesajlasmalar>();
        #endregion
        #region Yapay Zeka İçin
        public DateTime YapayZekaTarih { get; set; }
        public string Prompt { get; set; }
        public string YapayZekaMesaji { get; set; }
        #endregion
        #region Bildirimler İçin
        public List<Bildirim> Bildirimler { get; set; } = new List<Bildirim>();
        #endregion
    }
    public class Mesajlasmalar
    {
        public string MesajıAtanınAdı { get; set; }
        public string Mesaj { get; set; }
        public DateTime TarihSaat { get; set; }
    }
    public class GorevliKullanici
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciResmi { get; set; }
        public string Rolü { get; set; }
    }
    public class Bildirim
    {
        public int BildirimId { get; set; }
        public string BildirimTuru { get; set; }
        public string BildirimBasligi { get; set; }
        public string BildirimMesaji { get; set; }
        public DateTime BildirimTarih { get; set; }
    }
}
