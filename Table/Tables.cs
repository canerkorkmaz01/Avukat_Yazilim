using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    public class Tables
    {
        public static void DataGridViewDavaAra(DataGridView d)
        {
           // d.Columns[4].Width = 300;
            d.Columns[0].Visible = false;
            d.Columns[15].Visible = false;
            d.Columns[1].HeaderText = "Dosya No";
            d.Columns[2].HeaderText = "Müv Adı";
            d.Columns[3].HeaderText = "Müv Soyad";
            d.Columns[4].HeaderText = "Karşı Adı";
            d.Columns[5].HeaderText = "Karşı Soy";
            d.Columns[6].HeaderText = "Mahkeme Adı";
            d.Columns[7].HeaderText = "Mahkeme No";
            d.Columns[8].HeaderText = "Karar No";
            d.Columns[9].HeaderText = "Esas No";
            d.Columns[10].HeaderText = "Tarih";
            d.Columns[11].HeaderText = "Açıklama";
            d.Columns[12].HeaderText = "Saat";
            d.Columns[13].HeaderText = "Notlar";
            d.Columns[14].HeaderText = "Yer";
        }

        public static void DataGridViewMuvAra(DataGridView d)
        {
            // d.Columns[4].Width = 300;
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "Adı";
            d.Columns[2].HeaderText = "Soyadı";
            d.Columns[3].HeaderText = "Vekil No";
        }

    }
}
