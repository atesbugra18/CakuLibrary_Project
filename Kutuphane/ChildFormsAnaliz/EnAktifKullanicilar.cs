using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.Utils;

namespace Kutuphane.ChildFormsAnaliz
{
    public partial class EnAktifKullanicilar : Form
    {
        public EnAktifKullanicilar()
        {
            InitializeComponent();
        }
        string aktifbaglanti;
        private void EnAktifKullanicilar_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (string.IsNullOrEmpty(aktifbaglanti))
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            KullanicilariGetir();
        }
        private void KullanicilariGetir()
        {
            #region Datagridviewi Doldur
            string query = "SELECT ROW_NUMBER() OVER (ORDER BY COUNT(o.KitapId) DESC) AS SiraNo,ku.KullaniciAdi,u.Ad + ' ' + u.Soyad AS UyeAdiSoyadi, u.Email, COUNT(o.KitapId) AS ToplamOdunc,MAX(o.TeslimTarihi) AS SonOduncTarihi FROM KullaniciBilgileri u INNER JOIN OduncAlma o ON u.KullaniciId = o.KullaniciId INNER JOIN KullaniciSistem ku ON u.KullaniciId = ku.KullaniciId GROUP BY u.Ad, u.Soyad, u.Email, ku.KullaniciAdi ORDER BY ToplamOdunc DESC;";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            #endregion
            string query2 = "SELECT TOP 1 ROW_NUMBER() OVER (ORDER BY COUNT(o.KitapId) DESC) AS SiraNo, ku.KullaniciAdi, u.Ad + ' ' + u.Soyad AS UyeAdiSoyadi, u.Email, u.ProfilFotoUrl, COUNT(o.KitapId) AS ToplamOdunc, MAX(o.BaslangicTarihi) AS SonOduncTarihi FROM  KullaniciBilgileri u INNER JOIN  OduncAlma o ON u.KullaniciId = o.KullaniciId INNER JOIN KullaniciSistem ku ON u.KullaniciId = ku.KullaniciId GROUP BY  u.Ad, u.Soyad, u.Email, ku.KullaniciAdi, u.ProfilFotoUrl ORDER BY  ToplamOdunc DESC";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query2, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        lblkurtadi.Text = reader.GetString(1);
                        lblkurtadisoyadi.Text = reader.GetString(2);
                        lblkurtmail.Text = reader.GetString(3);
                        try
                        {
                            picboxkurt.BackgroundImage = Image.FromFile(PathHelper.ProfilResimleri + "\\" + reader.GetString(4));
                        }
                        catch (Exception ex)
                        {
                            //System Log a resim yükleme hatası gönderilecek
                        }
                        lblkurttoplamokuma.Text = reader.GetInt32(5).ToString();
                        lblkurtsonaktiflik.Text = reader.GetDateTime(6).ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string query = "SELECT TOP 1 ROW_NUMBER() OVER (ORDER BY COUNT(o.KitapId) DESC) AS SiraNo, ku.KullaniciAdi, u.Ad + ' ' + u.Soyad AS UyeAdiSoyadi, u.Email, u.ProfilFotoUrl, COUNT(o.KitapId) AS ToplamOdunc, MAX(o.BaslangicTarihi) AS SonOduncTarihi FROM KullaniciBilgileri u INNER JOIN OduncAlma o ON u.KullaniciId = o.KullaniciId INNER JOIN KullaniciSistem ku ON u.KullaniciId = ku.KullaniciId WHERE ku.KullaniciAdi = @KullaniciAdi GROUP BY u.Ad, u.Soyad, u.Email, ku.KullaniciAdi, u.ProfilFotoUrl ORDER BY ToplamOdunc DESC";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        secilenadi.Text = reader.GetString(1);
                        secilenadisoyadi.Text = reader.GetString(2);
                        secilenmaili.Text = reader.GetString(3);
                        try
                        {
                            picboxsecilen.BackgroundImage = Image.FromFile(PathHelper.ProfilResimleri + "\\" + reader.GetString(4));

                        }
                        catch (Exception ex)
                        {
                            //System Log a resim yükleme hatası gönderilecek
                        }
                        secilentoplamislemsayisi.Text = reader.GetInt32(5).ToString();
                        secilensonislemtarihi.Text = reader.GetDateTime(6).ToString("dd/MM/yyyy");
                    }
                    }
                    catch (Exception)
                    {
                        //System log a hatalı seçim gönderilecek
                        throw;
                    }
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picboxkurt_Click(object sender, EventArgs e)
        {

        }
    }
}
