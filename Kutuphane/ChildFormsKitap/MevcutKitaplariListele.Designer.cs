namespace Kutuphane.ChildFormsKitap
{
    partial class MevcutKitaplariListele
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gboxliste = new System.Windows.Forms.GroupBox();
            this.tablo = new System.Windows.Forms.DataGridView();
            this.lblsayisi = new System.Windows.Forms.Label();
            this.KitapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btngizle = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            this.gboxliste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxliste
            // 
            this.gboxliste.Controls.Add(this.btngizle);
            this.gboxliste.Controls.Add(this.btnclose);
            this.gboxliste.Controls.Add(this.lblsayisi);
            this.gboxliste.Controls.Add(this.tablo);
            this.gboxliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxliste.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gboxliste.Location = new System.Drawing.Point(0, 0);
            this.gboxliste.Name = "gboxliste";
            this.gboxliste.Size = new System.Drawing.Size(875, 605);
            this.gboxliste.TabIndex = 0;
            this.gboxliste.TabStop = false;
            this.gboxliste.Text = "Mevcut Olan Kitapları Listele";
            // 
            // tablo
            // 
            this.tablo.AllowUserToAddRows = false;
            this.tablo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.tablo.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tablo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.tablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KitapAdi,
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4});
            this.tablo.Location = new System.Drawing.Point(12, 66);
            this.tablo.Name = "tablo";
            this.tablo.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablo.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.tablo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tablo.Size = new System.Drawing.Size(850, 506);
            this.tablo.TabIndex = 0;
            // 
            // lblsayisi
            // 
            this.lblsayisi.AutoSize = true;
            this.lblsayisi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblsayisi.Location = new System.Drawing.Point(628, 577);
            this.lblsayisi.Name = "lblsayisi";
            this.lblsayisi.Size = new System.Drawing.Size(235, 19);
            this.lblsayisi.TabIndex = 1;
            this.lblsayisi.Text = "Görüntülenen Kitap Sayısı: 00000";
            // 
            // KitapAdi
            // 
            this.KitapAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KitapAdi.DataPropertyName = "kitapadi";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.KitapAdi.DefaultCellStyle = dataGridViewCellStyle11;
            this.KitapAdi.HeaderText = "Kitap Adı";
            this.KitapAdi.Name = "KitapAdi";
            this.KitapAdi.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "yazaradisoyadi";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column2.HeaderText = "Yazar Adı Soyadı";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 146;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "kategoriadi";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column1.HeaderText = "Kategori Adı";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 119;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "sayfasayisi";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column3.HeaderText = "Sayfa Sayısı";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 113;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.DataPropertyName = "ciltno";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column4.HeaderText = "Cilt No";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
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
            // timerclose
            // 
            this.timerclose.Interval = 80;
            this.timerclose.Tick += new System.EventHandler(this.timerclose_Tick);
            // 
            // MevcutKitaplariListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(875, 605);
            this.ControlBox = false;
            this.Controls.Add(this.gboxliste);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MevcutKitaplariListele";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MevcutKitaplariListele";
            this.Load += new System.EventHandler(this.MevcutKitaplariListele_Load);
            this.gboxliste.ResumeLayout(false);
            this.gboxliste.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxliste;
        private System.Windows.Forms.Label lblsayisi;
        private System.Windows.Forms.DataGridView tablo;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btngizle;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Timer timerclose;
    }
}