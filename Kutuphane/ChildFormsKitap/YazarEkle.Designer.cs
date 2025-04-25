namespace Kutuphane.ChildFormsKitap
{
    partial class YazarEkle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblinfo = new System.Windows.Forms.Label();
            this.lblmevcutyazarlar = new System.Windows.Forms.Label();
            this.lboxyazarekle = new System.Windows.Forms.ListBox();
            this.btngizle = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnyazarekle = new System.Windows.Forms.Button();
            this.txtyazarsoyadi = new System.Windows.Forms.TextBox();
            this.txtyazaradi = new System.Windows.Forms.TextBox();
            this.lblyazarsoyadı = new System.Windows.Forms.Label();
            this.lblyazaradı = new System.Windows.Forms.Label();
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.lblinfo);
            this.groupBox1.Controls.Add(this.lblmevcutyazarlar);
            this.groupBox1.Controls.Add(this.lboxyazarekle);
            this.groupBox1.Controls.Add(this.btngizle);
            this.groupBox1.Controls.Add(this.btnclose);
            this.groupBox1.Controls.Add(this.btnyazarekle);
            this.groupBox1.Controls.Add(this.txtyazarsoyadi);
            this.groupBox1.Controls.Add(this.txtyazaradi);
            this.groupBox1.Controls.Add(this.lblyazarsoyadı);
            this.groupBox1.Controls.Add(this.lblyazaradı);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 605);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yazar Ekle";
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblinfo.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblinfo.Location = new System.Drawing.Point(462, 327);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(135, 19);
            this.lblinfo.TabIndex = 16;
            this.lblinfo.Text = "Bu Yazar Zaten Var";
            this.lblinfo.Visible = false;
            // 
            // lblmevcutyazarlar
            // 
            this.lblmevcutyazarlar.AutoSize = true;
            this.lblmevcutyazarlar.Location = new System.Drawing.Point(56, 40);
            this.lblmevcutyazarlar.Name = "lblmevcutyazarlar";
            this.lblmevcutyazarlar.Size = new System.Drawing.Size(186, 26);
            this.lblmevcutyazarlar.TabIndex = 15;
            this.lblmevcutyazarlar.Text = "Mevcut Yazar Listesi";
            // 
            // lboxyazarekle
            // 
            this.lboxyazarekle.BackColor = System.Drawing.Color.LightBlue;
            this.lboxyazarekle.CausesValidation = false;
            this.lboxyazarekle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lboxyazarekle.FormattingEnabled = true;
            this.lboxyazarekle.ItemHeight = 26;
            this.lboxyazarekle.Location = new System.Drawing.Point(12, 69);
            this.lboxyazarekle.Name = "lboxyazarekle";
            this.lboxyazarekle.ScrollAlwaysVisible = true;
            this.lboxyazarekle.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lboxyazarekle.Size = new System.Drawing.Size(310, 524);
            this.lboxyazarekle.Sorted = true;
            this.lboxyazarekle.TabIndex = 14;
            // 
            // btngizle
            // 
            this.btngizle.BackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatAppearance.BorderSize = 0;
            this.btngizle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btngizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngizle.Location = new System.Drawing.Point(770, 20);
            this.btngizle.Name = "btngizle";
            this.btngizle.Size = new System.Drawing.Size(40, 40);
            this.btngizle.TabIndex = 13;
            this.btngizle.UseVisualStyleBackColor = false;
            this.btngizle.Click += new System.EventHandler(this.btngizle_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(820, 20);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(40, 40);
            this.btnclose.TabIndex = 12;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnyazarekle
            // 
            this.btnyazarekle.Location = new System.Drawing.Point(704, 348);
            this.btnyazarekle.Name = "btnyazarekle";
            this.btnyazarekle.Size = new System.Drawing.Size(106, 38);
            this.btnyazarekle.TabIndex = 4;
            this.btnyazarekle.Text = "Yazar Ekle";
            this.btnyazarekle.UseVisualStyleBackColor = true;
            this.btnyazarekle.Click += new System.EventHandler(this.btnyazarekle_Click);
            // 
            // txtyazarsoyadi
            // 
            this.txtyazarsoyadi.Location = new System.Drawing.Point(466, 276);
            this.txtyazarsoyadi.Name = "txtyazarsoyadi";
            this.txtyazarsoyadi.Size = new System.Drawing.Size(200, 33);
            this.txtyazarsoyadi.TabIndex = 3;
            // 
            // txtyazaradi
            // 
            this.txtyazaradi.Location = new System.Drawing.Point(466, 219);
            this.txtyazaradi.Name = "txtyazaradi";
            this.txtyazaradi.Size = new System.Drawing.Size(200, 33);
            this.txtyazaradi.TabIndex = 2;
            // 
            // lblyazarsoyadı
            // 
            this.lblyazarsoyadı.AutoSize = true;
            this.lblyazarsoyadı.Location = new System.Drawing.Point(335, 276);
            this.lblyazarsoyadı.Name = "lblyazarsoyadı";
            this.lblyazarsoyadı.Size = new System.Drawing.Size(125, 26);
            this.lblyazarsoyadı.TabIndex = 1;
            this.lblyazarsoyadı.Text = "Yazar Soyadı:";
            // 
            // lblyazaradı
            // 
            this.lblyazaradı.AutoSize = true;
            this.lblyazaradı.Location = new System.Drawing.Point(363, 219);
            this.lblyazaradı.Name = "lblyazaradı";
            this.lblyazaradı.Size = new System.Drawing.Size(97, 26);
            this.lblyazaradı.TabIndex = 0;
            this.lblyazaradı.Text = "Yazar Adı:";
            // 
            // timerclose
            // 
            this.timerclose.Interval = 80;
            this.timerclose.Tick += new System.EventHandler(this.timerclose_Tick);
            // 
            // YazarEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 605);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "YazarEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "YazarEkle";
            this.Load += new System.EventHandler(this.YazarEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtyazarsoyadi;
        private System.Windows.Forms.TextBox txtyazaradi;
        private System.Windows.Forms.Label lblyazarsoyadı;
        private System.Windows.Forms.Label lblyazaradı;
        private System.Windows.Forms.Button btnyazarekle;
        private System.Windows.Forms.Button btngizle;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.ListBox lboxyazarekle;
        private System.Windows.Forms.Label lblmevcutyazarlar;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.Timer timerclose;
    }
}