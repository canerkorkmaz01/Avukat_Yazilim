using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ORM
{
     public class Tools
        
    {
        public static string mahkeme_ad { get; set; }
        public static int dava_id { get; set; }

        public static int vek_id { get; set; }

        private static SqlConnection baglanti;
        public static SqlConnection Baglanti
        {
            get
            {
                if (baglanti == null)
                {
                    //  baglanti = new SqlConnection("Server = .; Database=MARKET; Integrated Security=true;");
                    baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["avukat"].ConnectionString);
                }
                return baglanti;
            }

        }

        public static bool Connect(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                int etk = cmd.ExecuteNonQuery();
                return etk > 0 ? true : false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }

        }
    }
}

