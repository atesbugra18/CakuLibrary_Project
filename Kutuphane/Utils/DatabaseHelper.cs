using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.Utils
{
    internal class DatabaseHelper
    {
        private static readonly string BaglantýV = ConfigurationManager.ConnectionStrings["BaglantýV"].ConnectionString;
        private static readonly string BaglantýSefa = ConfigurationManager.ConnectionStrings["BaglantýSefa"].ConnectionString;
        public static async Task DatabaseQueryAsync(string query, Func<SqlCommand, Task> commandAction)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BaglantýV))
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
                    using (SqlConnection con = new SqlConnection(BaglantýSefa))
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
                    MessageBox.Show("Veritabanýna baðlanýlamadý.", "Baðlantý Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
