namespace Kutuphane.ChildFormsKitap
{
    partial class KategorileriListele
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
            this.grlistele = new System.Windows.Forms.GroupBox();
            this.btngizle = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblmevcutkategoriler = new System.Windows.Forms.Label();
            this.lboxkategori = new System.Windows.Forms.ListBox();
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            this.grlistele.SuspendLayout();
            this.SuspendLayout();
            // 
            // grlistele
            // 
            this.grlistele.Controls.Add(this.btngizle);
            this.grlistele.Controls.Add(this.btnclose);
            this.grlistele.Controls.Add(this.lblmevcutkategoriler);
            this.grlistele.Controls.Add(this.lboxkategori);
            this.grlistele.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grlistele.Location = new System.Drawing.Point(0, 0);
            this.grlistele.Name = "grlistele";
            this.grlistele.Size = new System.Drawing.Size(890, 605);
            this.grlistele.TabIndex = 0;
            this.grlistele.TabStop = false;
            this.grlistele.Text = "Kategorileri Listele";
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
            this.btngizle.TabIndex = 28;
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
            this.btnclose.TabIndex = 27;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblmevcutkategoriler
            // 
            this.lblmevcutkategoriler.AutoSize = true;
            this.lblmevcutkategoriler.Location = new System.Drawing.Point(49, 25);
            this.lblmevcutkategoriler.Name = "lblmevcutkategoriler";
            this.lblmevcutkategoriler.Size = new System.Drawing.Size(236, 26);
            this.lblmevcutkategoriler.TabIndex = 12;
            this.lblmevcutkategoriler.Text = "Mevcut Kategoriler Listesi";
            // 
            // lboxkategori
            // 
            this.lboxkategori.BackColor = System.Drawing.Color.LightBlue;
            this.lboxkategori.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lboxkategori.FormattingEnabled = true;
            this.lboxkategori.ItemHeight = 26;
            this.lboxkategori.Location = new System.Drawing.Point(12, 54);
            this.lboxkategori.Name = "lboxkategori";
            this.lboxkategori.Size = new System.Drawing.Size(310, 524);
            this.lboxkategori.TabIndex = 11;
            // 
            // timerclose
            // 
            this.timerclose.Interval = 80;
            this.timerclose.Tick += new System.EventHandler(this.timerclose_Tick);
            // 
            // KategorileriListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(890, 605);
            this.Controls.Add(this.grlistele);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "KategorileriListele";
            this.Text = "KategorileriListele";
            this.Load += new System.EventHandler(this.KategorileriListele_Load);
            this.grlistele.ResumeLayout(false);
            this.grlistele.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grlistele;
        private System.Windows.Forms.Label lblmevcutkategoriler;
        private System.Windows.Forms.ListBox lboxkategori;
        private System.Windows.Forms.Button btngizle;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Timer timerclose;
    }
}