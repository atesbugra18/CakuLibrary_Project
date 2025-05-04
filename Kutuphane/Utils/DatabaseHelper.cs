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
        private static string ActiveConnectionString;

        static DatabaseHelper()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BaglantýV))
                {
                    con.Open();
                    ActiveConnectionString = BaglantýV;
                }
            }
            catch
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(BaglantýSefa))
                    {
                        con.Open();
                        ActiveConnectionString = BaglantýSefa;
                    }
                }
                catch
                {
                    MessageBox.Show("Veritabanýna baðlanýlamadý.", "Baðlantý Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
