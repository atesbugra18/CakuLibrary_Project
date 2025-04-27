namespace Kutuphane.ChildFormsKitap
{
    partial class KitapYonetimiDesignerUi
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
            this.panelarkaplan = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelarkaplan
            // 
            this.panelarkaplan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelarkaplan.Location = new System.Drawing.Point(0, 0);
            this.panelarkaplan.Name = "panelarkaplan";
            this.panelarkaplan.Size = new System.Drawing.Size(1100, 800);
            this.panelarkaplan.TabIndex = 1;
            // 
            // KitapYonetimiDesignerUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panelarkaplan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "KitapYonetimiDesignerUi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelarkaplan;
    }
}