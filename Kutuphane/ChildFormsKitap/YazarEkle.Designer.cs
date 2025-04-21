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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblyazaradı = new System.Windows.Forms.Label();
            this.lblyazarsoyadı = new System.Windows.Forms.Label();
            this.txtyazaradı = new System.Windows.Forms.TextBox();
            this.txtyazarsoyadı = new System.Windows.Forms.TextBox();
            this.btnyazarekle = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.btnclose);
            this.groupBox1.Controls.Add(this.btnyazarekle);
            this.groupBox1.Controls.Add(this.txtyazarsoyadı);
            this.groupBox1.Controls.Add(this.txtyazaradı);
            this.groupBox1.Controls.Add(this.lblyazarsoyadı);
            this.groupBox1.Controls.Add(this.lblyazaradı);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 605);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yazar Ekle";
            // 
            // lblyazaradı
            // 
            this.lblyazaradı.AutoSize = true;
            this.lblyazaradı.Location = new System.Drawing.Point(67, 46);
            this.lblyazaradı.Name = "lblyazaradı";
            this.lblyazaradı.Size = new System.Drawing.Size(97, 26);
            this.lblyazaradı.TabIndex = 0;
            this.lblyazaradı.Text = "Yazar Adı:";
            // 
            // lblyazarsoyadı
            // 
            this.lblyazarsoyadı.AutoSize = true;
            this.lblyazarsoyadı.Location = new System.Drawing.Point(39, 103);
            this.lblyazarsoyadı.Name = "lblyazarsoyadı";
            this.lblyazarsoyadı.Size = new System.Drawing.Size(125, 26);
            this.lblyazarsoyadı.TabIndex = 1;
            this.lblyazarsoyadı.Text = "Yazar Soyadı:";
            // 
            // txtyazaradı
            // 
            this.txtyazaradı.Location = new System.Drawing.Point(170, 46);
            this.txtyazaradı.Name = "txtyazaradı";
            this.txtyazaradı.Size = new System.Drawing.Size(200, 33);
            this.txtyazaradı.TabIndex = 2;
            // 
            // txtyazarsoyadı
            // 
            this.txtyazarsoyadı.Location = new System.Drawing.Point(170, 103);
            this.txtyazarsoyadı.Name = "txtyazarsoyadı";
            this.txtyazarsoyadı.Size = new System.Drawing.Size(200, 33);
            this.txtyazarsoyadı.TabIndex = 3;
            // 
            // btnyazarekle
            // 
            this.btnyazarekle.Location = new System.Drawing.Point(732, 216);
            this.btnyazarekle.Name = "btnyazarekle";
            this.btnyazarekle.Size = new System.Drawing.Size(106, 38);
            this.btnyazarekle.TabIndex = 4;
            this.btnyazarekle.Text = "Yazar Ekle";
            this.btnyazarekle.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(838, 32);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(40, 40);
            this.btnclose.TabIndex = 5;
            this.btnclose.UseVisualStyleBackColor = false;
            // 
            // YazarEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 605);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "YazarEkle";
            this.Text = "YazarEkle";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtyazarsoyadı;
        private System.Windows.Forms.TextBox txtyazaradı;
        private System.Windows.Forms.Label lblyazarsoyadı;
        private System.Windows.Forms.Label lblyazaradı;
        private System.Windows.Forms.Button btnyazarekle;
        private System.Windows.Forms.Button btnclose;
    }
}