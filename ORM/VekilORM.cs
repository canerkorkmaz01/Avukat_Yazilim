using Entity;
using System.Data;
using System.Data.SqlClient;


namespace ORM
{
    public class VekilORM
    {
        public static DataTable VekilGetir()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("prc_Muv_Getir", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(dt);
            return dt;
        }

        public bool VekilEkle(vek v)
        {
            SqlCommand cmd = new SqlCommand("prc_Muv_Ekle", Tools.Baglanti);
            cmd.Parameters.AddWithValue("@adi", v.adi);
            cmd.Parameters.AddWithValue("@soyadi", v.soyadi);
            cmd.Parameters.AddWithValue("@vno", v.vno);
            cmd.CommandType = CommandType.StoredProcedure;
            return Tools.Connect(cmd);
        }

        public static bool VekilSil(vek v)
        {
            SqlCommand cmd = new SqlCommand("prc_Muv_Sil", Tools.Baglanti);
            cmd.Parameters.AddWithValue("@ID", v.ID);
            cmd.CommandType = CommandType.StoredProcedure;
            return Tools.Connect(cmd);
        }

        public bool VekilGuncelle(vek v)
        {
            SqlCommand cmd = new SqlCommand("prc_Vekil_Guncelle", Tools.Baglanti);
            cmd.Parameters.AddWithValue("@ID", v.ID);
            cmd.Parameters.AddWithValue("@adi", v.adi);
            cmd.Parameters.AddWithValue("@soyadi", v.soyadi);
            cmd.Parameters.AddWithValue("@vno", v.vno);
            cmd.CommandType = CommandType.StoredProcedure;
            return Tools.Connect(cmd);
        }

        public static DataTable VekilArama(vek v)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("prc_Vek_Arama", Tools.Baglanti);
            adp.SelectCommand.Parameters.AddWithValue("@adi", v.adi);
            adp.SelectCommand.Parameters.AddWithValue("@soyadi", v.soyadi);
            adp.SelectCommand.Parameters.AddWithValue("@vno", v.vno);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(dt);
            return dt;
        }

        //public static DataTable VekilAdArama(vek v)
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter adp = new SqlDataAdapter("prc_Vek_AdAra", Tools.Baglanti);
        //    adp.SelectCommand.Parameters.AddWithValue("@adi",v.adi);
        //    adp.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    adp.Fill(dt);
        //    return dt;
        //}

        //public static DataTable VekilSoyadArama(vek v)
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter adp = new SqlDataAdapter("prc_Vek_SoyadAra", Tools.Baglanti);
        //    adp.SelectCommand.Parameters.AddWithValue("@soyadi", v.soyadi);
        //    adp.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    adp.Fill(dt);
        //    return dt;
        //}



        //public static DataTable VekilBasdikcaAra(vek v)
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter adp = new SqlDataAdapter("prc_Muv_BasdikcaAra", Tools.Baglanti);
        //    adp.SelectCommand.Parameters.AddWithValue("@adi", v.adi);
        //    adp.SelectCommand.Parameters.AddWithValue("@soyadi", v.soyadi);
        //    adp.SelectCommand.Parameters.AddWithValue("@vno", v.vno);
        //    adp.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    adp.Fill(dt);
        //    return dt;
        //}
    }
}
