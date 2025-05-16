using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.ChildFormsKitap.KategoriYonetim;
using Kutuphane.Utils;
namespace Kutuphane.ChildFormsOdeme
{
    public partial class OdemeSecenekleri : UserControl
    {
        public OdemeSecenekleri()
        {
            InitializeComponent();
        }
        #region Değişkenler
        public int adminid;
        private bool animasyonDevamEdiyor = false;
        //queue araştırılacak
        private Queue<int> animasyonKuyrugu = new Queue<int>();
        int animIndex = -1;
        int animStep = 0;
        Point orijinalKonum;
        string temizKartNo = "";
        string aktifbaglanti;
        public string Odemesekli = "";
        public string BorcluKullanici = "";
        public string BorcluAdSoyad = "";
        public string OdenenTutar = "";
        public string TahsilTarihi = "";
        int kullaniciId = 0;
        #endregion
        private void OdemeSecenekleri_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            DatabaseHelper.GetActiveConnectionString();
            Label[] sayihaneleri = {
                lblhane1,lblhane2,lblhane3,lblhane4,
                lblhane5,lblhane6,lblhane7,lblhane8,
                lblhane9,lblhane10,lblhane11,lblhane12,
                lblhane13,lblhane14,lblhane15,lblhane16
            };
            foreach (var hane in sayihaneleri)
            {
                hane.Text = "#";
            }
            lblcvcsayisi.Text = "CVC\r\n###";
            if (Odemesekli == "Nakit")
            {
                infonakit1.Text = BorcluKullanici;
                infonakit2.Text = BorcluAdSoyad;
                infonakit4.Text = OdenenTutar;
                infonakit5.Text = TahsilTarihi;
                panelkredikarti.Visible = false;
            }
            else
            {
                panelnakit.Visible = false;
            }
            infonakit3.Text = GunSayisi(out string gecikengün);
        }
        #region Kart İle Ödeme
        private void txtkartno_TextChanged(object sender, EventArgs e)
        {
            temizKartNo = txtkartno.Text.Replace(" ", "");
            Label[] sayihaneleri = {
                lblhane1,lblhane2,lblhane3,lblhane4,
                lblhane5,lblhane6,lblhane7,lblhane8,
                lblhane9,lblhane10,lblhane11,lblhane12,
                lblhane13,lblhane14,lblhane15,lblhane16
            };
            for (int i = 0; i < sayihaneleri.Length; i++)
            {
                if (i >= temizKartNo.Length && sayihaneleri[i].Text != "#")
                {
                    sayihaneleri[i].Text = "#";
                }
            }
            for (int i = 0; i < temizKartNo.Length && i < sayihaneleri.Length; i++)
            {
                if (sayihaneleri[i].Text == "#" && i < temizKartNo.Length)
                {
                    animasyonKuyrugu.Enqueue(i);
                    if (!animasyonDevamEdiyor)
                    {
                        BaslatiAnimasyon();
                    }

                    break;
                }
            }
        }

        private void BaslatiAnimasyon()
        {
            if (animasyonKuyrugu.Count > 0 && !animasyonDevamEdiyor)
            {
                animasyonDevamEdiyor = true;
                animIndex = animasyonKuyrugu.Dequeue();
                animStep = 0;
                Label[] sayihaneleri = {
                    lblhane1,lblhane2,lblhane3,lblhane4,
                    lblhane5,lblhane6,lblhane7,lblhane8,
                    lblhane9,lblhane10,lblhane11,lblhane12,
                    lblhane13,lblhane14,lblhane15,lblhane16
                };
                if (animIndex >= 0 && animIndex < sayihaneleri.Length)
                {
                    orijinalKonum = sayihaneleri[animIndex].Location;
                    timersayigirdi.Tag = temizKartNo;
                    timersayigirdi.Start();
                }
            }
        }

        private void txtadsoyad_TextChanged(object sender, EventArgs e)
        {
            sahipadisoyadi.Text = txtadsoyad.Text;
        }

        private void txtcvc_TextChanged(object sender, EventArgs e)
        {
            string cvcMetin = txtcvc.Text.Trim();
            string gosterilecekCVC = "###";
            if (cvcMetin.Length > 0)
            {
                gosterilecekCVC = "";
                for (int i = 0; i < 3; i++)
                {
                    if (i < cvcMetin.Length && !char.IsWhiteSpace(cvcMetin[i]))
                        gosterilecekCVC += cvcMetin[i];
                    else
                        gosterilecekCVC += "#";
                }
            }
            lblcvcsayisi.Text = "CVC\r\n" + gosterilecekCVC;
        }

        private void sonkullanma_ValueChanged(object sender, EventArgs e)
        {
            date.Text = sonkullanma.Value.ToString("MM/yy");
        }

