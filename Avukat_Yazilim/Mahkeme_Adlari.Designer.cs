namespace Avukat_Yazilim
{
    partial class Mahkeme_Adlari
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mahkeme_Adlari));
            this.txtMahkeme = new System.Windows.Forms.TextBox();
            this.lstMahkeme = new System.Windows.Forms.ListBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMahkeme
            // 
            resources.ApplyResources(this.txtMahkeme, "txtMahkeme");
            this.txtMahkeme.Name = "txtMahkeme";
            // 
            // lstMahkeme
            // 
            this.lstMahkeme.FormattingEnabled = true;
            this.lstMahkeme.Items.AddRange(new object[] {
            resources.GetString("lstMahkeme.Items")});
            resources.ApplyResources(this.lstMahkeme, "lstMahkeme");
            this.lstMahkeme.Name = "lstMahkeme";
            this.lstMahkeme.Click += new System.EventHandler(this.lstMahkeme_Click);
            // 
            // btnSil
            // 
            resources.ApplyResources(this.btnSil, "btnSil");
            this.btnSil.Image = global::Avukat_Yazilim.Properties.Resources.cop;
            this.btnSil.Name = "btnSil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            resources.ApplyResources(this.btnKaydet, "btnKaydet");
            this.btnKaydet.Image = global::Avukat_Yazilim.Properties.Resources.save;
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // Mahkeme_Adlari
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lstMahkeme);
            this.Controls.Add(this.txtMahkeme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mahkeme_Adlari";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Mahkeme_Adlari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMahkeme;
        private System.Windows.Forms.ListBox lstMahkeme;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnKaydet;
    }
}