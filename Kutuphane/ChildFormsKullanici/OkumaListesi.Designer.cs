namespace Kutuphane.ChildFormsKullanici
{
    partial class OkumaListesi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelkontroller = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.islemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okuyaninadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kitapadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaslangicTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SonTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teslimedilentarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teslimalankisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelara = new System.Windows.Forms.Panel();
            this.txtara = new System.Windows.Forms.TextBox();
            this.lblara = new System.Windows.Forms.Label();
            this.panelheader = new System.Windows.Forms.Panel();
            this.btnhide = new System.Windows.Forms.Button();
            this.btnbig = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnokumalistesi = new FontAwesome.Sharp.IconButton();
            this.panelcocuk = new System.Windows.Forms.Panel();
            this.panelkontroller.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelara.SuspendLayout();
            this.panelheader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelkontroller
            // 
            this.panelkontroller.BackColor = System.Drawing.Color.White;
            this.panelkontroller.Controls.Add(this.groupBox1);
            this.panelkontroller.Controls.Add(this.panelara);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1100, 661);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Okuma Listesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.islemid,
            this.okuyaninadi,
            this.kitapadi,
            this.BaslangicTarihi,
            this.SonTarih,
            this.teslimedilentarih,
            this.durumu,
            this.teslimalankisi});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1094, 635);
            this.dataGridView1.TabIndex = 0;
            // 
            // islemid
            // 
            this.islemid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.islemid.DataPropertyName = "IslemId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.islemid.DefaultCellStyle = dataGridViewCellStyle2;
            this.islemid.HeaderText = "İşlem No";
            this.islemid.Name = "islemid";
            this.islemid.ReadOnly = true;
            this.islemid.Width = 93;
            // 
            // okuyaninadi
            // 
            this.okuyaninadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.okuyaninadi.DataPropertyName = "okuyaninadi";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.okuyaninadi.DefaultCellStyle = dataGridViewCellStyle3;
            this.okuyaninadi.HeaderText = "Okuyanın Adı";
            this.okuyaninadi.Name = "okuyaninadi";
            this.okuyaninadi.ReadOnly = true;
            this.okuyaninadi.Width = 127;
            // 
            // kitapadi
            // 
            this.kitapadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.kitapadi.DataPropertyName = "kitapadi";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kitapadi.DefaultCellStyle = dataGridViewCellStyle4;
            this.kitapadi.HeaderText = "Kitabın Adı";
            this.kitapadi.Name = "kitapadi";
            this.kitapadi.ReadOnly = true;
            this.kitapadi.Width = 110;
            // 
            // BaslangicTarihi
            // 
            this.BaslangicTarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BaslangicTarihi.DataPropertyName = "baslangictarihi";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BaslangicTarihi.DefaultCellStyle = dataGridViewCellStyle5;
            this.BaslangicTarihi.HeaderText = "Kitabın Alınma Tarihi";
            this.BaslangicTarihi.Name = "BaslangicTarihi";
            this.BaslangicTarihi.ReadOnly = true;
            this.BaslangicTarihi.Width = 177;
            // 
            // SonTarih
            // 
            this.SonTarih.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SonTarih.DataPropertyName = "bitistarihi";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SonTarih.DefaultCellStyle = dataGridViewCellStyle6;
            this.SonTarih.HeaderText = "Kitabın Teslim Edilmesi Gereken Tarih";
            this.SonTarih.Name = "SonTarih";
            this.SonTarih.ReadOnly = true;
            this.SonTarih.Width = 288;
            // 
            // teslimedilentarih
            // 
            this.teslimedilentarih.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.teslimedilentarih.DataPropertyName = "teslimtarihi";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = "Henüz Teslim Edilmemiş";
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.teslimedilentarih.DefaultCellStyle = dataGridViewCellStyle7;
            this.teslimedilentarih.HeaderText = "Teslim Edilen Tarih";
            this.teslimedilentarih.Name = "teslimedilentarih";
            this.teslimedilentarih.ReadOnly = true;
            this.teslimedilentarih.Width = 160;
            // 
            // durumu
            // 
            this.durumu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.durumu.DataPropertyName = "durum";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.durumu.DefaultCellStyle = dataGridViewCellStyle8;
            this.durumu.HeaderText = "Durumu";
            this.durumu.Name = "durumu";
            this.durumu.ReadOnly = true;
            this.durumu.Width = 90;
            // 
            // teslimalankisi
            // 
            this.teslimalankisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.teslimalankisi.DataPropertyName = "teslimalankisi";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = "Teslim Alınmamış";
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.teslimalankisi.DefaultCellStyle = dataGridViewCellStyle9;
            this.teslimalankisi.HeaderText = "Teslim Alan Kişi";
            this.teslimalankisi.Name = "teslimalankisi";
            this.teslimalankisi.ReadOnly = true;
            // 
            // panelara
            // 
            this.panelara.Controls.Add(this.txtara);
            this.panelara.Controls.Add(this.lblara);
            this.panelara.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelara.Location = new System.Drawing.Point(0, 100);
            this.panelara.Name = "panelara";
            this.panelara.Size = new System.Drawing.Size(1100, 39);
            this.panelara.TabIndex = 1;
            // 
            // txtara
            // 
            this.txtara.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtara.Location = new System.Drawing.Point(0, 16);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(1100, 23);
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
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Controls.Add(this.btnhide);
            this.panelheader.Controls.Add(this.btnbig);
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.btnokumalistesi);
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
            this.btnhide.TabIndex = 17;
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
            this.btnbig.TabIndex = 16;
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
            this.btnclose.TabIndex = 15;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnokumalistesi
            // 
            this.btnokumalistesi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.btnokumalistesi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnokumalistesi.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnokumalistesi.FlatAppearance.BorderSize = 0;
            this.btnokumalistesi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnokumalistesi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnokumalistesi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnokumalistesi.IconChar = FontAwesome.Sharp.IconChar.Readme;
            this.btnokumalistesi.IconColor = System.Drawing.Color.Gainsboro;
            this.btnokumalistesi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnokumalistesi.IconSize = 30;
            this.btnokumalistesi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnokumalistesi.Location = new System.Drawing.Point(0, 0);
            this.btnokumalistesi.Name = "btnokumalistesi";
            this.btnokumalistesi.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnokumalistesi.Size = new System.Drawing.Size(173, 100);
            this.btnokumalistesi.TabIndex = 14;
            this.btnokumalistesi.Text = "Okuma Listesi";
            this.btnokumalistesi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnokumalistesi.UseVisualStyleBackColor = false;
            this.btnokumalistesi.MouseEnter += new System.EventHandler(this.btnokumalistesi_MouseEnter);
            this.btnokumalistesi.MouseLeave += new System.EventHandler(this.btnokumalistesi_MouseLeave);
            // 
            // panelcocuk
            // 
            this.panelcocuk.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelcocuk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcocuk.Location = new System.Drawing.Point(0, 0);
            this.panelcocuk.Name = "panelcocuk";
            this.panelcocuk.Size = new System.Drawing.Size(1100, 800);
            this.panelcocuk.TabIndex = 3;
            // 
            // OkumaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panelkontroller);
            this.Controls.Add(this.panelcocuk);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OkumaListesi";
            this.Load += new System.EventHandler(this.OkumaListesi_Load);
            this.panelkontroller.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelara.ResumeLayout(false);
            this.panelara.PerformLayout();
            this.panelheader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelkontroller;
        private System.Windows.Forms.Panel panelcocuk;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnbig;
        private System.Windows.Forms.Button btnclose;
        private FontAwesome.Sharp.IconButton btnokumalistesi;
        private System.Windows.Forms.Panel panelara;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.Label lblara;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn islemid;
        private System.Windows.Forms.DataGridViewTextBoxColumn okuyaninadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kitapadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaslangicTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SonTarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn teslimedilentarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn durumu;
        private System.Windows.Forms.DataGridViewTextBoxColumn teslimalankisi;
    }
}