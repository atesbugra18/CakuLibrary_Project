using Bogus;
using Kutuphane.ChildFormsKitap.YazarYonetim;
using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsKullanici
{
    public partial class KullaniciYonetimiLayout : UserControl
    {
        public KullaniciYonetimiLayout()
        {
            InitializeComponent();
        }
        #region Genel
        public string gonderilenistek { get; set; }
        public string gonderilenrol { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string tc { get; set; }
        public string email { get; set; }
        public string kullaniciadi { get; set; }
        public string rol { get; set; }
        List<string> kullanicilar = new List<string>();
        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Form parentForm = this.FindForm();
                if (parentForm is KullaniciYönetimi mainForm)
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
        private void btniptal_Click(object sender, EventArgs e)
        {
            btnclose_Click(sender, e);
        }

        private void btnyonetim_Click(object sender, EventArgs e)
        {
            btnclose_Click(sender, e);
        }

        private async void KullaniciYonetimiLayout_Load(object sender, EventArgs e)
        {
            if (gonderilenrol == "Admin")
            {
                if (gonderilenistek == "Ekle")
                {
                    lbldurum.Text = "Kullanıcı Ekle";
                    panelsilduzenle.Visible = false;
                }
                else
                {
                    lbldurum.Text = "Kullanıcı Sil&Düzenle";
                    panelekle.Visible = false;
                    txtadisil.Text = adi;
                    txtsoyadisil.Text = soyadi;
                    txttcsil.Text = tc;
                    txtepostasil.Text = email;
                    txtkullaniciadisil.Text = kullaniciadi;
                    int sirasi = crolsil.Items.IndexOf(rol);
                    crolsil.SelectedIndex = sirasi;
                }
            }
            else
            {
                if (gonderilenistek == "Ekle")
                {
                    lbldurum.Text = "Kullanıcı Ekle";
                    panelsilduzenle.Visible = false;
                    crolekle.Visible = false;
                    label6.Visible = false;
                }
                else
                {
                    lbldurum.Text = "Kullanıcı Sil&Düzenle";
                    panelekle.Visible = false;
                    txtadisil.Text = adi;
                    txtsoyadisil.Text = soyadi;
                    txttcsil.Text = tc;
                    txtepostasil.Text = email;
                    txtkullaniciadisil.Text = kullaniciadi;
                    int sirasi = crolsil.Items.IndexOf(rol);
                    crolsil.SelectedIndex = sirasi;
                }
            }
            await VarOlanKullanicilar();
        }
        private async Task VarOlanKullanicilar()
        {
            //Kullanıcı Tablolarında hatalar var onlar düzeltilecek
            //Kullanıcı şifresi gönderilmesine rağmen database e düşmüyor Kullanıcı Database de gözükmüyor
            string query = "SELECT KullaniciAdi,Tc,Email FROM KullaniciSistem,KullaniciBilgileri where KullaniciBilgileri.KullaniciId=KullaniciSistem.KullaniciId";
            //await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            //{
            //    using (var reader = await cmd.ExecuteReaderAsync())
            //    {
            //        while (await reader.ReadAsync())
            //        {
            //            string kullaniciadi = reader["KullaniciAdi"].ToString();
            //            string tc = reader["Tc"].ToString();
            //            string email = reader["Email"].ToString();
            //            string kullaniciprimary = $"{kullaniciadi}+{tc}+{email}";
            //            kullanicilar.Add(kullaniciprimary);
            //        }
            //    }
            //});
        }
        private void btnyonetim_MouseEnter(object sender, EventArgs e)
        {
            btnyonetim.ForeColor = Color.Red;
            btnyonetim.IconColor = Color.Red;
        }

        private void btnyonetim_MouseLeave(object sender, EventArgs e)
        {
            btnyonetim.ForeColor = Color.Gainsboro;
            btnyonetim.IconColor = Color.Gainsboro;
        }
#endregion
        #region Kullanıcı Ekle
        private async void btnkullaniciekle_Click(object sender, EventArgs e)
        {
            string ekleadi = txtadiekle.Text.TrimStart().TrimEnd().ToUpper();
            string eklesoyadi = txtsoyadiekle.Text.TrimStart().TrimEnd().ToUpper();
            string ekletc = txttcekle.Text.TrimStart().TrimEnd();
            string ekleemail = txtepostaekle.Text.TrimStart().TrimEnd();
            string eklekullaniciadi = txtkullaniciadiekle.Text.TrimStart().TrimEnd();
            string eklerolu = crolekle.SelectedItem.ToString();
            if (gonderilenrol == "Görevli")
            {
                eklerolu = "Okuyucu";
            }
            if (string.IsNullOrEmpty(ekleadi) ||
                string.IsNullOrEmpty(eklesoyadi) ||
                string.IsNullOrEmpty(ekletc) ||
                ekletc.Length < 11 ||
                !ekletc.All(char.IsDigit) ||
                string.IsNullOrEmpty(ekleemail) ||
                !ekleemail.Contains("@") ||
                !ekleemail.Contains(".") ||
                string.IsNullOrEmpty(eklekullaniciadi) ||
                string.IsNullOrEmpty(eklerolu) ||
                kullanicilar.Contains($"{eklekullaniciadi}+{ekletc}+{ekleemail}")
               )
            {
                MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurun. Ya da Kullanıcının hali hazırda var olmadığından emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                HashPassword(out string sifre, out string hashedPassword, out string salt);
                await SifreyiKullaniciyaGonder(sifre);
                int kullaniciId = 0;
                string query1 = "INSERT INTO KullaniciBilgileri (Ad, Soyad, Tc, Email) OUTPUT INSERTED.KullaniciId VALUES (@ad, @soyad, @tc, @email)";
                //await DatabaseHelper.DatabaseQueryAsync(query1, async cmd =>
                //{
                //    cmd.Parameters.AddWithValue("@ad", ekleadi);
                //    cmd.Parameters.AddWithValue("@soyad", eklesoyadi);
                //    cmd.Parameters.AddWithValue("@tc", ekletc);
                //    cmd.Parameters.AddWithValue("@email", ekleemail);
                //    object result = await cmd.ExecuteScalarAsync();
                //    if (result != null)
                //    {
                //        kullaniciId = Convert.ToInt32(result);
                //    }
                //});
                if (kullaniciId == 0)
                {
                    MessageBox.Show("Kullanıcı Sisteme Kayıt Edilemedi");
                }
                //Kullanıcı Sisteme Kişi Kayıt Edildi ancak Kullanıcı Bilgileri Tablosuna düşmedi
                string query2 = "INSERT INTO KullaniciSistem (KullaniciId, KullaniciAdi, Sifre, Salt) VALUES (@kullaniciid, @kullaniciadi, @sifre, @salt)";
                //await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
                //{
                //    cmd.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                //    cmd.Parameters.AddWithValue("@kullaniciadi", eklekullaniciadi);
                //    cmd.Parameters.AddWithValue("@sifre", hashedPassword);
                //    cmd.Parameters.AddWithValue("@salt", salt);
                //    await cmd.ExecuteNonQueryAsync();
                //});
                MessageBox.Show("Kullanıcı Başarıyla Sisteme Eklendi Şifresi Mail Adresine Gönderildi");
            }
        }
        public static void HashPassword(out string password, out string hashedPassword, out string salt)
        {
            var faker = new Faker();
            password = faker.Internet.Password(10);
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                hashedPassword = Convert.ToBase64String(hashBytes);
            }
        }
        private async Task SifreyiKullaniciyaGonder(string password)
        {
            await Task.Delay(1000);
            string subject = "Kütüphane Sistemi Şifre Bilgisi";
            string body = $"Merhaba, \n\nSisteme giriş şifreniz: {password} \n\nLütfen bu bilgiyi güvende tutun ve kimseyle paylaşmayın.\n\nİyi günler dileriz.\n\nÇankırı Karatekin Üniversitesi Meslek YüksekOkulu Bilgisayar Teknolojileri Bölümü Bilgisayar Programcılığı Programı Öğrencisi Tarafından Tasarlanmıştır. Eğer Fakedata dan denk geldiyseniz özürlerimizi iletiriz.";
            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("kutuphaneproje18@gmail.com", "jnzcrprgmzyjgezl");
                    smtpClient.EnableSsl = true;
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("kutuphaneproje18@gmail.com"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(txtepostaekle.Text.Trim());

                    smtpClient.Send(mailMessage);
                }
                MessageBox.Show("Şifre başarıyla e-posta adresine gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show($"SMTP hatası: {smtpEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şifre gönderilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Sil & Düzenle
        private async void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Kullanıcıyı silmek istediğinize emin misiniz?", "Devam Etmek İstiyor musunuz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string kullaniciAdi = txtkullaniciadisil.Text.Trim();
                if (string.IsNullOrEmpty(kullaniciAdi))
                {
                    MessageBox.Show("Lütfen silinecek kullanıcı adını giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int kullaniciId = 0;
                //string query1 = "SELECT KullaniciId FROM KullaniciSistem WHERE KullaniciAdi = @kullaniciadi";
                //await DatabaseHelper.DatabaseQueryAsync(query1, async cmd =>
                //{
                //    cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciAdi);
                //    object result = await cmd.ExecuteScalarAsync();
                //    if (result != null)
                //    {
                //        kullaniciId = Convert.ToInt32(result);
                //    }
                //});
                //if (kullaniciId == 0)
                //{
                //    MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //string query2 = "DELETE FROM KullaniciBilgileri WHERE KullaniciId = @kullaniciid";
                //await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
                //{
                //    cmd.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                //    await cmd.ExecuteNonQueryAsync();
                //});
                //string query3 = "DELETE FROM KullaniciSistem WHERE KullaniciId = @kullaniciid";
                //await DatabaseHelper.DatabaseQueryAsync(query3, async cmd =>
                //{
                //    cmd.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                //    await cmd.ExecuteNonQueryAsync();
                //});
                MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btndegistir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Kullanıcıyı değiştirmek istediğinize emin misiniz?", "Devam Etmek İstiyor musunuz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string kullaniciAdi = txtkullaniciadisil.Text.Trim();
                if (string.IsNullOrEmpty(kullaniciAdi))
                {
                    MessageBox.Show("Lütfen değiştirilecek kullanıcı adını giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int kullaniciId = 0;
                string query1 = "SELECT KullaniciId FROM KullaniciSistem WHERE KullaniciAdi = @kullaniciadi";
                //await DatabaseHelper.DatabaseQueryAsync(query1, async cmd =>
                //{
                //    cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciAdi);
                //    object result = await cmd.ExecuteScalarAsync();
                //    if (result != null)
                //    {
                //        kullaniciId = Convert.ToInt32(result);
                //    }
                //});
                if (kullaniciId == 0)
                {
                    MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string yeniAd = txtadisil.Text.TrimStart().TrimEnd().ToUpper();
                string yeniSoyad = txtsoyadisil.Text.TrimStart().TrimEnd().ToUpper();
                string yeniTc = txttcsil.Text.TrimStart().TrimEnd();
                string yeniEmail = txtepostasil.Text.TrimStart().TrimEnd();
                string yeniRol = crolsil.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(yeniAd) ||
                    string.IsNullOrEmpty(yeniSoyad) ||
                    string.IsNullOrEmpty(yeniTc) ||
                    yeniTc.Length < 11 ||
                    !yeniTc.All(char.IsDigit) ||
                    string.IsNullOrEmpty(yeniEmail) ||
                    !yeniEmail.Contains("@") ||
                    !yeniEmail.Contains(".") ||
                    string.IsNullOrEmpty(yeniRol))
                {
                    MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string query2 = "UPDATE KullaniciBilgileri SET Ad = @ad, Soyad = @soyad, Tc = @tc, Email = @email WHERE KullaniciId = @kullaniciid";
                //await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
                //{
                //    cmd.Parameters.AddWithValue("@ad", yeniAd);
                //    cmd.Parameters.AddWithValue("@soyad", yeniSoyad);
                //    cmd.Parameters.AddWithValue("@tc", yeniTc);
                //    cmd.Parameters.AddWithValue("@email", yeniEmail);
                //    cmd.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                //    await cmd.ExecuteNonQueryAsync();
                //});
                //string query3 = "UPDATE KullaniciSistem SET KullaniciAdi = @kullaniciadi WHERE KullaniciId = @kullaniciid";
                //await DatabaseHelper.DatabaseQueryAsync(query3, async cmd =>
                //{
                //    cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciAdi);
                //    cmd.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                //    await cmd.ExecuteNonQueryAsync();
                //});
                //MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
