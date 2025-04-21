namespace Kutuphane.ChildFormsKitap
{
    partial class KategoriEkle
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
            this.grboxkategoriekle = new System.Windows.Forms.GroupBox();
            this.lblkategoriadi = new System.Windows.Forms.Label();
            this.txtkategoriadi = new System.Windows.Forms.TextBox();
            this.btnkategoriekle = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.grboxkategoriekle.SuspendLayout();
            this.SuspendLayout();
            // 
            // grboxkategoriekle
            // 
            this.grboxkategoriekle.Controls.Add(this.btnclose);
            this.grboxkategoriekle.Controls.Add(this.btnkategoriekle);
            this.grboxkategoriekle.Controls.Add(this.txtkategoriadi);
            this.grboxkategoriekle.Controls.Add(this.lblkategoriadi);
            this.grboxkategoriekle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grboxkategoriekle.Location = new System.Drawing.Point(0, 0);
            this.grboxkategoriekle.Name = "grboxkategoriekle";
            this.grboxkategoriekle.Size = new System.Drawing.Size(890, 605);
            this.grboxkategoriekle.TabIndex = 0;
            this.grboxkategoriekle.TabStop = false;
            this.grboxkategoriekle.Text = "Kategori Ekle";
            // 
            // lblkategoriadi
            // 
            this.lblkategoriadi.AutoSize = true;
            this.lblkategoriadi.Location = new System.Drawing.Point(12, 47);
            this.lblkategoriadi.Name = "lblkategoriadi";
            this.lblkategoriadi.Size = new System.Drawing.Size(131, 26);
            this.lblkategoriadi.TabIndex = 0;
            this.lblkategoriadi.Text = "Kategori Ekle:";
            // 
            // txtkategoriadi
            // 
            this.txtkategoriadi.Location = new System.Drawing.Point(149, 44);
            this.txtkategoriadi.Name = "txtkategoriadi";
            this.txtkategoriadi.Size = new System.Drawing.Size(200, 33);
            this.txtkategoriadi.TabIndex = 1;
            // 
            // btnkategoriekle
            // 
            this.btnkategoriekle.Location = new System.Drawing.Point(710, 118);
            this.btnkategoriekle.Name = "btnkategoriekle";
            this.btnkategoriekle.Size = new System.Drawing.Size(168, 37);
            this.btnkategoriekle.TabIndex = 2;
            this.btnkategoriekle.Text = "Kategori Ekle";
            this.btnkategoriekle.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(838, 22);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(40, 40);
            this.btnclose.TabIndex = 3;
            this.btnclose.UseVisualStyleBackColor = false;
            // 
            // KategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(890, 605);
            this.Controls.Add(this.grboxkategoriekle);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "KategoriEkle";
            this.Text = "KategoriEkle";
            this.grboxkategoriekle.ResumeLayout(false);
            this.grboxkategoriekle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grboxkategoriekle;
        private System.Windows.Forms.Label lblkategoriadi;
        private System.Windows.Forms.Button btnkategoriekle;
        private System.Windows.Forms.TextBox txtkategoriadi;
        private System.Windows.Forms.Button btnclose;
    }
}