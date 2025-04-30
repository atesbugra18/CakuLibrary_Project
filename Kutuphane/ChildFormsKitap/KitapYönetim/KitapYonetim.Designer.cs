namespace Kutuphane.ChildFormsKitap
{
    partial class KitapYonetim
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelcocuk = new System.Windows.Forms.Panel();
            this.panelkontroller = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kitapid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kitapadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yazaradisoyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategori = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sayfasayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stokdurumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelara = new System.Windows.Forms.Panel();
            this.txtara = new System.Windows.Forms.TextBox();
            this.lblara = new System.Windows.Forms.Label();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.panelfiltre = new System.Windows.Forms.Panel();
            this.lblkategori = new System.Windows.Forms.Label();
            this.cboxstoksayisi = new System.Windows.Forms.ComboBox();
            this.lblstoksayisi = new System.Windows.Forms.Label();
            this.txtstoksayisi = new System.Windows.Forms.MaskedTextBox();
            this.lblSayfaSayisi = new System.Windows.Forms.Label();
            this.btnfiltrele = new FontAwesome.Sharp.IconButton();
            this.btnkitapsilduzenle = new FontAwesome.Sharp.IconButton();
            this.btnkitapekle = new FontAwesome.Sharp.IconButton();
            this.panelheader = new System.Windows.Forms.Panel();
            this.btnhide = new System.Windows.Forms.Button();
            this.btnbig = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.kitapislemleri = new FontAwesome.Sharp.IconButton();
            this.clistkategori = new System.Windows.Forms.CheckedListBox();
            this.btnfiltreleritemizle = new FontAwesome.Sharp.IconButton();
            this.timerbutonlar = new System.Windows.Forms.Timer(this.components);
            this.panelcocuk.SuspendLayout();
            this.panelkontroller.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelara.SuspendLayout();
            this.panelmenu.SuspendLayout();
            this.panelfiltre.SuspendLayout();
            this.panelheader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelcocuk
            // 
            this.panelcocuk.Controls.Add(this.panelkontroller);
            this.panelcocuk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcocuk.Location = new System.Drawing.Point(0, 0);
            this.panelcocuk.Name = "panelcocuk";
            this.panelcocuk.Size = new System.Drawing.Size(1100, 800);
            this.panelcocuk.TabIndex = 1;
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
            this.groupBox1.Location = new System.Drawing.Point(0, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 653);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kitaplar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kitapid,
            this.kitapadi,
            this.yazaradisoyadi,
            this.kategori,
            this.sayfasayisi,
            this.stokdurumu});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle56;
            this.dataGridView1.Size = new System.Drawing.Size(894, 627);
            this.dataGridView1.TabIndex = 1;
            // 
            // kitapid
            // 
            this.kitapid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.kitapid.DataPropertyName = "kitapıd";
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kitapid.DefaultCellStyle = dataGridViewCellStyle50;
            this.kitapid.HeaderText = "Kitap Id";
            this.kitapid.MaxInputLength = 50;
            this.kitapid.Name = "kitapid";
            this.kitapid.ReadOnly = true;
            this.kitapid.Width = 87;
            // 
            // kitapadi
            // 
            this.kitapadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kitapadi.DataPropertyName = "kitapadi";
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kitapadi.DefaultCellStyle = dataGridViewCellStyle51;
            this.kitapadi.HeaderText = "Kitap Adı";
            this.kitapadi.Name = "kitapadi";
            this.kitapadi.ReadOnly = true;
            // 
            // yazaradisoyadi
            // 
            this.yazaradisoyadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.yazaradisoyadi.DataPropertyName = "yazaradisoyadi";
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.yazaradisoyadi.DefaultCellStyle = dataGridViewCellStyle52;
            this.yazaradisoyadi.HeaderText = "Yazar Adı Soyadı";
            this.yazaradisoyadi.Name = "yazaradisoyadi";
            this.yazaradisoyadi.ReadOnly = true;
            // 
            // kategori
            // 
            this.kategori.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kategori.DefaultCellStyle = dataGridViewCellStyle53;
            this.kategori.HeaderText = "Kategori Adı";
            this.kategori.Name = "kategori";
            this.kategori.ReadOnly = true;
            this.kategori.Width = 119;
            // 
            // sayfasayisi
            // 
            this.sayfasayisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sayfasayisi.DataPropertyName = "sayfasayisi";
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sayfasayisi.DefaultCellStyle = dataGridViewCellStyle54;
            this.sayfasayisi.HeaderText = "Sayfa";
            this.sayfasayisi.Name = "sayfasayisi";
            this.sayfasayisi.ReadOnly = true;
            this.sayfasayisi.Width = 71;
            // 
            // stokdurumu
            // 
            this.stokdurumu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.stokdurumu.DataPropertyName = "stoksayisi";
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.stokdurumu.DefaultCellStyle = dataGridViewCellStyle55;
            this.stokdurumu.HeaderText = "Stok";
            this.stokdurumu.Name = "stokdurumu";
            this.stokdurumu.ReadOnly = true;
            this.stokdurumu.Width = 65;
            // 
            // panelara
            // 
            this.panelara.Controls.Add(this.txtara);
            this.panelara.Controls.Add(this.lblara);
            this.panelara.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelara.Location = new System.Drawing.Point(0, 100);
            this.panelara.Name = "panelara";
            this.panelara.Size = new System.Drawing.Size(900, 47);
            this.panelara.TabIndex = 2;
            // 
            // txtara
            // 
            this.txtara.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtara.Location = new System.Drawing.Point(0, 24);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(900, 23);
            this.txtara.TabIndex = 1;
            this.txtara.TextChanged += new System.EventHandler(this.txtara_TextChanged);
            // 
            // lblara
            // 
            this.lblara.AutoSize = true;
            this.lblara.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblara.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblara.Location = new System.Drawing.Point(0, 0);
            this.lblara.Name = "lblara";
            this.lblara.Size = new System.Drawing.Size(37, 19);
            this.lblara.TabIndex = 0;
            this.lblara.Text = "Ara:";
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelmenu.Controls.Add(this.panelfiltre);
            this.panelmenu.Controls.Add(this.btnfiltrele);
            this.panelmenu.Controls.Add(this.btnkitapsilduzenle);
            this.panelmenu.Controls.Add(this.btnkitapekle);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelmenu.Location = new System.Drawing.Point(900, 100);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(200, 700);
            this.panelmenu.TabIndex = 1;
            // 
            // panelfiltre
            // 
            this.panelfiltre.Controls.Add(this.btnfiltreleritemizle);
            this.panelfiltre.Controls.Add(this.clistkategori);
            this.panelfiltre.Controls.Add(this.lblkategori);
            this.panelfiltre.Controls.Add(this.cboxstoksayisi);
            this.panelfiltre.Controls.Add(this.lblstoksayisi);
            this.panelfiltre.Controls.Add(this.txtstoksayisi);
            this.panelfiltre.Controls.Add(this.lblSayfaSayisi);
            this.panelfiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelfiltre.Location = new System.Drawing.Point(0, 105);
            this.panelfiltre.Name = "panelfiltre";
            this.panelfiltre.Size = new System.Drawing.Size(200, 531);
            this.panelfiltre.TabIndex = 13;
            this.panelfiltre.Visible = false;
            // 
            // lblkategori
            // 
            this.lblkategori.AutoSize = true;
            this.lblkategori.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblkategori.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblkategori.Location = new System.Drawing.Point(0, 76);
            this.lblkategori.Name = "lblkategori";
            this.lblkategori.Size = new System.Drawing.Size(57, 15);
            this.lblkategori.TabIndex = 4;
            this.lblkategori.Text = "Kategori:";
            // 
            // cboxstoksayisi
            // 
            this.cboxstoksayisi.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboxstoksayisi.FormattingEnabled = true;
            this.cboxstoksayisi.Location = new System.Drawing.Point(0, 53);
            this.cboxstoksayisi.Name = "cboxstoksayisi";
            this.cboxstoksayisi.Size = new System.Drawing.Size(200, 23);
            this.cboxstoksayisi.TabIndex = 3;
            this.cboxstoksayisi.SelectedIndexChanged += new System.EventHandler(this.cboxstoksayisi_SelectedIndexChanged);
            // 
            // lblstoksayisi
            // 
            this.lblstoksayisi.AutoSize = true;
            this.lblstoksayisi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblstoksayisi.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblstoksayisi.Location = new System.Drawing.Point(0, 38);
            this.lblstoksayisi.Name = "lblstoksayisi";
            this.lblstoksayisi.Size = new System.Drawing.Size(67, 15);
            this.lblstoksayisi.TabIndex = 2;
            this.lblstoksayisi.Text = "Stok Sayısı:";
            // 
            // txtstoksayisi
            // 
            this.txtstoksayisi.Culture = new System.Globalization.CultureInfo("tr-TR");
            this.txtstoksayisi.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtstoksayisi.Location = new System.Drawing.Point(0, 15);
            this.txtstoksayisi.Mask = "0000";
            this.txtstoksayisi.Name = "txtstoksayisi";
            this.txtstoksayisi.PromptChar = ' ';
            this.txtstoksayisi.Size = new System.Drawing.Size(200, 23);
            this.txtstoksayisi.TabIndex = 1;
            this.txtstoksayisi.TextChanged += new System.EventHandler(this.txtstoksayisi_TextChanged);
            // 
            // lblSayfaSayisi
            // 
            this.lblSayfaSayisi.AutoSize = true;
            this.lblSayfaSayisi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSayfaSayisi.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSayfaSayisi.Location = new System.Drawing.Point(0, 0);
            this.lblSayfaSayisi.Name = "lblSayfaSayisi";
            this.lblSayfaSayisi.Size = new System.Drawing.Size(71, 15);
            this.lblSayfaSayisi.TabIndex = 0;
            this.lblSayfaSayisi.Text = "Sayfa Sayısı:";
            // 
            // btnfiltrele
            // 
            this.btnfiltrele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.btnfiltrele.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnfiltrele.FlatAppearance.BorderSize = 0;
            this.btnfiltrele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfiltrele.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.btnfiltrele.IconColor = System.Drawing.Color.Black;
            this.btnfiltrele.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnfiltrele.IconSize = 30;
            this.btnfiltrele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltrele.Location = new System.Drawing.Point(0, 70);
            this.btnfiltrele.Name = "btnfiltrele";
            this.btnfiltrele.Size = new System.Drawing.Size(200, 35);
            this.btnfiltrele.TabIndex = 12;
            this.btnfiltrele.Text = "Filtrele";
            this.btnfiltrele.UseVisualStyleBackColor = false;
            this.btnfiltrele.Click += new System.EventHandler(this.btnfiltrele_Click);
            // 
            // btnkitapsilduzenle
            // 
            this.btnkitapsilduzenle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnkitapsilduzenle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkitapsilduzenle.FlatAppearance.BorderSize = 0;
            this.btnkitapsilduzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkitapsilduzenle.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnkitapsilduzenle.IconColor = System.Drawing.Color.Black;
            this.btnkitapsilduzenle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkitapsilduzenle.IconSize = 30;
            this.btnkitapsilduzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkitapsilduzenle.Location = new System.Drawing.Point(0, 35);
            this.btnkitapsilduzenle.Name = "btnkitapsilduzenle";
            this.btnkitapsilduzenle.Size = new System.Drawing.Size(200, 35);
            this.btnkitapsilduzenle.TabIndex = 11;
            this.btnkitapsilduzenle.Text = "Kitap Sil && Düzenle";
            this.btnkitapsilduzenle.UseVisualStyleBackColor = false;
            this.btnkitapsilduzenle.Click += new System.EventHandler(this.btnkitapsilduzenle_Click);
            // 
            // btnkitapekle
            // 
            this.btnkitapekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnkitapekle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkitapekle.FlatAppearance.BorderSize = 0;
            this.btnkitapekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkitapekle.ForeColor = System.Drawing.Color.Black;
            this.btnkitapekle.IconChar = FontAwesome.Sharp.IconChar.BookMedical;
            this.btnkitapekle.IconColor = System.Drawing.Color.Black;
            this.btnkitapekle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkitapekle.IconSize = 30;
            this.btnkitapekle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkitapekle.Location = new System.Drawing.Point(0, 0);
            this.btnkitapekle.Name = "btnkitapekle";
            this.btnkitapekle.Size = new System.Drawing.Size(200, 35);
            this.btnkitapekle.TabIndex = 10;
            this.btnkitapekle.Text = "Kitap Ekle";
            this.btnkitapekle.UseVisualStyleBackColor = false;
            this.btnkitapekle.Click += new System.EventHandler(this.btnkitapekle_Click);
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Controls.Add(this.btnhide);
            this.panelheader.Controls.Add(this.btnbig);
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.kitapislemleri);
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
            this.btnhide.Location = new System.Drawing.Point(1031, 12);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(15, 15);
            this.btnhide.TabIndex = 13;
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
            this.btnbig.Location = new System.Drawing.Point(1052, 12);
            this.btnbig.Name = "btnbig";
            this.btnbig.Size = new System.Drawing.Size(15, 15);
            this.btnbig.TabIndex = 12;
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
            this.btnclose.Location = new System.Drawing.Point(1073, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(15, 15);
            this.btnclose.TabIndex = 11;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // kitapislemleri
            // 
            this.kitapislemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.kitapislemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kitapislemleri.Dock = System.Windows.Forms.DockStyle.Left;
            this.kitapislemleri.FlatAppearance.BorderSize = 0;
            this.kitapislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kitapislemleri.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kitapislemleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.kitapislemleri.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.kitapislemleri.IconColor = System.Drawing.Color.Gainsboro;
            this.kitapislemleri.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.kitapislemleri.IconSize = 30;
            this.kitapislemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kitapislemleri.Location = new System.Drawing.Point(0, 0);
            this.kitapislemleri.Name = "kitapislemleri";
            this.kitapislemleri.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.kitapislemleri.Size = new System.Drawing.Size(173, 100);
            this.kitapislemleri.TabIndex = 3;
            this.kitapislemleri.Text = "Kitap Yönetim";
            this.kitapislemleri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kitapislemleri.UseVisualStyleBackColor = false;
            this.kitapislemleri.MouseEnter += new System.EventHandler(this.kitapislemleri_MouseEnter);
            this.kitapislemleri.MouseLeave += new System.EventHandler(this.kitapislemleri_MouseLeave);
            // 
            // clistkategori
            // 
            this.clistkategori.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.clistkategori.CheckOnClick = true;
            this.clistkategori.Dock = System.Windows.Forms.DockStyle.Top;
            this.clistkategori.ForeColor = System.Drawing.Color.Gainsboro;
            this.clistkategori.FormattingEnabled = true;
            this.clistkategori.Location = new System.Drawing.Point(0, 91);
            this.clistkategori.Name = "clistkategori";
            this.clistkategori.Size = new System.Drawing.Size(200, 400);
            this.clistkategori.TabIndex = 5;
            this.clistkategori.SelectedIndexChanged += new System.EventHandler(this.clistkategori_SelectedIndexChanged);
            // 
            // btnfiltreleritemizle
            // 
            this.btnfiltreleritemizle.BackColor = System.Drawing.Color.Red;
            this.btnfiltreleritemizle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnfiltreleritemizle.FlatAppearance.BorderSize = 0;
            this.btnfiltreleritemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfiltreleritemizle.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.btnfiltreleritemizle.IconColor = System.Drawing.Color.Black;
            this.btnfiltreleritemizle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnfiltreleritemizle.IconSize = 30;
            this.btnfiltreleritemizle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltreleritemizle.Location = new System.Drawing.Point(0, 491);
            this.btnfiltreleritemizle.Name = "btnfiltreleritemizle";
            this.btnfiltreleritemizle.Size = new System.Drawing.Size(200, 35);
            this.btnfiltreleritemizle.TabIndex = 13;
            this.btnfiltreleritemizle.Text = "Filtreleri Temizle";
            this.btnfiltreleritemizle.UseVisualStyleBackColor = false;
            this.btnfiltreleritemizle.Click += new System.EventHandler(this.btnfiltreleritemizle_Click);
            // 
            // timerbutonlar
            // 
            this.timerbutonlar.Interval = 5;
            this.timerbutonlar.Tick += new System.EventHandler(this.timerbutonlar_Tick);
            // 
            // KitapYonetim
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panelcocuk);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KitapYonetim";
            this.Load += new System.EventHandler(this.KitapYonetim_Load);
            this.panelcocuk.ResumeLayout(false);
            this.panelkontroller.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelara.ResumeLayout(false);
            this.panelara.PerformLayout();
            this.panelmenu.ResumeLayout(false);
            this.panelfiltre.ResumeLayout(false);
            this.panelfiltre.PerformLayout();
            this.panelheader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelcocuk;
        private System.Windows.Forms.Panel panelkontroller;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Panel panelara;
        private System.Windows.Forms.Label lblara;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kitapid;
        private System.Windows.Forms.DataGridViewTextBoxColumn kitapadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn yazaradisoyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategori;
        private System.Windows.Forms.DataGridViewTextBoxColumn sayfasayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokdurumu;
        private System.Windows.Forms.Panel panelfiltre;
        private FontAwesome.Sharp.IconButton btnfiltrele;
        private FontAwesome.Sharp.IconButton btnkitapsilduzenle;
        private FontAwesome.Sharp.IconButton btnkitapekle;
        private System.Windows.Forms.Label lblstoksayisi;
        private System.Windows.Forms.MaskedTextBox txtstoksayisi;
        private System.Windows.Forms.Label lblSayfaSayisi;
        private System.Windows.Forms.Label lblkategori;
        private System.Windows.Forms.ComboBox cboxstoksayisi;
        private FontAwesome.Sharp.IconButton kitapislemleri;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnbig;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.CheckedListBox clistkategori;
        private FontAwesome.Sharp.IconButton btnfiltreleritemizle;
        private System.Windows.Forms.Timer timerbutonlar;
    }
}