using Kutuphane.Utils;
using KutuphaneMvc1.Models;
using KutuphaneMvc1.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneMvc1.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            HomeEkrani homeEkrani = new HomeEkrani();
            string query = "select Count(OduncAlma.KitapId) as'AktifSayi' from OduncAlma where Durum='Teslim Edilmedi'";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                object sayi = await cmd.ExecuteScalarAsync();
                homeEkrani.AktifSayi = Convert.ToInt32(sayi);
            });
            query = "select Count(KitapId) as'KitapSayi' from Kitaplar";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                object sayi = await cmd.ExecuteScalarAsync();
                homeEkrani.KitapSayi = Convert.ToInt32(sayi);
            });
            query = "select Count(KullaniciId) as'KullaniciSayi' from KullaniciSistem";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                object sayi = await cmd.ExecuteScalarAsync();
                homeEkrani.KullaniciSayi = Convert.ToInt32(sayi);
            });
            query = "select Sum(BorcTutari) as'CezaTutari' from Cezalar where OdemeDurumu='Ödenmedi'";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                object sayi = await cmd.ExecuteScalarAsync();
                homeEkrani.CezaTutari = Convert.ToInt32(sayi);
            });
            query = "SELECT TOP 8 k.KitapAdi,k.SayfaSayisi,k.OnKapakUrl,y.YazarAdi,y.YazarSoyadi,kat.KategoriAdi,s.MevcutStok from Kitaplar k JOIN Yazarlar y ON k.YazarID = y.YazarID JOIN Kategoriler kat ON k.KategoriID = kat.KategoriID JOIN KitapStoklari s ON k.KitapID = s.KitapID ORDER BY k.KitapID DESC;";
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Kitap kitap = new Kitap
                        {
                            Adi = reader["KitapAdi"].ToString(),
                            SayfaSayisi = Convert.ToInt32(reader["SayfaSayisi"]),
                            KapakResmi = PathHelper.OnKapak+"/"+reader["OnKapakUrl"].ToString(),
                            YazarAdi = reader["YazarAdi"].ToString(),
                            YazarSoyadi = reader["YazarSoyadi"].ToString(),
                            Kategori = reader["KategoriAdi"].ToString(),
                            MevcutStok = Convert.ToInt32(reader["MevcutStok"])
                        };
                        homeEkrani.SonEklenenKitaplar.Add(kitap);
                    }
                }
            });
            return View(homeEkrani);
        }
        public ActionResult KitaplariGoster()
        {
            return View();
        }
        public ActionResult TakvimiGoster()
        {
            return View();
        }
        public ActionResult PopulerleriGoster()
        {
            return View();
        }
        public ActionResult BildirimleriGoster()
        {
            return View();
        }
        public ActionResult Hakkinda()
        {
            return View();
        }

    }
}