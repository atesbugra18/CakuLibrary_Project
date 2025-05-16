using Kutuphane.Utils;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        #region Genel Yönetim
        public string gonderilenistek { get; set; }
        public string kitapadi { get; set; }
        public string yazaradisoyadi { get; set; }
        public string kategorisi { get; set; }
        public string sayfasayisi { get; set; }
        public string stoksayisi { get; set; }
        public string ciltnosu { get; set; }
        string onkapakadi, arkakapakadi;
        string aktifbaglanti;
        private void KitapYonetimLayout_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            DatabaseHelper.GetActiveConnectionString();
            KategorileriGetir();
            YazarlarıGetir();
            if (gonderilenistek == "Ekle")
            {
                panelsilduzenle.Visible = false;
                piconekle.BackgroundImage = Image.FromFile("Images\\kitaponsayfa.png");
                picarkaekle.BackgroundImage = Image.FromFile("Images\\kitaparkasayfa.png");
                lbldurum.Text = "Kitap Ekle";
            }
            else
            {
                lbldurum.Text = "Kitap Sil/Düzenle";
                panelekle.Visible = false;
                txtkitapadisil.Text = kitapadi;
                txtsayfasil.Text = sayfasayisi;
                txtciltsil.Text = ciltnosu;
                txtstoksil.Text = stoksayisi;
                int yazar = cyazarsil.Items.IndexOf(yazaradisoyadi);
                int kategori = ckategorisil.Items.IndexOf(kategorisi);
                cyazarsil.SelectedIndex = yazar;
                ckategorisil.SelectedIndex = kategori;
            }
        }
        private Task KategorileriGetir()
        {
            ckategoriadiekle.DataSource = null;
            ckategorisil.DataSource = null;
            string query = "SELECT KategoriId,KategoriAdi from Kategoriler";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            ckategoriadiekle.DisplayMember = "KategoriAdi";
                            ckategoriadiekle.ValueMember = "KategoriId";
                            ckategorisil.DisplayMember = "KategoriAdi";
                            ckategorisil.ValueMember = "KategoriId";
                            ckategorisil.DataSource = dataTable;
                            ckategoriadiekle.DataSource = dataTable;
                        }
                    }
                }
            }
            return Task.CompletedTask;
        }

        private Task YazarlarıGetir()
        {
            cyazaradisoyadi.DataSource = null;
            cyazarsil.DataSource = null;
            string query = "SELECT YazarId,YazarAdi+' '+YazarSoyadi as 'YazarAdiSoyadi' from Yazarlar";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            cyazaradisoyadi.DisplayMember = "YazarAdiSoyadi";
                            cyazaradisoyadi.ValueMember = "YazarId";
                            cyazarsil.DisplayMember = "YazarAdiSoyadi";
                            cyazarsil.ValueMember = "YazarId";
                            cyazarsil.DataSource = dataTable;
                            cyazaradisoyadi.DataSource = dataTable;
                        }
                    }
                }
            }
            return Task.CompletedTask;
        }
        #endregion

        #region Ekle
        private void btnyazarekle_Click(object sender, EventArgs e)
        {
            string kitapadi = txtkitapadi.Text;
            string yazaradi = cyazaradisoyadi.SelectedItem.ToString();
            int yazarid = Convert.ToInt32(cyazaradisoyadi.SelectedValue);
            string kategoriadi = ckategoriadiekle.SelectedItem.ToString();
            int kategoriid = Convert.ToInt32(ckategoriadiekle.SelectedValue);
            string sayfasayisi = txtsayfasayisiekle.Text;
            string stoksayisi = txtstoksayisiekle.Text;
            string ciltnosu = txtciltnoekle.Text;
            string querykontrol = "SELECT KitapAdi,YazarId,KategoriId,SayfaSayisi,ciltno,Onkapakurl,Arkakapakurl FROM Kitaplar WHERE KitapAdi = @kitapadi AND YazarId = @yazarid AND KategoriId = @kategoriid AND SayfaSayisi = @sayfasayisi AND ciltno = @ciltno";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmdkontrol = new SqlCommand(querykontrol, con))
                {
                    cmdkontrol.Parameters.AddWithValue("@kitapadi", kitapadi);
                    cmdkontrol.Parameters.AddWithValue("@yazarid", yazarid);
                    cmdkontrol.Parameters.AddWithValue("@kategoriid", kategoriid);
                    cmdkontrol.Parameters.AddWithValue("@sayfasayisi", sayfasayisi);
                    cmdkontrol.Parameters.AddWithValue("@ciltno", ciltnosu);
                    object mevcutKitap = cmdkontrol.ExecuteScalar();
                    if (mevcutKitap != null)
                    {
                        MessageBox.Show("Bu kitap zaten mevcut.");
                        return;
                    }
                    else
                    {
                        string query, query2, query3;
                        int kitapid = 0;
                        query = "INSERT INTO Kitaplar (KitapAdi,YazarId,KategoriId,SayfaSayisi,ciltno,Onkapakurl,Arkakapakurl) VALUES (@kitapadi,@yazarid,@kategoriid,@sayfasayisi,@ciltno,@onkapakurl,@arkakapakurl)";
                        query2 = "INSERT INTO KitapStoklari (KitapId,StokSayisi,MevcutStok) VALUES (@kitapid,@stoksayisi,@mevcutstok)";
                        query3 = "SELECT KitapId FROM Kitaplar WHERE KitapAdi = @kitapadi AND YazarId = @yazarid AND KategoriId = @kategoriid AND SayfaSayisi = @sayfasayisi AND ciltno = @ciltno";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@kitapadi", kitapadi);
                            cmd.Parameters.AddWithValue("@yazarid", yazarid);
                            cmd.Parameters.AddWithValue("@kategoriid", kategoriid);
                            cmd.Parameters.AddWithValue("@sayfasayisi", sayfasayisi);
                            cmd.Parameters.AddWithValue("@ciltno", ciltnosu);
                            cmd.Parameters.AddWithValue("@onkapakurl", onkapakadi);
                            cmd.Parameters.AddWithValue("@arkakapakurl", arkakapakadi);
                            int ks1 = cmd.ExecuteNonQuery();
                            if (ks1 > 0)
                            {
                                using (SqlCommand cmd3 = new SqlCommand(query3, con))
                                {
                                    cmd3.Parameters.AddWithValue("@kitapadi", kitapadi);
                                    cmd3.Parameters.AddWithValue("@yazarid", yazarid);
                                    cmd3.Parameters.AddWithValue("@kategoriid", kategoriid);
                                    cmd3.Parameters.AddWithValue("@sayfasayisi", sayfasayisi);
                                    cmd3.Parameters.AddWithValue("@ciltno", ciltnosu);
                                    kitapid = Convert.ToInt32(cmd3.ExecuteScalar());
                                    if (kitapid == 0)
                                    {
                                        MessageBox.Show("Kitap eklenirken hata oluştu.");
                                        return;
                                    }
                                    else
                                    {
                                        using (SqlCommand cmd2 = new SqlCommand(query2, con))
                                        {
                                            cmd2.Parameters.AddWithValue("@kitapid", kitapid);
                                            cmd2.Parameters.AddWithValue("@stoksayisi", stoksayisi);
                                            cmd2.Parameters.AddWithValue("@mevcutstok", stoksayisi);
                                            int ks2 = cmd2.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }
        private void btnonkapakekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                piconekle.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                string yenidosyaadi = ResmiKaydet(piconekle.BackgroundImage, "OnKapak", txtkitapadi.Text);
                onkapakadi = yenidosyaadi;
            }
        }

        private void btnarkakapakekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picarkaekle.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                string yenidosyaadi = ResmiKaydet(picarkaekle.BackgroundImage, "ArkaKapak", txtkitapadi.Text);
                arkakapakadi = yenidosyaadi;
            }
        }
        private string ResmiKaydet(Image resim, string yuzu, string kitapadi)
        {
            string klasor = yuzu == "OnKapak" ? PathHelper.OnKapakResimleri : PathHelper.ArkaKapakResimleri;
            if (!Directory.Exists(klasor))
            {
                Directory.CreateDirectory(klasor);
            }
            string temizKitapAdi = kitapadi.Replace(' ', '_');
            string uzanti = ".png";
            if (resim.Tag != null)
            {
                try
                {
                    uzanti = Path.GetExtension(resim.Tag.ToString());
                }
                catch { uzanti = ".png"; }
            }
            string dosyaAdi = $"{temizKitapAdi}{uzanti}";
            string filePath = Path.Combine(klasor, dosyaAdi);
            resim.Save(filePath);
            return dosyaAdi;
        }
        #endregion

    }
}
