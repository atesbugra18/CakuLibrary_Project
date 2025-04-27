namespace Kutuphane
{
    partial class HomeDesignerUi
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnkalansure = new FontAwesome.Sharp.IconButton();
            this.panelodeme = new System.Windows.Forms.Panel();
            this.btnodeme = new FontAwesome.Sharp.IconButton();
            this.btnodemeislemleri = new System.Windows.Forms.Button();
            this.panelanaliz = new System.Windows.Forms.Panel();
            this.btnkullanim = new FontAwesome.Sharp.IconButton();
            this.btngeciken = new FontAwesome.Sharp.IconButton();
            this.btnaktif = new FontAwesome.Sharp.IconButton();
            this.btnpopuler = new FontAwesome.Sharp.IconButton();
            this.btnanalizveistatistik = new System.Windows.Forms.Button();
            this.panelkullaniciislemleri = new System.Windows.Forms.Panel();
            this.btnbildirim = new FontAwesome.Sharp.IconButton();
            this.btnokumalistesi = new FontAwesome.Sharp.IconButton();
            this.btnkullanicilar = new FontAwesome.Sharp.IconButton();
            this.btnkullaniciislemleri = new System.Windows.Forms.Button();
            this.panelkitapislemleri = new System.Windows.Forms.Panel();
            this.btnyazaryonetim = new FontAwesome.Sharp.IconButton();
            this.btnkategoriyonetim = new FontAwesome.Sharp.IconButton();
            this.btnkitapyonetim = new FontAwesome.Sharp.IconButton();
            this.btnkitapislemlerimenu = new System.Windows.Forms.Button();
            this.panellogo = new System.Windows.Forms.Panel();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.panelheader = new System.Windows.Forms.Panel();
            this.btnhide = new System.Windows.Forms.Button();
            this.btnbig = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.HomeButton = new FontAwesome.Sharp.IconButton();
            this.panelkullanici = new System.Windows.Forms.Panel();
            this.btnkullanicinfo = new FontAwesome.Sharp.IconButton();
            this.panelebeveyn = new System.Windows.Forms.Panel();
            this.durumcubugu = new System.Windows.Forms.StatusStrip();
            this.lbltarihsaat = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerbutonlar = new System.Windows.Forms.Timer(this.components);
            this.tarihsaat = new System.Windows.Forms.Timer(this.components);
            this.picKullanici = new Kutuphane.Control.EllipsePictureBox();
            this.panelMenu.SuspendLayout();
            this.panelodeme.SuspendLayout();
            this.panelanaliz.SuspendLayout();
            this.panelkullaniciislemleri.SuspendLayout();
            this.panelkitapislemleri.SuspendLayout();
            this.panellogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            this.panelheader.SuspendLayout();
            this.panelkullanici.SuspendLayout();
            this.durumcubugu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKullanici)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnkalansure);
            this.panelMenu.Controls.Add(this.panelodeme);
            this.panelMenu.Controls.Add(this.btnodemeislemleri);
            this.panelMenu.Controls.Add(this.panelanaliz);
            this.panelMenu.Controls.Add(this.btnanalizveistatistik);
            this.panelMenu.Controls.Add(this.panelkullaniciislemleri);
            this.panelMenu.Controls.Add(this.btnkullaniciislemleri);
            this.panelMenu.Controls.Add(this.panelkitapislemleri);
            this.panelMenu.Controls.Add(this.btnkitapislemlerimenu);
            this.panelMenu.Controls.Add(this.panellogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(280, 904);
            this.panelMenu.TabIndex = 0;
            // 
            // btnkalansure
            // 
            this.btnkalansure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnkalansure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkalansure.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnkalansure.FlatAppearance.BorderSize = 0;
            this.btnkalansure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkalansure.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkalansure.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkalansure.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            this.btnkalansure.IconColor = System.Drawing.Color.Gainsboro;
            this.btnkalansure.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkalansure.IconSize = 30;
            this.btnkalansure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkalansure.Location = new System.Drawing.Point(0, 866);
            this.btnkalansure.Name = "btnkalansure";
            this.btnkalansure.Size = new System.Drawing.Size(280, 38);
            this.btnkalansure.TabIndex = 17;
            this.btnkalansure.Text = "Oturumun Kapanmasına Kalan Süre: 59:59";
            this.btnkalansure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnkalansure.UseVisualStyleBackColor = false;
            this.btnkalansure.Click += new System.EventHandler(this.btnkalansure_Click);
            // 
            // panelodeme
            // 
            this.panelodeme.Controls.Add(this.btnodeme);
            this.panelodeme.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelodeme.Location = new System.Drawing.Point(0, 560);
            this.panelodeme.Name = "panelodeme";
            this.panelodeme.Size = new System.Drawing.Size(280, 30);
            this.panelodeme.TabIndex = 8;
            this.panelodeme.Visible = false;
            // 
            // btnodeme
            // 
            this.btnodeme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnodeme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnodeme.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnodeme.FlatAppearance.BorderSize = 0;
            this.btnodeme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnodeme.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnodeme.IconChar = FontAwesome.Sharp.IconChar.TurkishLira;
            this.btnodeme.IconColor = System.Drawing.Color.Gainsboro;
            this.btnodeme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnodeme.IconSize = 30;
            this.btnodeme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnodeme.Location = new System.Drawing.Point(0, 0);
            this.btnodeme.Name = "btnodeme";
            this.btnodeme.Padding = new System.Windows.Forms.Padding(0, 0, 110, 0);
            this.btnodeme.Size = new System.Drawing.Size(280, 30);
            this.btnodeme.TabIndex = 16;
            this.btnodeme.Text = "Ödeme Al";
            this.btnodeme.UseVisualStyleBackColor = false;
            this.btnodeme.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnodeme.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnodemeislemleri
            // 
            this.btnodemeislemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnodemeislemleri.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnodemeislemleri.FlatAppearance.BorderSize = 0;
            this.btnodemeislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnodemeislemleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnodemeislemleri.Location = new System.Drawing.Point(0, 520);
            this.btnodemeislemleri.Name = "btnodemeislemleri";
            this.btnodemeislemleri.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnodemeislemleri.Size = new System.Drawing.Size(280, 40);
            this.btnodemeislemleri.TabIndex = 7;
            this.btnodemeislemleri.Text = "Ödeme İşlemleri";
            this.btnodemeislemleri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnodemeislemleri.UseVisualStyleBackColor = true;
            this.btnodemeislemleri.Click += new System.EventHandler(this.btnodemeislemleri_Click);
            // 
            // panelanaliz
            // 
            this.panelanaliz.Controls.Add(this.btnkullanim);
            this.panelanaliz.Controls.Add(this.btngeciken);
            this.panelanaliz.Controls.Add(this.btnaktif);
            this.panelanaliz.Controls.Add(this.btnpopuler);
            this.panelanaliz.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelanaliz.Location = new System.Drawing.Point(0, 400);
            this.panelanaliz.Name = "panelanaliz";
            this.panelanaliz.Size = new System.Drawing.Size(280, 120);
            this.panelanaliz.TabIndex = 6;
            this.panelanaliz.Visible = false;
            // 
            // btnkullanim
            // 
            this.btnkullanim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnkullanim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkullanim.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkullanim.FlatAppearance.BorderSize = 0;
            this.btnkullanim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkullanim.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkullanim.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnkullanim.IconColor = System.Drawing.Color.Gainsboro;
            this.btnkullanim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkullanim.IconSize = 30;
            this.btnkullanim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkullanim.Location = new System.Drawing.Point(0, 90);
            this.btnkullanim.Name = "btnkullanim";
            this.btnkullanim.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.btnkullanim.Size = new System.Drawing.Size(280, 30);
            this.btnkullanim.TabIndex = 15;
            this.btnkullanim.Text = "Kullanım İstatistikleri";
            this.btnkullanim.UseVisualStyleBackColor = false;
            this.btnkullanim.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnkullanim.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btngeciken
            // 
            this.btngeciken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btngeciken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btngeciken.Dock = System.Windows.Forms.DockStyle.Top;
            this.btngeciken.FlatAppearance.BorderSize = 0;
            this.btngeciken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngeciken.ForeColor = System.Drawing.Color.Gainsboro;
            this.btngeciken.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.btngeciken.IconColor = System.Drawing.Color.Gainsboro;
            this.btngeciken.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btngeciken.IconSize = 30;
            this.btngeciken.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngeciken.Location = new System.Drawing.Point(0, 60);
            this.btngeciken.Name = "btngeciken";
            this.btngeciken.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.btngeciken.Size = new System.Drawing.Size(280, 30);
            this.btngeciken.TabIndex = 14;
            this.btngeciken.Text = "Geciken Kitap Listesi";
            this.btngeciken.UseVisualStyleBackColor = false;
            this.btngeciken.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btngeciken.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnaktif
            // 
            this.btnaktif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnaktif.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaktif.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnaktif.FlatAppearance.BorderSize = 0;
            this.btnaktif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaktif.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnaktif.IconChar = FontAwesome.Sharp.IconChar.UserClock;
            this.btnaktif.IconColor = System.Drawing.Color.Gainsboro;
            this.btnaktif.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnaktif.IconSize = 30;
            this.btnaktif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaktif.Location = new System.Drawing.Point(0, 30);
            this.btnaktif.Name = "btnaktif";
            this.btnaktif.Padding = new System.Windows.Forms.Padding(0, 0, 80, 0);
            this.btnaktif.Size = new System.Drawing.Size(280, 30);
            this.btnaktif.TabIndex = 13;
            this.btnaktif.Text = "En Aktif Üyeler";
            this.btnaktif.UseVisualStyleBackColor = false;
            this.btnaktif.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnaktif.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnpopuler
            // 
            this.btnpopuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnpopuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpopuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnpopuler.FlatAppearance.BorderSize = 0;
            this.btnpopuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpopuler.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnpopuler.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.btnpopuler.IconColor = System.Drawing.Color.Gainsboro;
            this.btnpopuler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnpopuler.IconSize = 30;
            this.btnpopuler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpopuler.Location = new System.Drawing.Point(0, 0);
            this.btnpopuler.Name = "btnpopuler";
            this.btnpopuler.Padding = new System.Windows.Forms.Padding(0, 0, 110, 0);
            this.btnpopuler.Size = new System.Drawing.Size(280, 30);
            this.btnpopuler.TabIndex = 12;
            this.btnpopuler.Text = "Popülerler";
            this.btnpopuler.UseVisualStyleBackColor = false;
            this.btnpopuler.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnpopuler.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnanalizveistatistik
            // 
            this.btnanalizveistatistik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnanalizveistatistik.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnanalizveistatistik.FlatAppearance.BorderSize = 0;
            this.btnanalizveistatistik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnanalizveistatistik.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnanalizveistatistik.Location = new System.Drawing.Point(0, 360);
            this.btnanalizveistatistik.Name = "btnanalizveistatistik";
            this.btnanalizveistatistik.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnanalizveistatistik.Size = new System.Drawing.Size(280, 40);
            this.btnanalizveistatistik.TabIndex = 5;
            this.btnanalizveistatistik.Text = "Analiz ve İstatistik İşlemleri";
            this.btnanalizveistatistik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnanalizveistatistik.UseVisualStyleBackColor = true;
            this.btnanalizveistatistik.Click += new System.EventHandler(this.btnanalizveistatistik_Click);
            // 
            // panelkullaniciislemleri
            // 
            this.panelkullaniciislemleri.Controls.Add(this.btnbildirim);
            this.panelkullaniciislemleri.Controls.Add(this.btnokumalistesi);
            this.panelkullaniciislemleri.Controls.Add(this.btnkullanicilar);
            this.panelkullaniciislemleri.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelkullaniciislemleri.Location = new System.Drawing.Point(0, 270);
            this.panelkullaniciislemleri.Name = "panelkullaniciislemleri";
            this.panelkullaniciislemleri.Size = new System.Drawing.Size(280, 90);
            this.panelkullaniciislemleri.TabIndex = 4;
            this.panelkullaniciislemleri.Visible = false;
            // 
            // btnbildirim
            // 
            this.btnbildirim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnbildirim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbildirim.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnbildirim.FlatAppearance.BorderSize = 0;
            this.btnbildirim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbildirim.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnbildirim.IconChar = FontAwesome.Sharp.IconChar.MailBulk;
            this.btnbildirim.IconColor = System.Drawing.Color.Gainsboro;
            this.btnbildirim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbildirim.IconSize = 30;
            this.btnbildirim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbildirim.Location = new System.Drawing.Point(0, 60);
            this.btnbildirim.Name = "btnbildirim";
            this.btnbildirim.Padding = new System.Windows.Forms.Padding(0, 0, 75, 0);
            this.btnbildirim.Size = new System.Drawing.Size(280, 30);
            this.btnbildirim.TabIndex = 5;
            this.btnbildirim.Text = "Bildirim Gönder";
            this.btnbildirim.UseVisualStyleBackColor = false;
            this.btnbildirim.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnbildirim.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnokumalistesi
            // 
            this.btnokumalistesi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnokumalistesi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnokumalistesi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnokumalistesi.FlatAppearance.BorderSize = 0;
            this.btnokumalistesi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnokumalistesi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnokumalistesi.IconChar = FontAwesome.Sharp.IconChar.Readme;
            this.btnokumalistesi.IconColor = System.Drawing.Color.Gainsboro;
            this.btnokumalistesi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnokumalistesi.IconSize = 30;
            this.btnokumalistesi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnokumalistesi.Location = new System.Drawing.Point(0, 30);
            this.btnokumalistesi.Name = "btnokumalistesi";
            this.btnokumalistesi.Padding = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.btnokumalistesi.Size = new System.Drawing.Size(280, 30);
            this.btnokumalistesi.TabIndex = 4;
            this.btnokumalistesi.Text = "Üye Okuma Listesi";
            this.btnokumalistesi.UseVisualStyleBackColor = false;
            this.btnokumalistesi.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnokumalistesi.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnkullanicilar
            // 
            this.btnkullanicilar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnkullanicilar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkullanicilar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkullanicilar.FlatAppearance.BorderSize = 0;
            this.btnkullanicilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkullanicilar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkullanicilar.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnkullanicilar.IconColor = System.Drawing.Color.Gainsboro;
            this.btnkullanicilar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkullanicilar.IconSize = 30;
            this.btnkullanicilar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkullanicilar.Location = new System.Drawing.Point(0, 0);
            this.btnkullanicilar.Name = "btnkullanicilar";
            this.btnkullanicilar.Padding = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.btnkullanicilar.Size = new System.Drawing.Size(280, 30);
            this.btnkullanicilar.TabIndex = 3;
            this.btnkullanicilar.Text = "Kullanıcı Yönetimi";
            this.btnkullanicilar.UseVisualStyleBackColor = false;
            this.btnkullanicilar.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnkullanicilar.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnkullaniciislemleri
            // 
            this.btnkullaniciislemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkullaniciislemleri.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkullaniciislemleri.FlatAppearance.BorderSize = 0;
            this.btnkullaniciislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkullaniciislemleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkullaniciislemleri.Location = new System.Drawing.Point(0, 230);
            this.btnkullaniciislemleri.Name = "btnkullaniciislemleri";
            this.btnkullaniciislemleri.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnkullaniciislemleri.Size = new System.Drawing.Size(280, 40);
            this.btnkullaniciislemleri.TabIndex = 3;
            this.btnkullaniciislemleri.Text = "Kullanıcı İşlemleri";
            this.btnkullaniciislemleri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkullaniciislemleri.UseVisualStyleBackColor = true;
            this.btnkullaniciislemleri.Click += new System.EventHandler(this.btnkullaniciislemleri_Click);
            // 
            // panelkitapislemleri
            // 
            this.panelkitapislemleri.Controls.Add(this.btnyazaryonetim);
            this.panelkitapislemleri.Controls.Add(this.btnkategoriyonetim);
            this.panelkitapislemleri.Controls.Add(this.btnkitapyonetim);
            this.panelkitapislemleri.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelkitapislemleri.Location = new System.Drawing.Point(0, 140);
            this.panelkitapislemleri.Name = "panelkitapislemleri";
            this.panelkitapislemleri.Size = new System.Drawing.Size(280, 90);
            this.panelkitapislemleri.TabIndex = 2;
            this.panelkitapislemleri.Visible = false;
            // 
            // btnyazaryonetim
            // 
            this.btnyazaryonetim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnyazaryonetim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnyazaryonetim.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnyazaryonetim.FlatAppearance.BorderSize = 0;
            this.btnyazaryonetim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyazaryonetim.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnyazaryonetim.IconChar = FontAwesome.Sharp.IconChar.PenNib;
            this.btnyazaryonetim.IconColor = System.Drawing.Color.Gainsboro;
            this.btnyazaryonetim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnyazaryonetim.IconSize = 30;
            this.btnyazaryonetim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnyazaryonetim.Location = new System.Drawing.Point(0, 60);
            this.btnyazaryonetim.Name = "btnyazaryonetim";
            this.btnyazaryonetim.Padding = new System.Windows.Forms.Padding(0, 0, 80, 0);
            this.btnyazaryonetim.Size = new System.Drawing.Size(280, 30);
            this.btnyazaryonetim.TabIndex = 2;
            this.btnyazaryonetim.Text = "Yazar Yönetimi";
            this.btnyazaryonetim.UseVisualStyleBackColor = false;
            this.btnyazaryonetim.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnyazaryonetim.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnkategoriyonetim
            // 
            this.btnkategoriyonetim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnkategoriyonetim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkategoriyonetim.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkategoriyonetim.FlatAppearance.BorderSize = 0;
            this.btnkategoriyonetim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkategoriyonetim.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkategoriyonetim.IconChar = FontAwesome.Sharp.IconChar.FolderTree;
            this.btnkategoriyonetim.IconColor = System.Drawing.Color.Gainsboro;
            this.btnkategoriyonetim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkategoriyonetim.IconSize = 30;
            this.btnkategoriyonetim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkategoriyonetim.Location = new System.Drawing.Point(0, 30);
            this.btnkategoriyonetim.Name = "btnkategoriyonetim";
            this.btnkategoriyonetim.Padding = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.btnkategoriyonetim.Size = new System.Drawing.Size(280, 30);
            this.btnkategoriyonetim.TabIndex = 1;
            this.btnkategoriyonetim.Text = "Kategori Yönetimi";
            this.btnkategoriyonetim.UseVisualStyleBackColor = false;
            this.btnkategoriyonetim.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnkategoriyonetim.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnkitapyonetim
            // 
            this.btnkitapyonetim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.btnkitapyonetim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkitapyonetim.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkitapyonetim.FlatAppearance.BorderSize = 0;
            this.btnkitapyonetim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkitapyonetim.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkitapyonetim.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnkitapyonetim.IconColor = System.Drawing.Color.Gainsboro;
            this.btnkitapyonetim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkitapyonetim.IconSize = 30;
            this.btnkitapyonetim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkitapyonetim.Location = new System.Drawing.Point(0, 0);
            this.btnkitapyonetim.Name = "btnkitapyonetim";
            this.btnkitapyonetim.Padding = new System.Windows.Forms.Padding(0, 0, 80, 0);
            this.btnkitapyonetim.Size = new System.Drawing.Size(280, 30);
            this.btnkitapyonetim.TabIndex = 0;
            this.btnkitapyonetim.Text = "Kitap Yönetimi";
            this.btnkitapyonetim.UseVisualStyleBackColor = false;
            this.btnkitapyonetim.MouseEnter += new System.EventHandler(this.btnkitapyonetim_MouseEnter);
            this.btnkitapyonetim.MouseLeave += new System.EventHandler(this.btnodeme_MouseLeave);
            // 
            // btnkitapislemlerimenu
            // 
            this.btnkitapislemlerimenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkitapislemlerimenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnkitapislemlerimenu.FlatAppearance.BorderSize = 0;
            this.btnkitapislemlerimenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkitapislemlerimenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkitapislemlerimenu.Location = new System.Drawing.Point(0, 100);
            this.btnkitapislemlerimenu.Name = "btnkitapislemlerimenu";
            this.btnkitapislemlerimenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnkitapislemlerimenu.Size = new System.Drawing.Size(280, 40);
            this.btnkitapislemlerimenu.TabIndex = 1;
            this.btnkitapislemlerimenu.Text = "Kitap İşlemleri";
            this.btnkitapislemlerimenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkitapislemlerimenu.UseVisualStyleBackColor = true;
            this.btnkitapislemlerimenu.Click += new System.EventHandler(this.btnkitapislemlerimenu_Click);
            // 
            // panellogo
            // 
            this.panellogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panellogo.Controls.Add(this.piclogo);
            this.panellogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellogo.Location = new System.Drawing.Point(0, 0);
            this.panellogo.Name = "panellogo";
            this.panellogo.Size = new System.Drawing.Size(280, 100);
            this.panellogo.TabIndex = 0;
            // 
            // piclogo
            // 
            this.piclogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.piclogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.piclogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.piclogo.Location = new System.Drawing.Point(0, 0);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(280, 100);
            this.piclogo.TabIndex = 0;
            this.piclogo.TabStop = false;
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelheader.Controls.Add(this.btnhide);
            this.panelheader.Controls.Add(this.btnbig);
            this.panelheader.Controls.Add(this.btnclose);
            this.panelheader.Controls.Add(this.HomeButton);
            this.panelheader.Controls.Add(this.panelkullanici);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(280, 0);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1104, 100);
            this.panelheader.TabIndex = 1;
            this.panelheader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelheader_MouseDown);
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
            this.btnhide.Location = new System.Drawing.Point(1044, 3);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(15, 15);
            this.btnhide.TabIndex = 4;
            this.btnhide.UseVisualStyleBackColor = false;
            this.btnhide.Click += new System.EventHandler(this.btnhide_Click);
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
            this.btnbig.Location = new System.Drawing.Point(1065, 3);
            this.btnbig.Name = "btnbig";
            this.btnbig.Size = new System.Drawing.Size(15, 15);
            this.btnbig.TabIndex = 3;
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
            this.btnclose.Location = new System.Drawing.Point(1086, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(15, 15);
            this.btnclose.TabIndex = 2;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.HomeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.HomeButton.IconChar = FontAwesome.Sharp.IconChar.House;
            this.HomeButton.IconColor = System.Drawing.Color.Gainsboro;
            this.HomeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.HomeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.Location = new System.Drawing.Point(6, 23);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(104, 50);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "Home";
            this.HomeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.MouseEnter += new System.EventHandler(this.HomeButton_MouseEnter);
            this.HomeButton.MouseLeave += new System.EventHandler(this.HomeButton_MouseLeave);
            // 
            // panelkullanici
            // 
            this.panelkullanici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelkullanici.Controls.Add(this.btnkullanicinfo);
            this.panelkullanici.Controls.Add(this.picKullanici);
            this.panelkullanici.Location = new System.Drawing.Point(851, 19);
            this.panelkullanici.Name = "panelkullanici";
            this.panelkullanici.Size = new System.Drawing.Size(253, 80);
            this.panelkullanici.TabIndex = 0;
            // 
            // btnkullanicinfo
            // 
            this.btnkullanicinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnkullanicinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkullanicinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnkullanicinfo.FlatAppearance.BorderSize = 0;
            this.btnkullanicinfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnkullanicinfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnkullanicinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkullanicinfo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkullanicinfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnkullanicinfo.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this.btnkullanicinfo.IconColor = System.Drawing.Color.Gainsboro;
            this.btnkullanicinfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkullanicinfo.IconSize = 30;
            this.btnkullanicinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnkullanicinfo.Location = new System.Drawing.Point(87, 0);
            this.btnkullanicinfo.Name = "btnkullanicinfo";
            this.btnkullanicinfo.Size = new System.Drawing.Size(166, 80);
            this.btnkullanicinfo.TabIndex = 1;
            this.btnkullanicinfo.Text = "V";
            this.btnkullanicinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkullanicinfo.UseVisualStyleBackColor = false;
            // 
            // panelebeveyn
            // 
            this.panelebeveyn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelebeveyn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelebeveyn.Location = new System.Drawing.Point(280, 100);
            this.panelebeveyn.Name = "panelebeveyn";
            this.panelebeveyn.Size = new System.Drawing.Size(1104, 804);
            this.panelebeveyn.TabIndex = 3;
            // 
            // durumcubugu
            // 
            this.durumcubugu.AutoSize = false;
            this.durumcubugu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.durumcubugu.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.durumcubugu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbltarihsaat});
            this.durumcubugu.Location = new System.Drawing.Point(280, 866);
            this.durumcubugu.Name = "durumcubugu";
            this.durumcubugu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.durumcubugu.Size = new System.Drawing.Size(1104, 38);
            this.durumcubugu.TabIndex = 4;
            this.durumcubugu.Text = "statusStrip1";
            // 
            // lbltarihsaat
            // 
            this.lbltarihsaat.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbltarihsaat.Name = "lbltarihsaat";
            this.lbltarihsaat.Size = new System.Drawing.Size(0, 33);
            // 
            // timerbutonlar
            // 
            this.timerbutonlar.Interval = 5;
            this.timerbutonlar.Tick += new System.EventHandler(this.timerbutonlar_Tick);
            // 
            // tarihsaat
            // 
            this.tarihsaat.Enabled = true;
            this.tarihsaat.Interval = 1000;
            this.tarihsaat.Tick += new System.EventHandler(this.tarihsaat_Tick);
            // 
            // picKullanici
            // 
            this.picKullanici.borderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.picKullanici.Bordercolor = System.Drawing.Color.Transparent;
            this.picKullanici.Bordercolor2 = System.Drawing.Color.Transparent;
            this.picKullanici.borderlineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.picKullanici.BorderSize = 2;
            this.picKullanici.Dock = System.Windows.Forms.DockStyle.Left;
            this.picKullanici.GradientAngle = 50F;
            this.picKullanici.Location = new System.Drawing.Point(0, 0);
            this.picKullanici.Name = "picKullanici";
            this.picKullanici.Size = new System.Drawing.Size(87, 80);
            this.picKullanici.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picKullanici.TabIndex = 0;
            this.picKullanici.TabStop = false;
            // 
            // HomeDesignerUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 904);
            this.ControlBox = false;
            this.Controls.Add(this.durumcubugu);
            this.Controls.Add(this.panelebeveyn);
            this.Controls.Add(this.panelheader);
            this.Controls.Add(this.panelMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HomeDesignerUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HomeDesignerUi_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelodeme.ResumeLayout(false);
            this.panelanaliz.ResumeLayout(false);
            this.panelkullaniciislemleri.ResumeLayout(false);
            this.panelkitapislemleri.ResumeLayout(false);
            this.panellogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.panelheader.ResumeLayout(false);
            this.panelkullanici.ResumeLayout(false);
            this.durumcubugu.ResumeLayout(false);
            this.durumcubugu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKullanici)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panellogo;
        private System.Windows.Forms.Button btnkitapislemlerimenu;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Panel panelkitapislemleri;
        private System.Windows.Forms.Panel panelkullaniciislemleri;
        private System.Windows.Forms.Button btnkullaniciislemleri;
        private System.Windows.Forms.Panel panelanaliz;
        private System.Windows.Forms.Button btnanalizveistatistik;
        private System.Windows.Forms.Panel panelodeme;
        private System.Windows.Forms.Button btnodemeislemleri;
        private System.Windows.Forms.Panel panelkullanici;
        private System.Windows.Forms.StatusStrip durumcubugu;
        public System.Windows.Forms.Panel panelebeveyn;
        private System.Windows.Forms.Timer timerbutonlar;
        private FontAwesome.Sharp.IconButton HomeButton;
        private System.Windows.Forms.PictureBox piclogo;
        private FontAwesome.Sharp.IconButton btnkitapyonetim;
        private FontAwesome.Sharp.IconButton btnyazaryonetim;
        private FontAwesome.Sharp.IconButton btnkategoriyonetim;
        private FontAwesome.Sharp.IconButton btnkullanicilar;
        private FontAwesome.Sharp.IconButton btnbildirim;
        private FontAwesome.Sharp.IconButton btnokumalistesi;
        private FontAwesome.Sharp.IconButton btnodeme;
        private FontAwesome.Sharp.IconButton btnkullanim;
        private FontAwesome.Sharp.IconButton btngeciken;
        private FontAwesome.Sharp.IconButton btnaktif;
        private FontAwesome.Sharp.IconButton btnpopuler;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnbig;
        private Control.EllipsePictureBox picKullanici;
        private FontAwesome.Sharp.IconButton btnkullanicinfo;
        private System.Windows.Forms.ToolStripStatusLabel lbltarihsaat;
        private System.Windows.Forms.Timer tarihsaat;
        private FontAwesome.Sharp.IconButton btnkalansure;
    }
}