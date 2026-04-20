using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using RestoranRezervasyonSistemi.Controllers;
using RestoranRezervasyonSistemi.Services;
using RestoranRezervasyonSistemi.Models;

namespace RestoranRezervasyonSistemi
{
    public partial class RezervasyonDetay : Form
    {
        public string SecilenMasaAd { get; set; }
        public int SecilenMasaId { get; set; }
        public string GirisYapanAdminMail { get; set; }
        public User AktifKullanici { get; set; }
        public int SecilenMasaKapasite { get; set; }
        string dogrulamaKodu;

        // 6. hafta kodları eklendi
        private readonly ReservationController _reservationController = new ReservationController();
        private readonly SmtpEmailService _emailService = new SmtpEmailService();
        private int? _currentUserReservationId;

        public RezervasyonDetay()
        {
            InitializeComponent();
        }

        public RezervasyonDetay(int reservationId)
        {
            InitializeComponent();
            _currentUserReservationId = reservationId;
        }

        private void RezervasyonDetay_Load(object sender, EventArgs e)
        {
            lblBilgi.Text = SecilenMasaAd + " Rezervasyon İşlemi";

            // Login sonrası müşteri ad/soyad ve telefon otomatik gelsin.
            // DB'de full_name yoksa Username ile devam eder.
            if (AktifKullanici != null)
            {
                var displayName = string.IsNullOrWhiteSpace(AktifKullanici.FullName)
                    ? AktifKullanici.Username
                    : AktifKullanici.FullName;

                if (!string.IsNullOrWhiteSpace(displayName))
                    txtMusteriAd.Text = displayName;

                if (!string.IsNullOrWhiteSpace(AktifKullanici.Phone))
                    txtMusteriTel.Text = AktifKullanici.Phone;
            }

            // İptal butonu yalnızca iptal edilecek rezervasyon varsa aktif olsun.
            btnIptalEt.Enabled = false;
            dtpTarih.ValueChanged += (s, ev) => UpdateCancelButtonState();
            dtpSaat.ValueChanged += (s, ev) => UpdateCancelButtonState();
            UpdateCancelButtonState();
        }

        private void UpdateCancelButtonState()
        {
            try
            {
                _currentUserReservationId = null;

                var customerName = txtMusteriAd.Text?.Trim();
                var customerEmail = GirisYapanAdminMail;

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(customerEmail))
                {
                    btnIptalEt.Enabled = false;
                    return;
                }

                var r = _reservationController.GetNextReservationForUser(SecilenMasaId, dtpTarih.Value.Date, customerEmail, customerName);
                if (r == null)
                {
                    btnIptalEt.Enabled = false;
                    return;
                }

                _currentUserReservationId = r.Value.ReservationId;
                btnIptalEt.Enabled = true;

                // Kullanıcının rezervasyon saatini otomatik seçili yap (iptal kolay olsun).
                var desired = DateTime.Today.Add(r.Value.ReservationTime);
                if (dtpSaat.Value.TimeOfDay != r.Value.ReservationTime)
                    dtpSaat.Value = desired;
            }
            catch
            {
                btnIptalEt.Enabled = false;
                _currentUserReservationId = null;
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (nmrKisiSayisi.Value > SecilenMasaKapasite)
            {
                MessageBox.Show($"Hata: Seçtiğiniz masa en fazla {SecilenMasaKapasite} kişiliktir.", "Kapasite Aşımı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CakismaVarMi(SecilenMasaId, dtpTarih.Value, dtpSaat.Value.TimeOfDay))
            {
                MessageBox.Show("Bu masa seçilen saatlerde dolu.", "Çakışma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(GirisYapanAdminMail)) GirisYapanAdminMail = "merttemizcanbir@gmail.com";

            Random rnd = new Random();
            dogrulamaKodu = rnd.Next(100000, 999999).ToString();

            try
            {
                _emailService.Send(GirisYapanAdminMail, "Rezervasyon İşlem Onayı", $"Onay kodunuz: {dogrulamaKodu}");
                MessageBox.Show($"Güvenlik kodu {GirisYapanAdminMail} adresine gönderildi.", "Onay Gerekli");

                var onayEkrani = new RestoranRezervasyonSistemi.Views.IslemOnay();
                onayEkrani.GonderilenKod = dogrulamaKodu;

                if (onayEkrani.ShowDialog() == DialogResult.OK)
                {
                    AsilKaydiYap();
                }
            }
            catch (Exception ex) { MessageBox.Show("Mail hatası: " + ex.Message); }
        }

        private void AsilKaydiYap()
        {
            try
            {
                _reservationController.CreateReservation(
                    tableId: SecilenMasaId,
                    customerName: txtMusteriAd.Text,
                    customerPhone: txtMusteriTel.Text,
                    date: dtpTarih.Value.Date,
                    time: dtpSaat.Value.TimeOfDay,
                    guestCount: (int)nmrKisiSayisi.Value,
                    customerEmail: GirisYapanAdminMail
                );

                MessageBox.Show("Başarıyla rezerve edildi!");
                Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private bool CakismaVarMi(int masaId, DateTime tarih, TimeSpan saat)
        {
            return _reservationController.HasConflict(masaId, tarih.Date, saat);
        }

        
        
        private void btnIptalEt_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Rezervasyonunuzu iptal etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                var customerName = txtMusteriAd.Text?.Trim();
                var customerEmail = GirisYapanAdminMail;

                bool sonuc = false;

                if (_currentUserReservationId.HasValue)
                {
                    sonuc = _reservationController.CancelByIdForUser(_currentUserReservationId.Value, customerEmail, customerName);
                }
                else
                {
                    // Fallback: try by table/date/time
                    sonuc = _reservationController.CancelForUser(
                        tableId: SecilenMasaId,
                        date: dtpTarih.Value.Date,
                        time: dtpSaat.Value.TimeOfDay,
                        customerEmail: customerEmail,
                        customerName: customerName
                    );
                }

                if (sonuc)
                {
                    MessageBox.Show("İptal edildi.");
                    this.Close();
                }
                else
                {
                    // Eğer aynı masa/tarih/saat için rezervasyon varsa ama senin ad+mail eşleşmiyorsa -> yetki yok
                    // Hiç rezervasyon yoksa -> daha doğru mesaj
                    var anyReservationExists = _reservationController.ReservationExists(
                        tableId: SecilenMasaId,
                        date: dtpTarih.Value.Date,
                        time: dtpSaat.Value.TimeOfDay
                    );

                    if (anyReservationExists)
                    {
                        MessageBox.Show("Başkalarının rezervasyonunu iptal edemezsiniz!", "Yetki Yok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Bu tarih/saat için iptal edilecek rezervasyon bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}