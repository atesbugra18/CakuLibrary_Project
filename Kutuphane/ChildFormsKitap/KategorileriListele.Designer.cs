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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grlistele = new System.Windows.Forms.GroupBox();
            this.tablekategori = new System.Windows.Forms.DataGridView();
            this.grlistele.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablekategori)).BeginInit();
            this.SuspendLayout();
            // 
            // grlistele
            // 
            this.grlistele.Controls.Add(this.tablekategori);
            this.grlistele.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grlistele.Location = new System.Drawing.Point(0, 0);
            this.grlistele.Name = "grlistele";
            this.grlistele.Size = new System.Drawing.Size(890, 605);
            this.grlistele.TabIndex = 0;
            this.grlistele.TabStop = false;
            this.grlistele.Text = "Kategorileri Listele";
            // 
            // tablekategori
            // 
            this.tablekategori.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tablekategori.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablekategori.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablekategori.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablekategori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablekategori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablekategori.EnableHeadersVisualStyles = false;
            this.tablekategori.GridColor = System.Drawing.Color.LightGray;
            this.tablekategori.Location = new System.Drawing.Point(3, 29);
            this.tablekategori.Name = "tablekategori";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            this.tablekategori.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablekategori.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.tablekategori.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tablekategori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.tablekategori.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.tablekategori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tablekategori.Size = new System.Drawing.Size(884, 573);
            this.tablekategori.TabIndex = 0;
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
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "KategorileriListele";
            this.Text = "KategorileriListele";
            this.grlistele.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablekategori)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grlistele;
        private System.Windows.Forms.DataGridView tablekategori;
    }
}