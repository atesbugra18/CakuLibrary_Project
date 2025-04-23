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
            this.components = new System.ComponentModel.Container();
            this.grboxKategorisildüzenle = new System.Windows.Forms.GroupBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.btndegistir = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.chkKategoriadi = new System.Windows.Forms.CheckBox();
            this.txtKategoriadi = new System.Windows.Forms.TextBox();
            this.lblKategoriAdi = new System.Windows.Forms.Label();
            this.lboxkategori = new System.Windows.Forms.ListBox();
            this.btngizle = new System.Windows.Forms.Button();
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            this.grboxKategorisildüzenle.SuspendLayout();
            this.SuspendLayout();
            // 
            // grboxKategorisildüzenle
            // 
            this.grboxKategorisildüzenle.Controls.Add(this.btngizle);
            this.grboxKategorisildüzenle.Controls.Add(this.lboxkategori);
            this.grboxKategorisildüzenle.Controls.Add(this.btnclose);
            this.grboxKategorisildüzenle.Controls.Add(this.btndegistir);
            this.grboxKategorisildüzenle.Controls.Add(this.btnsil);
            this.grboxKategorisildüzenle.Controls.Add(this.chkKategoriadi);
            this.grboxKategorisildüzenle.Controls.Add(this.txtKategoriadi);
            this.grboxKategorisildüzenle.Controls.Add(this.lblKategoriAdi);
            this.grboxKategorisildüzenle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grboxKategorisildüzenle.Location = new System.Drawing.Point(0, 0);
            this.grboxKategorisildüzenle.Name = "grboxKategorisildüzenle";
            this.grboxKategorisildüzenle.Size = new System.Drawing.Size(875, 605);
            this.grboxKategorisildüzenle.TabIndex = 0;
            this.grboxKategorisildüzenle.TabStop = false;
            this.grboxKategorisildüzenle.Text = "Kategori Sil && Düzenle";
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(822, 21);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(40, 40);
            this.btnclose.TabIndex = 7;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btndegistir
            // 
            this.btndegistir.Location = new System.Drawing.Point(510, 354);
            this.btndegistir.Name = "btndegistir";
            this.btndegistir.Size = new System.Drawing.Size(168, 37);
            this.btndegistir.TabIndex = 6;
            this.btndegistir.Text = "Değiştir";
            this.btndegistir.UseVisualStyleBackColor = true;
            this.btndegistir.Click += new System.EventHandler(this.btndegistir_Click);
            // 
            // btnsil
            // 
            this.btnsil.Location = new System.Drawing.Point(700, 354);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(168, 37);
            this.btnsil.TabIndex = 5;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // chkKategoriadi
            // 
            this.chkKategoriadi.AutoSize = true;
            this.chkKategoriadi.Location = new System.Drawing.Point(522, 325);
            this.chkKategoriadi.Name = "chkKategoriadi";
            this.chkKategoriadi.Size = new System.Drawing.Size(15, 14);
            this.chkKategoriadi.TabIndex = 2;
            this.chkKategoriadi.UseVisualStyleBackColor = true;
            this.chkKategoriadi.CheckedChanged += new System.EventHandler(this.chkKategoriadi_CheckedChanged);
            // 
            // txtKategoriadi
            // 
            this.txtKategoriadi.Location = new System.Drawing.Point(657, 315);
            this.txtKategoriadi.MaxLength = 25;
            this.txtKategoriadi.Name = "txtKategoriadi";
            this.txtKategoriadi.ReadOnly = true;
            this.txtKategoriadi.Size = new System.Drawing.Size(211, 33);
            this.txtKategoriadi.TabIndex = 1;
            // 
            // lblKategoriAdi
            // 
            this.lblKategoriAdi.AutoSize = true;
            this.lblKategoriAdi.Location = new System.Drawing.Point(527, 318);
            this.lblKategoriAdi.Name = "lblKategoriAdi";
            this.lblKategoriAdi.Size = new System.Drawing.Size(124, 26);
            this.lblKategoriAdi.TabIndex = 0;
            this.lblKategoriAdi.Text = "Kategori Adı:";
            // 
            // lboxkategori
            // 
            this.lboxkategori.BackColor = System.Drawing.Color.LightBlue;
            this.lboxkategori.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lboxkategori.FormattingEnabled = true;
            this.lboxkategori.ItemHeight = 26;
            this.lboxkategori.Location = new System.Drawing.Point(12, 32);
            this.lboxkategori.Name = "lboxkategori";
            this.lboxkategori.Size = new System.Drawing.Size(310, 550);
            this.lboxkategori.TabIndex = 8;
            this.lboxkategori.SelectedIndexChanged += new System.EventHandler(this.lboxkategori_SelectedIndexChanged);
            // 
            // btngizle
            // 
            this.btngizle.BackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatAppearance.BorderSize = 0;
            this.btngizle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngizle.Location = new System.Drawing.Point(776, 21);
            this.btngizle.Name = "btngizle";
            this.btngizle.Size = new System.Drawing.Size(40, 40);
            this.btngizle.TabIndex = 9;
            this.btngizle.UseVisualStyleBackColor = false;
            this.btngizle.Click += new System.EventHandler(this.btngizle_Click);
            // 
            // timerclose
            // 
            this.timerclose.Interval = 80;
            this.timerclose.Tick += new System.EventHandler(this.timerclose_Tick);
            // 
            // KategoriSilDuzenle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(875, 605);
            this.Controls.Add(this.grboxKategorisildüzenle);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KategoriSilDuzenle";
            this.Text = "KategoriSilDuzenle";
            this.Load += new System.EventHandler(this.KategoriSilDuzenle_Load);
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
        private System.Windows.Forms.ListBox lboxkategori;
        private System.Windows.Forms.Button btngizle;
        private System.Windows.Forms.Timer timerclose;
    }
}