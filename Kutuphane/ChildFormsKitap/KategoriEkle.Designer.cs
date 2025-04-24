namespace Kutuphane.ChildFormsKitap
{
    partial class KategoriEkle
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
            this.grboxkategoriekle = new System.Windows.Forms.GroupBox();
            this.btnkategoriekle = new System.Windows.Forms.Button();
            this.txtkategoriadi = new System.Windows.Forms.TextBox();
            this.lblkategoriadi = new System.Windows.Forms.Label();
            this.btngizle = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            this.lblmevcutkategoriler = new System.Windows.Forms.Label();
            this.lboxkategori = new System.Windows.Forms.ListBox();
            this.lblinfo = new System.Windows.Forms.Label();
            this.grboxkategoriekle.SuspendLayout();
            this.SuspendLayout();
            // 
            // grboxkategoriekle
            // 
            this.grboxkategoriekle.Controls.Add(this.lblinfo);
            this.grboxkategoriekle.Controls.Add(this.lblmevcutkategoriler);
            this.grboxkategoriekle.Controls.Add(this.lboxkategori);
            this.grboxkategoriekle.Controls.Add(this.btngizle);
            this.grboxkategoriekle.Controls.Add(this.btnclose);
            this.grboxkategoriekle.Controls.Add(this.btnkategoriekle);
            this.grboxkategoriekle.Controls.Add(this.txtkategoriadi);
            this.grboxkategoriekle.Controls.Add(this.lblkategoriadi);
            this.grboxkategoriekle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grboxkategoriekle.Location = new System.Drawing.Point(0, 0);
            this.grboxkategoriekle.Name = "grboxkategoriekle";
            this.grboxkategoriekle.Size = new System.Drawing.Size(875, 605);
            this.grboxkategoriekle.TabIndex = 0;
            this.grboxkategoriekle.TabStop = false;
            this.grboxkategoriekle.Text = "Kategori Ekle";
            // 
            // btnkategoriekle
            // 
            this.btnkategoriekle.Location = new System.Drawing.Point(692, 527);
            this.btnkategoriekle.Name = "btnkategoriekle";
            this.btnkategoriekle.Size = new System.Drawing.Size(168, 37);
            this.btnkategoriekle.TabIndex = 2;
            this.btnkategoriekle.Text = "Kategori Ekle";
            this.btnkategoriekle.UseVisualStyleBackColor = true;
            this.btnkategoriekle.Click += new System.EventHandler(this.btnkategoriekle_Click);
            // 
            // txtkategoriadi
            // 
            this.txtkategoriadi.Location = new System.Drawing.Point(660, 457);
            this.txtkategoriadi.Name = "txtkategoriadi";
            this.txtkategoriadi.Size = new System.Drawing.Size(200, 33);
            this.txtkategoriadi.TabIndex = 1;
            this.txtkategoriadi.TextChanged += new System.EventHandler(this.txtkategoriadi_TextChanged);
            // 
            // lblkategoriadi
            // 
            this.lblkategoriadi.AutoSize = true;
            this.lblkategoriadi.Location = new System.Drawing.Point(523, 460);
            this.lblkategoriadi.Name = "lblkategoriadi";
            this.lblkategoriadi.Size = new System.Drawing.Size(131, 26);
            this.lblkategoriadi.TabIndex = 0;
            this.lblkategoriadi.Text = "Kategori Ekle:";
            // 
            // btngizle
            // 
            this.btngizle.BackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatAppearance.BorderSize = 0;
            this.btngizle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngizle.Location = new System.Drawing.Point(770, 20);
            this.btngizle.Name = "btngizle";
            this.btngizle.Size = new System.Drawing.Size(40, 40);
            this.btngizle.TabIndex = 11;
            this.btngizle.UseVisualStyleBackColor = false;
            this.btngizle.Click += new System.EventHandler(this.btngizle_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(820, 20);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(40, 40);
            this.btnclose.TabIndex = 10;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // timerclose
            // 
            this.timerclose.Interval = 80;
            this.timerclose.Tick += new System.EventHandler(this.timerclose_Tick);
            // 
            // lblmevcutkategoriler
            // 
            this.lblmevcutkategoriler.AutoSize = true;
            this.lblmevcutkategoriler.Location = new System.Drawing.Point(47, 27);
            this.lblmevcutkategoriler.Name = "lblmevcutkategoriler";
            this.lblmevcutkategoriler.Size = new System.Drawing.Size(236, 26);
            this.lblmevcutkategoriler.TabIndex = 13;
            this.lblmevcutkategoriler.Text = "Mevcut Kategoriler Listesi";
            // 
            // lboxkategori
            // 
            this.lboxkategori.BackColor = System.Drawing.Color.LightBlue;
            this.lboxkategori.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lboxkategori.FormattingEnabled = true;
            this.lboxkategori.ItemHeight = 26;
            this.lboxkategori.Location = new System.Drawing.Point(10, 56);
            this.lboxkategori.Name = "lboxkategori";
            this.lboxkategori.ScrollAlwaysVisible = true;
            this.lboxkategori.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lboxkategori.Size = new System.Drawing.Size(310, 524);
            this.lboxkategori.Sorted = true;
            this.lboxkategori.TabIndex = 12;
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblinfo.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblinfo.Location = new System.Drawing.Point(702, 499);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(158, 19);
            this.lblinfo.TabIndex = 14;
            this.lblinfo.Text = "Bu Kategori Zaten Var";
            this.lblinfo.Visible = false;
            // 
            // KategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(875, 605);
            this.Controls.Add(this.grboxkategoriekle);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "KategoriEkle";
            this.Text = "KategoriEkle";
            this.Load += new System.EventHandler(this.KategoriEkle_Load);
            this.grboxkategoriekle.ResumeLayout(false);
            this.grboxkategoriekle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grboxkategoriekle;
        private System.Windows.Forms.Label lblkategoriadi;
        private System.Windows.Forms.Button btnkategoriekle;
        private System.Windows.Forms.TextBox txtkategoriadi;
        private System.Windows.Forms.Button btngizle;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Timer timerclose;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.Label lblmevcutkategoriler;
        private System.Windows.Forms.ListBox lboxkategori;
    }
}