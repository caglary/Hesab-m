namespace Hesabım.Forms
{
    partial class Analiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analiz));
            this.dataGridViewGelir = new System.Windows.Forms.DataGridView();
            this.dataGridViewGider = new System.Windows.Forms.DataGridView();
            this.comboBoxAylar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearchByMonth = new System.Windows.Forms.Button();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblToplamGelir = new System.Windows.Forms.Label();
            this.lblToplamGider = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblKalan = new System.Windows.Forms.Label();
            this.comboBoxFilitreKategori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilitrele = new System.Windows.Forms.Button();
            this.lblMaastanKalan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGelir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewGelir
            // 
            this.dataGridViewGelir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGelir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGelir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGelir.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGelir.Name = "dataGridViewGelir";
            this.dataGridViewGelir.RowHeadersWidth = 51;
            this.dataGridViewGelir.RowTemplate.Height = 24;
            this.dataGridViewGelir.Size = new System.Drawing.Size(660, 540);
            this.dataGridViewGelir.TabIndex = 6;
            // 
            // dataGridViewGider
            // 
            this.dataGridViewGider.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGider.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGider.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGider.Name = "dataGridViewGider";
            this.dataGridViewGider.RowHeadersWidth = 51;
            this.dataGridViewGider.RowTemplate.Height = 24;
            this.dataGridViewGider.Size = new System.Drawing.Size(660, 540);
            this.dataGridViewGider.TabIndex = 6;
            // 
            // comboBoxAylar
            // 
            this.comboBoxAylar.FormattingEnabled = true;
            this.comboBoxAylar.Items.AddRange(new object[] {
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık",
            "Aralık2019"});
            this.comboBoxAylar.Location = new System.Drawing.Point(676, 39);
            this.comboBoxAylar.Name = "comboBoxAylar";
            this.comboBoxAylar.Size = new System.Drawing.Size(278, 32);
            this.comboBoxAylar.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(691, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "2020 yılı için bir ay seçiniz:";
            // 
            // btnSearchByMonth
            // 
            this.btnSearchByMonth.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearchByMonth.Location = new System.Drawing.Point(676, 78);
            this.btnSearchByMonth.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchByMonth.Name = "btnSearchByMonth";
            this.btnSearchByMonth.Size = new System.Drawing.Size(278, 41);
            this.btnSearchByMonth.TabIndex = 2;
            this.btnSearchByMonth.Text = "Kayıtları göster";
            this.btnSearchByMonth.UseVisualStyleBackColor = true;
            this.btnSearchByMonth.Click += new System.EventHandler(this.btnSearchByMonth_Click);
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAciklama.ForeColor = System.Drawing.Color.DimGray;
            this.lblAciklama.Location = new System.Drawing.Point(673, 134);
            this.lblAciklama.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(56, 17);
            this.lblAciklama.TabIndex = 3;
            this.lblAciklama.Text = "............";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewGelir);
            this.panel1.Location = new System.Drawing.Point(10, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 540);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewGider);
            this.panel2.Location = new System.Drawing.Point(676, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 540);
            this.panel2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(278, 172);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "Gelir";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(986, 172);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 24);
            this.label7.TabIndex = 3;
            this.label7.Text = "Gider";
            // 
            // lblToplamGelir
            // 
            this.lblToplamGelir.AutoSize = true;
            this.lblToplamGelir.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamGelir.ForeColor = System.Drawing.Color.LightCoral;
            this.lblToplamGelir.Location = new System.Drawing.Point(330, 172);
            this.lblToplamGelir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamGelir.Name = "lblToplamGelir";
            this.lblToplamGelir.Size = new System.Drawing.Size(51, 24);
            this.lblToplamGelir.TabIndex = 3;
            this.lblToplamGelir.Text = "Gelir";
            // 
            // lblToplamGider
            // 
            this.lblToplamGider.AutoSize = true;
            this.lblToplamGider.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamGider.ForeColor = System.Drawing.Color.LightCoral;
            this.lblToplamGider.Location = new System.Drawing.Point(1043, 172);
            this.lblToplamGider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamGider.Name = "lblToplamGider";
            this.lblToplamGider.Size = new System.Drawing.Size(57, 24);
            this.lblToplamGider.TabIndex = 3;
            this.lblToplamGider.Text = "Gider";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.lblKalan);
            this.panel3.Controls.Add(this.lblMaastanKalan);
            this.panel3.Location = new System.Drawing.Point(970, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 100);
            this.panel3.TabIndex = 9;
            // 
            // lblKalan
            // 
            this.lblKalan.AutoSize = true;
            this.lblKalan.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKalan.Location = new System.Drawing.Point(80, 44);
            this.lblKalan.Name = "lblKalan";
            this.lblKalan.Size = new System.Drawing.Size(50, 52);
            this.lblKalan.TabIndex = 0;
            this.lblKalan.Text = "0";
            // 
            // comboBoxFilitreKategori
            // 
            this.comboBoxFilitreKategori.FormattingEnabled = true;
            this.comboBoxFilitreKategori.Location = new System.Drawing.Point(10, 39);
            this.comboBoxFilitreKategori.Name = "comboBoxFilitreKategori";
            this.comboBoxFilitreKategori.Size = new System.Drawing.Size(278, 32);
            this.comboBoxFilitreKategori.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kategorileri filitrelemek için seçim yapınız.";
            // 
            // btnFilitrele
            // 
            this.btnFilitrele.ForeColor = System.Drawing.Color.DimGray;
            this.btnFilitrele.Location = new System.Drawing.Point(10, 78);
            this.btnFilitrele.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilitrele.Name = "btnFilitrele";
            this.btnFilitrele.Size = new System.Drawing.Size(278, 41);
            this.btnFilitrele.TabIndex = 2;
            this.btnFilitrele.Text = "Filitrele";
            this.btnFilitrele.UseVisualStyleBackColor = true;
            this.btnFilitrele.Click += new System.EventHandler(this.btnFilitrele_Click);
            // 
            // lblMaastanKalan
            // 
            this.lblMaastanKalan.AutoSize = true;
            this.lblMaastanKalan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMaastanKalan.ForeColor = System.Drawing.Color.DimGray;
            this.lblMaastanKalan.Location = new System.Drawing.Point(15, 2);
            this.lblMaastanKalan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaastanKalan.Name = "lblMaastanKalan";
            this.lblMaastanKalan.Size = new System.Drawing.Size(31, 24);
            this.lblMaastanKalan.TabIndex = 3;
            this.lblMaastanKalan.Text = "---";
            // 
            // Analiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1347, 756);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblToplamGider);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblToplamGelir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxFilitreKategori);
            this.Controls.Add(this.comboBoxAylar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.btnFilitrele);
            this.Controls.Add(this.btnSearchByMonth);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Analiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analiz";
            this.Load += new System.EventHandler(this.TarihAraligiAra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGelir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.DataGridView dataGridViewGelir;
        private System.Windows.Forms.DataGridView dataGridViewGider;
        private System.Windows.Forms.ComboBox comboBoxAylar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchByMonth;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblToplamGelir;
        private System.Windows.Forms.Label lblToplamGider;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblKalan;
        private System.Windows.Forms.ComboBox comboBoxFilitreKategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilitrele;
        private System.Windows.Forms.Label lblMaastanKalan;
    }
}