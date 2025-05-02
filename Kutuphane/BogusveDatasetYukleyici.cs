using Bogus;
using Kutuphane.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class BogusveDatasetYukleyici : Form
    {
        public BogusveDatasetYukleyici()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                // Handle empty input case
            }
            else
            {
                if (textBox1.Text.All(char.IsDigit))
                {
                    Faker faker = new Faker("tr");
                    int limit = int.Parse(textBox1.Text);
                    for (int i = 0; i < limit; i++)
                    {
                        string ad = faker.Name.FirstName();
                        string soyad = faker.Name.LastName();
                        string tc = faker.Random.Replace("###########");
                        string email = faker.Internet.Email();
                        string kullaniciadi = faker.Internet.UserName(ad, soyad);
                        string sifre = faker.Internet.Password();
                        string rolu = "Okuyucu";
                        string hash, salt;
                        int kullaniciId = 0;    
                        GeneratePasswordHashAndSalt(sifre, out hash, out salt);
                        string query1 = "INSERT INTO KullaniciBilgileri (Ad, Soyad, Tc, Email) OUTPUT INSERTED.KullaniciId VALUES (@ad, @soyad, @tc, @email)";
                        await DatabaseHelper.DatabaseQueryAsync(query1, async cmd =>
                        {
                            cmd.Parameters.AddWithValue("@ad", ad);
                            cmd.Parameters.AddWithValue("@soyad", soyad);
                            cmd.Parameters.AddWithValue("@tc", tc);
                            cmd.Parameters.AddWithValue("@email", email);
                            object result = await cmd.ExecuteScalarAsync();
                            if (result != null)
                            {
                                kullaniciId = Convert.ToInt32(result);
                            }
                        });
                        if (kullaniciId == 0)
                        {
                            MessageBox.Show("Kullanıcı Sisteme Kayıt Edilemedi");
                        }
                        string query2 = "INSERT INTO KullaniciSistem (KullaniciId, KullaniciAdi, Sifre, Salt) VALUES (@kullaniciid, @kullaniciadi, @sifre, @salt)";
                        await DatabaseHelper.DatabaseQueryAsync(query2, async cmd =>
                        {
                            cmd.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                            cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                            cmd.Parameters.AddWithValue("@sifre", hash);
                            cmd.Parameters.AddWithValue("@salt", salt);
                            await cmd.ExecuteNonQueryAsync();
                        });
                    }
                }
                else
                {
                    
                }
            }
        }

        private void GeneratePasswordHashAndSalt(string password, out string hash, out string salt)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                salt = Convert.ToBase64String(saltBytes);

                using (var sha256 = SHA256.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                    byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                    hash = Convert.ToBase64String(hashBytes);
                }
            }
        }
        List<int> kullaniciIdList = new List<int>();
        private async void button3_Click(object sender, EventArgs e)
        {
            string query= "Select KullaniciId from KullaniciBilgileri";
            kullaniciIdList.Clear();
            await DatabaseHelper.DatabaseQueryAsync(query, async cmd =>
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int kullaniciId = reader.GetInt32(0);
                        kullaniciIdList.Add(kullaniciId);
                    }
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
        }
    }
}
