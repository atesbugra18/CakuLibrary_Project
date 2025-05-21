using Kutuphane.Utils;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KutuphaneMvc1.Utils
{
    public class CsvHelper
    {
        public static async Task ExportAsync()
        {
            string csvPath = HttpContext.Current.Server.MapPath("~/OrtakNesneler/CSV/kitaplar.csv");
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(csvPath));
                var connStr = DatabaseHelper.GetActiveConnectionString();
                const string query = "select Kitaplar.KitapAdi, " +
                    "Yazarlar.YazarAdi+' '+Yazarlar.YazarSoyadi as 'YazarAdiSoyadi', " +
                    "Kategoriler.KategoriAdi " +
                    "from Kitaplar " +
                    "join Yazarlar on Kitaplar.YazarId=Yazarlar.YazarId " +
                    "join Kategoriler on Kitaplar.KategoriId=Kategoriler.KategoriId;";
                using (var conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    using (StreamWriter sw = new StreamWriter(csvPath, false, new UTF8Encoding(true)))
                    {
                        await sw.WriteLineAsync("KitapAdi,YazarAdi,Kategorisi");
                        while (await reader.ReadAsync())
                        {
                            string CsvEscape(string s)
                            {
                                if (string.IsNullOrEmpty(s)) return "";
                                return (s.Contains(",") || s.Contains("\""))
                                    ? $"\"{s.Replace("\"", "\"\"")}\""
                                    : s;
                            }
                            string kitapAdi = CsvEscape(reader["KitapAdi"]?.ToString());
                            string yazarAdiSoyadi = CsvEscape(reader["YazarAdiSoyadi"]?.ToString());
                            string kategoriAdi = CsvEscape(reader["KategoriAdi"]?.ToString());
                            string line = string.Join(",", kitapAdi, yazarAdiSoyadi, kategoriAdi);
                            await sw.WriteLineAsync(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(
                    HttpContext.Current.Server.MapPath("~/OrtakNesneler/CSV/EXPORT_HATA.txt"),
                    DateTime.Now + Environment.NewLine + ex.ToString()
                );
                throw;
            }
        }
    }
}