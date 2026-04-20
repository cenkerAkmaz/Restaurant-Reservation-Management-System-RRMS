using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;
using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Services;

namespace RestoranRezervasyonSistemi.Views
{
    public partial class AdminPanel : Form
    {
        TableController tableController = new TableController();
        ReservationController reservationController = new ReservationController();
        UserController userController = new UserController();
        private List<User> _users;
        private List<Reservation> _reservations;

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            LoadTables();
            LoadUsers();
            LoadReservations();
        }

        private void LoadTables()
        {
            dgvMasalar.DataSource = null;
            dgvMasalar.DataSource = tableController.GetAllTables();

            if (dgvMasalar.Columns["Id"] != null) dgvMasalar.Columns["Id"].HeaderText = "No";
            if (dgvMasalar.Columns["TableName"] != null) dgvMasalar.Columns["TableName"].HeaderText = "Masa Adı";
            if (dgvMasalar.Columns["Capacity"] != null) dgvMasalar.Columns["Capacity"].HeaderText = "Kapasite";
            if (dgvMasalar.Columns["Location"] != null) dgvMasalar.Columns["Location"].HeaderText = "Konum";
        }

        private void LoadUsers()
        {
            try
            {
                _users = userController.GetAllUsers();
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _users;

                if (dgvUsers.Columns["Id"] != null) dgvUsers.Columns["Id"].HeaderText = "ID";
                if (dgvUsers.Columns["Username"] != null) dgvUsers.Columns["Username"].HeaderText = "Kullanıcı Adı";
                if (dgvUsers.Columns["FullName"] != null) dgvUsers.Columns["FullName"].HeaderText = "Tam Ad";
                if (dgvUsers.Columns["Email"] != null) dgvUsers.Columns["Email"].HeaderText = "E-posta";
                if (dgvUsers.Columns["Phone"] != null) dgvUsers.Columns["Phone"].HeaderText = "Telefon";
                if (dgvUsers.Columns["Role"] != null) dgvUsers.Columns["Role"].HeaderText = "Rol";
                if (dgvUsers.Columns["IsBanned"] != null) dgvUsers.Columns["IsBanned"].HeaderText = "Durum";

                // Banlı kullanıcıları renklendir
                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    bool isBanned = Convert.ToBoolean(row.Cells["IsBanned"].Value);
                    if (isBanned)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 230, 230);
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(180, 0, 0);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowError($"Kullanıcılar yüklenirken hata: {ex.Message}");
            }
        }

        private void LoadReservations()
        {
            try
            {
                _reservations = reservationController.GetAllReservations();
                dgvRezervasyonlar.DataSource = null;
                dgvRezervasyonlar.DataSource = _reservations;

                if (dgvRezervasyonlar.Columns["Id"] != null) dgvRezervasyonlar.Columns["Id"].HeaderText = "ID";
                if (dgvRezervasyonlar.Columns["CustomerName"] != null) dgvRezervasyonlar.Columns["CustomerName"].HeaderText = "Müşteri Adı";
                if (dgvRezervasyonlar.Columns["CustomerPhone"] != null) dgvRezervasyonlar.Columns["CustomerPhone"].HeaderText = "Telefon";
                if (dgvRezervasyonlar.Columns["CustomerEmail"] != null) dgvRezervasyonlar.Columns["CustomerEmail"].HeaderText = "E-posta";
                if (dgvRezervasyonlar.Columns["ReservationDate"] != null) dgvRezervasyonlar.Columns["ReservationDate"].HeaderText = "Tarih";
                if (dgvRezervasyonlar.Columns["ReservationTime"] != null) dgvRezervasyonlar.Columns["ReservationTime"].HeaderText = "Saat";
                if (dgvRezervasyonlar.Columns["TableId"] != null) dgvRezervasyonlar.Columns["TableId"].HeaderText = "Masa ID";
                if (dgvRezervasyonlar.Columns["GuestCount"] != null) dgvRezervasyonlar.Columns["GuestCount"].HeaderText = "Kişi Sayısı";
            }
            catch (Exception ex)
            {
                DialogService.ShowError($"Rezervasyonlar yüklenirken hata: {ex.Message}");
            }
        }

        // MASAYÖNETİM BUTONLARI
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Table yeniMasa = new Table
                {
                    TableName = txtMasaAdi.Text,
                    Capacity = int.Parse(txtKapasite.Text),
                    Location = txtKonum.Text
                };

                if (tableController.AddTable(yeniMasa))
                {
                    DialogService.ShowInfo("Masa başarıyla eklendi!");
                    LoadTables();
                    ClearTableFields();
                }
            }
            catch (Exception ex) { DialogService.ShowError($"Hata: {ex.Message}"); }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvMasalar.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvMasalar.CurrentRow.Cells["Id"].Value);
                if (DialogService.ShowConfirmation("Seçili masayı silmek istediğinize emin misiniz?", "Silme Onayı"))
                {
                    if (tableController.DeleteTable(id))
                    {
                        DialogService.ShowInfo("Masa başarıyla silindi.");
                        LoadTables();
                        ClearTableFields();
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvMasalar.CurrentRow != null)
            {
                try
                {
                    Table guncellenecek = new Table
                    {
                        Id = Convert.ToInt32(dgvMasalar.CurrentRow.Cells["Id"].Value),
                        TableName = txtMasaAdi.Text,
                        Capacity = int.Parse(txtKapasite.Text),
                        Location = txtKonum.Text
                    };

                    if (tableController.UpdateTable(guncellenecek))
                    {
                        DialogService.ShowInfo("Masa bilgileri güncellendi.");
                        LoadTables();
                        ClearTableFields();
                    }
                }
                catch (Exception ex) { DialogService.ShowError($"Hata: {ex.Message}"); }
            }
        }

        private void dgvMasalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMasalar.CurrentRow != null)
            {
                txtMasaAdi.Text = dgvMasalar.CurrentRow.Cells["TableName"].Value?.ToString() ?? "";
                txtKapasite.Text = dgvMasalar.CurrentRow.Cells["Capacity"].Value?.ToString() ?? "";
                txtKonum.Text = dgvMasalar.CurrentRow.Cells["Location"].Value?.ToString() ?? "";
            }
        }

        private void ClearTableFields()
        {
            txtMasaAdi.Clear();
            txtKapasite.Clear();
            txtKonum.Clear();
        }

        // KULLANICI YÖNETİM BUTONLARI
        private void btnBanUser_Click(object sender, EventArgs e)
        {
            if (!ValidateUserSelection())
                return;

            var selectedUser = GetSelectedUser();
            if (DialogService.ShowConfirmation($"{selectedUser.FullName} kullanıcısını banlamak istediğinizden emin misiniz?", "Ban Onayı"))
            {
                try
                {
                    if (userController.BanUser(selectedUser.Id, selectedUser.FullName))
                    {
                        DialogService.ShowInfo("Kullanıcı başarıyla banlandı.");
                        LoadUsers();
                    }
                    else
                    {
                        DialogService.ShowError("Banlama işlemi başarısız oldu.");
                    }
                }
                catch (Exception ex)
                {
                    DialogService.ShowError($"Hata: {ex.Message}");
                }
            }
        }

        private void btnUnbanUser_Click(object sender, EventArgs e)
        {
            if (!ValidateUserSelection())
                return;

            var selectedUser = GetSelectedUser();
            if (DialogService.ShowConfirmation($"{selectedUser.FullName} kullanıcısının banını kaldırmak istediğinizden emin misiniz?", "Ban Kaldırma Onayı"))
            {
                try
                {
                    if (userController.UnbanUser(selectedUser.Id, selectedUser.FullName))
                    {
                        DialogService.ShowInfo("Kullanıcının banı başarıyla kaldırıldı.");
                        LoadUsers();
                    }
                    else
                    {
                        DialogService.ShowError("Ban kaldırma işlemi başarısız oldu.");
                    }
                }
                catch (Exception ex)
                {
                    DialogService.ShowError($"Hata: {ex.Message}");
                }
            }
        }

        private void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            LoadUsers();
            DialogService.ShowInfo("Kullanıcı listesi yenilendi.");
        }

        private bool ValidateUserSelection()
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                DialogService.ShowWarning("Lütfen bir kullanıcı seçin.");
                return false;
            }
            return true;
        }

        private User GetSelectedUser()
        {
            var selectedRow = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        // REZERVASYON YÖNETİM BUTONLARI
        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (!ValidateReservationSelection())
                return;

            var selectedReservation = GetSelectedReservation();
            if (DialogService.ShowConfirmation($"{selectedReservation.CustomerName} kullanıcısının rezervasyonunu iptal etmek istediğinizden emin misiniz?", "Rezervasyon İptal Onayı"))
            {
                try
                {
                    if (reservationController.CancelById(selectedReservation.Id))
                    {
                        DialogService.ShowInfo("Rezervasyon başarıyla iptal edildi.");
                        LoadReservations();
                    }
                    else
                    {
                        DialogService.ShowError("Rezervasyon iptal işlemi başarısız oldu.");
                    }
                }
                catch (Exception ex)
                {
                    DialogService.ShowError($"Hata: {ex.Message}");
                }
            }
        }

        private void btnRefreshReservations_Click(object sender, EventArgs e)
        {
            LoadReservations();
            DialogService.ShowInfo("Rezervasyon listesi yenilendi.");
        }

        private bool ValidateReservationSelection()
        {
            if (dgvRezervasyonlar.SelectedRows.Count == 0)
            {
                DialogService.ShowWarning("Lütfen bir rezervasyon seçin.");
                return false;
            }
            return true;
        }

        private Reservation GetSelectedReservation()
        {
            var selectedRow = dgvRezervasyonlar.SelectedRows[0];
            int reservationId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            return _reservations.FirstOrDefault(r => r.Id == reservationId);
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView click event - optional functionality
        }

        private void dgvRezervasyonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView click event - optional functionality
        }
    }
}
