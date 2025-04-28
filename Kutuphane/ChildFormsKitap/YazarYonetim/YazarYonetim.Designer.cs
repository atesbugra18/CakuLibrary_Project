namespace Kutuphane.ChildFormsKitap.YazarYonetim
{
    partial class YazarYonetim
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelcocuk = new System.Windows.Forms.Panel();
            this.panelcontroller = new System.Windows.Forms.Panel();
            this.panelheader = new System.Windows.Forms.Panel();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.yazarislemleri = new FontAwesome.Sharp.IconButton();
            this.btnhide = new System.Windows.Forms.Button();
            this.btnbig = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.panelfiltre = new System.Windows.Forms.Panel();
            this.btnfiltrele = new FontAwesome.Sharp.IconButton();
            this.btnyazarsilduzenle = new FontAwesome.Sharp.IconButton();
            this.btnyazarekle = new FontAwesome.Sharp.IconButton();
            this.panelara = new System.Windows.Forms.Panel();
            this.txtarama = new System.Windows.Forms.TextBox();
            this.lblara = new System.Windows.Forms.Label();
            this.gboxyazar = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.yazarid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yazaradi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yazarsoyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelcocuk.SuspendLayout();
            this.panelcontroller.SuspendLayout();
            this.panelheader.SuspendLayout();
            this.panelmenu.SuspendLayout();
            this.panelara.SuspendLayout();
            this.gboxyazar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelcocuk
            // 
            this.panelcocuk.Controls.Add(this.panelcontroller);
            this.panelcocuk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcocuk.Location = new System.Drawing.Point(0, 0);
            this.panelcocuk.Name = "panelcocuk";
            this.panelcocuk.Size = new System.Drawing.Size(1100, 800);
            this.panelcocuk.TabIndex = 0;
            // 
            // panelcontroller
            // 
            this.panelcontroller.Controls.Add(this.gboxyazar);
            this.panelcontroller.Controls.Add(this.panelara);
            this.panelcontroller.Controls.Add(this.panelmenu);
            this.panelcontroller.Controls.Add(this.panelheader);
            this.panelcontroller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcontroller.Location = new System.Drawing.Point(0, 0);
            this.panelcontroller.Name = "panelcontroller";
            this.panelcontroller.Size = new System.Drawing.Size(1100, 800);
            this.panelcontroller.TabIndex = 0;
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Controls.Add(this.btnhide);
            this.panelheader.Controls.Add(this.btnbig);
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.yazarislemleri);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1100, 100);
            this.panelheader.TabIndex = 0;
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelmenu.Controls.Add(this.panelfiltre);
            this.panelmenu.Controls.Add(this.btnfiltrele);
            this.panelmenu.Controls.Add(this.btnyazarsilduzenle);
            this.panelmenu.Controls.Add(this.btnyazarekle);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelmenu.Location = new System.Drawing.Point(900, 100);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(200, 700);
            this.panelmenu.TabIndex = 1;
            // 
            // yazarislemleri
            // 
            this.yazarislemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.yazarislemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yazarislemleri.Dock = System.Windows.Forms.DockStyle.Left;
            this.yazarislemleri.FlatAppearance.BorderSize = 0;
            this.yazarislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yazarislemleri.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yazarislemleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.yazarislemleri.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.yazarislemleri.IconColor = System.Drawing.Color.Gainsboro;
            this.yazarislemleri.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.yazarislemleri.IconSize = 30;
            this.yazarislemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yazarislemleri.Location = new System.Drawing.Point(0, 0);
            this.yazarislemleri.Name = "yazarislemleri";
            this.yazarislemleri.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.yazarislemleri.Size = new System.Drawing.Size(173, 100);
            this.yazarislemleri.TabIndex = 2;
            this.yazarislemleri.Text = "Yazar Yönetim";
            this.yazarislemleri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yazarislemleri.UseVisualStyleBackColor = false;
            this.yazarislemleri.MouseEnter += new System.EventHandler(this.yazarislemleri_MouseEnter);
            this.yazarislemleri.MouseLeave += new System.EventHandler(this.yazarislemleri_MouseLeave);
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
            this.btnhide.TabIndex = 10;
            this.btnhide.UseVisualStyleBackColor = false;
            this.btnhide.Click += new System.EventHandler(this.btnhide_Click);
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
            this.btnbig.TabIndex = 9;
            this.btnbig.UseVisualStyleBackColor = false;
            this.btnbig.Click += new System.EventHandler(this.btnbig_Click);
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
            this.btnclose.TabIndex = 8;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panelfiltre
            // 
            this.panelfiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelfiltre.Location = new System.Drawing.Point(0, 105);
            this.panelfiltre.Name = "panelfiltre";
            this.panelfiltre.Size = new System.Drawing.Size(200, 74);
            this.panelfiltre.TabIndex = 9;
            this.panelfiltre.Visible = false;
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
            this.btnfiltrele.TabIndex = 8;
            this.btnfiltrele.Text = "Filtrele";
            this.btnfiltrele.UseVisualStyleBackColor = false;
            this.btnfiltrele.Visible = false;
            this.btnfiltrele.Click += new System.EventHandler(this.btnfiltrele_Click);
            // 
            // btnyazarsilduzenle
            // 
            this.btnyazarsilduzenle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnyazarsilduzenle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnyazarsilduzenle.FlatAppearance.BorderSize = 0;
            this.btnyazarsilduzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyazarsilduzenle.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnyazarsilduzenle.IconColor = System.Drawing.Color.Black;
            this.btnyazarsilduzenle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnyazarsilduzenle.IconSize = 30;
            this.btnyazarsilduzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnyazarsilduzenle.Location = new System.Drawing.Point(0, 35);
            this.btnyazarsilduzenle.Name = "btnyazarsilduzenle";
            this.btnyazarsilduzenle.Size = new System.Drawing.Size(200, 35);
            this.btnyazarsilduzenle.TabIndex = 7;
            this.btnyazarsilduzenle.Text = "Yazar Sil && Düzenle";
            this.btnyazarsilduzenle.UseVisualStyleBackColor = false;
            this.btnyazarsilduzenle.Click += new System.EventHandler(this.btnyazarsilduzenle_Click);
            // 
            // btnyazarekle
            // 
            this.btnyazarekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnyazarekle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnyazarekle.FlatAppearance.BorderSize = 0;
            this.btnyazarekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyazarekle.ForeColor = System.Drawing.Color.Black;
            this.btnyazarekle.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnyazarekle.IconColor = System.Drawing.Color.Black;
            this.btnyazarekle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnyazarekle.IconSize = 30;
            this.btnyazarekle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnyazarekle.Location = new System.Drawing.Point(0, 0);
            this.btnyazarekle.Name = "btnyazarekle";
            this.btnyazarekle.Size = new System.Drawing.Size(200, 35);
            this.btnyazarekle.TabIndex = 5;
            this.btnyazarekle.Text = "Yazar Ekle";
            this.btnyazarekle.UseVisualStyleBackColor = false;
            this.btnyazarekle.Click += new System.EventHandler(this.btnyazarekle_Click);
            // 
            // panelara
            // 
            this.panelara.Controls.Add(this.lblara);
            this.panelara.Controls.Add(this.txtarama);
            this.panelara.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelara.Location = new System.Drawing.Point(0, 100);
            this.panelara.Name = "panelara";
            this.panelara.Size = new System.Drawing.Size(900, 47);
            this.panelara.TabIndex = 12;
            // 
            // txtarama
            // 
            this.txtarama.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtarama.Location = new System.Drawing.Point(0, 24);
            this.txtarama.MaxLength = 50;
            this.txtarama.Name = "txtarama";
            this.txtarama.Size = new System.Drawing.Size(900, 23);
            this.txtarama.TabIndex = 0;
            this.txtarama.TextChanged += new System.EventHandler(this.txtarama_TextChanged);
            // 
            // lblara
            // 
            this.lblara.AutoSize = true;
            this.lblara.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblara.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblara.Location = new System.Drawing.Point(0, 0);
            this.lblara.Name = "lblara";
            this.lblara.Size = new System.Drawing.Size(37, 19);
            this.lblara.TabIndex = 1;
            this.lblara.Text = "Ara:";
            // 
            // gboxyazar
            // 
            this.gboxyazar.Controls.Add(this.dataGridView1);
            this.gboxyazar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxyazar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gboxyazar.Location = new System.Drawing.Point(0, 147);
            this.gboxyazar.Name = "gboxyazar";
            this.gboxyazar.Size = new System.Drawing.Size(900, 653);
            this.gboxyazar.TabIndex = 13;
            this.gboxyazar.TabStop = false;
            this.gboxyazar.Text = "Yazarlar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yazarid,
            this.yazaradi,
            this.yazarsoyadi});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(894, 627);
            this.dataGridView1.TabIndex = 0;
            // 
            // yazarid
            // 
            this.yazarid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.yazarid.DataPropertyName = "yazarid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.yazarid.DefaultCellStyle = dataGridViewCellStyle4;
            this.yazarid.HeaderText = "Yazar Id";
            this.yazarid.MaxInputLength = 50;
            this.yazarid.Name = "yazarid";
            this.yazarid.ReadOnly = true;
            this.yazarid.Width = 86;
            // 
            // yazaradi
            // 
            this.yazaradi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.yazaradi.DataPropertyName = "yazaradi";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.yazaradi.DefaultCellStyle = dataGridViewCellStyle5;
            this.yazaradi.HeaderText = "Adı";
            this.yazaradi.MaxInputLength = 50;
            this.yazaradi.Name = "yazaradi";
            this.yazaradi.ReadOnly = true;
            // 
            // yazarsoyadi
            // 
            this.yazarsoyadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.yazarsoyadi.DataPropertyName = "yazarsoyadi";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.yazarsoyadi.DefaultCellStyle = dataGridViewCellStyle6;
            this.yazarsoyadi.HeaderText = "Soyad";
            this.yazarsoyadi.MaxInputLength = 50;
            this.yazarsoyadi.Name = "yazarsoyadi";
            this.yazarsoyadi.ReadOnly = true;
            // 
            // YazarYonetim
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panelcocuk);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YazarYonetim";
            this.Load += new System.EventHandler(this.YazarYonetim_Load);
            this.panelcocuk.ResumeLayout(false);
            this.panelcontroller.ResumeLayout(false);
            this.panelheader.ResumeLayout(false);
            this.panelmenu.ResumeLayout(false);
            this.panelara.ResumeLayout(false);
            this.panelara.PerformLayout();
            this.gboxyazar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelcocuk;
        private System.Windows.Forms.Panel panelcontroller;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Panel panelmenu;
        private FontAwesome.Sharp.IconButton yazarislemleri;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnbig;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panelfiltre;
        private FontAwesome.Sharp.IconButton btnfiltrele;
        private FontAwesome.Sharp.IconButton btnyazarsilduzenle;
        private FontAwesome.Sharp.IconButton btnyazarekle;
        private System.Windows.Forms.GroupBox gboxyazar;
        private System.Windows.Forms.Panel panelara;
        private System.Windows.Forms.Label lblara;
        private System.Windows.Forms.TextBox txtarama;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn yazarid;
        private System.Windows.Forms.DataGridViewTextBoxColumn yazaradi;
        private System.Windows.Forms.DataGridViewTextBoxColumn yazarsoyadi;
    }
}