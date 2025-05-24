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
        private static string ActiveConnectionString;

        static DatabaseHelper()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Baglant�V))
                {
                    con.Open();
                    ActiveConnectionString = Baglant�V;
                }
            }
            catch
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(Baglant�Sefa))
                    {
                        con.Open();
                        ActiveConnectionString = Baglant�Sefa;
                    }
                }
                catch
                {
                    MessageBox.Show("Veritaban�na ba�lan�lamad�.", "Ba�lant� Hatas�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveConnectionString = null;
                }
            }
        }
        public static string GetActiveConnectionString()
        {
            return ActiveConnectionString;
        }
    }
}
