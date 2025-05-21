using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.Utils;
using Newtonsoft.Json;
using System.Data.SqlClient;
using FontAwesome.Sharp;
using System.Net.Http;
namespace Kutuphane.ChildFormsKullanici
{
    public partial class BildirimGonder : Form
    {
        public BildirimGonder()
        {
            InitializeComponent();
        }
        string aktifbaglanti;
        private void BildirimGonder_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            DatabaseHelper.GetActiveConnectionString();
            btnclose.BackgroundImage = Image.FromFile("Images\\close.png");
            btnbig.BackgroundImage = Image.FromFile("Images\\big.png");
            btnhide.BackgroundImage = Image.FromFile("Images\\hide.png");
            EskiMailleriGetir();
        }
        private void EskiMailleriGetir()
        {
            int mesajno = 0;
            while (File.Exists(Path.Combine(PathHelper.Mesajlar, $"{mesajno}Mesaj.json")))
            {
                string path = Path.Combine(PathHelper.Mesajlar, $"{mesajno}Mesaj.json");
                IconButton btneskimesaj = new IconButton
                {
                    IconChar = IconChar.Envelope,
                    IconColor = Color.Gainsboro,
                    IconSize = 20,
                    Text = $"{mesajno}Mesaj",
                    ForeColor = Color.Gainsboro,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    TextAlign = ContentAlignment.MiddleRight,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    BackColor = Color.FromArgb(64, 64, 114),
                    Font = new Font("Calibri", 10, FontStyle.Bold),
                    Size = new Size(200, 30),
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };
                btneskimesaj.Click += BtnEskiMesaj_Click;
                paneleskimailler.SuspendLayout();
                paneleskimailler.Controls.Add(btneskimesaj);
                paneleskimailler.ResumeLayout();
                btneskimesaj.Dock = DockStyle.Top;
                mesajno++;
            }
        }

