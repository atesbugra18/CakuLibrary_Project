namespace Kutuphane.ChildFormsKitap
{
    partial class KategoriSilDuzenle
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
            this.grboxKategorisildüzenle = new System.Windows.Forms.GroupBox();
            this.lblKategoriAdi = new System.Windows.Forms.Label();
            this.txtKategoriadi = new System.Windows.Forms.TextBox();
            this.chkKategoriadi = new System.Windows.Forms.CheckBox();
            this.btnsil = new System.Windows.Forms.Button();
            this.btndegistir = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.grboxKategorisildüzenle.SuspendLayout();
            this.SuspendLayout();
            // 
            // grboxKategorisildüzenle
            // 
            this.grboxKategorisildüzenle.Controls.Add(this.btnclose);
            this.grboxKategorisildüzenle.Controls.Add(this.btndegistir);
            this.grboxKategorisildüzenle.Controls.Add(this.btnsil);
            this.grboxKategorisildüzenle.Controls.Add(this.chkKategoriadi);
            this.grboxKategorisildüzenle.Controls.Add(this.txtKategoriadi);
            this.grboxKategorisildüzenle.Controls.Add(this.lblKategoriAdi);
            this.grboxKategorisildüzenle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grboxKategorisildüzenle.Location = new System.Drawing.Point(0, 0);
            this.grboxKategorisildüzenle.Name = "grboxKategorisildüzenle";
            this.grboxKategorisildüzenle.Size = new System.Drawing.Size(890, 605);
            this.grboxKategorisildüzenle.TabIndex = 0;
            this.grboxKategorisildüzenle.TabStop = false;
            this.grboxKategorisildüzenle.Text = "Kategori Sil && Düzenle";
            // 
            // lblKategoriAdi
            // 
            this.lblKategoriAdi.AutoSize = true;
            this.lblKategoriAdi.Location = new System.Drawing.Point(12, 41);
            this.lblKategoriAdi.Name = "lblKategoriAdi";
            this.lblKategoriAdi.Size = new System.Drawing.Size(124, 26);
            this.lblKategoriAdi.TabIndex = 0;
            this.lblKategoriAdi.Text = "Kategori Adı:";
            // 
            // txtKategoriadi
            // 
            this.txtKategoriadi.Location = new System.Drawing.Point(142, 38);
            this.txtKategoriadi.MaxLength = 25;
            this.txtKategoriadi.Name = "txtKategoriadi";
            this.txtKategoriadi.Size = new System.Drawing.Size(200, 33);
            this.txtKategoriadi.TabIndex = 1;
            // 
            // chkKategoriadi
            // 
            this.chkKategoriadi.AutoSize = true;
            this.chkKategoriadi.Location = new System.Drawing.Point(358, 40);
            this.chkKategoriadi.Name = "chkKategoriadi";
            this.chkKategoriadi.Size = new System.Drawing.Size(97, 30);
            this.chkKategoriadi.TabIndex = 2;
            this.chkKategoriadi.Text = "Değiştir";
            this.chkKategoriadi.UseVisualStyleBackColor = true;
            // 
            // btnsil
            // 
            this.btnsil.Location = new System.Drawing.Point(710, 155);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(168, 37);
            this.btnsil.TabIndex = 5;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            // 
            // btndegistir
            // 
            this.btndegistir.Location = new System.Drawing.Point(520, 155);
            this.btndegistir.Name = "btndegistir";
            this.btndegistir.Size = new System.Drawing.Size(168, 37);
            this.btndegistir.TabIndex = 6;
            this.btndegistir.Text = "Değiştir";
            this.btndegistir.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(838, 27);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(40, 40);
            this.btnclose.TabIndex = 7;
            this.btnclose.UseVisualStyleBackColor = false;
            // 
            // KategoriSilDuzenle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(890, 605);
            this.Controls.Add(this.grboxKategorisildüzenle);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KategoriSilDuzenle";
            this.Text = "KategoriSilDuzenle";
            this.grboxKategorisildüzenle.ResumeLayout(false);
            this.grboxKategorisildüzenle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grboxKategorisildüzenle;
        private System.Windows.Forms.CheckBox chkKategoriadi;
        private System.Windows.Forms.TextBox txtKategoriadi;
        private System.Windows.Forms.Label lblKategoriAdi;
        private System.Windows.Forms.Button btndegistir;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnclose;
    }
}