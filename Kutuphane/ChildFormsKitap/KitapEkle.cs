using Bogus;
using Kutuphane.Utils;
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
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System.Threading;
using File = Google.Apis.Drive.v3.Data.File;
using System.Management;
using System.Security.Cryptography;

namespace Kutuphane.ChildFormsKitap
{
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
        bool onkapaktetiklendi = false;
        bool arkakapaktetiklendi = false;
        string kitapKodu;
        string oncekiKitapAdi = null;
        bool degisiklikkaydedildi = false;
        private void btnclose_Click(object sender, EventArgs e)
        {
            timerclose.Start();
        }

        private void btnonkapak_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                onkapaktetiklendi = true;
                KodOlustur();
                pictureonkapak.BackgroundImage = Image.FromFile(ofd.FileName);
                pictureonkapak.Visible = true;
                lblonkapakgoster.Visible = true;
            }
        }

        private void btnarkakapak_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                arkakapaktetiklendi = true;
                KodOlustur();
                picturearkakapak.BackgroundImage = Image.FromFile(ofd.FileName);
                picturearkakapak.Visible = true;
                lblarkakapakgoster.Visible = true;
            }
        }
        private void KodOlustur()
        {
            degisiklikkaydedildi = false;
            string suankiKitapAdi = txtkitapadi.Text;
            if (kitapKodu != null && suankiKitapAdi == oncekiKitapAdi)
            {
                return;
            }
            else
            {
                Faker faker = new Faker();
                int karakterSayisi = faker.Random.Int(6, 18);
                kitapKodu = faker.Random.AlphaNumeric(karakterSayisi);
                oncekiKitapAdi = suankiKitapAdi;
            }
        }
        private async void btnkitabiekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtkitapadi.Text))
            {
                MessageBox.Show("Kitap adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbyazaradi.Text))
            {
                MessageBox.Show("Yazar adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtsayfasayisi.Text))
            {
                MessageBox.Show("Sayfa sayısı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtciltno.Text))
            {
                MessageBox.Show("Cilt numarası boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtstoksayisi.Text) || !int.TryParse(txtstoksayisi.Text, out _))
            {
                MessageBox.Show("Stok sayısı boş bırakılamaz ve geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbkategori.Text))
            {
                MessageBox.Show("Kategori seçimi boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string kitapadi = txtkitapadi.Text;
            string yazaradi = cbyazaradi.Text;
            string sayfasayisi = txtsayfasayisi.Text;
            string ciltno = txtciltno.Text;
            int stoksayisi = Convert.ToInt32(txtstoksayisi.Text);
            string onkapakLink = "";
            string arkakapakLink = "";
            string tempDirectory = "Temp";
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }
            if (onkapaktetiklendi)
            {
                string localPath = Path.Combine(tempDirectory, $"{kitapKodu}_f.jpg");
                if (pictureonkapak.BackgroundImage != null)
                {
                    pictureonkapak.BackgroundImage.Save(localPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    onkapakLink = await ResimleriSistemeYukle(localPath, "image/jpeg", "1_kY7fr3EKL--mS0x-N6H3DdqLCZiXvpI");
                }
            }
            if (arkakapaktetiklendi)
            {
                string localPath = Path.Combine(tempDirectory, $"{kitapKodu}_b.jpg");
                if (picturearkakapak.BackgroundImage != null)
                {
                    picturearkakapak.BackgroundImage.Save(localPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    arkakapakLink = await ResimleriSistemeYukle(localPath, "image/jpeg", "1ijZms0lzWG9z2FwC09YyvsASCE_vf7Wd");
                }
            }
            string kategori = cbkategori.Text;
            string query1 = "SELECT YazarId from Yazarlar Where Yazaradi=@Yazaradi";
            string query2 = "SELECT KategoriID FROM Kategoriler WHERE KategoriAdi = @kategoriadi";
            string query3 = "INSERT INTO Kitaplar (KitapAdi, YazarId, SayfaSayisi, CiltNo, OnKapakUrl, ArkaKapakUrl,KategoriID) VALUES (@kitapadi, @yazarid, @sayfasayisi, @ciltno, @onkapakurl, @arkakapakurl, @kategoriid)";
            string query4 = "SELECT KitapId FROM Kitaplar WHERE KitapAdi = @kitapadi";
            string query5 = "INSERT INTO KitapStoklari (KitapId, StokSayisi) VALUES (@KitapId, @stoksayisi)";
            int yazarid = 0;
            int kategoriid = 0;
            int kitapid = 0;
            await DatabaseHelper.DatabaseQueryAsync(query1, async cmd =>
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        yazarid = reader.GetInt32(0);
                    }
                }
            });
            await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        kategoriid = reader.GetInt32(0);
                    }
                }
            });
            await DatabaseHelper.DatabaseQueryAsync(query3, async cmd =>
            {
                cmd.Parameters.AddWithValue("@kitapadi", kitapadi);
                cmd.Parameters.AddWithValue("@yazarid", yazarid);
                cmd.Parameters.AddWithValue("@sayfasayisi", sayfasayisi);
                cmd.Parameters.AddWithValue("@ciltno", ciltno);
                cmd.Parameters.AddWithValue("@onkapakurl", onkapakLink);
                cmd.Parameters.AddWithValue("@arkakapakurl", arkakapakLink);
                cmd.Parameters.AddWithValue("@kategoriid", kategoriid);
                await cmd.ExecuteNonQueryAsync();
            });
            await DatabaseHelper.DatabaseQueryAsync(query4, async cmd =>
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        kitapid = reader.GetInt32(0);
                    }
                }
            });
            await DatabaseHelper.DatabaseQueryAsync(query5, async cmd =>
            {
                cmd.Parameters.AddWithValue("@kitapid", kitapid);
                cmd.Parameters.AddWithValue("@stoksayisi", stoksayisi);
                await cmd.ExecuteNonQueryAsync();
            });
            degisiklikkaydedildi = true;
        }


        private async Task<string> ResimleriSistemeYukle(string path, string mimeType, string folderId)
        {
            var service = GetDriveService();
            var fileMetadata = new File()
            {
                Name = Path.GetFileName(path),
                Parents = new List<string> { folderId }
            };
            FilesResource.CreateMediaUpload request;

            using (var stream = new FileStream(path, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, mimeType);
                request.Fields = "id";
                request.Upload();
            }

            var file = request.ResponseBody;
            return await Task.FromResult("https://drive.google.com/file/d/" + file.Id + "/view");
        }
        private static DriveService GetDriveService()
        {
            UserCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { DriveService.Scope.DriveFile },
                    "user", CancellationToken.None, new FileDataStore("Drive.Auth.Store")).Result;
            }

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "KutuphaneApp",
            });
        }

        private async void KitapEkle_Load(object sender, EventArgs e)
        {
            btnclose.BringToFront();
            btngizle.BringToFront();
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            await ComboBoxDoldur();
        }
        private async Task ComboBoxDoldur()
        {
            string query1 = "SELECT KategoriAdi FROM Kategoriler";
            string query2 = "SELECT YazarAdi +' '+ YazarSoyadi as 'YazarAdıSoyadı' from Yazarlar";
            await DatabaseHelper.DatabaseQueryAsync(query1, async cmd =>
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string kategoriadi = reader.GetString(0);
                        cbkategori.Items.Add(kategoriadi);
                    }
                }
            });
            await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string yazaradi = reader.GetString(0);
                        cbyazaradi.Items.Add(yazaradi);
                    }
                }
            });
        }

        private async void timerclose_Tick(object sender, EventArgs e)
        {
            if (!degisiklikkaydedildi)
            {
                await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this, false);
            }
            else
            {
                await CloseHelper.CloseButtonAnimation(sender, e, timerclose, btnclose, this, true);
            }
        }
    }
}