        private void BtnEskiMesaj_Click(object sender, EventArgs e)
        {
            string butonname = ((IconButton)sender).Text + ".json";
            if (File.Exists(Path.Combine(PathHelper.Mesajlar, butonname)))
            {
                string json = File.ReadAllText(Path.Combine(PathHelper.Mesajlar, butonname));
                BildirimModel model = JsonConvert.DeserializeObject<BildirimModel>(json);
                txtbaslik.Text = model.BildirimBaslik;
                txtkonu.Text = model.BildirimKonu;
                txticerik.Rtf = model.BildirimIcerik;
            }
            else
            {
                txtbaslik.Clear();
                txtkonu.Clear();
                txticerik.Clear();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            //Mesaj Gönderme işleminin devam edip etmediği kontrol edilecek. Değişiklik kontrolü yapılacak. 
            this.Close();
        }

        private void btnbildirimgonder_MouseEnter(object sender, EventArgs e)
        {
            btnbildirimgonder.ForeColor = Color.Red;
            btnbildirimgonder.IconColor = Color.Red;
        }

        private void btnbildirimgonder_MouseLeave(object sender, EventArgs e)
        {
            btnbildirimgonder.ForeColor = Color.Gainsboro;
            btnbildirimgonder.IconColor = Color.Gainsboro;
        }

        private async void btnai_Click(object sender, EventArgs e)
        {
            string prompt = Microsoft.VisualBasic.Interaction.InputBox(
                    "Yapay zekaya iletmek istediğiniz mesajı yazınız:",
                    "Yapay Zeka Prompt",
                    "Merhaba!");
            if (!string.IsNullOrWhiteSpace(prompt))
            {
                string yanit = await YapayZekayaGonder(prompt);
                txticerik.Text = yanit;
            }
        }
        //Merhaba! Kütüphane sistemini tanıtmak için metin yazmanı istiyorum. Metnin dili Türkçe Olacak. Sistem online şekilde kitap alma ve teslim etme sunuyor okuyuculara. Admin ve Görevlilere ise form ile yönetim işlemlerini kolayca kontrol edebilmesini sağlıyor. İnteraktif arayüzü ile kullanıcı dostu bir sistemdir. Metnin en altında admin ve görevliler alacaz sisteme bunu yaz
        public async Task<string> YapayZekayaGonder(string prompt)
        {
            var httpClient = new HttpClient();
            var requestUri = "http://localhost:1234/v1/chat/completions";
            var requestBody = new
            {
                model = "mistral-7b-instruct-v0.2-turkish",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                temperature = 0.7
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestUri, content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);
                var message = responseObject.choices[0].message.content.ToString();
                return message;
            }
            else
            {
                return $"Hata: {response.StatusCode}\n{await response.Content.ReadAsStringAsync()}";
            }
        }
        private async void btngonder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbaslik.Text) || string.IsNullOrEmpty(txtkonu.Text) || string.IsNullOrEmpty(txticerik.Text))
            {
                MessageBox.Show("Lütfen bütün mesaj içeriğini(Başlık,Konu,İçerik) doldurduktan sonra tekrar deneyiniz", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                #region Mailin Bilgisayara Kaydedilmesi
                BildirimModel model = new BildirimModel
                {
                    BildirimID = int.Parse(Properties.Settings.Default.MesajId.ToString()),
                    BildirimBaslik = txtbaslik.Text,
                    BildirimKonu = txtkonu.Text,
                    BildirimIcerik = txticerik.Rtf,
                    BildirimTarihi = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                int anlıkMesajId = Properties.Settings.Default.MesajId;
                string path = Path.Combine(PathHelper.Mesajlar, $"{anlıkMesajId}Mesaj.json");
                string json = JsonConvert.SerializeObject(model);
                File.WriteAllText(path, json);
                anlıkMesajId++;
                Properties.Settings.Default.MesajId = anlıkMesajId;
                Properties.Settings.Default.Save();
                EskiMailleriGetir();
                #endregion
                string secilenrolisaretli = cboxrol.SelectedItem.ToString();
                string secilenrol = secilenrolisaretli.Replace('@', ' ').Trim();
                List<string> emailList = new List<string>();
                List<int> kullaniciIdList = new List<int>();
                if (secilenrol != "Herkes")
                {
                    string query1 = "Select KullaniciId from KullaniciSistem where Rolu=@rol";
                    string query2 = "Select Email from KullaniciBilgileri where KullaniciId=@id";
                    using (SqlConnection con = new SqlConnection(aktifbaglanti))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query1, con))
                        {
                            cmd.Parameters.AddWithValue("@rol", secilenrol);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int kullaniciId = reader.GetInt32(0);
                                    kullaniciIdList.Add(kullaniciId);
                                }
                            }
                        }
                        foreach (int kullaniciId in kullaniciIdList)
                        {
                            using (SqlCommand cmd = new SqlCommand(query2, con))
                            {
                                cmd.Parameters.AddWithValue("@id", kullaniciId);
                                string email = cmd.ExecuteScalar()?.ToString();
                                if (!string.IsNullOrEmpty(email))
                                {
                                    emailList.Add(email);
                                }
                            }
                        }
                    }
                }
                else
                {
                    string query = "Select Email from KullaniciBilgileri";
                    using (SqlConnection con = new SqlConnection(aktifbaglanti))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string email = reader.GetString(0);
                                    emailList.Add(email);
                                }
                            }
                        }
                    }
                }
                MessageBox.Show($"{emailList.Count} kişiye mesaj gönderildi");
                foreach (string email in emailList)
                {
                    string subject = txtbaslik.Text;
                    string tarihSaat = DateTime.Now.ToString("g");
                    string body = $@"
                                  <h1>{txtkonu.Text}</h1>
                                  <p>{txticerik.Rtf}</p>
                                  <br><br><br>
                                  <hr>
                                  <p style='font-size:12px; color:gray;'>
                                  Bu mesaj Çankırı Karatekin Üniversitesi Bilgisayar Programcılığı Öğrencileri tarafından hazırlanan bir otomasyon sisteminden gönderilmiştir.<br>
                                  Mail adresleri rastgele oluşturulmaktadır. Eğer rahatsızlık verdiysek özür dileriz.<br>
                                  Gönderim Zamanı: {tarihSaat}
                                  </p>";
                    await SendMail(email, subject, body);
                }
            }
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
        private void cboxrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color renk;
            if (cboxrol.SelectedIndex == 3)
            {
                renk = Color.FromArgb(67, 197, 153);
            }
            else if (cboxrol.SelectedIndex == 2)
            {
                renk = Color.FromArgb(197, 67, 67);
            }
            else if (cboxrol.SelectedIndex == 1)
            {
                renk = Color.FromArgb(188, 102, 58);
            }
            else
            {
                renk = Color.FromArgb(67, 153, 197);
            }
            cboxrol.BackColor = renk;
        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            txticerik.Undo();
            txticerik.Focus();
        }

        private void btnredo_Click(object sender, EventArgs e)
        {
            txticerik.Redo();
            txticerik.Focus();
        }

        private void btnbold_Click(object sender, EventArgs e)
        {
            txticerik.SelectionFont = new Font(txticerik.Font, txticerik.SelectionFont.Style ^ FontStyle.Bold);
            txticerik.Focus();

        }

        private void btnitalic_Click(object sender, EventArgs e)
        {
            txticerik.SelectionFont = new Font(txticerik.Font, txticerik.SelectionFont.Style ^ FontStyle.Italic);
            txticerik.Focus();

        }

        private void btnunderline_Click(object sender, EventArgs e)
        {
            txticerik.SelectionFont = new Font(txticerik.Font, txticerik.SelectionFont.Style ^ FontStyle.Underline);
            txticerik.Focus();

        }

        private void btnfont_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            DialogResult res = cd.ShowDialog();
            if (res == DialogResult.OK)
            {
                txticerik.SelectionColor = cd.Color;
            }
        }

        private void btntextheight_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            DialogResult res = fd.ShowDialog();
            if (res == DialogResult.OK)
            {
                txticerik.SelectionFont = fd.Font;
            }
            txticerik.Focus();
        }

        private void btnhizalama_Click(object sender, EventArgs e)
        {
            panelhizalama.Visible = !panelhizalama.Visible;
        }

        private void btnlisteleme_Click(object sender, EventArgs e)
        {
            panelliste.Visible = !panelliste.Visible;
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txticerik.Clear();
            txticerik.Focus();
        }

        private void btnaddlink_Click(object sender, EventArgs e)
        {
            string url = Microsoft.VisualBasic.Interaction.InputBox("Link adresini giriniz:", "Bağlantı Ekle", "https://");
            if (!string.IsNullOrWhiteSpace(url))
            {
                int selectionStart = txticerik.SelectionStart;
                int selectionLength = txticerik.SelectionLength;
                string selectedText = txticerik.SelectedText;
                if (string.IsNullOrEmpty(selectedText))
                {
                    selectedText = url;
                }
                txticerik.SelectedRtf = $@"{{\rtf1\ansi {selectedText}\v #{url}\v0}}";
            }
        }

        private void btnaddimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Resim Seçin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string resimYolu = ofd.FileName;
                Clipboard.SetImage(Image.FromFile(resimYolu));
                txticerik.Paste();
            }
            txticerik.Focus();
        }

        private void btnaddfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tüm Dosyalar|*.*";
            ofd.Title = "Dosya Seçin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = ofd.FileName;
                Clipboard.SetFileDropList(new System.Collections.Specialized.StringCollection { dosyaYolu });
                txticerik.Paste();
            }
            txticerik.Focus();
        }

        private void btnalignleft_Click(object sender, EventArgs e)
        {
            txticerik.SelectionAlignment = HorizontalAlignment.Left;
            panelhizalama.Visible = false;
            txticerik.Focus();
        }

        private void btnaligncenter_Click(object sender, EventArgs e)
        {
            txticerik.SelectionAlignment = HorizontalAlignment.Center;
            panelhizalama.Visible = false;
            txticerik.Focus();
        }

        private void btnalignright_Click(object sender, EventArgs e)
        {
            txticerik.SelectionAlignment = HorizontalAlignment.Right;
            panelhizalama.Visible = false;
            txticerik.Focus();
        }

        private void btnlistul_Click(object sender, EventArgs e)
        {
            txticerik.SelectionBullet = true;
            panelliste.Visible = false;
            txticerik.Focus();
        }

        private void btnlist12_Click(object sender, EventArgs e)
        {
            //txticerik.SelectionBullet = false;
            //int satirno = txticerik.GetLineFromCharIndex(txticerik.SelectionStart);
            //string[] satirlar = txticerik.Lines;
            //if (satirno < satirlar.Length)
            //{
            //    if (!satirlar[satirno].TrimStart().StartsWith((satirno + 1).ToString() + "."))
            //    {
            //        satirlar[satirno] = (satirno + 1).ToString() + ". " + satirlar[satirno];
            //        txticerik.Lines = satirlar;
            //    }
            //}
            //txticerik.Focus();
        }

        private void btngirintiarttır_Click(object sender, EventArgs e)
        {
            txticerik.SelectionIndent += 10;
            txticerik.SelectionHangingIndent += 10;
            txticerik.Focus();
        }

        private void btngirintiazalt_Click(object sender, EventArgs e)
        {
            txticerik.SelectionIndent -= 10;
            txticerik.SelectionHangingIndent -= 10;
            txticerik.Focus();
        }

        private void txticerik_TextChanged(object sender, EventArgs e)
        {
            panelhizalama.Visible = false;
            panelliste.Visible = false;
        }
    }
}
