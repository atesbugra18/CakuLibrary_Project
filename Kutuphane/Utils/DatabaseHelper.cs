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
        private static readonly string BaglantıV = ConfigurationManager.ConnectionStrings["BaglantıV"].ConnectionString;
        private static readonly string BaglantıSefa = ConfigurationManager.ConnectionStrings["BaglantıSefa"].ConnectionString;
        private static string ActiveConnectionString;

        static DatabaseHelper()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BaglantıV))
                {
                    con.Open();
                    ActiveConnectionString = BaglantıV;
                }
            }
            catch
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(BaglantıSefa))
                    {
                        con.Open();
                        ActiveConnectionString = BaglantıSefa;
                    }
                }
                catch
                {
                    MessageBox.Show("Veritabanına bağlanılamadı.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