        private void timersayigirdi_Tick(object sender, EventArgs e)
        {
            Label[] sayihaneleri = {
                lblhane1,lblhane2,lblhane3,lblhane4,
                lblhane5,lblhane6,lblhane7,lblhane8,
                lblhane9,lblhane10,lblhane11,lblhane12,
                lblhane13,lblhane14,lblhane15,lblhane16
            };
            if (animIndex == -1 || animIndex >= sayihaneleri.Length)
            {
                AnimasyonuBitir();
                return;
            }
            Label aktifLabel = sayihaneleri[animIndex];
            if (animStep < 10)
            {
                aktifLabel.Top -= 2;
                animStep++;
            }
            else if (animStep < 20)
            {
                if (animStep == 10)
                {
                    if (temizKartNo.Length > animIndex)
                    {
                        aktifLabel.Text = temizKartNo[animIndex].ToString();
                    }
                }
                aktifLabel.Top += 2;
                animStep++;
            }
            else
            {
                aktifLabel.Location = orijinalKonum;
                AnimasyonuBitir();
            }
        }

        private void AnimasyonuBitir()
        {
            timersayigirdi.Stop();
            animStep = 0;
            animIndex = -1;
            animasyonDevamEdiyor = false;
            BaslatiAnimasyon();
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (kullaniciId != 0)
            {
                string query = "UPDATE Cezalar SET BorcTutari = @borctutari, OdemeDurumu = 'Ödendi', OdemeTarihi = @odemeTarihi WHERE KullaniciId = @kullaniciId";
                using (SqlConnection con = new SqlConnection(aktifbaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@borctutari", OdenenTutar);
                        cmd.Parameters.AddWithValue("@odemeTarihi", DateTime.Now);
                        cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        int satir = cmd.ExecuteNonQuery();
                        if (satir != 0)
                        {
                            MessageBox.Show($"{BorcluKullanici} adlı kullanıcının {OdenenTutar}₺ borcu tahsil edilmiştir.", "Tahsilat Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İşlem İptal Edildi", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("İşlemi iptal etmek istediğinize emin misiniz?", "İşlem İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Form parentForm = this.FindForm();
                if (parentForm is OdemeAl mainForm)
                {
                    _ = mainForm.CloseEdildi();
                }
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
                this.Dispose();
            }
        }
        private string GunSayisi(out string gecikengün)
        {
            gecikengün = "0";
            string query1 = "Select KullaniciId from KullaniciSistem where KullaniciAdi=@kullaniciAdi";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query1, con))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", BorcluKullanici);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        kullaniciId = (int)result;
                    }
                }
            }
            if (kullaniciId != 0)
            {
                string query2 = "Select bitistarihi, teslimtarihi from OduncAlma where KullaniciId=@kullaniciId";
                using (SqlConnection con = new SqlConnection(aktifbaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query2, con))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime bitisTarihi = reader.GetDateTime(0);
                                object teslimTarihiObj = reader["teslimtarihi"];

                                if (teslimTarihiObj == DBNull.Value)
                                {
                                    DialogResult result = MessageBox.Show("Henüz kitap teslim edilmemiş. Teslim alındı olarak işaretlemek ister misiniz?", "Kitap Teslim Durumu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                    {
                                        teslimTarihiObj = DateTime.Now;
                                        string updateQuery = "UPDATE OduncAlma SET teslimtarihi = @teslimTarihi,Durum = @Durum,TeslimAlanId = @TeslimAlanId WHERE KullaniciId = @kullaniciId";
                                        reader.Close();
                                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                                        {
                                            updateCmd.Parameters.AddWithValue("@teslimTarihi", DateTime.Now);
                                            updateCmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                            updateCmd.Parameters.AddWithValue("@Durum", "Teslim Alındı");
                                            updateCmd.Parameters.AddWithValue("@TeslimAlanId", adminid);
                                            updateCmd.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        gecikengün = "0";
                                        return "0 gün";
                                    }
                                }

                                DateTime teslimTarihi = (DateTime)teslimTarihiObj;
                                TimeSpan gecikenSure = teslimTarihi - bitisTarihi;
                                gecikengün = gecikenSure.Days.ToString();
                                if (gecikenSure.Days < 0)
                                    gecikengün = "0";
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return gecikengün + " gün";
        }
        private void btnnakitodemeyial_Click(object sender, EventArgs e)
        {
            if (kullaniciId != 0)
            {
                string query = "UPDATE Cezalar SET BorcTutari = @borctutari, OdemeDurumu = 'Ödendi', OdemeTarihi = @odemeTarihi WHERE KullaniciId = @kullaniciId";
                using (SqlConnection con = new SqlConnection(aktifbaglanti))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@borctutari", OdenenTutar);
                        cmd.Parameters.AddWithValue("@odemeTarihi", DateTime.Now);
                        cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        int satir = cmd.ExecuteNonQuery();
                        if (satir != 0)
                        {
                            MessageBox.Show($"{BorcluKullanici} adlı kullanıcının {OdenenTutar}₺ borcu tahsil edilmiştir.", "Tahsilat Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("İşlemi iptal etmek istediğinize emin misiniz?", "İşlem İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Form parentForm = this.FindForm();
                if (parentForm is OdemeAl mainForm)
                {
                    _ = mainForm.CloseEdildi();
                }
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
                this.Dispose();
            }
        }
        private void btnnakitiptalet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nakit İptal Edildi", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion


    }
}
