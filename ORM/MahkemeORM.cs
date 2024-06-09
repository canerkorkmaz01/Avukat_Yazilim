using Entity;
using System.Data;
using System.Data.SqlClient;


namespace ORM
{
     public class MahkemeORM
    {
        public static DataTable MahkemeListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("prc_Mahkemeler_Getir", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(dt);
            return dt;
        }

        public bool MahkemeEkle(Mahkemeler m)
        {
            SqlCommand cmd = new SqlCommand("prc_Mahkemeler_Ekle", Tools.Baglanti);
            cmd.Parameters.AddWithValue("@Adi", m.Adi);
            cmd.CommandType = CommandType.StoredProcedure;
            return Tools.Connect(cmd);
        }

        public bool MahkemeSil(Mahkemeler m)
        {
            SqlCommand cmd = new SqlCommand("prc_Mahkemeler_Sil", Tools.Baglanti);
            cmd.Parameters.AddWithValue("@Adi", m.Adi);
            cmd.CommandType = CommandType.StoredProcedure;
            return Tools.Connect(cmd);
        }
    }
}
