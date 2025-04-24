using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KutuphaneMvc1.Utils
{
    public class DatabaseHelper
    {
        private static readonly string BaglantıV = ConfigurationManager.ConnectionStrings["BaglantıV"].ConnectionString;
        private static readonly string BaglantıSefa = ConfigurationManager.ConnectionStrings["BaglantıSefa"].ConnectionString;
        public static async Task DatabaseQueryAsync(string query, Func<SqlCommand, Task> commandAction)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BaglantıV))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        await commandAction(cmd);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(BaglantıSefa))
                    {
                        await con.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            await commandAction(cmd);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Veritabanına bağlanılamadı.");
                }
            }
        }
    }
}