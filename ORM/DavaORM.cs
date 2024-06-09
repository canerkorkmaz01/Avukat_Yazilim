using Entity;
using System.Data;
using System.Data.SqlClient;

namespace ORM
{
    public class DavaORM
    {
        public bool DavaEkle(Davalar d)
        {
            SqlCommand cmd = new SqlCommand("prc_Dava_Ekle", Tools.Baglanti);
            cmd.Parameters.AddWithValue("@dno", d.dno);
            cmd.Parameters.AddWithValue("@muvad", d.muvad);
            cmd.Parameters.AddWithValue("@muvsoy", d.muvsoy);
            cmd.Parameters.AddWithValue("@karsiad",d.karsiad);
            cmd.Parameters.AddWithValue("@karsisoy", d.karsisoy);
            cmd.Parameters.AddWithValue("@mahkadi", d.mahkadi);
            cmd.Parameters.AddWithValue("@mahno", d.mahno);
            cmd.Parameters.AddWithValue("@kararno", d.kararno);
            cmd.Parameters.AddWithValue("@esasno", d.esasno);
            cmd.Parameters.AddWithValue("@tarih", d.tarih);
            cmd.Parameters.AddWithValue("@aciklama", d.aciklama);
            cmd.Parameters.AddWithValue("@saat", d.saat);
            cmd.Parameters.AddWithValue("@noti", d.noti);
            cmd.Parameters.AddWithValue("@yer", d.yer);
            cmd.Parameters.AddWithValue("@arsiv", d.arsiv);
            cmd.CommandType = CommandType.StoredProcedure;
            return Tools.Connect(cmd);
        }

        public static DataTable DavaGetir()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("prc_Davalar_Getir", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(dt);
            return dt;

        }

        
        public static DataTable DavaTarihAra(Davalar d)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("prc_Davalar_TarihAra", Tools.Baglanti);
            adp.SelectCommand.Parameters.AddWithValue("@baslangic", d.tarih);
            adp.SelectCommand.Parameters.AddWithValue("@bitis", d.tarih2);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(dt);
            return dt;
        }

        

        public static bool DavaSil(Davalar d)
        {
            SqlCommand cmd = new SqlCommand("prc_Davalar_Sil", Tools.Baglanti);
            cmd.Parameters.AddWithValue("@ID", d.ID);
            cmd.CommandType = CommandType.StoredProcedure;
            return Tools.Connect(cmd);

        }

       

        public bool DavaGuncelle(Davalar d)
        {
            SqlCommand cmd = new SqlCommand("prc_Dava_Guncelle", Tools.Baglanti);
            cmd.Parameters.AddWithValue("@ID", d.ID);
            cmd.Parameters.AddWithValue("@dno", d.dno);
            cmd.Parameters.AddWithValue("@muvad", d.muvad);
            cmd.Parameters.AddWithValue("@muvsoy", d.muvsoy);
            cmd.Parameters.AddWithValue("@karsiad", d.karsiad);
            cmd.Parameters.AddWithValue("@karsisoy", d.karsisoy);
            cmd.Parameters.AddWithValue("@mahkadi", d.mahkadi);
            cmd.Parameters.AddWithValue("@mahno", d.mahno);
            cmd.Parameters.AddWithValue("@kararno", d.kararno);
            cmd.Parameters.AddWithValue("@esasno", d.esasno);
            cmd.Parameters.AddWithValue("@tarih", d.tarih);
            cmd.Parameters.AddWithValue("@aciklama", d.aciklama);
            cmd.Parameters.AddWithValue("@saat", d.saat);
            cmd.Parameters.AddWithValue("@noti", d.noti);
            cmd.Parameters.AddWithValue("@yer", d.yer);
            cmd.Parameters.AddWithValue("@arsiv", d.arsiv);
            cmd.CommandType = CommandType.StoredProcedure;
            return Tools.Connect(cmd);
        }


        public static DataTable DavaBilgiAraBastikca(Davalar d)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("prc_Dava_BasdikcaAra", Tools.Baglanti);
            adp.SelectCommand.Parameters.Add("@dno", SqlDbType.NVarChar).Value =  d.dno;
            adp.SelectCommand.Parameters.Add("@muvad", SqlDbType.NVarChar).Value = d.muvad;
            adp.SelectCommand.Parameters.Add("@muvsoy", SqlDbType.NVarChar).Value = d.muvsoy;
            adp.SelectCommand.Parameters.Add("@karsiad", SqlDbType.NVarChar).Value = d.karsiad;
            adp.SelectCommand.Parameters.Add("@karsisoy", SqlDbType.NVarChar).Value = d.karsisoy;
            adp.SelectCommand.Parameters.Add("@mahkadi", SqlDbType.NVarChar).Value = d.mahkadi;
            adp.SelectCommand.Parameters.Add("@mahno", SqlDbType.NVarChar).Value = d.mahno;
            adp.SelectCommand.Parameters.Add("@kararno", SqlDbType.NVarChar).Value = d.kararno;
            adp.SelectCommand.Parameters.Add("@esasno", SqlDbType.NVarChar).Value = d.esasno;
            adp.SelectCommand.Parameters.Add("@aciklama", SqlDbType.NVarChar).Value = d.aciklama;
            adp.SelectCommand.Parameters.Add("@noti", SqlDbType.NVarChar).Value = d.noti;
            adp.SelectCommand.Parameters.Add("@yer", SqlDbType.NVarChar).Value = d.yer;
            adp.SelectCommand.Parameters.Add("@tarih", SqlDbType.NVarChar).Value = d.tarih;
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(dt);
           return dt;
        }
    }
}
