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
        List<string> kitaplar = new List<string>();
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
            KitaplariGetir();
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
        private Task KitaplariGetir()
        {
            string query = "SELECT Kitaplar.KitapId,Kitaplar.KitapAdi,Yazarlar.YazarAdi+' '+Yazarlar.YazarSoyadi as 'YazarAdiSoyadi',Kategoriler.KategoriAdi,Kitaplar.SayfaSayisi,KitapStoklari.StokSayisi from Kitaplar,Yazarlar,Kategoriler,KitapStoklari where Kitaplar.YazarId=Yazarlar.YazarId and Kitaplar.KategoriId=Kategoriler.KategoriId and Kitaplar.KitapId=KitapStoklari.KitapId";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int kitapid = reader.GetInt32(0);
                        string kitapadi = reader.GetString(1);
                        string yazari = reader.GetString(2);
                        string kategorisi = reader.GetString(3);
                        int sayfasayisi = reader.GetInt32(4);
                        int stoksayisi = reader.GetInt32(5);
                        string kitapbilgileri = $"{kitapid}+{kitapadi}+{yazari}+{kategorisi}+{sayfasayisi}+{stoksayisi}";
                        kitaplar.Add(kitapbilgileri);
                    }
                }
            }
            return Task.CompletedTask;
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
            string kitapbilgileri = $"{kitapadi}+{yazaradi}+{kategoriadi}+{sayfasayisi}+{stoksayisi}+{ciltnosu}";
            if (!kitaplar.Contains(kitapbilgileri))
            {
                string query, query2;
                int kitapid = 0;
                query = "INSERT INTO Kitaplar (KitapAdi,YazarId,KategoriId,SayfaSayisi,ciltno,Onkapakurl,Arkakapakurl) VALUES (@kitapadi,@yazarid,@kategoriid,@sayfasayisi,@ciltno,@onkapakurl,@arkakapakurl)";
                query2 = "INSERT INTO KitapStoklari (KitapId,StokSayisi) VALUES (@kitapid,@stoksayisi)";
                using (SqlConnection con = new SqlConnection(aktifbaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@kitapadi", kitapadi);
                        cmd.Parameters.AddWithValue("@yazarid", yazarid);
                        cmd.Parameters.AddWithValue("@kategoriid", kategoriid);
                        cmd.Parameters.AddWithValue("@sayfasayisi", sayfasayisi);
                        cmd.Parameters.AddWithValue("@ciltno", ciltnosu);
                        cmd.Parameters.AddWithValue("@onkapakurl", "BFP\\" + onkapakadi);
                        cmd.Parameters.AddWithValue("@arkakapakurl", "BBP\\" + arkakapakadi);
                        kitapid = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    using (SqlCommand cmd = new SqlCommand(query2, con))
                    {
                        cmd.Parameters.AddWithValue("@kitapid", kitapid);
                        cmd.Parameters.AddWithValue("@stoksayisi", stoksayisi);
                        cmd.ExecuteNonQuery();
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
                string yenidosyaadi = ResmiKaydet(piconekle.BackgroundImage, "OnKapak");
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
                string yenidosyaadi = ResmiKaydet(picarkaekle.BackgroundImage, "ArkaKapak");
                arkakapakadi = yenidosyaadi;
            }
        }
        private string ResmiKaydet(Image resim, string yuzu)
        {
            string klasor = @"C:\Users\atess\source\repos\atesbugra18\cakulibraryprojects\OrtakResimler\";
            if (yuzu == "OnKapak")
            {
                klasor = Path.Combine(klasor, "BFP");
            }
            else if (yuzu == "ArkaKapak")
            {
                klasor = Path.Combine(klasor, "BBP");
            }
            if (!Directory.Exists(klasor))
            {
                Directory.CreateDirectory(klasor);
            }
            string randomFileName = RastgeleIsımOlustur() + Path.GetExtension(resim.Tag.ToString());
            string filePath = Path.Combine(klasor, randomFileName);
            resim.Save(filePath);
            return randomFileName;
        }
        private string RastgeleIsımOlustur()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 16).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion

    }
}
