namespace Kutuphane.ChildFormsKullanici
{
    partial class OkumaListesi
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
            this.panelkontroller = new System.Windows.Forms.Panel();
            this.panelcocuk = new System.Windows.Forms.Panel();
            this.panelheader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelkontroller.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelkontroller
            // 
            this.panelkontroller.BackColor = System.Drawing.Color.White;
            this.panelkontroller.Controls.Add(this.panel1);
            this.panelkontroller.Controls.Add(this.panelheader);
            this.panelkontroller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelkontroller.Location = new System.Drawing.Point(0, 0);
            this.panelkontroller.Name = "panelkontroller";
            this.panelkontroller.Size = new System.Drawing.Size(1100, 800);
            this.panelkontroller.TabIndex = 0;
            // 
            // panelcocuk
            // 
            this.panelcocuk.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelcocuk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcocuk.Location = new System.Drawing.Point(0, 0);
            this.panelcocuk.Name = "panelcocuk";
            this.panelcocuk.Size = new System.Drawing.Size(1100, 800);
            this.panelcocuk.TabIndex = 3;
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1100, 100);
            this.panelheader.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(114)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(900, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 700);
            this.panel1.TabIndex = 1;
            // 
            // OkumaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panelkontroller);
            this.Controls.Add(this.panelcocuk);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OkumaListesi";
            this.panelkontroller.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelkontroller;
        private System.Windows.Forms.Panel panelcocuk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelheader;
    }
}