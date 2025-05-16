namespace Kutuphane.ChildFormsAnaliz
{
    partial class GecikenKitapListesi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelgenel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KullaniciAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdSoyad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KitabınYazari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kitabınadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teslimedilmesigerekentarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelara = new System.Windows.Forms.Panel();
            this.txtara = new System.Windows.Forms.TextBox();
            this.lblara = new System.Windows.Forms.Label();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.btnban = new FontAwesome.Sharp.IconButton();
            this.btnhatirlat = new FontAwesome.Sharp.IconButton();
            this.panelheader = new System.Windows.Forms.Panel();
            this.btnhide = new System.Windows.Forms.Button();
            this.btnbig = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnenaktifuyeler = new FontAwesome.Sharp.IconButton();
            this.panelgenel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelara.SuspendLayout();
            this.panelmenu.SuspendLayout();
            this.panelheader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelgenel
            // 
            this.panelgenel.Controls.Add(this.groupBox1);
            this.panelgenel.Controls.Add(this.panelara);
            this.panelgenel.Controls.Add(this.panelmenu);
            this.panelgenel.Controls.Add(this.panelheader);
            this.panelgenel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelgenel.Location = new System.Drawing.Point(0, 0);
            this.panelgenel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelgenel.Name = "panelgenel";
            this.panelgenel.Size = new System.Drawing.Size(1100, 800);
            this.panelgenel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 660);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teslim Tarihi Geçen Kitapların Listesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.KullaniciAdi,
            this.AdSoyad,
            this.KitabınYazari,
            this.Kitabınadi,
            this.Teslimedilmesigerekentarih});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(894, 634);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Id.DataPropertyName = "sirano";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Id.DefaultCellStyle = dataGridViewCellStyle2;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 47;
            // 
            // KullaniciAdi
            // 
            this.KullaniciAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KullaniciAdi.DataPropertyName = "kullaniciadi";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.KullaniciAdi.DefaultCellStyle = dataGridViewCellStyle3;
            this.KullaniciAdi.HeaderText = "Kullanıcı Adı";
            this.KullaniciAdi.Name = "KullaniciAdi";
            this.KullaniciAdi.ReadOnly = true;
            // 
            // AdSoyad
            // 
            this.AdSoyad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AdSoyad.DataPropertyName = "kullaniciadisoyadi";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AdSoyad.DefaultCellStyle = dataGridViewCellStyle4;
            this.AdSoyad.HeaderText = "Adı Soyadı";
            this.AdSoyad.Name = "AdSoyad";
            this.AdSoyad.ReadOnly = true;
            this.AdSoyad.Width = 107;
            // 
            // KitabınYazari
            // 
            this.KitabınYazari.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KitabınYazari.DataPropertyName = "yazaradisoyadi";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.KitabınYazari.DefaultCellStyle = dataGridViewCellStyle5;
            this.KitabınYazari.HeaderText = "Yazar Adı Soyadı";
            this.KitabınYazari.Name = "KitabınYazari";
            this.KitabınYazari.ReadOnly = true;
            this.KitabınYazari.Width = 146;
            // 
            // Kitabınadi
            // 
            this.Kitabınadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kitabınadi.DataPropertyName = "kitapadi";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Kitabınadi.DefaultCellStyle = dataGridViewCellStyle6;
            this.Kitabınadi.HeaderText = "Kitabın Adı";
            this.Kitabınadi.Name = "Kitabınadi";
            this.Kitabınadi.ReadOnly = true;
            // 
            // Teslimedilmesigerekentarih
            // 
            this.Teslimedilmesigerekentarih.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Teslimedilmesigerekentarih.DataPropertyName = "bitistarihi";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Teslimedilmesigerekentarih.DefaultCellStyle = dataGridViewCellStyle7;
            this.Teslimedilmesigerekentarih.HeaderText = "Teslim Edilmesi Gereken Tarih";
            this.Teslimedilmesigerekentarih.Name = "Teslimedilmesigerekentarih";
            this.Teslimedilmesigerekentarih.ReadOnly = true;
            this.Teslimedilmesigerekentarih.Width = 235;
            // 
            // panelara
            // 
            this.panelara.Controls.Add(this.txtara);
            this.panelara.Controls.Add(this.lblara);
            this.panelara.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelara.Location = new System.Drawing.Point(0, 100);
            this.panelara.Name = "panelara";
            this.panelara.Size = new System.Drawing.Size(900, 40);
            this.panelara.TabIndex = 6;
            // 
            // txtara
            // 
            this.txtara.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtara.Location = new System.Drawing.Point(0, 17);
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
            this.panelmenu.Controls.Add(this.btnban);
            this.panelmenu.Controls.Add(this.btnhatirlat);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelmenu.Location = new System.Drawing.Point(900, 100);
            this.panelmenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(200, 700);
            this.panelmenu.TabIndex = 4;
            // 
            // btnban
            // 
            this.btnban.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnban.FlatAppearance.BorderSize = 0;
            this.btnban.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnban.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnban.IconChar = FontAwesome.Sharp.IconChar.UserLargeSlash;
            this.btnban.IconColor = System.Drawing.Color.Gainsboro;
            this.btnban.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnban.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnban.Location = new System.Drawing.Point(0, 46);
            this.btnban.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnban.Name = "btnban";
            this.btnban.Size = new System.Drawing.Size(200, 46);
            this.btnban.TabIndex = 3;
            this.btnban.Text = "Banla";
            this.btnban.UseVisualStyleBackColor = true;
            this.btnban.Click += new System.EventHandler(this.btnban_Click);
            // 
            // btnhatirlat
            // 
            this.btnhatirlat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnhatirlat.FlatAppearance.BorderSize = 0;
            this.btnhatirlat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhatirlat.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnhatirlat.IconChar = FontAwesome.Sharp.IconChar.MailBulk;
            this.btnhatirlat.IconColor = System.Drawing.Color.Gainsboro;
            this.btnhatirlat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnhatirlat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhatirlat.Location = new System.Drawing.Point(0, 0);
            this.btnhatirlat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnhatirlat.Name = "btnhatirlat";
            this.btnhatirlat.Size = new System.Drawing.Size(200, 46);
            this.btnhatirlat.TabIndex = 0;
            this.btnhatirlat.Text = "Hatırlatma Yap";
            this.btnhatirlat.UseVisualStyleBackColor = true;
            this.btnhatirlat.Click += new System.EventHandler(this.btnhatirlat_Click);
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Controls.Add(this.btnhide);
            this.panelheader.Controls.Add(this.btnbig);
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.btnenaktifuyeler);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1100, 100);
            this.panelheader.TabIndex = 3;
            // 
            // btnhide
            // 
            this.btnhide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnhide.BackColor = System.Drawing.Color.Transparent;
            this.btnhide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnhide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnhide.FlatAppearance.BorderSize = 0;
            this.btnhide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnhide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnhide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhide.Location = new System.Drawing.Point(1019, 11);
            this.btnhide.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(18, 17);
            this.btnhide.TabIndex = 13;
            this.btnhide.UseVisualStyleBackColor = false;
            this.btnhide.Click += new System.EventHandler(this.btnhide_Click);
            // 
            // btnbig
            // 
            this.btnbig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbig.BackColor = System.Drawing.Color.Transparent;
            this.btnbig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnbig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbig.Enabled = false;
            this.btnbig.FlatAppearance.BorderSize = 0;
            this.btnbig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnbig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnbig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbig.Location = new System.Drawing.Point(1044, 11);
            this.btnbig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnbig.Name = "btnbig";
            this.btnbig.Size = new System.Drawing.Size(18, 17);
            this.btnbig.TabIndex = 12;
            this.btnbig.UseVisualStyleBackColor = false;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(1069, 11);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(18, 17);
            this.btnclose.TabIndex = 11;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnenaktifuyeler
            // 
            this.btnenaktifuyeler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.btnenaktifuyeler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnenaktifuyeler.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnenaktifuyeler.FlatAppearance.BorderSize = 0;
            this.btnenaktifuyeler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnenaktifuyeler.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnenaktifuyeler.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnenaktifuyeler.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.btnenaktifuyeler.IconColor = System.Drawing.Color.Gainsboro;
            this.btnenaktifuyeler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnenaktifuyeler.IconSize = 30;
            this.btnenaktifuyeler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnenaktifuyeler.Location = new System.Drawing.Point(0, 0);
            this.btnenaktifuyeler.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnenaktifuyeler.Name = "btnenaktifuyeler";
            this.btnenaktifuyeler.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btnenaktifuyeler.Size = new System.Drawing.Size(227, 100);
            this.btnenaktifuyeler.TabIndex = 3;
            this.btnenaktifuyeler.Text = "Geciken Kitaplar Listesi";
            this.btnenaktifuyeler.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnenaktifuyeler.UseVisualStyleBackColor = false;
            this.btnenaktifuyeler.MouseEnter += new System.EventHandler(this.btnenaktifuyeler_MouseEnter);
            this.btnenaktifuyeler.MouseLeave += new System.EventHandler(this.btnenaktifuyeler_MouseLeave);
            // 
            // GecikenKitapListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.Controls.Add(this.panelgenel);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GecikenKitapListesi";
            this.Text = "GecikenKitapListesi";
            this.Load += new System.EventHandler(this.GecikenKitapListesi_Load);
            this.panelgenel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelara.ResumeLayout(false);
            this.panelara.PerformLayout();
            this.panelmenu.ResumeLayout(false);
            this.panelheader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelgenel;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnbig;
        private System.Windows.Forms.Button btnclose;
        private FontAwesome.Sharp.IconButton btnenaktifuyeler;
        private System.Windows.Forms.Panel panelmenu;
        private FontAwesome.Sharp.IconButton btnban;
        private FontAwesome.Sharp.IconButton btnhatirlat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelara;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.Label lblara;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KullaniciAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdSoyad;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitabınYazari;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kitabınadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teslimedilmesigerekentarih;
    }
}