namespace Kutuphane.ChildFormsKullanici
{
    partial class KullaniciYönetimi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelebeveyn = new System.Windows.Forms.Panel();
            this.panelkontroller = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelara = new System.Windows.Forms.Panel();
            this.txtara = new System.Windows.Forms.TextBox();
            this.lblara = new System.Windows.Forms.Label();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.panelfiltre = new System.Windows.Forms.Panel();
            this.txtmaxtutar = new System.Windows.Forms.MaskedTextBox();
            this.txtmintutar = new System.Windows.Forms.MaskedTextBox();
            this.lblminmax = new System.Windows.Forms.Label();
            this.lblCezası = new System.Windows.Forms.Label();
            this.caktifpasif = new System.Windows.Forms.ComboBox();
            this.lblaktifpasif = new System.Windows.Forms.Label();
            this.crolu = new System.Windows.Forms.ComboBox();
            this.btnfiltreleritemizle = new FontAwesome.Sharp.IconButton();
            this.lblrolu = new System.Windows.Forms.Label();
            this.btnfiltrele = new FontAwesome.Sharp.IconButton();
            this.btnkullanicisil = new FontAwesome.Sharp.IconButton();
            this.btnkullanicikle = new FontAwesome.Sharp.IconButton();
            this.panelheader = new System.Windows.Forms.Panel();
            this.btnhide = new System.Windows.Forms.Button();
            this.btnbig = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnkullaniciyonetim = new FontAwesome.Sharp.IconButton();
            this.timerbutonlar = new System.Windows.Forms.Timer(this.components);
            this.kullaniciid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adisoyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullaniciadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cezasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aktifpasif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelebeveyn.SuspendLayout();
            this.panelkontroller.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelara.SuspendLayout();
            this.panelmenu.SuspendLayout();
            this.panelfiltre.SuspendLayout();
            this.panelheader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelebeveyn
            // 
            this.panelebeveyn.Controls.Add(this.panelkontroller);
            this.panelebeveyn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelebeveyn.Location = new System.Drawing.Point(0, 0);
            this.panelebeveyn.Name = "panelebeveyn";
            this.panelebeveyn.Size = new System.Drawing.Size(1084, 784);
            this.panelebeveyn.TabIndex = 0;
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
            this.panelkontroller.Size = new System.Drawing.Size(1084, 784);
            this.panelkontroller.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 642);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcılar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kullaniciid,
            this.Tc,
            this.adisoyadi,
            this.kullaniciadi,
            this.mail,
            this.rolu,
            this.Cezasi,
            this.aktifpasif});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(878, 616);
            this.dataGridView1.TabIndex = 0;
            // 
            // panelara
            // 
            this.panelara.Controls.Add(this.txtara);
            this.panelara.Controls.Add(this.lblara);
            this.panelara.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelara.Location = new System.Drawing.Point(0, 100);
            this.panelara.Name = "panelara";
            this.panelara.Size = new System.Drawing.Size(884, 42);
            this.panelara.TabIndex = 2;
            // 
            // txtara
            // 
            this.txtara.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtara.Location = new System.Drawing.Point(0, 19);
            this.txtara.Name = "txtara";
            this.txtara.Size = new System.Drawing.Size(884, 23);
            this.txtara.TabIndex = 1;
            this.txtara.TextChanged += new System.EventHandler(this.txtara_TextChanged);
            // 
            // lblara
            // 
            this.lblara.AutoSize = true;
            this.lblara.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblara.Location = new System.Drawing.Point(0, 0);
            this.lblara.Name = "lblara";
            this.lblara.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblara.Size = new System.Drawing.Size(26, 15);
            this.lblara.TabIndex = 0;
            this.lblara.Text = "Ara";
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelmenu.Controls.Add(this.panelfiltre);
            this.panelmenu.Controls.Add(this.btnfiltrele);
            this.panelmenu.Controls.Add(this.btnkullanicisil);
            this.panelmenu.Controls.Add(this.btnkullanicikle);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelmenu.Location = new System.Drawing.Point(884, 100);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(200, 684);
            this.panelmenu.TabIndex = 1;
            // 
            // panelfiltre
            // 
            this.panelfiltre.Controls.Add(this.txtmaxtutar);
            this.panelfiltre.Controls.Add(this.txtmintutar);
            this.panelfiltre.Controls.Add(this.lblminmax);
            this.panelfiltre.Controls.Add(this.lblCezası);
            this.panelfiltre.Controls.Add(this.caktifpasif);
            this.panelfiltre.Controls.Add(this.lblaktifpasif);
            this.panelfiltre.Controls.Add(this.crolu);
            this.panelfiltre.Controls.Add(this.btnfiltreleritemizle);
            this.panelfiltre.Controls.Add(this.lblrolu);
            this.panelfiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelfiltre.Location = new System.Drawing.Point(0, 105);
            this.panelfiltre.Name = "panelfiltre";
            this.panelfiltre.Size = new System.Drawing.Size(200, 174);
            this.panelfiltre.TabIndex = 17;
            this.panelfiltre.Visible = false;
            // 
            // txtmaxtutar
            // 
            this.txtmaxtutar.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtmaxtutar.Location = new System.Drawing.Point(132, 106);
            this.txtmaxtutar.Mask = "00000000";
            this.txtmaxtutar.Name = "txtmaxtutar";
            this.txtmaxtutar.PromptChar = ' ';
            this.txtmaxtutar.Size = new System.Drawing.Size(68, 23);
            this.txtmaxtutar.TabIndex = 31;
            this.txtmaxtutar.TextChanged += new System.EventHandler(this.txtmaxtutar_TextChanged);
            // 
            // txtmintutar
            // 
            this.txtmintutar.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtmintutar.Location = new System.Drawing.Point(0, 106);
            this.txtmintutar.Mask = "00000000";
            this.txtmintutar.Name = "txtmintutar";
            this.txtmintutar.PromptChar = ' ';
            this.txtmintutar.Size = new System.Drawing.Size(68, 23);
            this.txtmintutar.TabIndex = 30;
            this.txtmintutar.TextChanged += new System.EventHandler(this.txtmintutar_TextChanged);
            // 
            // lblminmax
            // 
            this.lblminmax.AutoSize = true;
            this.lblminmax.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblminmax.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblminmax.Location = new System.Drawing.Point(0, 91);
            this.lblminmax.Name = "lblminmax";
            this.lblminmax.Size = new System.Drawing.Size(199, 15);
            this.lblminmax.TabIndex = 29;
            this.lblminmax.Text = "Minimum            -             Maksimum";
            // 
            // lblCezası
            // 
            this.lblCezası.AutoSize = true;
            this.lblCezası.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCezası.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCezası.Location = new System.Drawing.Point(0, 76);
            this.lblCezası.Name = "lblCezası";
            this.lblCezası.Size = new System.Drawing.Size(44, 15);
            this.lblCezası.TabIndex = 28;
            this.lblCezası.Text = "Cezası:";
            // 
            // caktifpasif
            // 
            this.caktifpasif.Dock = System.Windows.Forms.DockStyle.Top;
            this.caktifpasif.FormattingEnabled = true;
            this.caktifpasif.Items.AddRange(new object[] {
            "Aktif",
            "Pasif"});
            this.caktifpasif.Location = new System.Drawing.Point(0, 53);
            this.caktifpasif.Name = "caktifpasif";
            this.caktifpasif.Size = new System.Drawing.Size(200, 23);
            this.caktifpasif.TabIndex = 16;
            this.caktifpasif.SelectedIndexChanged += new System.EventHandler(this.caktifpasif_SelectedIndexChanged);
            // 
            // lblaktifpasif
            // 
            this.lblaktifpasif.AutoSize = true;
            this.lblaktifpasif.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblaktifpasif.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblaktifpasif.Location = new System.Drawing.Point(0, 38);
            this.lblaktifpasif.Name = "lblaktifpasif";
            this.lblaktifpasif.Size = new System.Drawing.Size(66, 15);
            this.lblaktifpasif.TabIndex = 15;
            this.lblaktifpasif.Text = "Aktif-Pasif:";
            // 
            // crolu
            // 
            this.crolu.Dock = System.Windows.Forms.DockStyle.Top;
            this.crolu.FormattingEnabled = true;
            this.crolu.Items.AddRange(new object[] {
            "Admin",
            "Görevli",
            "Okuyucu"});
            this.crolu.Location = new System.Drawing.Point(0, 15);
            this.crolu.Name = "crolu";
            this.crolu.Size = new System.Drawing.Size(200, 23);
            this.crolu.TabIndex = 14;
            this.crolu.SelectedIndexChanged += new System.EventHandler(this.crolu_SelectedIndexChanged);
            // 
            // btnfiltreleritemizle
            // 
            this.btnfiltreleritemizle.BackColor = System.Drawing.Color.Red;
            this.btnfiltreleritemizle.FlatAppearance.BorderSize = 0;
            this.btnfiltreleritemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfiltreleritemizle.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.btnfiltreleritemizle.IconColor = System.Drawing.Color.Black;
            this.btnfiltreleritemizle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnfiltreleritemizle.IconSize = 30;
            this.btnfiltreleritemizle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltreleritemizle.Location = new System.Drawing.Point(0, 132);
            this.btnfiltreleritemizle.Name = "btnfiltreleritemizle";
            this.btnfiltreleritemizle.Size = new System.Drawing.Size(200, 35);
            this.btnfiltreleritemizle.TabIndex = 13;
            this.btnfiltreleritemizle.Text = "Filtreleri Temizle";
            this.btnfiltreleritemizle.UseVisualStyleBackColor = false;
            this.btnfiltreleritemizle.Click += new System.EventHandler(this.btnfiltreleritemizle_Click);
            // 
            // lblrolu
            // 
            this.lblrolu.AutoSize = true;
            this.lblrolu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblrolu.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblrolu.Location = new System.Drawing.Point(0, 0);
            this.lblrolu.Name = "lblrolu";
            this.lblrolu.Size = new System.Drawing.Size(35, 15);
            this.lblrolu.TabIndex = 0;
            this.lblrolu.Text = "Rolü:";
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
            this.btnfiltrele.TabIndex = 16;
            this.btnfiltrele.Text = "Filtrele";
            this.btnfiltrele.UseVisualStyleBackColor = false;
            this.btnfiltrele.Click += new System.EventHandler(this.btnfiltrele_Click);
            // 
            // btnkullanicisil
            // 
            this.btnkullanicisil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnkullanicisil.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkullanicisil.FlatAppearance.BorderSize = 0;
            this.btnkullanicisil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkullanicisil.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnkullanicisil.IconColor = System.Drawing.Color.Black;
            this.btnkullanicisil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkullanicisil.IconSize = 30;
            this.btnkullanicisil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkullanicisil.Location = new System.Drawing.Point(0, 35);
            this.btnkullanicisil.Name = "btnkullanicisil";
            this.btnkullanicisil.Size = new System.Drawing.Size(200, 35);
            this.btnkullanicisil.TabIndex = 15;
            this.btnkullanicisil.Text = "Kullanıcı Sil && Düzenle";
            this.btnkullanicisil.UseVisualStyleBackColor = false;
            this.btnkullanicisil.Click += new System.EventHandler(this.btnkullanicisil_Click);
            // 
            // btnkullanicikle
            // 
            this.btnkullanicikle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnkullanicikle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkullanicikle.FlatAppearance.BorderSize = 0;
            this.btnkullanicikle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkullanicikle.ForeColor = System.Drawing.Color.Black;
            this.btnkullanicikle.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnkullanicikle.IconColor = System.Drawing.Color.Black;
            this.btnkullanicikle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkullanicikle.IconSize = 30;
            this.btnkullanicikle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkullanicikle.Location = new System.Drawing.Point(0, 0);
            this.btnkullanicikle.Name = "btnkullanicikle";
            this.btnkullanicikle.Size = new System.Drawing.Size(200, 35);
            this.btnkullanicikle.TabIndex = 14;
            this.btnkullanicikle.Text = "Kullanıcı Ekle";
            this.btnkullanicikle.UseVisualStyleBackColor = false;
            this.btnkullanicikle.Click += new System.EventHandler(this.btnkullanicikle_Click);
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Controls.Add(this.btnhide);
            this.panelheader.Controls.Add(this.btnbig);
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.btnkullaniciyonetim);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1084, 100);
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
            this.btnhide.Location = new System.Drawing.Point(1015, 12);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(15, 15);
            this.btnhide.TabIndex = 7;
            this.btnhide.UseVisualStyleBackColor = false;
            // 
            // btnbig
            // 
            this.btnbig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbig.BackColor = System.Drawing.Color.Transparent;
            this.btnbig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbig.FlatAppearance.BorderSize = 0;
            this.btnbig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnbig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnbig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbig.Location = new System.Drawing.Point(1036, 12);
            this.btnbig.Name = "btnbig";
            this.btnbig.Size = new System.Drawing.Size(15, 15);
            this.btnbig.TabIndex = 6;
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
            this.btnclose.Location = new System.Drawing.Point(1057, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(15, 15);
            this.btnclose.TabIndex = 5;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnkullaniciyonetim
            // 
            this.btnkullaniciyonetim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.btnkullaniciyonetim.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnkullaniciyonetim.FlatAppearance.BorderSize = 0;
            this.btnkullaniciyonetim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkullaniciyonetim.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkullaniciyonetim.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.btnkullaniciyonetim.IconColor = System.Drawing.Color.Gainsboro;
            this.btnkullaniciyonetim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkullaniciyonetim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkullaniciyonetim.Location = new System.Drawing.Point(0, 0);
            this.btnkullaniciyonetim.Name = "btnkullaniciyonetim";
            this.btnkullaniciyonetim.Size = new System.Drawing.Size(164, 100);
            this.btnkullaniciyonetim.TabIndex = 0;
            this.btnkullaniciyonetim.Text = "Kullanıcı Yönetimi";
            this.btnkullaniciyonetim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnkullaniciyonetim.UseVisualStyleBackColor = false;
            this.btnkullaniciyonetim.MouseEnter += new System.EventHandler(this.btnkullaniciyonetim_MouseEnter);
            this.btnkullaniciyonetim.MouseLeave += new System.EventHandler(this.btnkullaniciyonetim_MouseLeave);
            // 
            // timerbutonlar
            // 
            this.timerbutonlar.Interval = 2;
            this.timerbutonlar.Tick += new System.EventHandler(this.timerbutonlar_Tick);
            // 
            // kullaniciid
            // 
            this.kullaniciid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.kullaniciid.DataPropertyName = "kullaniciId";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kullaniciid.DefaultCellStyle = dataGridViewCellStyle3;
            this.kullaniciid.HeaderText = "Id";
            this.kullaniciid.Name = "kullaniciid";
            this.kullaniciid.ReadOnly = true;
            this.kullaniciid.Width = 47;
            // 
            // Tc
            // 
            this.Tc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tc.DataPropertyName = "tc";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Tc.DefaultCellStyle = dataGridViewCellStyle4;
            this.Tc.HeaderText = "Tc Kimlik No";
            this.Tc.MaxInputLength = 11;
            this.Tc.Name = "Tc";
            this.Tc.ReadOnly = true;
            this.Tc.Width = 118;
            // 
            // adisoyadi
            // 
            this.adisoyadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.adisoyadi.DataPropertyName = "adisoyadi";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.adisoyadi.DefaultCellStyle = dataGridViewCellStyle5;
            this.adisoyadi.HeaderText = "Ad Soyad";
            this.adisoyadi.Name = "adisoyadi";
            this.adisoyadi.ReadOnly = true;
            // 
            // kullaniciadi
            // 
            this.kullaniciadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kullaniciadi.DataPropertyName = "kullaniciadi";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kullaniciadi.DefaultCellStyle = dataGridViewCellStyle6;
            this.kullaniciadi.HeaderText = "Kullanıcı Adı";
            this.kullaniciadi.Name = "kullaniciadi";
            this.kullaniciadi.ReadOnly = true;
            // 
            // mail
            // 
            this.mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mail.DataPropertyName = "email";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mail.DefaultCellStyle = dataGridViewCellStyle7;
            this.mail.HeaderText = "E-Posta";
            this.mail.Name = "mail";
            this.mail.ReadOnly = true;
            this.mail.Width = 85;
            // 
            // rolu
            // 
            this.rolu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rolu.DataPropertyName = "rolu";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rolu.DefaultCellStyle = dataGridViewCellStyle8;
            this.rolu.HeaderText = "Rolü";
            this.rolu.Name = "rolu";
            this.rolu.ReadOnly = true;
            this.rolu.Width = 65;
            // 
            // Cezasi
            // 
            this.Cezasi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cezasi.DataPropertyName = "aktifcezatutari";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Cezasi.DefaultCellStyle = dataGridViewCellStyle9;
            this.Cezasi.HeaderText = "Ceza Tutarı";
            this.Cezasi.Name = "Cezasi";
            this.Cezasi.ReadOnly = true;
            this.Cezasi.Width = 108;
            // 
            // aktifpasif
            // 
            this.aktifpasif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.aktifpasif.DataPropertyName = "aktifpasif";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.aktifpasif.DefaultCellStyle = dataGridViewCellStyle10;
            this.aktifpasif.HeaderText = "Aktif-Pasif";
            this.aktifpasif.Name = "aktifpasif";
            this.aktifpasif.ReadOnly = true;
            this.aktifpasif.Width = 103;
            // 
            // KullaniciYönetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 784);
            this.ControlBox = false;
            this.Controls.Add(this.panelebeveyn);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciYönetimi";
            this.Load += new System.EventHandler(this.KullaniciYönetimi_Load);
            this.panelebeveyn.ResumeLayout(false);
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

        private System.Windows.Forms.Panel panelebeveyn;
        private System.Windows.Forms.Panel panelkontroller;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelara;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.TextBox txtara;
        private System.Windows.Forms.Label lblara;
        private FontAwesome.Sharp.IconButton btnkullaniciyonetim;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnbig;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panelfiltre;
        private FontAwesome.Sharp.IconButton btnfiltreleritemizle;
        private System.Windows.Forms.Label lblrolu;
        private FontAwesome.Sharp.IconButton btnfiltrele;
        private FontAwesome.Sharp.IconButton btnkullanicisil;
        private FontAwesome.Sharp.IconButton btnkullanicikle;
        private System.Windows.Forms.ComboBox crolu;
        private System.Windows.Forms.MaskedTextBox txtmaxtutar;
        private System.Windows.Forms.MaskedTextBox txtmintutar;
        private System.Windows.Forms.Label lblminmax;
        private System.Windows.Forms.Label lblCezası;
        private System.Windows.Forms.ComboBox caktifpasif;
        private System.Windows.Forms.Label lblaktifpasif;
        private System.Windows.Forms.Timer timerbutonlar;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tc;
        private System.Windows.Forms.DataGridViewTextBoxColumn adisoyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cezasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn aktifpasif;
    }
}