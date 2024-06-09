using Entity;
using Microsoft.Office.Interop.Excel;
using ORM;
using PrintDataGrid;
using System;
using System.Data;
using System.Windows.Forms;
using Table;
using TextBox = System.Windows.Forms.TextBox;

namespace Avukat_Yazilim
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Combobox();
            VeriOku();
        }

        private void KontrolleriTemizle()
        {
            foreach (Control txt in groupBox1.Controls)
            {
                if (txt is TextBox)
                {
                    txt.Text = string.Empty;

                }
            }
        }

        private void btnMahkemeAdi_Click(object sender, EventArgs e)
        {
            Mahkeme_Adlari ma = new Mahkeme_Adlari();
            ma.Show();
        }

        private void DavaBilgileri()
        {
            int durum;
            txtDosyaNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMuvAd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMuvSoy.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtKarAdi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtKarSoy.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cboMadi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtMahNo.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtKarNo.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtEsNo.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtTarih.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtAciklama.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtSaat.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txtNot.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtDvYer.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            durum = Convert.ToInt32(dataGridView1.CurrentRow.Cells[15].Value);
            if (durum == 1)
            {
                chcArsiv.Checked = true;
            }
            else chcArsiv.Checked = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DavaORM dORM = new DavaORM();
                Davalar d = new Davalar();
                d.dno = txtDosyaNo.Text;
                d.muvad = txtMuvAd.Text;
                d.muvsoy = txtMuvSoy.Text;
                d.karsiad = txtKarAdi.Text;
                d.karsisoy = txtKarSoy.Text;
                d.mahno = txtMahNo.Text;
                d.mahkadi = cboMadi.Text.ToString();
                d.esasno = txtEsNo.Text;
                d.kararno = txtKarNo.Text;
                d.yer = txtDvYer.Text;
                d.tarih = txtTarih.Text == string.Empty ? DateTime.Now.Date.ToString() : txtTarih.Text;
                d.saat = txtSaat.Text == string.Empty ? DateTime.Now.TimeOfDay.ToString(): txtTarih.Text;
                if (chcArsiv.Checked) { d.arsiv = 1; }
                else d.arsiv = 0;
                d.aciklama = txtAciklama.Text;
                d.noti = txtNot.Text;
                bool deger = dORM.DavaEkle(d);
                if (deger) MessageBox.Show("Dosya Kaydedildi", "Dosya", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Dosya Kaydedilirken Sorun Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            KontrolleriTemizle();
            VeriOku();
        }

        public void VeriOku()
        {
            dataGridView1.DataSource = DavaORM.DavaGetir();
            Tables.DataGridViewDavaAra(dataGridView1);
            lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();

            dataGridView2.DataSource = VekilORM.VekilGetir();
            Tables.DataGridViewMuvAra(dataGridView2);
            lbltoplm.Text = ToplamMuv().ToString();
        }

        private void Combobox()
        {
            cboMadi.ValueMember = "Sira";
            cboMadi.DisplayMember = "Adi";
            cboMadi.DataSource = MahkemeORM.MahkemeListele();

            cboMah.ValueMember = "Sira";
            cboMah.DisplayMember = "Adi";
            cboMah.DataSource = MahkemeORM.MahkemeListele();

        }
        private int ToplamDava()
        {
            int dava = 1;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dava = i;
            }
            return dava + 1;
        }
        private int ToplamMuv()
        {
            int muv = 1;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                muv = i;
            }
            return muv + 1;
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void btnBul_Click(object sender, EventArgs e)
        {
            if (rdoTus.Checked)
            {

                //string mahalle = "";
                //var cbSelected = cboMah.SelectedItem as DataRowView;
                //if (cbSelected != null)
                //{
                //    mahalle = (string)cbSelected["Adi"];
                //}

                Davalar d = new Davalar();
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtDno_TextChanged(object sender, EventArgs e)
        {
            Davalar d = new Davalar();
            if (rdoHizli.Checked)
            {
                d.dno = txtDno.Text;
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtEno_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                d.esasno = txtEno.Text;
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtKno_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                d.kararno = txtKno.Text;
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtMuAd_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                // d.muvad = (txtMuAd.Text ?? "").Trim();
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }


        }

        private void txtMuSoy_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                //d.muvsoy = (txtMuSoy.Text ?? "").Trim();
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }

        }

        private void txtMno_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                //d.mahno = txtMno.Text;
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void cboMah_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                // d.mahkadi = cboMah.Text;
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtKarAd_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                // d.karsiad = txtKarAd.Text;
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtKSoy_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                //d.karsisoy = txtKSoy.Text;
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }



        private void txtYer_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                //d.yer = txtYer.Text;
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtBilgi_TextChanged(object sender, EventArgs e)
        {
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                //d.noti = txtBilgi.Text;
                Aramalar(d);
                dataGridView1.DataSource = DavaORM.DavaBilgiAraBastikca(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDno.Text = String.Empty;
            txtEno.Text = String.Empty;
            txtKno.Text = String.Empty;
            txtMuAd.Text = String.Empty;
            txtMuSoy.Text = String.Empty;
            txtMno.Text = String.Empty;
            txtKarAd.Text = String.Empty;
            txtKSoy.Text = String.Empty;
            txtYer.Text = String.Empty;
            txtBilgi.Text = String.Empty;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (dataGridView1.SelectedRows.Count != 0)
            {
                Davalar d = new Davalar();
                d.ID = id;
                bool deger = DavaORM.DavaSil(d);
                if (deger)
                {
                    MessageBox.Show("Dava Silindi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VeriOku();
                    lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
                }
                else MessageBox.Show("Dava Silinirken Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Lütfen Dava Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                Tools.dava_id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                DavaBilgileri();
                tabControl1.SelectedTab = tabPage2;
                btnGuncelle.Enabled = true;
            }
            else MessageBox.Show("Lütfen Dava Seçiniz");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            byte durum;
            if (chcArsiv.Checked) { durum = 1; }
            else durum = 0;
            try
            {
                DavaORM dORM = new DavaORM();
                Davalar d = new Davalar();
                d.ID = Tools.dava_id;
                d.dno = txtDosyaNo.Text;
                d.muvad = txtMuvAd.Text;
                d.muvsoy = txtMuvSoy.Text;
                d.karsiad = txtKarAdi.Text;
                d.karsisoy = txtKarSoy.Text;
                d.mahkadi = cboMadi.Text.ToString();
                d.mahno = txtMahNo.Text;
                d.kararno = txtKarNo.Text;
                d.esasno = txtEsNo.Text;
                d.tarih = txtTarih.Text;
                d.aciklama = txtAciklama.Text;
                d.saat = txtSaat.Text;
                d.noti = txtNot.Text;
                d.yer = txtDvYer.Text;
                d.arsiv = durum;
                bool deger = dORM.DavaGuncelle(d);
                if (deger)
                {
                    MessageBox.Show("Dava Güncellendi", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VeriOku();
                    tabControl1.SelectedTab = tabPage1;
                    KontrolleriTemizle();
                }
                else MessageBox.Show("Dava Güncellenirken Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnGuncelle.Enabled = false;
            KontrolleriTemizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                VekilORM vORM = new VekilORM();
                vek v = new vek();
                v.adi = txtMadi.Text;
                v.soyadi = txtMsoy.Text;
                v.vno = txtVno.Text;
                bool deger = vORM.VekilEkle(v);
                if (deger) MessageBox.Show("Müvekkil Kaydedildi", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Müvekkil  Kaydedilirken Sorun Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            VeriOku();

        }

        void VekilTemizle()
        {
            txtMadi.Text = string.Empty;
            txtMsoy.Text = string.Empty;
            txtVno.Text = string.Empty;
        }

        private void btnClears_Click(object sender, EventArgs e)
        {
            VekilTemizle();
            VeriOku();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                int id = (int)dataGridView2.CurrentRow.Cells[0].Value;
                if (dataGridView2.SelectedRows.Count != 0)
                {
                    vek v = new vek();
                    v.ID = id;
                    bool deger = VekilORM.VekilSil(v);
                    if (deger)
                    {
                        MessageBox.Show("Vekil Silindi", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Vekil Silinirken Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Lütfen Vekil Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                VeriOku();
                VekilTemizle();
            }
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void btnVduzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                try
                {

                    VekilORM vORM = new VekilORM();
                    vek v = new vek();
                    v.ID = Tools.vek_id;
                    v.adi = txtMadi.Text;
                    v.soyadi = txtMsoy.Text;
                    v.vno = txtVno.Text;
                    bool deger = vORM.VekilGuncelle(v);
                    if (deger)
                    {
                        MessageBox.Show("Dava Güncellendi", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VeriOku();
                    }
                    else MessageBox.Show("Dava Güncellenirken Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Düzenlenecek Vekil Seçiniz");
            VekilTemizle();

        }


        private void txtMadiAra_TextChanged(object sender, EventArgs e)
        {

            if (rdoHizliAra.Checked)
            {
                vek v = new vek();
                VekArama(v);
                
                //v.adi = txtMadiAra.Text;
                dataGridView2.DataSource = VekilORM.VekilArama(v);
                Tables.DataGridViewMuvAra(dataGridView2);
                lbltoplm.Text = ToplamMuv().ToString();
            }

        }

        private void txtMsoyAra_TextChanged(object sender, EventArgs e)
        {
            vek v = new vek();
            if (rdoHizliAra.Checked)
            {
                VekArama(v);
                //v.soyadi = txtMsoyAra.Text;
                dataGridView2.DataSource = VekilORM.VekilArama(v);
                Tables.DataGridViewMuvAra(dataGridView2);
                lbltoplm.Text = ToplamMuv().ToString();
            }
        }

        private void txtMnoAra_TextChanged(object sender, EventArgs e)
        {
            vek v = new vek();
            if (rdoHizliAra.Checked)
            {
                VekArama(v);
                //v.vno = txtMnoAra.Text;
                dataGridView2.DataSource = VekilORM.VekilArama(v);
                Tables.DataGridViewMuvAra(dataGridView2);
                lbltoplm.Text = ToplamMuv().ToString();
            }
        }


        private void btnYazdir_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView1);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(dataGridView2);
        }

        private void btnVara_Click(object sender, EventArgs e)
        {
            if (rdoBastikcaAra.Checked)
            {
                vek v = new vek();
                v.adi = (txtMadiAra.Text ?? "").Trim();
                v.soyadi = (txtMsoyAra.Text ?? "").Trim();
                v.vno = (txtMnoAra.Text ?? "").Trim();
                dataGridView2.DataSource = VekilORM.VekilArama(v);
                Tables.DataGridViewMuvAra(dataGridView2);
                 lbltoplm.Text = ToplamMuv().ToString();

              
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            Tools.vek_id = (int)dataGridView2.CurrentRow.Cells[0].Value;
            txtMadi.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtMsoy.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtVno.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {

            excele_aktar(dataGridView1);
        }

        void excele_aktar(DataGridView dg)
        {
            dg.AllowUserToAddRows = false;
            System.Globalization.CultureInfo dil = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
            Microsoft.Office.Interop.Excel.Application Tablo = new Microsoft.Office.Interop.Excel.Application();
            Workbook kitap = Tablo.Workbooks.Add(true);
            Worksheet sayfa = (Worksheet)Tablo.ActiveSheet;
            System.Threading.Thread.CurrentThread.CurrentCulture = dil;
            Tablo.Visible = true;
            sayfa = (Worksheet)kitap.ActiveSheet;
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (i == 0)
                    {
                        Tablo.Cells[1, j + 1] = dg.Columns[j].HeaderText;
                    }
                    Tablo.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();
                }
            }
            Tablo.Visible = true;
            Tablo.UserControl = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            VeriOku();
        }

        private void txtTarih2_TextChanged(object sender, EventArgs e)
        {
            txtTarih.MaxLength = 10;
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                d.tarih = txtTarih1.Text;
                d.tarih2 = txtTarih2.Text;
                dataGridView1.DataSource = DavaORM.DavaTarihAra(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtTarih1_TextChanged(object sender, EventArgs e)
        {
            txtTarih.MaxLength = 10;
            if (rdoHizli.Checked)
            {
                Davalar d = new Davalar();
                d.tarih = txtTarih1.Text;
                d.tarih2 = txtTarih2.Text;
                dataGridView1.DataSource = DavaORM.DavaTarihAra(d);
                Tables.DataGridViewDavaAra(dataGridView1);
                lblToplam.Text = "Toplam Kayıt Sayısı :" + ToplamDava().ToString();
            }
        }

        private void txtTarih_TextChanged(object sender, EventArgs e)
        {
            txtTarih.MaxLength = 10;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            KontrolleriTemizle();
        }

        private void Aramalar(Davalar d)
        {
            d.dno = (txtDno.Text ?? "").Trim();
            d.muvad = (txtMuAd.Text ?? "").Trim();
            d.esasno = (txtEno.Text ?? "").Trim();
            d.kararno = (txtKno.Text ?? "").Trim();
            d.muvsoy = (txtMuSoy.Text ?? "").Trim();
            d.mahno = (txtMno.Text ?? "").Trim();
            d.mahkadi = (cboMah.Text ?? "").Trim();
            d.karsiad = (txtKarAd.Text ?? "").Trim();
            d.karsisoy = (txtKSoy.Text ?? "").Trim();
            d.tarih = (txtTarih1.Text ?? "").Trim();
            d.tarih2 = (txtTarih2.Text ?? "").Trim();
            d.yer = (txtYer.Text ?? "").Trim();
            d.noti = (txtBilgi.Text ?? "").Trim();
        }

        private void VekArama(vek v)
        {
            v.adi = (txtMadiAra.Text ?? "").Trim();
            v.soyadi = (txtMsoyAra.Text ?? "").Trim();
            v.vno = (txtMnoAra.Text ?? "").Trim();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();

        }
    }
}

   


