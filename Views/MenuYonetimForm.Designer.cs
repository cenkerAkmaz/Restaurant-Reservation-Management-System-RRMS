namespace RestoranRezervasyonSistemi.Views
{
    partial class MenuYonetimForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lstMenu = new System.Windows.Forms.ListBox();
            this.grpYemekBilgileri = new System.Windows.Forms.GroupBox();
            this.chkMevcut = new System.Windows.Forms.CheckBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.lblKategori = new System.Windows.Forms.Label();
            this.txtResimYolu = new System.Windows.Forms.TextBox();
            this.lblResimYolu = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.nudFiyat = new System.Windows.Forms.NumericUpDown();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.grpButonlar = new System.Windows.Forms.GroupBox();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.picYemekResmi = new System.Windows.Forms.PictureBox();
            this.lblYemekDetay = new System.Windows.Forms.Label();
            this.grpYemekBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFiyat)).BeginInit();
            this.grpButonlar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(20, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(140, 29);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Menü Yönetimi";
            // 
            // lstMenu
            // 
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.Location = new System.Drawing.Point(20, 60);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(300, 350);
            this.lstMenu.TabIndex = 1;
            this.lstMenu.SelectedIndexChanged += new System.EventHandler(this.lstMenu_SelectedIndexChanged);
            // 
            // grpYemekBilgileri
            // 
            this.grpYemekBilgileri.Controls.Add(this.chkMevcut);
            this.grpYemekBilgileri.Controls.Add(this.cmbKategori);
            this.grpYemekBilgileri.Controls.Add(this.lblKategori);
            this.grpYemekBilgileri.Controls.Add(this.txtResimYolu);
            this.grpYemekBilgileri.Controls.Add(this.lblResimYolu);
            this.grpYemekBilgileri.Controls.Add(this.txtAciklama);
            this.grpYemekBilgileri.Controls.Add(this.lblAciklama);
            this.grpYemekBilgileri.Controls.Add(this.nudFiyat);
            this.grpYemekBilgileri.Controls.Add(this.lblFiyat);
            this.grpYemekBilgileri.Controls.Add(this.txtAd);
            this.grpYemekBilgileri.Controls.Add(this.lblAd);
            this.grpYemekBilgileri.Location = new System.Drawing.Point(340, 60);
            this.grpYemekBilgileri.Name = "grpYemekBilgileri";
            this.grpYemekBilgileri.Size = new System.Drawing.Size(320, 350);
            this.grpYemekBilgileri.TabIndex = 2;
            this.grpYemekBilgileri.TabStop = false;
            this.grpYemekBilgileri.ForeColor = System.Drawing.Color.White;
            this.grpYemekBilgileri.Text = "Yemek Bilgileri";
            // 
            // lblYemekDetay
            // 
            this.lblYemekDetay.AutoSize = true;
            this.lblYemekDetay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYemekDetay.ForeColor = System.Drawing.Color.White;
            this.lblYemekDetay.Location = new System.Drawing.Point(680, 60);
            this.lblYemekDetay.Name = "lblYemekDetay";
            this.lblYemekDetay.Size = new System.Drawing.Size(250, 30);
            this.lblYemekDetay.TabIndex = 11;
            this.lblYemekDetay.Text = "Yemek Detayları";
            // 
            // picYemekResmi
            // 
            this.picYemekResmi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picYemekResmi.Location = new System.Drawing.Point(680, 100);
            this.picYemekResmi.Name = "picYemekResmi";
            this.picYemekResmi.Size = new System.Drawing.Size(250, 200);
            this.picYemekResmi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picYemekResmi.TabIndex = 12;
            this.picYemekResmi.TabStop = false;
            // 
            // chkMevcut
            // 
            this.chkMevcut.AutoSize = true;
            this.chkMevcut.Checked = true;
            this.chkMevcut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMevcut.ForeColor = System.Drawing.Color.White;
            this.chkMevcut.Location = new System.Drawing.Point(150, 280);
            this.chkMevcut.Name = "chkMevcut";
            this.chkMevcut.Size = new System.Drawing.Size(70, 20);
            this.chkMevcut.TabIndex = 10;
            this.chkMevcut.Text = "Mevcut";
            this.chkMevcut.UseVisualStyleBackColor = true;
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Items.AddRange(new object[] {
            "Ana Yemek",
            "Çorba",
            "Başlangıç",
            "Tatlı",
            "İçecek",
            "Yan Ürün"});
            this.cmbKategori.Location = new System.Drawing.Point(100, 250);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(200, 24);
            this.cmbKategori.TabIndex = 9;
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.ForeColor = System.Drawing.Color.White;
            this.lblKategori.Location = new System.Drawing.Point(10, 253);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(57, 16);
            this.lblKategori.TabIndex = 8;
            this.lblKategori.Text = "Kategori:";
            // 
            // txtResimYolu
            // 
            this.txtResimYolu.Location = new System.Drawing.Point(100, 220);
            this.txtResimYolu.Name = "txtResimYolu";
            this.txtResimYolu.Size = new System.Drawing.Size(200, 22);
            this.txtResimYolu.TabIndex = 7;
            // 
            // lblResimYolu
            // 
            this.lblResimYolu.AutoSize = true;
            this.lblResimYolu.ForeColor = System.Drawing.Color.White;
            this.lblResimYolu.Location = new System.Drawing.Point(10, 223);
            this.lblResimYolu.Name = "lblResimYolu";
            this.lblResimYolu.Size = new System.Drawing.Size(70, 16);
            this.lblResimYolu.TabIndex = 6;
            this.lblResimYolu.Text = "Resim Yolu:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(100, 150);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(200, 60);
            this.txtAciklama.TabIndex = 5;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.ForeColor = System.Drawing.Color.White;
            this.lblAciklama.Location = new System.Drawing.Point(10, 150);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(67, 16);
            this.lblAciklama.TabIndex = 4;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // nudFiyat
            // 
            this.nudFiyat.DecimalPlaces = 2;
            this.nudFiyat.Location = new System.Drawing.Point(100, 120);
            this.nudFiyat.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudFiyat.Name = "nudFiyat";
            this.nudFiyat.Size = new System.Drawing.Size(200, 22);
            this.nudFiyat.TabIndex = 3;
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.ForeColor = System.Drawing.Color.White;
            this.lblFiyat.Location = new System.Drawing.Point(10, 122);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(35, 16);
            this.lblFiyat.TabIndex = 2;
            this.lblFiyat.Text = "Fiyat:";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(100, 30);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(200, 22);
            this.txtAd.TabIndex = 1;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.ForeColor = System.Drawing.Color.White;
            this.lblAd.Location = new System.Drawing.Point(10, 33);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(82, 16);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "Yemek Adı:";
            // 
            // grpButonlar
            // 
            this.grpButonlar.Controls.Add(this.btnKapat);
            this.grpButonlar.Controls.Add(this.btnTemizle);
            this.grpButonlar.Controls.Add(this.btnSil);
            this.grpButonlar.Controls.Add(this.btnGuncelle);
            this.grpButonlar.Controls.Add(this.btnEkle);
            this.grpButonlar.Location = new System.Drawing.Point(20, 420);
            this.grpButonlar.Name = "grpButonlar";
            this.grpButonlar.Size = new System.Drawing.Size(640, 80);
            this.grpButonlar.TabIndex = 3;
            this.grpButonlar.TabStop = false;
            this.grpButonlar.ForeColor = System.Drawing.Color.White;
            this.grpButonlar.Text = "İşlemler";
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(520, 25);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(100, 35);
            this.btnKapat.TabIndex = 4;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Location = new System.Drawing.Point(410, 25);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(100, 35);
            this.btnTemizle.TabIndex = 3;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Firebrick;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(300, 25);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 35);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Orange;
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(190, 25);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 35);
            this.btnGuncelle.TabIndex = 1;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(20, 25);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 35);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // MenuYonetimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(950, 520);
            this.Controls.Add(this.grpButonlar);
            this.Controls.Add(this.grpYemekBilgileri);
            this.Controls.Add(this.lstMenu);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.lblYemekDetay);
            this.Controls.Add(this.picYemekResmi);
            this.Name = "MenuYonetimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menü Yönetimi";
            this.grpYemekBilgileri.ResumeLayout(false);
            this.grpYemekBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYemekResmi)).EndInit();
            this.grpButonlar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.ListBox lstMenu;
        private System.Windows.Forms.GroupBox grpYemekBilgileri;
        private System.Windows.Forms.CheckBox chkMevcut;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.TextBox txtResimYolu;
        private System.Windows.Forms.Label lblResimYolu;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.NumericUpDown nudFiyat;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.GroupBox grpButonlar;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label lblYemekDetay;
        private System.Windows.Forms.PictureBox picYemekResmi;
    }
}
