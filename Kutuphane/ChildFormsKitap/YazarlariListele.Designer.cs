namespace Kutuphane.ChildFormsKitap
{
    partial class YazarlariListele
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
            this.grblistele = new System.Windows.Forms.GroupBox();
            this.btngizle = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblmevcutyazarlar = new System.Windows.Forms.Label();
            this.lboxyazarlar = new System.Windows.Forms.ListBox();
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            this.grblistele.SuspendLayout();
            this.SuspendLayout();
            // 
            // grblistele
            // 
            this.grblistele.BackColor = System.Drawing.Color.LightBlue;
            this.grblistele.Controls.Add(this.btngizle);
            this.grblistele.Controls.Add(this.btnclose);
            this.grblistele.Controls.Add(this.lblmevcutyazarlar);
            this.grblistele.Controls.Add(this.lboxyazarlar);
            this.grblistele.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grblistele.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grblistele.Location = new System.Drawing.Point(0, 0);
            this.grblistele.Name = "grblistele";
            this.grblistele.Size = new System.Drawing.Size(890, 605);
            this.grblistele.TabIndex = 0;
            this.grblistele.TabStop = false;
            this.grblistele.Text = "Yazar Listele";
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
            this.btngizle.TabIndex = 30;
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
            this.btnclose.TabIndex = 29;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblmevcutyazarlar
            // 
            this.lblmevcutyazarlar.AutoSize = true;
            this.lblmevcutyazarlar.Location = new System.Drawing.Point(49, 40);
            this.lblmevcutyazarlar.Name = "lblmevcutyazarlar";
            this.lblmevcutyazarlar.Size = new System.Drawing.Size(208, 26);
            this.lblmevcutyazarlar.TabIndex = 12;
            this.lblmevcutyazarlar.Text = "Mevcut Yazarlar Listesi";
            // 
            // lboxyazarlar
            // 
            this.lboxyazarlar.BackColor = System.Drawing.Color.LightBlue;
            this.lboxyazarlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lboxyazarlar.FormattingEnabled = true;
            this.lboxyazarlar.ItemHeight = 26;
            this.lboxyazarlar.Location = new System.Drawing.Point(12, 69);
            this.lboxyazarlar.Name = "lboxyazarlar";
            this.lboxyazarlar.Size = new System.Drawing.Size(310, 524);
            this.lboxyazarlar.TabIndex = 11;
            // 
            // timerclose
            // 
            this.timerclose.Interval = 80;
            this.timerclose.Tick += new System.EventHandler(this.timerclose_Tick);
            // 
            // YazarlariListele
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(890, 605);
            this.Controls.Add(this.grblistele);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YazarlariListele";
            this.Text = "Yazarlistele";
            this.Load += new System.EventHandler(this.YazarlariListele_Load);
            this.grblistele.ResumeLayout(false);
            this.grblistele.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grblistele;
        private System.Windows.Forms.Label lblmevcutyazarlar;
        private System.Windows.Forms.ListBox lboxyazarlar;
        private System.Windows.Forms.Button btngizle;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Timer timerclose;
    }
}