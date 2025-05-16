using Kutuphane.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsKullanici
{
    public partial class KitapresimleriniKaydet : Form
    {
        public KitapresimleriniKaydet()
        {
            InitializeComponent();
        }
        string aktifbaglanti,onkapakadi,arkakapakadi;
        private void KitapresimleriniKaydet_Load(object sender, EventArgs e)
        {
            aktifbaglanti = DatabaseHelper.GetActiveConnectionString();
            if (aktifbaglanti == null)
            {
                MessageBox.Show("Hiçbir veritabanı bağlantısı sağlanamadı. Uygulama kapatılıyor.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            string query= "SELECT KitapAdi from Kitaplar";
            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    listBox1.DisplayMember = "KitapAdi";
                    listBox1.ValueMember = "KitapAdi";
                    listBox1.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                string yenidosyaadi = ResmiKaydet(pictureBox1.BackgroundImage, "OnKapak", listBox1.SelectedItem.ToString());
                onkapakadi = yenidosyaadi;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                string yenidosyaadi = ResmiKaydet(pictureBox2.BackgroundImage, "ArkaKapak", listBox1.SelectedItem.ToString());
                arkakapakadi = yenidosyaadi;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kitap seçiniz.");
                return;
            }

            // Kitap adı alınırken DataRowView kontrolü
            string kitapadi = "";
            if (listBox1.SelectedItem is DataRowView drv)
                kitapadi = drv["KitapAdi"].ToString();
            else
                kitapadi = listBox1.SelectedItem.ToString();

            string yenikitapadi = kitapadi.ToUpper();

            string query = "UPDATE Kitaplar SET OnkapakUrl=@onkapak, ArkaKapakUrl=@arkakapak, Kitapadi=@kitabinadi WHERE KitapAdi=@kitapadi";

            using (SqlConnection con = new SqlConnection(aktifbaglanti))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@onkapak", onkapakadi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@arkakapak", arkakapakadi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@kitapadi", kitapadi);
                    cmd.Parameters.AddWithValue("@kitabinadi", yenikitapadi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kitabın adı büyük harfe çevirildi. Resimler de sisteme eklendi.");
                        if (listBox1.DataSource is DataTable dt)
                        {
                            DataRow rowToRemove = null;
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["KitapAdi"].ToString() == kitapadi)
                                {
                                    rowToRemove = row;
                                    break;
                                }
                            }
                            if (rowToRemove != null)
                                dt.Rows.Remove(rowToRemove);
                        }
                        else
                        {
                            listBox1.Items.Remove(listBox1.SelectedItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek kitap bulunamadı.");
                    }
                }
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
    }
}
