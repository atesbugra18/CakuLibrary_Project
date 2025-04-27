namespace Kutuphane.ChildFormsKitap.KategoriYonetim
{
    partial class KategoriLayoutDesignerUi
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
            this.panelheader = new System.Windows.Forms.Panel();
            this.lbldurum = new System.Windows.Forms.Label();
            this.btnKategori = new FontAwesome.Sharp.IconButton();
            this.panelgenel = new System.Windows.Forms.Panel();
            this.panelkategoriekle = new System.Windows.Forms.Panel();
            this.lblkategoriekleadi = new System.Windows.Forms.Label();
            this.txtkategoriadi = new System.Windows.Forms.TextBox();
            this.panelsilduzenle = new System.Windows.Forms.Panel();
            this.panelgenelkontroller = new System.Windows.Forms.Panel();
            this.lblkategoriduzenle = new System.Windows.Forms.Label();
            this.txtyeniad = new System.Windows.Forms.TextBox();
            this.btnekle = new FontAwesome.Sharp.IconButton();
            this.btnsil = new FontAwesome.Sharp.IconButton();
            this.btndegistir = new FontAwesome.Sharp.IconButton();
            this.btniptal = new FontAwesome.Sharp.IconButton();
            this.btnclose = new FontAwesome.Sharp.IconButton();
            this.panelheader.SuspendLayout();
            this.panelgenel.SuspendLayout();
            this.panelkategoriekle.SuspendLayout();
            this.panelsilduzenle.SuspendLayout();
            this.panelgenelkontroller.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.lbldurum);
            this.panelheader.Controls.Add(this.btnKategori);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(897, 91);
            this.panelheader.TabIndex = 3;
            // 
            // lbldurum
            // 
            this.lbldurum.AutoSize = true;
            this.lbldurum.BackColor = System.Drawing.Color.White;
            this.lbldurum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbldurum.Location = new System.Drawing.Point(0, 76);
            this.lbldurum.Name = "lbldurum";
            this.lbldurum.Size = new System.Drawing.Size(78, 15);
            this.lbldurum.TabIndex = 1;
            this.lbldurum.Text = "Kategori Ekle";
            // 
            // btnKategori
            // 
            this.btnKategori.FlatAppearance.BorderSize = 0;
            this.btnKategori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategori.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKategori.IconChar = FontAwesome.Sharp.IconChar.FolderTree;
            this.btnKategori.IconColor = System.Drawing.Color.Gainsboro;
            this.btnKategori.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKategori.IconSize = 30;
            this.btnKategori.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKategori.Location = new System.Drawing.Point(3, 3);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(143, 70);
            this.btnKategori.TabIndex = 0;
            this.btnKategori.Text = "Kategori Yönetimi";
            this.btnKategori.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKategori.UseVisualStyleBackColor = true;
            this.btnKategori.MouseEnter += new System.EventHandler(this.btnKategori_MouseEnter);
            this.btnKategori.MouseLeave += new System.EventHandler(this.btnKategori_MouseLeave);
            // 
            // panelgenel
            // 
            this.panelgenel.Controls.Add(this.panelgenelkontroller);
            this.panelgenel.Controls.Add(this.panelsilduzenle);
            this.panelgenel.Controls.Add(this.panelkategoriekle);
            this.panelgenel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelgenel.Location = new System.Drawing.Point(0, 91);
            this.panelgenel.Name = "panelgenel";
            this.panelgenel.Size = new System.Drawing.Size(897, 589);
            this.panelgenel.TabIndex = 4;
            // 
            // panelkategoriekle
            // 
            this.panelkategoriekle.Controls.Add(this.txtkategoriadi);
            this.panelkategoriekle.Controls.Add(this.lblkategoriekleadi);
            this.panelkategoriekle.Controls.Add(this.btnekle);
            this.panelkategoriekle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelkategoriekle.Location = new System.Drawing.Point(0, 0);
            this.panelkategoriekle.Name = "panelkategoriekle";
            this.panelkategoriekle.Size = new System.Drawing.Size(897, 100);
            this.panelkategoriekle.TabIndex = 0;
            this.panelkategoriekle.Visible = false;
            // 
            // lblkategoriekleadi
            // 
            this.lblkategoriekleadi.AutoSize = true;
            this.lblkategoriekleadi.Location = new System.Drawing.Point(12, 17);
            this.lblkategoriekleadi.Name = "lblkategoriekleadi";
            this.lblkategoriekleadi.Size = new System.Drawing.Size(78, 15);
            this.lblkategoriekleadi.TabIndex = 0;
            this.lblkategoriekleadi.Text = "Kategori Adı:";
            // 
            // txtkategoriadi
            // 
            this.txtkategoriadi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtkategoriadi.Location = new System.Drawing.Point(15, 35);
            this.txtkategoriadi.MaxLength = 50;
            this.txtkategoriadi.Name = "txtkategoriadi";
            this.txtkategoriadi.Size = new System.Drawing.Size(173, 23);
            this.txtkategoriadi.TabIndex = 1;
            // 
            // panelsilduzenle
            // 
            this.panelsilduzenle.Controls.Add(this.txtyeniad);
            this.panelsilduzenle.Controls.Add(this.btndegistir);
            this.panelsilduzenle.Controls.Add(this.lblkategoriduzenle);
            this.panelsilduzenle.Controls.Add(this.btnsil);
            this.panelsilduzenle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelsilduzenle.Location = new System.Drawing.Point(0, 100);
            this.panelsilduzenle.Name = "panelsilduzenle";
            this.panelsilduzenle.Size = new System.Drawing.Size(897, 111);
            this.panelsilduzenle.TabIndex = 1;
            this.panelsilduzenle.Visible = false;
            // 
            // panelgenelkontroller
            // 
            this.panelgenelkontroller.Controls.Add(this.btniptal);
            this.panelgenelkontroller.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelgenelkontroller.Location = new System.Drawing.Point(0, 211);
            this.panelgenelkontroller.Name = "panelgenelkontroller";
            this.panelgenelkontroller.Size = new System.Drawing.Size(897, 56);
            this.panelgenelkontroller.TabIndex = 2;
            // 
            // lblkategoriduzenle
            // 
            this.lblkategoriduzenle.AutoSize = true;
            this.lblkategoriduzenle.Location = new System.Drawing.Point(12, 16);
            this.lblkategoriduzenle.Name = "lblkategoriduzenle";
            this.lblkategoriduzenle.Size = new System.Drawing.Size(78, 15);
            this.lblkategoriduzenle.TabIndex = 1;
            this.lblkategoriduzenle.Text = "Kategori Adı:";
            // 
            // txtyeniad
            // 
            this.txtyeniad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtyeniad.Location = new System.Drawing.Point(15, 36);
            this.txtyeniad.Name = "txtyeniad";
            this.txtyeniad.Size = new System.Drawing.Size(173, 23);
            this.txtyeniad.TabIndex = 2;
            // 
            // btnekle
            // 
            this.btnekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnekle.FlatAppearance.BorderSize = 0;
            this.btnekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnekle.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            this.btnekle.IconColor = System.Drawing.Color.Black;
            this.btnekle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnekle.IconSize = 25;
            this.btnekle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnekle.Location = new System.Drawing.Point(15, 62);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(112, 32);
            this.btnekle.TabIndex = 0;
            this.btnekle.Text = "Kategori Ekle";
            this.btnekle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // btnsil
            // 
            this.btnsil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnsil.FlatAppearance.BorderSize = 0;
            this.btnsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsil.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnsil.IconColor = System.Drawing.Color.Black;
            this.btnsil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsil.IconSize = 25;
            this.btnsil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsil.Location = new System.Drawing.Point(15, 71);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(112, 32);
            this.btnsil.TabIndex = 1;
            this.btnsil.Text = "Kategoriyi Sil ";
            this.btnsil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsil.UseVisualStyleBackColor = false;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btndegistir
            // 
            this.btndegistir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btndegistir.FlatAppearance.BorderSize = 0;
            this.btndegistir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndegistir.IconChar = FontAwesome.Sharp.IconChar.PenNib;
            this.btndegistir.IconColor = System.Drawing.Color.Black;
            this.btndegistir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndegistir.IconSize = 25;
            this.btndegistir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndegistir.Location = new System.Drawing.Point(133, 71);
            this.btndegistir.Name = "btndegistir";
            this.btndegistir.Size = new System.Drawing.Size(145, 32);
            this.btndegistir.TabIndex = 2;
            this.btndegistir.Text = "Değişiklikleri Kaydet";
            this.btndegistir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndegistir.UseVisualStyleBackColor = false;
            this.btndegistir.Click += new System.EventHandler(this.btndegistir_Click);
            // 
            // btniptal
            // 
            this.btniptal.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btniptal.IconColor = System.Drawing.Color.Black;
            this.btniptal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btniptal.Location = new System.Drawing.Point(133, 6);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(145, 32);
            this.btniptal.TabIndex = 3;
            this.btniptal.Text = "İptal Et";
            this.btniptal.UseVisualStyleBackColor = true;
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // btnclose
            // 
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnclose.IconColor = System.Drawing.Color.Gainsboro;
            this.btnclose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnclose.IconSize = 30;
            this.btnclose.Location = new System.Drawing.Point(841, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(44, 42);
            this.btnclose.TabIndex = 2;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // KategoriLayoutDesignerUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 680);
            this.ControlBox = false;
            this.Controls.Add(this.panelgenel);
            this.Controls.Add(this.panelheader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "KategoriLayoutDesignerUi";
            this.Text = "KategoriEkle";
            this.Load += new System.EventHandler(this.KategoriLayoutDesignerUi_Load);
            this.panelheader.ResumeLayout(false);
            this.panelheader.PerformLayout();
            this.panelgenel.ResumeLayout(false);
            this.panelkategoriekle.ResumeLayout(false);
            this.panelkategoriekle.PerformLayout();
            this.panelsilduzenle.ResumeLayout(false);
            this.panelsilduzenle.PerformLayout();
            this.panelgenelkontroller.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Label lbldurum;
        private FontAwesome.Sharp.IconButton btnKategori;
        private System.Windows.Forms.Panel panelgenel;
        private System.Windows.Forms.Panel panelgenelkontroller;
        private System.Windows.Forms.Panel panelsilduzenle;
        private System.Windows.Forms.TextBox txtyeniad;
        private System.Windows.Forms.Label lblkategoriduzenle;
        private System.Windows.Forms.Panel panelkategoriekle;
        private System.Windows.Forms.TextBox txtkategoriadi;
        private System.Windows.Forms.Label lblkategoriekleadi;
        private FontAwesome.Sharp.IconButton btndegistir;
        private FontAwesome.Sharp.IconButton btnsil;
        private FontAwesome.Sharp.IconButton btnekle;
        private FontAwesome.Sharp.IconButton btniptal;
        private FontAwesome.Sharp.IconButton btnclose;
    }
}