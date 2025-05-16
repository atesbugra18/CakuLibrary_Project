using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsAnaliz
{
    public partial class GecikenKitapListesi : Form
    {
        public GecikenKitapListesi()
        {
            InitializeComponent();
        }
        string aktifbaglanti;
        public static int adminid;
        bool admin;
        private void GecikenKitapListesi_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (string.IsNullOrEmpty(aktifbaglanti))
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            admin = AdminMi();
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
            VerileriGetir();
        }
        private void VerileriGetir()
        {
            string query = "SELECT ROW_NUMBER() OVER (ORDER BY oa.BitisTarihi DESC) AS SiraNo,ks.KullaniciAdi,kb.Ad + ' ' + kb.Soyad AS KullaniciAdiSoyadi,y.YazarAdi + ' ' + y.YazarSoyadi AS YazarAdiSoyadi,k.KitapAdi,oa.BitisTarihi FROM OduncAlma oa INNER JOIN KullaniciBilgileri kb ON oa.KullaniciId = kb.KullaniciId INNER JOIN KullaniciSistem ks ON kb.KullaniciId = ks.KullaniciId INNER JOIN Kitaplar k ON oa.KitapId = k.KitapId INNER JOIN Yazarlar y ON k.YazarId = y.YazarId ORDER BY oa.BitisTarihi DESC;";
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
        }
        private bool AdminMi()
        {
            string query = "SELECT Rolu From KullaniciSistem where KullaniciId=@KullaniciId";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciId", adminid);
                    string rol = (string)cmd.ExecuteScalar();
                    if (rol == "Admin")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnhide_Click(object sender, EventArgs e)
        {

        }
        private async void btnhatirlat_Click(object sender, EventArgs e)
        {
            string query = "SELECT Email FROM KullaniciBilgileri WHERE Ad+' '+Soyad = @adisoyadi";
            string email;
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@adisoyadi", dataGridView1.CurrentRow.Cells[2].Value.ToString());
                    email = (string)cmd.ExecuteScalar();
                }
            }
            string subject = "Geciken Kitap Hatırlatması";
            string body = "Merhaba, \n\n" +
                          "Aşağıdaki kitapların iade tarihi geçmiştir:\n\n" +
                          "Kitap Adı: " + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "\n" +
                          "İade Tarihi: " + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "\n\n" +
                          "Lütfen en kısa sürede iade ediniz.\n\n" +
                          "Teşekkürler,\n" +
                          "BASK Kütüphane Sistemi<br><br><br>" +
                          "<hr>" +
                          "<p style='font-size:12px; color:gray;'>" +
                          "Bu mesaj Çankırı Karatekin Üniversitesi Bilgisayar Programcılığı Öğrencileri tarafından hazırlanan bir otomasyon sisteminden gönderilmiştir.<br>Mail adresleri rastgele oluşturulmaktadır. Eğer rahatsızlık verdiysek özür dileriz.<br></p>";
            await SendMail(email, subject, body);
        }
        private async Task SendMail(string toEmail, string subject, string body)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("kutuphaneproje18@gmail.com", "jnzcrprgmzyjgezl");
                    smtpClient.EnableSsl = true;
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("kutuphaneproje18@gmail.com");
                        mailMessage.To.Add(toEmail);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show("SMTP Hatası: " + smtpEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilirken hata oluştu: " + ex.Message);
            }
        }
        private async void btnban_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                string kullaniciadi = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string adisoyadi = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                DialogResult res = MessageBox.Show($"{kullaniciadi} adlı kullanıcıyı yasaklamak istediğinize emin misiniz?", "Devam etmek istiyor musunuz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "UPDATE KullaniciSistem SET AktifPasif=0 where KullaniciAdi=@KullaniciAdi";
                    using (SqlConnection con = new SqlConnection(aktifbaglanti))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciadi);
                            int ks = cmd.ExecuteNonQuery();
                            if (ks > 0)
                            {
                                MessageBox.Show($"{kullaniciadi} adlı kullanıcı sistemde yasaklandı. Kitabı geri getirmesi için bildirim gönderildi.");
                                string subject = "Kütüphane Sistemi - Yasaklama Bildirimi";
                                string body = "Merhaba, \n\n" +
                                              $"{kullaniciadi} adlı hesabınız sistemden yasaklanmıştır. \n" +
                                              "Lütfen almış olduğunuz kitapları geri getiriniz. 1 Hafta içerisinde kitapların teslimi durumunda hesabınız geri açılacaktır.\n\n" +
                                              "Teşekkürler,\n" +
                                              "BASK Kütüphane Sistemi<br><br><br>" +
                                              "<hr>" +
                                              "<p style='font-size:12px; color:gray;'>" +
                                              "Bu mesaj Çankırı Karatekin Üniversitesi Bilgisayar Programcılığı Öğrencileri tarafından hazırlanan bir otomasyon sisteminden gönderilmiştir.<br>Mail adresleri rastgele oluşturulmaktadır. Eğer rahatsızlık verdiysek özür dileriz.<br></p>";
                                string email;
                                string query2 = "SELECT Email FROM KullaniciBilgileri WHERE Ad+' '+Soyad = @adisoyadi";
                                using (SqlCommand cmd2 = new SqlCommand(query2,con))
                                {
                                    cmd2.Parameters.AddWithValue("@adisoyadi", adisoyadi);
                                    email = (string)cmd2.ExecuteScalar();
                                }
                                if (!string.IsNullOrEmpty(email))
                                {
                                    await SendMail(email, subject, body);
                                }
                                else
                                {
                                    MessageBox.Show("E-posta adresi bulunamadı. Kullanıcıya bildirim gönderilemedi.");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bu işlemi yapmak için yetkiniz bulunmamaktadır. Bir adminle iletişime geçiniz.", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnenaktifuyeler_MouseEnter(object sender, EventArgs e)
        {
            btnenaktifuyeler.ForeColor = Color.Red;
            btnenaktifuyeler.IconColor = Color.Red;
        }

        private void btnenaktifuyeler_MouseLeave(object sender, EventArgs e)
        {
            btnenaktifuyeler.ForeColor = Color.Gainsboro;
            btnenaktifuyeler.IconColor = Color.Gainsboro;
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtara.Text;
            if (!string.IsNullOrEmpty(searchText)) 
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool isVisible = false;
                    int[] index = { 1, 2, 3, 4 };
                    foreach (int i in index)
                    {
                        if (row.Cells[i].Value != null &&
                            row.Cells[i].Value.ToString().ToLower().Contains(searchText))
                        {
                            isVisible = true;
                            break;
                        }
                    }
                    row.Visible = isVisible;
                }
            }
        }

    }
}
