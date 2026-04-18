using System;
using System.Data;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;

namespace RestoranRezervasyonSistemi
{
    public partial class RezervasyonListesi : Form
    {
        private readonly ReservationController _reservationController = new ReservationController();
        public Models.User CurrentUser { get; set; }

        public RezervasyonListesi()
        {
            InitializeComponent();
        }

        private void RezervasyonListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele()
        {
            try
            {
                DataTable dt = _reservationController.GetReservationList();
                dgvRezervasyonlar.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIptalEt_Click(object sender, EventArgs e)
        {
            // 1. Önce tabloda bir satır seçili mi kontrol et
            if (dgvRezervasyonlar.SelectedRows.Count > 0)
            {
                // 2. Seçili satırdaki ID'yi al 
                int seciliRezervasyonId = Convert.ToInt32(dgvRezervasyonlar.SelectedRows[0].Cells["id"].Value);

                DialogResult onay = MessageBox.Show("Bu rezervasyonu iptal etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);

                if (onay == DialogResult.Yes)
                {
                    try
                    {
                        if (CurrentUser == null || string.IsNullOrWhiteSpace(CurrentUser.Email))
                        {
                            MessageBox.Show("Aktif kullanıcı bulunamadı. Lütfen tekrar giriş yapın.");
                            return;
                        }

                        var name = string.IsNullOrWhiteSpace(CurrentUser.FullName) ? CurrentUser.Username : CurrentUser.FullName;

                        if (_reservationController.CancelByIdForUser(seciliRezervasyonId, CurrentUser.Email, name))
                        {
                            MessageBox.Show("Rezervasyon başarıyla silindi.");
                            Listele(); // Listeyi yenile
                        }
                        else
                        {
                            MessageBox.Show("Başkalarının rezervasyonunu iptal edemezsiniz!", "Yetki Yok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen iptal etmek istediğiniz rezervasyonu listeden seçin.");
            }
        }
    }
}