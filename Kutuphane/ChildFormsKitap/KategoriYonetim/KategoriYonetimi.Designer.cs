namespace Kutuphane.ChildFormsKitap.KategoriYonetim
{
    partial class KategoriYonetimi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelcocuk = new System.Windows.Forms.Panel();
            this.panelkontroller = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kategoriid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategoriadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelara = new System.Windows.Forms.Panel();
            this.txtara = new System.Windows.Forms.TextBox();
            this.lblara = new System.Windows.Forms.Label();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.btnkategorisilduzenle = new FontAwesome.Sharp.IconButton();
            this.btnkategoriekle = new FontAwesome.Sharp.IconButton();
            this.panelheader = new System.Windows.Forms.Panel();
            this.btnhide = new System.Windows.Forms.Button();
            this.btnbig = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.kategorislemleri = new FontAwesome.Sharp.IconButton();
            this.panelkontroller.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelara.SuspendLayout();
            this.panelmenu.SuspendLayout();
            this.panelheader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelcocuk
            // 
            this.panelcocuk.Location = new System.Drawing.Point(0, 0);
            this.panelcocuk.Name = "panelcocuk";
            this.panelcocuk.Size = new System.Drawing.Size(1100, 800);
            this.panelcocuk.TabIndex = 0;
            // 
            // panelkontroller
            // 
            this.panelkontroller.Controls.Add(this.groupBox1);
            this.panelkontroller.Controls.Add(this.panelara);
            this.panelkontroller.Controls.Add(this.panelmenu);
            this.panelkontroller.Controls.Add(this.panelheader);
            this.panelkontroller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelkontroller.Location = new System.Drawing.Point(0, 0);
            this.panelkontroller.Name = "panelkontroller";
            this.panelkontroller.Size = new System.Drawing.Size(1100, 800);
            this.panelkontroller.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 662);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kategoriler";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kategoriid,
            this.Kategoriadi});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(894, 636);
            this.dataGridView1.TabIndex = 0;
            // 
            // kategoriid
            // 
            this.kategoriid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.kategoriid.DataPropertyName = "kategoriid";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kategoriid.DefaultCellStyle = dataGridViewCellStyle7;
            this.kategoriid.HeaderText = "Kategori Id";
            this.kategoriid.Name = "kategoriid";
            this.kategoriid.ReadOnly = true;
            this.kategoriid.Width = 109;
            // 
            // Kategoriadi
            // 
            this.Kategoriadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kategoriadi.DataPropertyName = "kategoriadi";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Kategoriadi.DefaultCellStyle = dataGridViewCellStyle8;
            this.Kategoriadi.HeaderText = "Kategori Adı";
            this.Kategoriadi.Name = "Kategoriadi";
            this.Kategoriadi.ReadOnly = true;
            // 
            // panelara
            // 
            this.panelara.Controls.Add(this.txtara);
            this.panelara.Controls.Add(this.lblara);
            this.panelara.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelara.Location = new System.Drawing.Point(0, 100);
            this.panelara.Name = "panelara";
            this.panelara.Size = new System.Drawing.Size(900, 38);
            this.panelara.TabIndex = 2;
            // 
            // txtara
            // 
            this.txtara.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtara.Location = new System.Drawing.Point(0, 15);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(900, 23);
            this.txtara.TabIndex = 1;
            this.txtara.TextChanged += new System.EventHandler(this.txtara_TextChanged);
            // 
            // lblara
            // 
            this.lblara.AutoSize = true;
            this.lblara.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblara.Location = new System.Drawing.Point(0, 0);
            this.lblara.Name = "lblara";
            this.lblara.Size = new System.Drawing.Size(30, 15);
            this.lblara.TabIndex = 0;
            this.lblara.Text = "Ara:";
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelmenu.Controls.Add(this.btnkategorisilduzenle);
            this.panelmenu.Controls.Add(this.btnkategoriekle);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelmenu.Location = new System.Drawing.Point(900, 100);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(200, 700);
            this.panelmenu.TabIndex = 1;
            // 
            // btnkategorisilduzenle
            // 
            this.btnkategorisilduzenle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnkategorisilduzenle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkategorisilduzenle.FlatAppearance.BorderSize = 0;
            this.btnkategorisilduzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkategorisilduzenle.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnkategorisilduzenle.IconColor = System.Drawing.Color.Black;
            this.btnkategorisilduzenle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkategorisilduzenle.IconSize = 30;
            this.btnkategorisilduzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkategorisilduzenle.Location = new System.Drawing.Point(0, 35);
            this.btnkategorisilduzenle.Name = "btnkategorisilduzenle";
            this.btnkategorisilduzenle.Size = new System.Drawing.Size(200, 35);
            this.btnkategorisilduzenle.TabIndex = 3;
            this.btnkategorisilduzenle.Text = "Kategori Sil && Düzenle";
            this.btnkategorisilduzenle.UseVisualStyleBackColor = false;
            this.btnkategorisilduzenle.Click += new System.EventHandler(this.btnkategorisilduzenle_Click);
            // 
            // btnkategoriekle
            // 
            this.btnkategoriekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnkategoriekle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkategoriekle.FlatAppearance.BorderSize = 0;
            this.btnkategoriekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkategoriekle.ForeColor = System.Drawing.Color.Black;
            this.btnkategoriekle.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            this.btnkategoriekle.IconColor = System.Drawing.Color.Black;
            this.btnkategoriekle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkategoriekle.IconSize = 30;
            this.btnkategoriekle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkategoriekle.Location = new System.Drawing.Point(0, 0);
            this.btnkategoriekle.Name = "btnkategoriekle";
            this.btnkategoriekle.Size = new System.Drawing.Size(200, 35);
            this.btnkategoriekle.TabIndex = 2;
            this.btnkategoriekle.Text = "Kategori Ekle";
            this.btnkategoriekle.UseVisualStyleBackColor = false;
            this.btnkategoriekle.Click += new System.EventHandler(this.btnkategoriekle_Click);
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Controls.Add(this.btnhide);
            this.panelheader.Controls.Add(this.btnbig);
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.kategorislemleri);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1100, 100);
            this.panelheader.TabIndex = 0;
            // 
            // btnhide
            // 
            this.btnhide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnhide.BackColor = System.Drawing.Color.Transparent;
            this.btnhide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnhide.FlatAppearance.BorderSize = 0;
            this.btnhide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnhide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnhide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhide.Location = new System.Drawing.Point(1037, 12);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(15, 15);
            this.btnhide.TabIndex = 14;
            this.btnhide.UseVisualStyleBackColor = false;
            // 
            // btnbig
            // 
            this.btnbig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbig.BackColor = System.Drawing.Color.Transparent;
            this.btnbig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbig.Enabled = false;
            this.btnbig.FlatAppearance.BorderSize = 0;
            this.btnbig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnbig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnbig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbig.Location = new System.Drawing.Point(1058, 12);
            this.btnbig.Name = "btnbig";
            this.btnbig.Size = new System.Drawing.Size(15, 15);
            this.btnbig.TabIndex = 13;
            this.btnbig.UseVisualStyleBackColor = false;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(1079, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(15, 15);
            this.btnclose.TabIndex = 12;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // kategorislemleri
            // 
            this.kategorislemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.kategorislemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kategorislemleri.Dock = System.Windows.Forms.DockStyle.Left;
            this.kategorislemleri.FlatAppearance.BorderSize = 0;
            this.kategorislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kategorislemleri.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kategorislemleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.kategorislemleri.IconChar = FontAwesome.Sharp.IconChar.FolderTree;
            this.kategorislemleri.IconColor = System.Drawing.Color.Gainsboro;
            this.kategorislemleri.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.kategorislemleri.IconSize = 30;
            this.kategorislemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kategorislemleri.Location = new System.Drawing.Point(0, 0);
            this.kategorislemleri.Name = "kategorislemleri";
            this.kategorislemleri.Size = new System.Drawing.Size(168, 100);
            this.kategorislemleri.TabIndex = 11;
            this.kategorislemleri.Text = "Kategori Yönetimi";
            this.kategorislemleri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kategorislemleri.UseVisualStyleBackColor = false;
            this.kategorislemleri.MouseEnter += new System.EventHandler(this.kategorislemleri_MouseEnter);
            this.kategorislemleri.MouseLeave += new System.EventHandler(this.kategorislemleri_MouseLeave);
            // 
            // KategoriYonetimi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panelkontroller);
            this.Controls.Add(this.panelcocuk);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KategoriYonetimi";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KategoriYonetimi_Load);
            this.panelkontroller.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelara.ResumeLayout(false);
            this.panelara.PerformLayout();
            this.panelmenu.ResumeLayout(false);
            this.panelheader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelcocuk;
        private System.Windows.Forms.Panel panelkontroller;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelara;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.Label lblara;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnbig;
        private System.Windows.Forms.Button btnclose;
        private FontAwesome.Sharp.IconButton kategorislemleri;
        private FontAwesome.Sharp.IconButton btnkategorisilduzenle;
        private FontAwesome.Sharp.IconButton btnkategoriekle;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategoriid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategoriadi;
    }
}