namespace Kutuphane
{
    partial class Home
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
            this.oturumtimer = new System.Windows.Forms.Timer(this.components);
            this.menutimer = new System.Windows.Forms.Timer(this.components);
            this.btnmenu = new System.Windows.Forms.Button();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.PanelMenuButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnkitapislemleri = new System.Windows.Forms.Button();
            this.PanelKitapIslemleri = new System.Windows.Forms.FlowLayoutPanel();
            this.btnkitapekle = new System.Windows.Forms.Button();
            this.btnkitapsilguncelle = new System.Windows.Forms.Button();
            this.grbtnkitaplistele = new System.Windows.Forms.Button();
            this.altbtnkitaplarilistele = new System.Windows.Forms.Button();
            this.altbtnteslimlistele = new System.Windows.Forms.Button();
            this.btnkategoriekle = new System.Windows.Forms.Button();
            this.btnkategorisilguncelle = new System.Windows.Forms.Button();
            this.btnkategorilistele = new System.Windows.Forms.Button();
            this.btnyazarekle = new System.Windows.Forms.Button();
            this.btnyazarsilguncelle = new System.Windows.Forms.Button();
            this.btnyazarlistele = new System.Windows.Forms.Button();
            this.btnkullaniciislemleri = new System.Windows.Forms.Button();
            this.PanelKullanicislemleri = new System.Windows.Forms.FlowLayoutPanel();
            this.btnkullaniciekle = new System.Windows.Forms.Button();
            this.btnkullanicibilgilerinidegistir = new System.Windows.Forms.Button();
            this.btnkullanicilistele = new System.Windows.Forms.Button();
            this.btnokumalistesi = new System.Windows.Forms.Button();
            this.btnbildirimgonder = new System.Windows.Forms.Button();
            this.btnanalizveistatistikislemleri = new System.Windows.Forms.Button();
            this.PanelAnalizveİstatistikİslemleri = new System.Windows.Forms.FlowLayoutPanel();
            this.btnencokkitap = new System.Windows.Forms.Button();
            this.btnencokyazar = new System.Windows.Forms.Button();
            this.btnpopulerkategoriler = new System.Windows.Forms.Button();
            this.btnenaktif = new System.Windows.Forms.Button();
            this.btngecikenkitaplar = new System.Windows.Forms.Button();
            this.btnkullanimistatistikleri = new System.Windows.Forms.Button();
            this.btnodemeislemleri = new System.Windows.Forms.Button();
            this.PanelOdemeIslemleri = new System.Windows.Forms.FlowLayoutPanel();
            this.btnodemeal = new System.Windows.Forms.Button();
            this.PanelKullaniciInfo = new System.Windows.Forms.Panel();
            this.lblkullanici = new System.Windows.Forms.Label();
            this.profilphotos = new System.Windows.Forms.PictureBox();
            this.durumcubugu = new System.Windows.Forms.StatusStrip();
            this.tarihsaat = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelApp = new System.Windows.Forms.TableLayoutPanel();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnforward = new System.Windows.Forms.Button();
            this.btnbackward = new System.Windows.Forms.Button();
            this.btnoturumsure = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.closetimer = new System.Windows.Forms.Timer(this.components);
            this.panelAnimasyonTimer = new System.Windows.Forms.Timer(this.components);
            this.PanelMenu.SuspendLayout();
            this.PanelMenuButtons.SuspendLayout();
            this.PanelKitapIslemleri.SuspendLayout();
            this.PanelKullanicislemleri.SuspendLayout();
            this.PanelAnalizveİstatistikİslemleri.SuspendLayout();
            this.PanelOdemeIslemleri.SuspendLayout();
            this.PanelKullaniciInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilphotos)).BeginInit();
            this.durumcubugu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // oturumtimer
            // 
            this.oturumtimer.Enabled = true;
            this.oturumtimer.Interval = 1000;
            this.oturumtimer.Tick += new System.EventHandler(this.oturumtimer_Tick);
            // 
            // menutimer
            // 
            this.menutimer.Tick += new System.EventHandler(this.menutimer_Tick);
            // 
            // btnmenu
            // 
            this.btnmenu.BackColor = System.Drawing.Color.PowderBlue;
            this.btnmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmenu.FlatAppearance.BorderSize = 0;
            this.btnmenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnmenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnmenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmenu.Location = new System.Drawing.Point(10, 10);
            this.btnmenu.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnmenu.Name = "btnmenu";
            this.btnmenu.Size = new System.Drawing.Size(50, 50);
            this.btnmenu.TabIndex = 1;
            this.btnmenu.TabStop = false;
            this.btnmenu.UseVisualStyleBackColor = false;
            this.btnmenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.PowderBlue;
            this.PanelMenu.Controls.Add(this.PanelMenuButtons);
            this.PanelMenu.Controls.Add(this.PanelKullaniciInfo);
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(350, 3000);
            this.PanelMenu.TabIndex = 3;
            this.PanelMenu.Visible = false;
            // 
            // PanelMenuButtons
            // 
            this.PanelMenuButtons.AutoScroll = true;
            this.PanelMenuButtons.Controls.Add(this.btnkitapislemleri);
            this.PanelMenuButtons.Controls.Add(this.PanelKitapIslemleri);
            this.PanelMenuButtons.Controls.Add(this.btnkullaniciislemleri);
            this.PanelMenuButtons.Controls.Add(this.PanelKullanicislemleri);
            this.PanelMenuButtons.Controls.Add(this.btnanalizveistatistikislemleri);
            this.PanelMenuButtons.Controls.Add(this.PanelAnalizveİstatistikİslemleri);
            this.PanelMenuButtons.Controls.Add(this.btnodemeislemleri);
            this.PanelMenuButtons.Controls.Add(this.PanelOdemeIslemleri);
            this.PanelMenuButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelMenuButtons.Location = new System.Drawing.Point(0, 134);
            this.PanelMenuButtons.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMenuButtons.Name = "PanelMenuButtons";
            this.PanelMenuButtons.Padding = new System.Windows.Forms.Padding(15, 5, 0, 0);
            this.PanelMenuButtons.Size = new System.Drawing.Size(350, 591);
            this.PanelMenuButtons.TabIndex = 1;
            this.PanelMenuButtons.TabStop = true;
            this.PanelMenuButtons.WrapContents = false;
            // 
            // btnkitapislemleri
            // 
            this.btnkitapislemleri.BackColor = System.Drawing.Color.Black;
            this.btnkitapislemleri.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkitapislemleri.FlatAppearance.BorderSize = 2;
            this.btnkitapislemleri.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnkitapislemleri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnkitapislemleri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnkitapislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnkitapislemleri.ForeColor = System.Drawing.Color.White;
            this.btnkitapislemleri.Location = new System.Drawing.Point(18, 8);
            this.btnkitapislemleri.Name = "btnkitapislemleri";
            this.btnkitapislemleri.Size = new System.Drawing.Size(310, 45);
            this.btnkitapislemleri.TabIndex = 0;
            this.btnkitapislemleri.Text = "Kitap İşlemleri";
            this.btnkitapislemleri.UseVisualStyleBackColor = false;
            this.btnkitapislemleri.Click += new System.EventHandler(this.btnanabutonlar_Click);
            // 
            // PanelKitapIslemleri
            // 
            this.PanelKitapIslemleri.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelKitapIslemleri.Controls.Add(this.btnkitapekle);
            this.PanelKitapIslemleri.Controls.Add(this.btnkitapsilguncelle);
            this.PanelKitapIslemleri.Controls.Add(this.grbtnkitaplistele);
            this.PanelKitapIslemleri.Controls.Add(this.altbtnkitaplarilistele);
            this.PanelKitapIslemleri.Controls.Add(this.altbtnteslimlistele);
            this.PanelKitapIslemleri.Controls.Add(this.btnkategoriekle);
            this.PanelKitapIslemleri.Controls.Add(this.btnkategorisilguncelle);
            this.PanelKitapIslemleri.Controls.Add(this.btnkategorilistele);
            this.PanelKitapIslemleri.Controls.Add(this.btnyazarekle);
            this.PanelKitapIslemleri.Controls.Add(this.btnyazarsilguncelle);
            this.PanelKitapIslemleri.Controls.Add(this.btnyazarlistele);
            this.PanelKitapIslemleri.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelKitapIslemleri.Location = new System.Drawing.Point(15, 56);
            this.PanelKitapIslemleri.Margin = new System.Windows.Forms.Padding(0);
            this.PanelKitapIslemleri.Name = "PanelKitapIslemleri";
            this.PanelKitapIslemleri.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.PanelKitapIslemleri.Size = new System.Drawing.Size(310, 38);
            this.PanelKitapIslemleri.TabIndex = 4;
            this.PanelKitapIslemleri.Visible = false;
            // 
            // btnkitapekle
            // 
            this.btnkitapekle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkitapekle.FlatAppearance.BorderSize = 2;
            this.btnkitapekle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkitapekle.Location = new System.Drawing.Point(10, 5);
            this.btnkitapekle.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnkitapekle.Name = "btnkitapekle";
            this.btnkitapekle.Size = new System.Drawing.Size(290, 35);
            this.btnkitapekle.TabIndex = 1;
            this.btnkitapekle.Text = "Kitap Ekle";
            this.btnkitapekle.UseVisualStyleBackColor = true;
            this.btnkitapekle.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkitapekle.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkitapekle.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnkitapsilguncelle
            // 
            this.btnkitapsilguncelle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkitapsilguncelle.FlatAppearance.BorderSize = 2;
            this.btnkitapsilguncelle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkitapsilguncelle.Location = new System.Drawing.Point(305, 10);
            this.btnkitapsilguncelle.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnkitapsilguncelle.Name = "btnkitapsilguncelle";
            this.btnkitapsilguncelle.Size = new System.Drawing.Size(290, 35);
            this.btnkitapsilguncelle.TabIndex = 2;
            this.btnkitapsilguncelle.Text = "Kitap Sil && Güncelle";
            this.btnkitapsilguncelle.UseVisualStyleBackColor = true;
            this.btnkitapsilguncelle.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkitapsilguncelle.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkitapsilguncelle.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // grbtnkitaplistele
            // 
            this.grbtnkitaplistele.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.grbtnkitaplistele.FlatAppearance.BorderSize = 2;
            this.grbtnkitaplistele.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grbtnkitaplistele.Location = new System.Drawing.Point(600, 10);
            this.grbtnkitaplistele.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.grbtnkitaplistele.Name = "grbtnkitaplistele";
            this.grbtnkitaplistele.Size = new System.Drawing.Size(290, 35);
            this.grbtnkitaplistele.TabIndex = 3;
            this.grbtnkitaplistele.Text = "Kitapları Listele";
            this.grbtnkitaplistele.UseVisualStyleBackColor = true;
            this.grbtnkitaplistele.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.grbtnkitaplistele.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.grbtnkitaplistele.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // altbtnkitaplarilistele
            // 
            this.altbtnkitaplarilistele.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.altbtnkitaplarilistele.FlatAppearance.BorderSize = 2;
            this.altbtnkitaplarilistele.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.altbtnkitaplarilistele.Location = new System.Drawing.Point(905, 10);
            this.altbtnkitaplarilistele.Margin = new System.Windows.Forms.Padding(15, 5, 0, 0);
            this.altbtnkitaplarilistele.Name = "altbtnkitaplarilistele";
            this.altbtnkitaplarilistele.Size = new System.Drawing.Size(270, 35);
            this.altbtnkitaplarilistele.TabIndex = 4;
            this.altbtnkitaplarilistele.Text = "Mevcut Kitapları Listele";
            this.altbtnkitaplarilistele.UseVisualStyleBackColor = true;
            this.altbtnkitaplarilistele.Visible = false;
            this.altbtnkitaplarilistele.Click += new System.EventHandler(this.btnaltgrupbtn_Click);
            this.altbtnkitaplarilistele.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.altbtnkitaplarilistele.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // altbtnteslimlistele
            // 
            this.altbtnteslimlistele.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.altbtnteslimlistele.FlatAppearance.BorderSize = 2;
            this.altbtnteslimlistele.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.altbtnteslimlistele.Location = new System.Drawing.Point(1190, 10);
            this.altbtnteslimlistele.Margin = new System.Windows.Forms.Padding(15, 5, 0, 0);
            this.altbtnteslimlistele.Name = "altbtnteslimlistele";
            this.altbtnteslimlistele.Size = new System.Drawing.Size(270, 35);
            this.altbtnteslimlistele.TabIndex = 5;
            this.altbtnteslimlistele.Text = "Teslim Alınacak Kitapları Listele";
            this.altbtnteslimlistele.UseVisualStyleBackColor = true;
            this.altbtnteslimlistele.Visible = false;
            this.altbtnteslimlistele.Click += new System.EventHandler(this.btnaltgrupbtn_Click);
            this.altbtnteslimlistele.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.altbtnteslimlistele.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnkategoriekle
            // 
            this.btnkategoriekle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkategoriekle.FlatAppearance.BorderSize = 2;
            this.btnkategoriekle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkategoriekle.Location = new System.Drawing.Point(1465, 10);
            this.btnkategoriekle.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnkategoriekle.Name = "btnkategoriekle";
            this.btnkategoriekle.Size = new System.Drawing.Size(290, 35);
            this.btnkategoriekle.TabIndex = 6;
            this.btnkategoriekle.Text = "Kategori Ekle";
            this.btnkategoriekle.UseVisualStyleBackColor = true;
            this.btnkategoriekle.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkategoriekle.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkategoriekle.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnkategorisilguncelle
            // 
            this.btnkategorisilguncelle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkategorisilguncelle.FlatAppearance.BorderSize = 2;
            this.btnkategorisilguncelle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkategorisilguncelle.Location = new System.Drawing.Point(1760, 10);
            this.btnkategorisilguncelle.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnkategorisilguncelle.Name = "btnkategorisilguncelle";
            this.btnkategorisilguncelle.Size = new System.Drawing.Size(290, 35);
            this.btnkategorisilguncelle.TabIndex = 7;
            this.btnkategorisilguncelle.Text = "Kategori Sil && Güncelle";
            this.btnkategorisilguncelle.UseVisualStyleBackColor = true;
            this.btnkategorisilguncelle.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkategorisilguncelle.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkategorisilguncelle.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnkategorilistele
            // 
            this.btnkategorilistele.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkategorilistele.FlatAppearance.BorderSize = 2;
            this.btnkategorilistele.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkategorilistele.Location = new System.Drawing.Point(2055, 10);
            this.btnkategorilistele.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnkategorilistele.Name = "btnkategorilistele";
            this.btnkategorilistele.Size = new System.Drawing.Size(290, 35);
            this.btnkategorilistele.TabIndex = 8;
            this.btnkategorilistele.Text = "Kategorileri Listele";
            this.btnkategorilistele.UseVisualStyleBackColor = true;
            this.btnkategorilistele.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkategorilistele.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkategorilistele.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnyazarekle
            // 
            this.btnyazarekle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnyazarekle.FlatAppearance.BorderSize = 2;
            this.btnyazarekle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnyazarekle.Location = new System.Drawing.Point(2350, 10);
            this.btnyazarekle.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnyazarekle.Name = "btnyazarekle";
            this.btnyazarekle.Size = new System.Drawing.Size(290, 35);
            this.btnyazarekle.TabIndex = 9;
            this.btnyazarekle.Text = "Yazar Ekle";
            this.btnyazarekle.UseVisualStyleBackColor = true;
            this.btnyazarekle.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnyazarekle.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnyazarekle.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnyazarsilguncelle
            // 
            this.btnyazarsilguncelle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnyazarsilguncelle.FlatAppearance.BorderSize = 2;
            this.btnyazarsilguncelle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnyazarsilguncelle.Location = new System.Drawing.Point(2645, 10);
            this.btnyazarsilguncelle.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnyazarsilguncelle.Name = "btnyazarsilguncelle";
            this.btnyazarsilguncelle.Size = new System.Drawing.Size(290, 35);
            this.btnyazarsilguncelle.TabIndex = 10;
            this.btnyazarsilguncelle.Text = "Yazar Sil && Güncelle";
            this.btnyazarsilguncelle.UseVisualStyleBackColor = true;
            this.btnyazarsilguncelle.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnyazarsilguncelle.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnyazarsilguncelle.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnyazarlistele
            // 
            this.btnyazarlistele.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnyazarlistele.FlatAppearance.BorderSize = 2;
            this.btnyazarlistele.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnyazarlistele.Location = new System.Drawing.Point(2940, 10);
            this.btnyazarlistele.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnyazarlistele.Name = "btnyazarlistele";
            this.btnyazarlistele.Size = new System.Drawing.Size(290, 35);
            this.btnyazarlistele.TabIndex = 11;
            this.btnyazarlistele.Text = "Yazarları Listele";
            this.btnyazarlistele.UseVisualStyleBackColor = true;
            this.btnyazarlistele.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnyazarlistele.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnyazarlistele.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnkullaniciislemleri
            // 
            this.btnkullaniciislemleri.BackColor = System.Drawing.Color.Black;
            this.btnkullaniciislemleri.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkullaniciislemleri.FlatAppearance.BorderSize = 2;
            this.btnkullaniciislemleri.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnkullaniciislemleri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnkullaniciislemleri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnkullaniciislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnkullaniciislemleri.ForeColor = System.Drawing.Color.White;
            this.btnkullaniciislemleri.Location = new System.Drawing.Point(18, 97);
            this.btnkullaniciislemleri.Name = "btnkullaniciislemleri";
            this.btnkullaniciislemleri.Size = new System.Drawing.Size(310, 45);
            this.btnkullaniciislemleri.TabIndex = 1;
            this.btnkullaniciislemleri.Text = "Kullanıcı İşlemleri";
            this.btnkullaniciislemleri.UseVisualStyleBackColor = false;
            this.btnkullaniciislemleri.Click += new System.EventHandler(this.btnanabutonlar_Click);
            // 
            // PanelKullanicislemleri
            // 
            this.PanelKullanicislemleri.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelKullanicislemleri.Controls.Add(this.btnkullaniciekle);
            this.PanelKullanicislemleri.Controls.Add(this.btnkullanicibilgilerinidegistir);
            this.PanelKullanicislemleri.Controls.Add(this.btnkullanicilistele);
            this.PanelKullanicislemleri.Controls.Add(this.btnokumalistesi);
            this.PanelKullanicislemleri.Controls.Add(this.btnbildirimgonder);
            this.PanelKullanicislemleri.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelKullanicislemleri.Location = new System.Drawing.Point(15, 145);
            this.PanelKullanicislemleri.Margin = new System.Windows.Forms.Padding(0);
            this.PanelKullanicislemleri.Name = "PanelKullanicislemleri";
            this.PanelKullanicislemleri.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.PanelKullanicislemleri.Size = new System.Drawing.Size(310, 25);
            this.PanelKullanicislemleri.TabIndex = 5;
            this.PanelKullanicislemleri.Visible = false;
            // 
            // btnkullaniciekle
            // 
            this.btnkullaniciekle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkullaniciekle.FlatAppearance.BorderSize = 2;
            this.btnkullaniciekle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkullaniciekle.Location = new System.Drawing.Point(10, 5);
            this.btnkullaniciekle.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnkullaniciekle.Name = "btnkullaniciekle";
            this.btnkullaniciekle.Size = new System.Drawing.Size(290, 35);
            this.btnkullaniciekle.TabIndex = 1;
            this.btnkullaniciekle.Text = "Kullanıcı Ekle";
            this.btnkullaniciekle.UseVisualStyleBackColor = true;
            this.btnkullaniciekle.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkullaniciekle.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkullaniciekle.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnkullanicibilgilerinidegistir
            // 
            this.btnkullanicibilgilerinidegistir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkullanicibilgilerinidegistir.FlatAppearance.BorderSize = 2;
            this.btnkullanicibilgilerinidegistir.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkullanicibilgilerinidegistir.Location = new System.Drawing.Point(305, 10);
            this.btnkullanicibilgilerinidegistir.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnkullanicibilgilerinidegistir.Name = "btnkullanicibilgilerinidegistir";
            this.btnkullanicibilgilerinidegistir.Size = new System.Drawing.Size(290, 35);
            this.btnkullanicibilgilerinidegistir.TabIndex = 2;
            this.btnkullanicibilgilerinidegistir.Text = "Kullanıcı Bilgilerini Değiştir";
            this.btnkullanicibilgilerinidegistir.UseVisualStyleBackColor = true;
            this.btnkullanicibilgilerinidegistir.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkullanicibilgilerinidegistir.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkullanicibilgilerinidegistir.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnkullanicilistele
            // 
            this.btnkullanicilistele.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkullanicilistele.FlatAppearance.BorderSize = 2;
            this.btnkullanicilistele.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkullanicilistele.Location = new System.Drawing.Point(600, 10);
            this.btnkullanicilistele.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnkullanicilistele.Name = "btnkullanicilistele";
            this.btnkullanicilistele.Size = new System.Drawing.Size(290, 35);
            this.btnkullanicilistele.TabIndex = 3;
            this.btnkullanicilistele.Text = "Kullanıcıları Listele";
            this.btnkullanicilistele.UseVisualStyleBackColor = true;
            this.btnkullanicilistele.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkullanicilistele.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkullanicilistele.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnokumalistesi
            // 
            this.btnokumalistesi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnokumalistesi.FlatAppearance.BorderSize = 2;
            this.btnokumalistesi.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnokumalistesi.Location = new System.Drawing.Point(895, 10);
            this.btnokumalistesi.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnokumalistesi.Name = "btnokumalistesi";
            this.btnokumalistesi.Size = new System.Drawing.Size(290, 35);
            this.btnokumalistesi.TabIndex = 6;
            this.btnokumalistesi.Text = "Üye Okuma Listesi";
            this.btnokumalistesi.UseVisualStyleBackColor = true;
            this.btnokumalistesi.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnokumalistesi.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnokumalistesi.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnbildirimgonder
            // 
            this.btnbildirimgonder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbildirimgonder.FlatAppearance.BorderSize = 2;
            this.btnbildirimgonder.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbildirimgonder.Location = new System.Drawing.Point(1190, 10);
            this.btnbildirimgonder.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnbildirimgonder.Name = "btnbildirimgonder";
            this.btnbildirimgonder.Size = new System.Drawing.Size(290, 35);
            this.btnbildirimgonder.TabIndex = 7;
            this.btnbildirimgonder.Text = "Üyelere Bildirim Gönder";
            this.btnbildirimgonder.UseVisualStyleBackColor = true;
            this.btnbildirimgonder.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnbildirimgonder.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnbildirimgonder.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnanalizveistatistikislemleri
            // 
            this.btnanalizveistatistikislemleri.BackColor = System.Drawing.Color.Black;
            this.btnanalizveistatistikislemleri.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnanalizveistatistikislemleri.FlatAppearance.BorderSize = 2;
            this.btnanalizveistatistikislemleri.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnanalizveistatistikislemleri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnanalizveistatistikislemleri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnanalizveistatistikislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnanalizveistatistikislemleri.ForeColor = System.Drawing.Color.White;
            this.btnanalizveistatistikislemleri.Location = new System.Drawing.Point(18, 173);
            this.btnanalizveistatistikislemleri.Name = "btnanalizveistatistikislemleri";
            this.btnanalizveistatistikislemleri.Size = new System.Drawing.Size(310, 45);
            this.btnanalizveistatistikislemleri.TabIndex = 2;
            this.btnanalizveistatistikislemleri.Text = "Analiz ve İstatistik İşlemleri";
            this.btnanalizveistatistikislemleri.UseVisualStyleBackColor = false;
            this.btnanalizveistatistikislemleri.Click += new System.EventHandler(this.btnanabutonlar_Click);
            // 
            // PanelAnalizveİstatistikİslemleri
            // 
            this.PanelAnalizveİstatistikİslemleri.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelAnalizveİstatistikİslemleri.Controls.Add(this.btnencokkitap);
            this.PanelAnalizveİstatistikİslemleri.Controls.Add(this.btnencokyazar);
            this.PanelAnalizveİstatistikİslemleri.Controls.Add(this.btnpopulerkategoriler);
            this.PanelAnalizveİstatistikİslemleri.Controls.Add(this.btnenaktif);
            this.PanelAnalizveİstatistikİslemleri.Controls.Add(this.btngecikenkitaplar);
            this.PanelAnalizveİstatistikİslemleri.Controls.Add(this.btnkullanimistatistikleri);
            this.PanelAnalizveİstatistikİslemleri.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelAnalizveİstatistikİslemleri.Location = new System.Drawing.Point(15, 221);
            this.PanelAnalizveİstatistikİslemleri.Margin = new System.Windows.Forms.Padding(0);
            this.PanelAnalizveİstatistikİslemleri.Name = "PanelAnalizveİstatistikİslemleri";
            this.PanelAnalizveİstatistikİslemleri.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.PanelAnalizveİstatistikİslemleri.Size = new System.Drawing.Size(310, 23);
            this.PanelAnalizveİstatistikİslemleri.TabIndex = 6;
            this.PanelAnalizveİstatistikİslemleri.Visible = false;
            // 
            // btnencokkitap
            // 
            this.btnencokkitap.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnencokkitap.FlatAppearance.BorderSize = 2;
            this.btnencokkitap.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnencokkitap.Location = new System.Drawing.Point(10, 5);
            this.btnencokkitap.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnencokkitap.Name = "btnencokkitap";
            this.btnencokkitap.Size = new System.Drawing.Size(290, 35);
            this.btnencokkitap.TabIndex = 1;
            this.btnencokkitap.Text = "En Çok Okunan Kitaplar";
            this.btnencokkitap.UseVisualStyleBackColor = true;
            this.btnencokkitap.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnencokkitap.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnencokkitap.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnencokyazar
            // 
            this.btnencokyazar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnencokyazar.FlatAppearance.BorderSize = 2;
            this.btnencokyazar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnencokyazar.Location = new System.Drawing.Point(305, 10);
            this.btnencokyazar.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnencokyazar.Name = "btnencokyazar";
            this.btnencokyazar.Size = new System.Drawing.Size(290, 35);
            this.btnencokyazar.TabIndex = 2;
            this.btnencokyazar.Text = "En Çok Okunan Yazarlar";
            this.btnencokyazar.UseVisualStyleBackColor = true;
            this.btnencokyazar.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnencokyazar.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnencokyazar.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnpopulerkategoriler
            // 
            this.btnpopulerkategoriler.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnpopulerkategoriler.FlatAppearance.BorderSize = 2;
            this.btnpopulerkategoriler.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnpopulerkategoriler.Location = new System.Drawing.Point(600, 10);
            this.btnpopulerkategoriler.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnpopulerkategoriler.Name = "btnpopulerkategoriler";
            this.btnpopulerkategoriler.Size = new System.Drawing.Size(290, 35);
            this.btnpopulerkategoriler.TabIndex = 3;
            this.btnpopulerkategoriler.Text = "En Popüler Kategoriler";
            this.btnpopulerkategoriler.UseVisualStyleBackColor = true;
            this.btnpopulerkategoriler.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnpopulerkategoriler.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnpopulerkategoriler.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnenaktif
            // 
            this.btnenaktif.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnenaktif.FlatAppearance.BorderSize = 2;
            this.btnenaktif.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnenaktif.Location = new System.Drawing.Point(895, 10);
            this.btnenaktif.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnenaktif.Name = "btnenaktif";
            this.btnenaktif.Size = new System.Drawing.Size(290, 35);
            this.btnenaktif.TabIndex = 6;
            this.btnenaktif.Text = "En Aktif Üyeler";
            this.btnenaktif.UseVisualStyleBackColor = true;
            this.btnenaktif.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnenaktif.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnenaktif.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btngecikenkitaplar
            // 
            this.btngecikenkitaplar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btngecikenkitaplar.FlatAppearance.BorderSize = 2;
            this.btngecikenkitaplar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngecikenkitaplar.Location = new System.Drawing.Point(1190, 10);
            this.btngecikenkitaplar.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btngecikenkitaplar.Name = "btngecikenkitaplar";
            this.btngecikenkitaplar.Size = new System.Drawing.Size(290, 35);
            this.btngecikenkitaplar.TabIndex = 7;
            this.btngecikenkitaplar.Text = "Geciken Kitaplar Listesi";
            this.btngecikenkitaplar.UseVisualStyleBackColor = true;
            this.btngecikenkitaplar.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btngecikenkitaplar.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btngecikenkitaplar.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnkullanimistatistikleri
            // 
            this.btnkullanimistatistikleri.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnkullanimistatistikleri.FlatAppearance.BorderSize = 2;
            this.btnkullanimistatistikleri.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkullanimistatistikleri.Location = new System.Drawing.Point(1485, 10);
            this.btnkullanimistatistikleri.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnkullanimistatistikleri.Name = "btnkullanimistatistikleri";
            this.btnkullanimistatistikleri.Size = new System.Drawing.Size(290, 35);
            this.btnkullanimistatistikleri.TabIndex = 8;
            this.btnkullanimistatistikleri.Text = "Kütüphane Kullanım İstatistikleri";
            this.btnkullanimistatistikleri.UseVisualStyleBackColor = true;
            this.btnkullanimistatistikleri.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnkullanimistatistikleri.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnkullanimistatistikleri.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // btnodemeislemleri
            // 
            this.btnodemeislemleri.BackColor = System.Drawing.Color.Black;
            this.btnodemeislemleri.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnodemeislemleri.FlatAppearance.BorderSize = 2;
            this.btnodemeislemleri.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnodemeislemleri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnodemeislemleri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnodemeislemleri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnodemeislemleri.ForeColor = System.Drawing.Color.White;
            this.btnodemeislemleri.Location = new System.Drawing.Point(18, 247);
            this.btnodemeislemleri.Name = "btnodemeislemleri";
            this.btnodemeislemleri.Size = new System.Drawing.Size(310, 45);
            this.btnodemeislemleri.TabIndex = 3;
            this.btnodemeislemleri.Text = "Ödeme İşlemleri";
            this.btnodemeislemleri.UseVisualStyleBackColor = false;
            this.btnodemeislemleri.Click += new System.EventHandler(this.btnanabutonlar_Click);
            // 
            // PanelOdemeIslemleri
            // 
            this.PanelOdemeIslemleri.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelOdemeIslemleri.Controls.Add(this.btnodemeal);
            this.PanelOdemeIslemleri.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelOdemeIslemleri.Location = new System.Drawing.Point(15, 295);
            this.PanelOdemeIslemleri.Margin = new System.Windows.Forms.Padding(0);
            this.PanelOdemeIslemleri.Name = "PanelOdemeIslemleri";
            this.PanelOdemeIslemleri.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.PanelOdemeIslemleri.Size = new System.Drawing.Size(310, 48);
            this.PanelOdemeIslemleri.TabIndex = 7;
            this.PanelOdemeIslemleri.Visible = false;
            // 
            // btnodemeal
            // 
            this.btnodemeal.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnodemeal.FlatAppearance.BorderSize = 2;
            this.btnodemeal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnodemeal.Location = new System.Drawing.Point(5, 5);
            this.btnodemeal.Margin = new System.Windows.Forms.Padding(0);
            this.btnodemeal.Name = "btnodemeal";
            this.btnodemeal.Size = new System.Drawing.Size(300, 35);
            this.btnodemeal.TabIndex = 1;
            this.btnodemeal.Text = "Ödeme Al";
            this.btnodemeal.UseVisualStyleBackColor = true;
            this.btnodemeal.Click += new System.EventHandler(this.btnaltbutonlar_Click);
            this.btnodemeal.MouseEnter += new System.EventHandler(this.Imlecustunde);
            this.btnodemeal.MouseLeave += new System.EventHandler(this.Imlecustundedegil);
            // 
            // PanelKullaniciInfo
            // 
            this.PanelKullaniciInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelKullaniciInfo.Controls.Add(this.lblkullanici);
            this.PanelKullaniciInfo.Controls.Add(this.profilphotos);
            this.PanelKullaniciInfo.Location = new System.Drawing.Point(70, 10);
            this.PanelKullaniciInfo.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.PanelKullaniciInfo.Name = "PanelKullaniciInfo";
            this.PanelKullaniciInfo.Size = new System.Drawing.Size(270, 110);
            this.PanelKullaniciInfo.TabIndex = 0;
            // 
            // lblkullanici
            // 
            this.lblkullanici.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblkullanici.Location = new System.Drawing.Point(99, 0);
            this.lblkullanici.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblkullanici.Name = "lblkullanici";
            this.lblkullanici.Size = new System.Drawing.Size(180, 100);
            this.lblkullanici.TabIndex = 1;
            this.lblkullanici.Text = "V";
            this.lblkullanici.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // profilphotos
            // 
            this.profilphotos.Location = new System.Drawing.Point(6, 7);
            this.profilphotos.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.profilphotos.Name = "profilphotos";
            this.profilphotos.Size = new System.Drawing.Size(90, 90);
            this.profilphotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilphotos.TabIndex = 0;
            this.profilphotos.TabStop = false;
            // 
            // durumcubugu
            // 
            this.durumcubugu.AutoSize = false;
            this.durumcubugu.BackColor = System.Drawing.Color.PowderBlue;
            this.durumcubugu.Dock = System.Windows.Forms.DockStyle.None;
            this.durumcubugu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tarihsaat});
            this.durumcubugu.Location = new System.Drawing.Point(0, 725);
            this.durumcubugu.Name = "durumcubugu";
            this.durumcubugu.Padding = new System.Windows.Forms.Padding(28, 0, 2, 0);
            this.durumcubugu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.durumcubugu.Size = new System.Drawing.Size(1300, 25);
            this.durumcubugu.TabIndex = 4;
            this.durumcubugu.Text = "statusStrip1";
            // 
            // tarihsaat
            // 
            this.tarihsaat.Name = "tarihsaat";
            this.tarihsaat.Size = new System.Drawing.Size(0, 20);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanelApp);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 750);
            this.panel1.TabIndex = 5;
            // 
            // PanelApp
            // 
            this.PanelApp.ColumnCount = 4;
            this.PanelApp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.PanelApp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.PanelApp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.PanelApp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.PanelApp.Controls.Add(this.btnclose, 3, 0);
            this.PanelApp.Controls.Add(this.btnforward, 2, 0);
            this.PanelApp.Controls.Add(this.btnbackward, 1, 0);
            this.PanelApp.Controls.Add(this.btnoturumsure, 0, 0);
            this.PanelApp.Location = new System.Drawing.Point(900, 0);
            this.PanelApp.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.PanelApp.Name = "PanelApp";
            this.PanelApp.RowCount = 1;
            this.PanelApp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelApp.Size = new System.Drawing.Size(400, 60);
            this.PanelApp.TabIndex = 3;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(346, 7);
            this.btnclose.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(48, 46);
            this.btnclose.TabIndex = 5;
            this.btnclose.TabStop = false;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnforward
            // 
            this.btnforward.BackColor = System.Drawing.Color.Transparent;
            this.btnforward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnforward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnforward.FlatAppearance.BorderSize = 0;
            this.btnforward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnforward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnforward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnforward.Location = new System.Drawing.Point(286, 7);
            this.btnforward.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnforward.Name = "btnforward";
            this.btnforward.Size = new System.Drawing.Size(48, 46);
            this.btnforward.TabIndex = 4;
            this.btnforward.TabStop = false;
            this.btnforward.UseVisualStyleBackColor = false;
            // 
            // btnbackward
            // 
            this.btnbackward.BackColor = System.Drawing.Color.Transparent;
            this.btnbackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnbackward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbackward.FlatAppearance.BorderSize = 0;
            this.btnbackward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnbackward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnbackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbackward.Location = new System.Drawing.Point(226, 7);
            this.btnbackward.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnbackward.Name = "btnbackward";
            this.btnbackward.Size = new System.Drawing.Size(48, 46);
            this.btnbackward.TabIndex = 3;
            this.btnbackward.TabStop = false;
            this.btnbackward.UseVisualStyleBackColor = false;
            // 
            // btnoturumsure
            // 
            this.btnoturumsure.Enabled = false;
            this.btnoturumsure.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnoturumsure.Location = new System.Drawing.Point(6, 7);
            this.btnoturumsure.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnoturumsure.Name = "btnoturumsure";
            this.btnoturumsure.Size = new System.Drawing.Size(208, 46);
            this.btnoturumsure.TabIndex = 2;
            this.btnoturumsure.Text = "Oturumun Kapanmasına Kalan Süre  59:59";
            this.btnoturumsure.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // closetimer
            // 
            this.closetimer.Interval = 80;
            this.closetimer.Tick += new System.EventHandler(this.closetimer_Tick);
            // 
            // panelAnimasyonTimer
            // 
            this.panelAnimasyonTimer.Interval = 10;
            this.panelAnimasyonTimer.Tick += new System.EventHandler(this.PanelAnimasyonTimer_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1300, 750);
            this.ControlBox = false;
            this.Controls.Add(this.durumcubugu);
            this.Controls.Add(this.PanelMenu);
            this.Controls.Add(this.btnmenu);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.PanelMenu.ResumeLayout(false);
            this.PanelMenuButtons.ResumeLayout(false);
            this.PanelKitapIslemleri.ResumeLayout(false);
            this.PanelKullanicislemleri.ResumeLayout(false);
            this.PanelAnalizveİstatistikİslemleri.ResumeLayout(false);
            this.PanelOdemeIslemleri.ResumeLayout(false);
            this.PanelKullaniciInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilphotos)).EndInit();
            this.durumcubugu.ResumeLayout(false);
            this.durumcubugu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.PanelApp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer oturumtimer;
        private System.Windows.Forms.Timer menutimer;
        private System.Windows.Forms.Button btnmenu;
        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Panel PanelKullaniciInfo;
        private System.Windows.Forms.PictureBox profilphotos;
        private System.Windows.Forms.FlowLayoutPanel PanelMenuButtons;
        private System.Windows.Forms.Label lblkullanici;
        private System.Windows.Forms.Button btnkitapislemleri;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel PanelApp;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnforward;
        private System.Windows.Forms.Button btnbackward;
        private System.Windows.Forms.Button btnoturumsure;
        private System.Windows.Forms.Button btnkullaniciislemleri;
        private System.Windows.Forms.Button btnanalizveistatistikislemleri;
        private System.Windows.Forms.Button btnodemeislemleri;
        private System.Windows.Forms.FlowLayoutPanel PanelKitapIslemleri;
        private System.Windows.Forms.Button btnkitapekle;
        private System.Windows.Forms.Button btnkitapsilguncelle;
        private System.Windows.Forms.Button grbtnkitaplistele;
        private System.Windows.Forms.Button altbtnkitaplarilistele;
        private System.Windows.Forms.Button altbtnteslimlistele;
        private System.Windows.Forms.Button btnkategoriekle;
        private System.Windows.Forms.Button btnkategorisilguncelle;
        private System.Windows.Forms.Button btnkategorilistele;
        private System.Windows.Forms.Button btnyazarekle;
        private System.Windows.Forms.Button btnyazarsilguncelle;
        private System.Windows.Forms.Button btnyazarlistele;
        private System.Windows.Forms.FlowLayoutPanel PanelKullanicislemleri;
        private System.Windows.Forms.Button btnkullaniciekle;
        private System.Windows.Forms.Button btnkullanicibilgilerinidegistir;
        private System.Windows.Forms.Button btnkullanicilistele;
        private System.Windows.Forms.Button btnokumalistesi;
        private System.Windows.Forms.Button btnbildirimgonder;
        private System.Windows.Forms.FlowLayoutPanel PanelAnalizveİstatistikİslemleri;
        private System.Windows.Forms.Button btnencokkitap;
        private System.Windows.Forms.Button btnencokyazar;
        private System.Windows.Forms.Button btnpopulerkategoriler;
        private System.Windows.Forms.Button btnenaktif;
        private System.Windows.Forms.Button btngecikenkitaplar;
        private System.Windows.Forms.Button btnkullanimistatistikleri;
        private System.Windows.Forms.FlowLayoutPanel PanelOdemeIslemleri;
        private System.Windows.Forms.Button btnodemeal;
        private System.Windows.Forms.ToolStripStatusLabel tarihsaat;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer closetimer;
        private System.Windows.Forms.Timer panelAnimasyonTimer;
        public System.Windows.Forms.StatusStrip durumcubugu;
    }
}