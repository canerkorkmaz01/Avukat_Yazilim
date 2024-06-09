using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrintDataGrid
{
    public partial class PrintOptions : Form
    {
        public PrintOptions()
        {
            InitializeComponent();
        }
        public PrintOptions(List<string> availableFields)
        {
            InitializeComponent();

            foreach (string field in availableFields)
                chklst.Items.Add(field, true);
        }

     
       

      

        public List<string> GetSelectedColumns()
        {
            List<string> lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
                lst.Add(item.ToString());
            return lst;
        }

        public string PrintTitle
        {
            get { return txtTitle.Text; }
        }

        public bool PrintAllRows
        {
            get { return rdoAllRows.Checked; }
        }

        public bool FitToPageWidth
        {
            get { return chkFitToPageWidth.Checked; }
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PrintOptions_Load(object sender, EventArgs e)
        {
            // Initialize some controls
            rdoAllRows.Checked = true;
            chkFitToPageWidth.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rdoAllRows_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckedListBox  item in chklst.Controls)
            {
                item.CheckOnClick = true;
            }
                

        }

        private void rdoSelectedRows_CheckedChanged(object sender, EventArgs e)
        {
            chklst.CheckOnClick = false;
        }

        private void chkFitToPageWidth_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gboxRowsToPrint_Enter(object sender, EventArgs e)
        {

        }
    }
}