namespace Kutuphane.ChildFormsKitap.YazarYonetim
{
    partial class YazarYonetimLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelheader = new System.Windows.Forms.Panel();
            this.btnclose = new FontAwesome.Sharp.IconButton();
            this.lbldurum = new System.Windows.Forms.Label();
            this.kategoriislemleri = new FontAwesome.Sharp.IconButton();
            this.panelekle = new System.Windows.Forms.Panel();
            this.btnyazarekle = new FontAwesome.Sharp.IconButton();
            this.txtyazarsoyadi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtyazaradi = new System.Windows.Forms.TextBox();
            this.lblkategoriekleadi = new System.Windows.Forms.Label();
            this.panelsilduzenle = new System.Windows.Forms.Panel();
            this.btndegistir = new FontAwesome.Sharp.IconButton();
            this.btnsil = new FontAwesome.Sharp.IconButton();
            this.txtyazarsoyadiyeni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtyazaryeniad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelgenel = new System.Windows.Forms.Panel();
            this.btniptal = new FontAwesome.Sharp.IconButton();
            this.panelheader.SuspendLayout();
            this.panelekle.SuspendLayout();
            this.panelsilduzenle.SuspendLayout();
            this.panelgenel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.lbldurum);
            this.panelheader.Controls.Add(this.kategoriislemleri);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1100, 100);
            this.panelheader.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnclose.IconColor = System.Drawing.Color.Gainsboro;
            this.btnclose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnclose.IconSize = 30;
            this.btnclose.Location = new System.Drawing.Point(1053, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(44, 42);
            this.btnclose.TabIndex = 5;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lbldurum
            // 
            this.lbldurum.AutoSize = true;
            this.lbldurum.BackColor = System.Drawing.Color.White;
            this.lbldurum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbldurum.Location = new System.Drawing.Point(0, 85);
            this.lbldurum.Name = "lbldurum";
            this.lbldurum.Size = new System.Drawing.Size(60, 15);
            this.lbldurum.TabIndex = 4;
            this.lbldurum.Text = "Yazar Ekle";
            // 
            // kategoriislemleri
            // 
            this.kategoriislemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.kategoriislemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kategoriislemleri.FlatAppearance.BorderSize = 0;
            this.kategoriislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kategoriislemleri.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kategoriislemleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.kategoriislemleri.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.kategoriislemleri.IconColor = System.Drawing.Color.Gainsboro;
            this.kategoriislemleri.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.kategoriislemleri.IconSize = 30;
            this.kategoriislemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kategoriislemleri.Location = new System.Drawing.Point(3, 3);
            this.kategoriislemleri.Name = "kategoriislemleri";
            this.kategoriislemleri.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.kategoriislemleri.Size = new System.Drawing.Size(173, 70);
            this.kategoriislemleri.TabIndex = 3;
            this.kategoriislemleri.Text = "Yazar Yönetim";
            this.kategoriislemleri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kategoriislemleri.UseVisualStyleBackColor = false;
            this.kategoriislemleri.MouseEnter += new System.EventHandler(this.kategoriislemleri_MouseEnter);
            this.kategoriislemleri.MouseLeave += new System.EventHandler(this.kategoriislemleri_MouseLeave);
            // 
            // panelekle
            // 
            this.panelekle.Controls.Add(this.btnyazarekle);
            this.panelekle.Controls.Add(this.txtyazarsoyadi);
            this.panelekle.Controls.Add(this.label1);
            this.panelekle.Controls.Add(this.txtyazaradi);
            this.panelekle.Controls.Add(this.lblkategoriekleadi);
            this.panelekle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelekle.Location = new System.Drawing.Point(0, 100);
            this.panelekle.Name = "panelekle";
            this.panelekle.Size = new System.Drawing.Size(1100, 163);
            this.panelekle.TabIndex = 1;
            // 
            // btnyazarekle
            // 
            this.btnyazarekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnyazarekle.FlatAppearance.BorderSize = 0;
            this.btnyazarekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyazarekle.ForeColor = System.Drawing.Color.Black;
            this.btnyazarekle.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnyazarekle.IconColor = System.Drawing.Color.Black;
            this.btnyazarekle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnyazarekle.IconSize = 30;
            this.btnyazarekle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnyazarekle.Location = new System.Drawing.Point(6, 113);
            this.btnyazarekle.Name = "btnyazarekle";
            this.btnyazarekle.Size = new System.Drawing.Size(103, 35);
            this.btnyazarekle.TabIndex = 7;
            this.btnyazarekle.Text = "Yazar Ekle";
            this.btnyazarekle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnyazarekle.UseVisualStyleBackColor = false;
            this.btnyazarekle.Click += new System.EventHandler(this.btnyazarekle_Click);
            // 
            // txtyazarsoyadi
            // 
            this.txtyazarsoyadi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtyazarsoyadi.Location = new System.Drawing.Point(6, 74);
            this.txtyazarsoyadi.MaxLength = 50;
            this.txtyazarsoyadi.Name = "txtyazarsoyadi";
            this.txtyazarsoyadi.Size = new System.Drawing.Size(173, 23);
            this.txtyazarsoyadi.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Yazar Soyadı:";
            // 
            // txtyazaradi
            // 
            this.txtyazaradi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtyazaradi.Location = new System.Drawing.Point(6, 30);
            this.txtyazaradi.MaxLength = 50;
            this.txtyazaradi.Name = "txtyazaradi";
            this.txtyazaradi.Size = new System.Drawing.Size(173, 23);
            this.txtyazaradi.TabIndex = 4;
            // 
            // lblkategoriekleadi
            // 
            this.lblkategoriekleadi.AutoSize = true;
            this.lblkategoriekleadi.Location = new System.Drawing.Point(3, 12);
            this.lblkategoriekleadi.Name = "lblkategoriekleadi";
            this.lblkategoriekleadi.Size = new System.Drawing.Size(60, 15);
            this.lblkategoriekleadi.TabIndex = 2;
            this.lblkategoriekleadi.Text = "Yazar Adı:";
            // 
            // panelsilduzenle
            // 
            this.panelsilduzenle.Controls.Add(this.btndegistir);
            this.panelsilduzenle.Controls.Add(this.btnsil);
            this.panelsilduzenle.Controls.Add(this.txtyazarsoyadiyeni);
            this.panelsilduzenle.Controls.Add(this.label2);
            this.panelsilduzenle.Controls.Add(this.txtyazaryeniad);
            this.panelsilduzenle.Controls.Add(this.label3);
            this.panelsilduzenle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelsilduzenle.Location = new System.Drawing.Point(0, 263);
            this.panelsilduzenle.Name = "panelsilduzenle";
            this.panelsilduzenle.Size = new System.Drawing.Size(1100, 157);
            this.panelsilduzenle.TabIndex = 2;
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
            this.btndegistir.Location = new System.Drawing.Point(95, 103);
            this.btndegistir.Name = "btndegistir";
            this.btndegistir.Size = new System.Drawing.Size(145, 32);
            this.btndegistir.TabIndex = 12;
            this.btndegistir.Text = "Değişiklikleri Kaydet";
            this.btndegistir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndegistir.UseVisualStyleBackColor = false;
            this.btndegistir.Click += new System.EventHandler(this.btndegistir_Click);
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
            this.btnsil.Location = new System.Drawing.Point(5, 103);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(84, 32);
            this.btnsil.TabIndex = 11;
            this.btnsil.Text = "Yazarı Sil";
            this.btnsil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsil.UseVisualStyleBackColor = false;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // txtyazarsoyadiyeni
            // 
            this.txtyazarsoyadiyeni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtyazarsoyadiyeni.Location = new System.Drawing.Point(6, 74);
            this.txtyazarsoyadiyeni.MaxLength = 50;
            this.txtyazarsoyadiyeni.Name = "txtyazarsoyadiyeni";
            this.txtyazarsoyadiyeni.Size = new System.Drawing.Size(173, 23);
            this.txtyazarsoyadiyeni.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Yazar Soyadı:";
            // 
            // txtyazaryeniad
            // 
            this.txtyazaryeniad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtyazaryeniad.Location = new System.Drawing.Point(6, 30);
            this.txtyazaryeniad.MaxLength = 50;
            this.txtyazaryeniad.Name = "txtyazaryeniad";
            this.txtyazaryeniad.Size = new System.Drawing.Size(173, 23);
            this.txtyazaryeniad.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Yazar Adı:";
            // 
            // panelgenel
            // 
            this.panelgenel.Controls.Add(this.btniptal);
            this.panelgenel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelgenel.Location = new System.Drawing.Point(0, 420);
            this.panelgenel.Name = "panelgenel";
            this.panelgenel.Size = new System.Drawing.Size(1100, 45);
            this.panelgenel.TabIndex = 3;
            // 
            // btniptal
            // 
            this.btniptal.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btniptal.IconColor = System.Drawing.Color.Black;
            this.btniptal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btniptal.Location = new System.Drawing.Point(109, 5);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(173, 32);
            this.btniptal.TabIndex = 4;
            this.btniptal.Text = "İptal Et";
            this.btniptal.UseVisualStyleBackColor = true;
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // YazarYonetimLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelgenel);
            this.Controls.Add(this.panelsilduzenle);
            this.Controls.Add(this.panelekle);
            this.Controls.Add(this.panelheader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "YazarYonetimLayout";
            this.Size = new System.Drawing.Size(1100, 800);
            this.Load += new System.EventHandler(this.YazarYonetimLayout_Load);
            this.panelheader.ResumeLayout(false);
            this.panelheader.PerformLayout();
            this.panelekle.ResumeLayout(false);
            this.panelekle.PerformLayout();
            this.panelsilduzenle.ResumeLayout(false);
            this.panelsilduzenle.PerformLayout();
            this.panelgenel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Panel panelekle;
        private System.Windows.Forms.Panel panelsilduzenle;
        private FontAwesome.Sharp.IconButton kategoriislemleri;
        private System.Windows.Forms.Label lbldurum;
        private System.Windows.Forms.TextBox txtyazarsoyadi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtyazaradi;
        private System.Windows.Forms.Label lblkategoriekleadi;
        private FontAwesome.Sharp.IconButton btnyazarekle;
        private System.Windows.Forms.TextBox txtyazarsoyadiyeni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtyazaryeniad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelgenel;
        private FontAwesome.Sharp.IconButton btniptal;
        private FontAwesome.Sharp.IconButton btndegistir;
        private FontAwesome.Sharp.IconButton btnsil;
        private FontAwesome.Sharp.IconButton btnclose;
    }
}
