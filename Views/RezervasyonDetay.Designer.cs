namespace RestoranRezervasyonSistemi.Views
{
    partial class RezervasyonDetay
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
            this.lblBilgi = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtMusteriAd = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtMusteriTel = new System.Windows.Forms.TextBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnIptalEt = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.nmrKisiSayisi = new System.Windows.Forms.NumericUpDown();
            this.lblSaat = new System.Windows.Forms.Label();
            this.dtpSaat = new System.Windows.Forms.DateTimePicker();
            this.grpYemekSecimi = new System.Windows.Forms.GroupBox();
            this.lstYemekSecimi = new System.Windows.Forms.ListView();
            this.colYemekAdi = new System.Windows.Forms.ColumnHeader();
            this.colFiyat = new System.Windows.Forms.ColumnHeader();
            this.colAdet = new System.Windows.Forms.ColumnHeader();
            this.lblToplamFiyat = new System.Windows.Forms.Label();
            this.picYemekResmi = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmrKisiSayisi)).BeginInit();
            this.grpYemekSecimi.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgi.ForeColor = System.Drawing.Color.White;
            this.lblBilgi.Location = new System.Drawing.Point(50, 30);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(260, 25);
            this.lblBilgi.TabIndex = 0;
            this.lblBilgi.Text = "Masalar İçin Rezervsayon\r\n";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.ForeColor = System.Drawing.Color.White;
            this.lblAd.Location = new System.Drawing.Point(50, 80);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(76, 16);
            this.lblAd.TabIndex = 1;
            this.lblAd.Text = "Müşteri Adı:";
            // 
            // txtMusteriAd
            // 
            this.txtMusteriAd.Location = new System.Drawing.Point(50, 100);
            this.txtMusteriAd.Name = "txtMusteriAd";
            this.txtMusteriAd.Size = new System.Drawing.Size(280, 22);
            this.txtMusteriAd.TabIndex = 2;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.ForeColor = System.Drawing.Color.White;
            this.lblTel.Location = new System.Drawing.Point(50, 150);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(56, 16);
            this.lblTel.TabIndex = 3;
            this.lblTel.Text = "Telefon:";
            // 
            // txtMusteriTel
            // 
            this.txtMusteriTel.Location = new System.Drawing.Point(50, 170);
            this.txtMusteriTel.Name = "txtMusteriTel";
            this.txtMusteriTel.Size = new System.Drawing.Size(280, 22);
            this.txtMusteriTel.TabIndex = 4;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.ForeColor = System.Drawing.Color.White;
            this.lblTarih.Location = new System.Drawing.Point(50, 220);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(41, 16);
            this.lblTarih.TabIndex = 5;
            this.lblTarih.Text = "Tarih:";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(50, 240);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(280, 22);
            this.dtpTarih.TabIndex = 6;
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOnayla.Location = new System.Drawing.Point(50, 358);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(280, 45);
            this.btnOnayla.TabIndex = 7;
            this.btnOnayla.Text = "Rezervasyonu Kaydet";
            this.btnOnayla.UseVisualStyleBackColor = false;
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // btnIptalEt
            // 
            this.btnIptalEt.BackColor = System.Drawing.Color.Firebrick;
            this.btnIptalEt.ForeColor = System.Drawing.Color.White;
            this.btnIptalEt.Location = new System.Drawing.Point(50, 409);
            this.btnIptalEt.Name = "btnIptalEt";
            this.btnIptalEt.Size = new System.Drawing.Size(280, 32);
            this.btnIptalEt.TabIndex = 8;
            this.btnIptalEt.Text = "Rezervasyonu İptal Et";
            this.btnIptalEt.UseVisualStyleBackColor = false;
            this.btnIptalEt.Click += new System.EventHandler(this.btnIptalEt_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnVazgec.ForeColor = System.Drawing.Color.White;
            this.btnVazgec.Location = new System.Drawing.Point(50, 447);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(280, 32);
            this.btnVazgec.TabIndex = 9;
            this.btnVazgec.Text = "Kapat";
            this.btnVazgec.UseVisualStyleBackColor = false;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // nmrKisiSayisi
            // 
            this.nmrKisiSayisi.Location = new System.Drawing.Point(50, 280);
            this.nmrKisiSayisi.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nmrKisiSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrKisiSayisi.Name = "nmrKisiSayisi";
            this.nmrKisiSayisi.Size = new System.Drawing.Size(280, 22);
            this.nmrKisiSayisi.TabIndex = 9;
            this.nmrKisiSayisi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSaat
            // 
            this.lblSaat.AutoSize = true;
            this.lblSaat.ForeColor = System.Drawing.Color.White;
            this.lblSaat.Location = new System.Drawing.Point(50, 310);
            this.lblSaat.Name = "lblSaat";
            this.lblSaat.Size = new System.Drawing.Size(75, 16);
            this.lblSaat.TabIndex = 10;
            this.lblSaat.Text = "Geliş Saati:";
            // 
            // dtpSaat
            // 
            this.dtpSaat.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaat.Location = new System.Drawing.Point(50, 330);
            this.dtpSaat.Name = "dtpSaat";
            this.dtpSaat.ShowUpDown = true;
            this.dtpSaat.Size = new System.Drawing.Size(280, 22);
            this.dtpSaat.TabIndex = 11;
            // 
            // grpYemekSecimi
            // 
            this.grpYemekSecimi.Controls.Add(this.lstYemekSecimi);
            this.grpYemekSecimi.ForeColor = System.Drawing.Color.White;
            this.grpYemekSecimi.Location = new System.Drawing.Point(350, 30);
            this.grpYemekSecimi.Name = "grpYemekSecimi";
            this.grpYemekSecimi.Size = new System.Drawing.Size(280, 450);
            this.grpYemekSecimi.TabIndex = 12;
            this.grpYemekSecimi.TabStop = false;
            this.grpYemekSecimi.Text = "Yemek Seçimi (Opsiyonel)";
            // 
            // lstYemekSecimi
            // 
            this.lstYemekSecimi.CheckBoxes = true;
            this.lstYemekSecimi.FullRowSelect = true;
            this.lstYemekSecimi.GridLines = true;
            this.lstYemekSecimi.Location = new System.Drawing.Point(10, 20);
            this.lstYemekSecimi.MultiSelect = false;
            this.lstYemekSecimi.Name = "lstYemekSecimi";
            this.lstYemekSecimi.Size = new System.Drawing.Size(250, 400);
            this.lstYemekSecimi.TabIndex = 0;
            this.lstYemekSecimi.UseCompatibleStateImageBehavior = false;
            this.lstYemekSecimi.View = System.Windows.Forms.View.Details;
            this.lstYemekSecimi.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LstYemekSecimi_ItemCheck);
            this.lstYemekSecimi.SelectedIndexChanged += new System.EventHandler(this.LstYemekSecimi_SelectedIndexChanged);
            this.lstYemekSecimi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstYemekSecimi_MouseDoubleClick);
            // 
            // colYemekAdi
            // 
            this.colYemekAdi.Text = "Yemek Adı";
            this.colYemekAdi.Width = 120;
            // 
            // colFiyat
            // 
            this.colFiyat.Text = "Fiyat";
            this.colFiyat.Width = 60;
            // 
            // colAdet
            // 
            this.colAdet.Text = "Adet";
            this.colAdet.Width = 50;
            // 
            // lblToplamFiyat
            // 
            this.lblToplamFiyat.AutoSize = true;
            this.lblToplamFiyat.ForeColor = System.Drawing.Color.White;
            this.lblToplamFiyat.Location = new System.Drawing.Point(350, 490);
            this.lblToplamFiyat.Name = "lblToplamFiyat";
            this.lblToplamFiyat.Size = new System.Drawing.Size(85, 16);
            this.lblToplamFiyat.TabIndex = 13;
            this.lblToplamFiyat.Text = "Toplam Fiyat:";
            // 
            // picYemekResmi
            // 
            this.picYemekResmi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picYemekResmi.Location = new System.Drawing.Point(650, 30);
            this.picYemekResmi.Name = "picYemekResmi";
            this.picYemekResmi.Size = new System.Drawing.Size(200, 150);
            this.picYemekResmi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picYemekResmi.TabIndex = 14;
            this.picYemekResmi.TabStop = false;
            // 
            // RezervasyonDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.picYemekResmi);
            this.Controls.Add(this.lblToplamFiyat);
            this.Controls.Add(this.grpYemekSecimi);
            this.Controls.Add(this.dtpSaat);
            this.Controls.Add(this.lblSaat);
            this.Controls.Add(this.nmrKisiSayisi);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnIptalEt);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.lblTarih);
            this.Controls.Add(this.txtMusteriTel);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.txtMusteriAd);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.lblBilgi);
            this.Name = "RezervasyonDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masa Rezervasyon İşlemleri";
            this.Load += new System.EventHandler(this.RezervasyonDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrKisiSayisi)).EndInit();
            this.grpYemekSecimi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBilgi;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TextBox txtMusteriAd;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtMusteriTel;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Button btnOnayla;
        private System.Windows.Forms.Button btnIptalEt;
        private System.Windows.Forms.Button btnVazgec;
        private System.Windows.Forms.NumericUpDown nmrKisiSayisi;
        private System.Windows.Forms.Label lblSaat;
        private System.Windows.Forms.DateTimePicker dtpSaat;
        private System.Windows.Forms.GroupBox grpYemekSecimi;
        private System.Windows.Forms.ListView lstYemekSecimi;
        private System.Windows.Forms.ColumnHeader colYemekAdi;
        private System.Windows.Forms.ColumnHeader colFiyat;
        private System.Windows.Forms.ColumnHeader colAdet;
        private System.Windows.Forms.Label lblToplamFiyat;
        private System.Windows.Forms.PictureBox picYemekResmi;
    }
}