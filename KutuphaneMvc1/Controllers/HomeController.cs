using Kutuphane.Utils;
using KutuphaneMvc1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneMvc1.Controllers
{
    public class HomeController : BaseController
    {
        static string aktifbaglanti;
        public async Task<ActionResult> Index()
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            HomeEkrani homeEkrani = new HomeEkrani();
            string query1, query2, query3, query4, query5;
            query1 = "select Count(OduncAlma.KitapId) as'AktifSayi' from OduncAlma where Durum='Teslim Edilmedi'";
            query2 = "select Count(KitapId) as'KitapSayi' from Kitaplar";
            query3 = "select Count(KullaniciId) as'KullaniciSayi' from KullaniciSistem";
            query4 = "select Sum(BorcTutari) as'CezaTutari' from Cezalar where OdemeDurumu='Ödenmedi'";
            query5 = "SELECT TOP 8 k.KitapAdi,k.SayfaSayisi,k.OnKapakUrl,y.YazarAdi,y.YazarSoyadi,kat.KategoriAdi,s.MevcutStok from Kitaplar k JOIN Yazarlar y ON k.YazarID = y.YazarID JOIN Kategoriler kat ON k.KategoriID = kat.KategoriID JOIN KitapStoklari s ON k.KitapID = s.KitapID ORDER BY k.KitapID DESC;";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand(query1, con))
                {
                    object sayi = await cmd1.ExecuteScalarAsync();
                    homeEkrani.AktifSayi = Convert.ToInt32(sayi);
                }
                using (SqlCommand cmd2 = new SqlCommand(query2, con))
                {
                    object sayi = await cmd2.ExecuteScalarAsync();
                    homeEkrani.KitapSayi = Convert.ToInt32(sayi);
                }
                using (SqlCommand cmd3 = new SqlCommand(query3, con))
                {
                    object sayi = await cmd3.ExecuteScalarAsync();
                    homeEkrani.KullaniciSayi = Convert.ToInt32(sayi);
                }
                using (SqlCommand cmd4 = new SqlCommand(query4, con))
                {
                    object sayi = await cmd4.ExecuteScalarAsync();
                    homeEkrani.CezaTutari = Convert.ToInt32(sayi);
                }
                using (SqlCommand cmd5 = new SqlCommand(query5, con))
                {
                    using (SqlDataReader reader = cmd5.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kitap kitap = new Kitap
                            {
                                Adi = reader["KitapAdi"].ToString(),
                                SayfaSayisi = Convert.ToInt32(reader["SayfaSayisi"]),
                                KapakResmi = PathHelper.OnKapak + "/" + reader["OnKapakUrl"].ToString(),
                                YazarAdi = reader["YazarAdi"].ToString(),
                                YazarSoyadi = reader["YazarSoyadi"].ToString(),
                                Kategori = reader["KategoriAdi"].ToString(),
                                MevcutStok = Convert.ToInt32(reader["MevcutStok"])
                            };
                            homeEkrani.SonEklenenKitaplar.Add(kitap);
                        }
                    }
                }
            }
            return View(homeEkrani);
        }
        public ActionResult KitaplariGoster()
        {
            return View();
        }
        public ActionResult TakvimiGoster()
        {
            List<Takvim> takvimListesi = new List<Takvim>();
            string query = @"SELECT Kitaplar.KitapAdi, OduncAlma.BitisTarihi 
                    FROM Kitaplar, OduncAlma 
                    WHERE KullaniciId=@KullaniciId 
                    AND OduncAlma.KitapId=Kitaplar.KitapId 
                    AND OduncAlma.TeslimTarihi IS NULL";

            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciId", Session["KullaniciId"]);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int sayac = 1;
                        while (reader.Read())
                        {
                            takvimListesi.Add(new Takvim
                            {
                                Id = sayac++,
                                KitapAdi = reader["KitapAdi"].ToString(),
                                SonTarih = Convert.ToDateTime(reader["BitisTarihi"])
                            });
                        }
                    }
                }
            }
            return View(takvimListesi);
        }
        public ActionResult PopulerleriGoster()
        {
            PopulerleriListele populerleriListele = new PopulerleriListele();
            TopKitaplar kitaplar = new TopKitaplar();
            TopKategoriler kategoriler = new TopKategoriler();
            TopYazarlar yazarlar = new TopYazarlar();
            string query1 = "SELECT k.KitapAdi, k.SayfaSayisi, y.YazarAdi + ' ' + y.YazarSoyadi as 'YazarAdi',kat.KategoriAdi,k.OnKapakUrl, ks.MevcutStok, Count(oa.KitapId) as OduncSayisi  from Kitaplar  as k INNER JOIN Yazarlar y On K.YazarId=y.YazarId  INNER JOIN Kategoriler kat On K.KategoriId=Kat.kategoriId  LEFT JOIN OduncAlma oa On K.KitapId=oa.KitapId  LEFT JOIN KitapStoklari ks on k.KitapId=ks.KitapId Group By K.KitapAdi,Y.yazarAdi,y.yazarsoyadi,kat.kategoriAdi,k.onkapakurl,ks.MevcutStok,k.SayfaSayisi order by OduncSayisi desc";
            string query2 = "SELECT k.KategoriAdi, COUNT(DISTINCT ki.KitapID) AS KitapSayisi,COUNT(o.KitapID) AS OduncSayisi, k.KategoriResimIsmi FROM Kategoriler k LEFT JOIN Kitaplar ki ON k.KategoriID = ki.KategoriID LEFT JOIN OduncAlma o ON ki.KitapID = o.KitapID GROUP BY k.KategoriAdi,k.KategoriResimIsmi ORDER BY OduncSayisi DESC";
            string query3 = "WITH YazarOkunma AS ( SELECT k.YazarId, k.KitapId, COUNT(o.IslemId) AS KitapOkunmaSayisi FROM Kitaplar k LEFT JOIN OduncAlma o ON o.KitapId = k.KitapId GROUP BY k.YazarId, k.KitapId ), YazarToplamOkunma AS ( SELECT y.YazarId, y.YazarAdi+' '+y.YazarSoyadi as 'yazaradisoyadi', SUM(yo.KitapOkunmaSayisi) AS ToplamOkunma FROM Yazarlar y LEFT JOIN YazarOkunma yo ON y.YazarId = yo.YazarId GROUP BY y.YazarId, y.YazarAdi,y.YazarSoyadi ), YazarEnCokOkunanKitap AS ( SELECT yo.YazarId, k.KitapAdi, yo.KitapOkunmaSayisi, ROW_NUMBER() OVER (PARTITION BY yo.YazarId ORDER BY yo.KitapOkunmaSayisi DESC) AS rn FROM YazarOkunma yo JOIN Kitaplar k ON k.KitapId = yo.KitapId ) SELECT  ROW_NUMBER() OVER (ORDER BY yto.ToplamOkunma DESC) AS Siralama, yto.YazarAdiSoyadi, ISNULL(yto.ToplamOkunma, 0) AS ToplamOkunma, ISNULL(yek.KitapAdi, '-') AS EnCokOkunanKitap, ISNULL(yek.KitapOkunmaSayisi, 0) AS KitapOkunmaSayisi FROM YazarToplamOkunma yto LEFT JOIN YazarEnCokOkunanKitap yek ON yto.YazarId = yek.YazarId AND yek.rn = 1 ORDER BY Siralama;";
            string sıralama1 = "Gold";
            string sıralama2 = "Silver";
            string sıralama3 = "Brown";
            string sıralamadigerleri = "Wheat";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand(query1, con))
                {
                    int sayac = 1;
                    using (var reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var kitap = new TopKitaplar
                            {
                                KitapAdi = reader["KitapAdi"].ToString(),
                                YazarAdi = reader["YazarAdi"].ToString(),
                                KategoriAdi = reader["KategoriAdi"].ToString(),
                                KapakResmi = PathHelper.OnKapak + "/" + reader["OnKapakUrl"],
                                OduncSayisi = Convert.ToInt32(reader["OduncSayisi"]),
                                SayfaSayisi = Convert.ToInt32(reader["SayfaSayisi"]),
                                MevcutStok = Convert.ToInt32(reader["MevcutStok"]),
                                Sıralaması = sayac,
                                KapakRenk = sayac == 1 ?  sıralama1:
                                                sayac == 2 ? sıralama2 :
                                                sayac == 3 ? sıralama3 : sıralamadigerleri
                            };
                            sayac++;
                            populerleriListele.Kitaplar.Add(kitap);
                        }
                    }
                }
                using (SqlCommand cmd2 = new SqlCommand(query2, con))
                {
                    int sayac = 1;
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var kategori = new TopKategoriler()
                            {
                                KategoriAdi = reader["KategoriAdi"].ToString(),
                                KitapSayisi = Convert.ToInt32(reader["KitapSayisi"]),
                                OduncSayisi = Convert.ToInt32(reader["OduncSayisi"]),
                                KapakResmi = PathHelper.Category + "/" + reader["KategoriResimIsmi"].ToString(),
                                Sıralaması = sayac,
                                KapakRenk = sayac == 1 ? sıralama1 :
                                                sayac == 2 ? sıralama2 :
                                                sayac == 3 ? sıralama3 : sıralamadigerleri
                            };
                            sayac++;
                            populerleriListele.Kategoriler.Add(kategori);
                        }
                    }
                }
                using (SqlCommand cmd3 = new SqlCommand(query3, con))
                {
                    int sayac = 1;
                    using (SqlDataReader reader = cmd3.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Yazar = new TopYazarlar()
                            {
                                Sıralaması = Convert.ToInt32(reader["Siralama"]),
                                YazarAdi = reader["YazarAdiSoyadi"].ToString(),
                                ToplamOkunmaSayisi = Convert.ToInt32(reader["ToplamOkunma"]),
                                FavoriKitabi = reader["EnCokOkunanKitap"].ToString(),
                                FavoriKitapOkunmaSayisi = Convert.ToInt32(reader["KitapOkunmaSayisi"]),
                                KapakRenk = sayac == 1 ? sıralama1 :
                                                sayac == 2 ? sıralama2 :
                                                sayac == 3 ? sıralama3 : sıralamadigerleri
                            };
                            sayac++;
                            populerleriListele.Yazarlar.Add(Yazar);
                        }
                    }
                }
            }
            return View(populerleriListele);
        }
    }
}