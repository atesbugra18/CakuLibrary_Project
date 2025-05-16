using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.Utils;

namespace Kutuphane.ChildFormsAnaliz
{
    public partial class Populerler : Form
    {
        public Populerler()
        {
            InitializeComponent();
        }
        string aktifbaglanti;
        private void Populerler_Load(object sender, EventArgs e)
        {
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (string.IsNullOrEmpty(aktifbaglanti))
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            KitaplariAyarla();
            KategorileriAyarla();
            YazarlarıAyarla();
        }
        #region Kitaplar
        private void KitaplariAyarla()
        {
            #region Kitapları Listele
            string query2 = "SELECT k.KitapAdi,y.YazarAdi + ' ' + y.YazarSoyadi as 'YazarAdi',kat.KategoriAdi,k.OnkapakUrl,Count(oa.KitapId) as OduncSayisi from Kitaplar as k INNER JOIN Yazarlar y On K.YazarId=y.YazarId INNER JOIN Kategoriler kat On K.KategoriId=Kat.kategoriId LEFT JOIN OduncAlma oa On K.KitapId=oa.KitapId Group By K.KitapAdi,Y.yazarAdi,y.yazarsoyadi,kat.kategoriAdi,k.onkapakurl order by OduncSayisi desc";
            int sayac2 = 0;
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query2, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string kitapAdi = reader["KitapAdi"].ToString();
                            string yazarAdi = reader["YazarAdi"].ToString();
                            string kategoriAdi = reader["KategoriAdi"].ToString();
                            string kapakUrl = reader["OnKapakUrl"].ToString();
                            string oduncSayisi = reader["OduncSayisi"].ToString();
                            if (sayac2 == 0)
                            {
                                picaltin.BackgroundImage = Image.FromFile(PathHelper.OnKapakResimleri + "\\" + kapakUrl);
                                lblaltinkitapadi.Text = kitapAdi;
                                lblaltinkitapyazari.Text = yazarAdi;
                                lblaltinkitapkategorisi.Text = kategoriAdi;
                                lblaltinkitapoduncsayisi.Text = oduncSayisi;
                            }
                            else if (sayac2 == 1)
                            {
                                picgumus.BackgroundImage = Image.FromFile(PathHelper.OnKapakResimleri + "\\" + kapakUrl);
                                lblgumusadi.Text = kitapAdi;
                                lblgumusyazari.Text = yazarAdi;
                                lblgumuskategorisi.Text = kategoriAdi;
                                lblgumusoduncsayisi.Text = oduncSayisi;
                            }
                            else if (sayac2 == 2)
                            {
                                picbronz.BackgroundImage = Image.FromFile(PathHelper.OnKapakResimleri + "\\" + kapakUrl);
                                lblbronzadi.Text = kitapAdi;
                                lblbronzkategorisi.Text = kategoriAdi;
                                lblbronzyazari.Text = yazarAdi;
                                lblbronzoduncsayisi.Text = oduncSayisi;
                            }
                            else
                            {
                                KitapOlustur(kitapAdi, yazarAdi, kategoriAdi, kapakUrl, oduncSayisi);
                            }
                            sayac2++;
                        }
                    }
                }
            }
            #endregion
        }
        private void KitapOlustur(string kitapadi, string yazaradi, string kategoriadi, string kapakurl, string oduncsayisi)
        {
            Panel kitapCerceve = new Panel
            {
                Size = new Size(200, 400),
                BackColor = Color.Wheat
            };
            Panel KitapPanel = new Panel
            {
                Size = new Size(190, 390),
                Location = new Point(5, 3)
            };
            PictureBox KitapResmi = new PictureBox
            {
                Dock = DockStyle.Top,
                Size = new Size(190, 296),
                BackgroundImage = Image.FromFile(PathHelper.OnKapakResimleri + "\\" + kapakurl),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            TableLayoutPanel KitapBilgileri = new TableLayoutPanel
            {
                Location = new Point(0, 296),
                Size = new Size(190, 94),
                Dock = DockStyle.Bottom,
                ColumnCount = 2,
                RowCount = 4,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };
            KitapBilgileri.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            KitapBilgileri.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            for (int i = 0; i < 4; i++)
            {
                KitapBilgileri.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }
            Label lblinfo1 = new Label { Text = "Kitap Adı:", Anchor = AnchorStyles.Left, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
            Label lblinfo2 = new Label { Text = "Yazarı:", Anchor = AnchorStyles.Left, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
            Label lblinfo3 = new Label { Text = "Kategorisi:", Anchor = AnchorStyles.Left, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
            Label lblinfo4 = new Label { Text = "Ödünç Sayısı:", Anchor = AnchorStyles.Left, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
            Label lblKitapAdi = new Label { Text = kitapadi, Anchor = AnchorStyles.Left, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
            Label lblYazarAdi = new Label { Text = yazaradi, Anchor = AnchorStyles.Left, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
            Label lblKategoriAdi = new Label { Text = kategoriadi, Anchor = AnchorStyles.Left, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
            Label lblOduncSayisi = new Label { Text = oduncsayisi, Anchor = AnchorStyles.Left, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
            KitapBilgileri.Controls.Add(lblinfo1, 0, 0);
            KitapBilgileri.Controls.Add(lblKitapAdi, 1, 0);
            KitapBilgileri.Controls.Add(lblinfo2, 0, 1);
            KitapBilgileri.Controls.Add(lblYazarAdi, 1, 1);
            KitapBilgileri.Controls.Add(lblinfo3, 0, 2);
            KitapBilgileri.Controls.Add(lblKategoriAdi, 1, 2);
            KitapBilgileri.Controls.Add(lblinfo4, 0, 3);
            KitapBilgileri.Controls.Add(lblOduncSayisi, 1, 3);
            KitapPanel.Controls.Add(KitapResmi);
            KitapPanel.Controls.Add(KitapBilgileri);
            kitapCerceve.Controls.Add(KitapPanel);
            PanelKitaplar.Controls.Add(kitapCerceve);
        }
        #endregion
        #region Kategoriler
        private Task KategorileriAyarla()
        {
            string query = "SELECT k.KategoriAdi, COUNT(DISTINCT ki.KitapID) AS KitapSayisi,COUNT(o.KitapID) AS OduncSayisi, k.KategoriResimIsmi FROM Kategoriler k LEFT JOIN Kitaplar ki ON k.KategoriID = ki.KategoriID LEFT JOIN OduncAlma o ON ki.KitapID = o.KitapID GROUP BY k.KategoriAdi,k.KategoriResimIsmi ORDER BY OduncSayisi DESC";
            int sayac = 0;
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string kategoriAdi = reader["KategoriAdi"].ToString();
                            string kitapSayisi = reader["KitapSayisi"].ToString();
                            string oduncSayisi = reader["OduncSayisi"].ToString();
                            string kategoriResimIsmi = reader["KategoriResimIsmi"].ToString();
                            if (sayac == 0)
                            {
                                picaltinkategori.BackgroundImage = Image.FromFile(PathHelper.Kategoriler + "\\" + kategoriResimIsmi);
                                lblaltinkategori.Text = kategoriAdi;
                                lblaltinkitapsayisi.Text = "Kitap Sayısı: " + kitapSayisi + " Ödünç Sayısı: " + oduncSayisi;
                            }
                            else if (sayac == 1)
                            {
                                picgumuskategori.BackgroundImage = Image.FromFile(PathHelper.Kategoriler + "\\" + kategoriResimIsmi);
                                lblgumuskategori.Text = kategoriAdi;
                                lblgumuskitapsayisi.Text = "Kitap Sayısı: " + kitapSayisi + " Ödünç Sayısı: " + oduncSayisi;
                            }
                            else if (sayac == 2)
                            {
                                picbronzkategori.BackgroundImage = Image.FromFile(PathHelper.Kategoriler + "\\" + kategoriResimIsmi);
                                lblbronzkategori.Text = kategoriAdi;
                                lblbronzkitapsayisi.Text = "Kitap Sayısı: " + kitapSayisi + " Ödünç Sayısı: " + oduncSayisi;
                            }
                            else
                            {
                                KategoriOlustur(kategoriAdi, kitapSayisi, oduncSayisi, kategoriResimIsmi);
                            }
                            sayac++;
                        }
                    }
                }
            }
            return Task.CompletedTask;
        }
        private void KategoriOlustur(string kategoriadi, string kitapsayisi, string oduncsayisi, string resimismi)
        {
            Panel KategoriCerceve = new Panel
            {
                Size = new Size(630, 280),
                BackColor = Color.Wheat
            };
            Panel KategoriPaneli = new Panel
            {
                Size = new Size(600, 255),
                Location = new Point(12, 11)
            };
            PictureBox KategoriResmi = new PictureBox
            {
                Dock = DockStyle.Fill,
                Size = new Size(600, 189),
                BackgroundImage = Image.FromFile(PathHelper.Kategoriler + "\\" + resimismi),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            Panel KategoriBilgileri = new Panel
            {
                Size = new Size(600, 51),
                Location = new Point(0, 204),
                Dock = DockStyle.Bottom,
            };
            Label lblkategoriinfo = new Label
            {
                Text = "Kitap Sayısı: " + kitapsayisi + " Ödünç Sayısı: " + oduncsayisi,
                Dock = DockStyle.Bottom,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
            };
            Label lblkategoriadi = new Label
            {
                Text = kategoriadi,
                AutoSize = true,
                Font = new Font("Calibri", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            PanelKategoriler.Controls.Add(KategoriCerceve);
            KategoriCerceve.Controls.Add(KategoriPaneli);
            KategoriPaneli.Controls.Add(KategoriResmi);
            KategoriPaneli.Controls.Add(KategoriBilgileri);
            KategoriPaneli.Controls.Add(lblkategoriinfo);
            KategoriBilgileri.Controls.Add(lblkategoriadi);
        }
        #endregion
        #region Yazarlar
        private void YazarlarıAyarla()
        {
            string query = "WITH YazarOkunma AS ( SELECT k.YazarId, k.KitapId, COUNT(o.IslemId) AS KitapOkunmaSayisi FROM Kitaplar k LEFT JOIN OduncAlma o ON o.KitapId = k.KitapId GROUP BY k.YazarId, k.KitapId ), YazarToplamOkunma AS ( SELECT y.YazarId, y.YazarAdi+' '+y.YazarSoyadi as 'yazaradisoyadi', SUM(yo.KitapOkunmaSayisi) AS ToplamOkunma FROM Yazarlar y LEFT JOIN YazarOkunma yo ON y.YazarId = yo.YazarId GROUP BY y.YazarId, y.YazarAdi,y.YazarSoyadi ), YazarEnCokOkunanKitap AS ( SELECT yo.YazarId, k.KitapAdi, yo.KitapOkunmaSayisi, ROW_NUMBER() OVER (PARTITION BY yo.YazarId ORDER BY yo.KitapOkunmaSayisi DESC) AS rn FROM YazarOkunma yo JOIN Kitaplar k ON k.KitapId = yo.KitapId ) SELECT  ROW_NUMBER() OVER (ORDER BY yto.ToplamOkunma DESC) AS Siralama, yto.YazarAdiSoyadi, ISNULL(yto.ToplamOkunma, 0) AS ToplamOkunma, ISNULL(yek.KitapAdi, '-') AS EnCokOkunanKitap, ISNULL(yek.KitapOkunmaSayisi, 0) AS KitapOkunmaSayisi FROM YazarToplamOkunma yto LEFT JOIN YazarEnCokOkunanKitap yek ON yto.YazarId = yek.YazarId AND yek.rn = 1 ORDER BY Siralama;";
            using (SqlConnection con=new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand(query,con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
        #endregion

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
