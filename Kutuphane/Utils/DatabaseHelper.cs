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
        private static readonly string Baglant�V = ConfigurationManager.ConnectionStrings["Baglant�V"].ConnectionString;
        private static readonly string Baglant�Sefa = ConfigurationManager.ConnectionStrings["Baglant�Sefa"].ConnectionString;
        public static async Task DatabaseQueryAsync(string query, Func<SqlCommand, Task> commandAction)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Baglant�V))
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
                    using (SqlConnection con = new SqlConnection(Baglant�Sefa))
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
                    MessageBox.Show("Veritaban�na ba�lan�lamad�.", "Ba�lant� Hatas�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
