using Entity;
using ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avukat_Yazilim
{
    public partial class Mahkeme_Adlari : Form
    {
        public Mahkeme_Adlari()
        {
            InitializeComponent();
        }

        private void Mahkeme_Adlari_Load(object sender, EventArgs e)
        {
            lstMahkeme.ValueMember = "Sira";
            lstMahkeme.DisplayMember = "Adi";
            lstMahkeme.DataSource = MahkemeORM.MahkemeListele();



        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
           
            try
            {
                MahkemeORM mORM = new MahkemeORM();
                Mahkemeler m = new Mahkemeler();
                m.Adi = txtMahkeme.Text;
                bool durum = mORM.MahkemeEkle(m);
                if (durum) MessageBox.Show("Kayıt Bşarılı");
                else MessageBox.Show("Başarısız Kayıt");
                Mahkeme_Adlari_Load(null, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                MahkemeORM mORM = new MahkemeORM();
                Mahkemeler m = new Mahkemeler();
                m.Adi = Tools.mahkeme_ad;
                bool durum = mORM.MahkemeSil(m);
                if (durum) MessageBox.Show("Kayıt Silindi");
                else MessageBox.Show("Başarısız Silme");
                Mahkeme_Adlari_Load(null, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void lstMahkeme_Click(object sender, EventArgs e)
        {
            Tools.mahkeme_ad = lstMahkeme.Text;

        }
    }
}
