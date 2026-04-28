using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;
using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Services;

namespace RestoranRezervasyonSistemi.Views
{
    public partial class UserManagementForm : Form
    {
        private readonly UserController _userController;
        private List<User> _users;

        public UserManagementForm()
        {
            InitializeComponent();
            _userController = new UserController();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                _users = _userController.GetAllUsers();
                RefreshUserList();
            }
            catch (Exception ex)
            {
                DialogService.ShowError($"Kullanıcılar yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private void RefreshUserList()
        {
            usersListView.Items.Clear();

            foreach (var user in _users)
            {
                var item = new ListViewItem(new string[]
                {
                    user.Id.ToString(),
                    user.Username,
                    user.FullName,
                    user.Email,
                    user.Role,
                    user.IsBanned ? "Banlandı" : "Aktif",
                    user.Phone ?? "-"
                });

                SetUserItemStyle(item, user);
                usersListView.Items.Add(item);
            }
        }

        private void SetUserItemStyle(ListViewItem item, User user)
        {
            if (user.IsBanned)
            {
                item.BackColor = Color.FromArgb(255, 230, 230);
                item.ForeColor = Color.FromArgb(180, 0, 0);
            }
            else
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
            }
        }

        private void BanButton_Click(object sender, EventArgs e)
        {
            if (!ValidateUserSelection())
                return;

            var selectedUser = GetSelectedUser();
            if (!ConfirmAction($"{selectedUser.FullName} kullanıcısını banlamak istediğinizden emin misiniz?", 
                "Ban Onayı"))
                return;

            ExecuteUserAction(() => _userController.BanUser(selectedUser.Id, selectedUser.FullName),
                "Kullanıcı başarıyla banlandı.", 
                "Banlama işlemi başarısız oldu.");
        }

        private void UnbanButton_Click(object sender, EventArgs e)
        {
            if (!ValidateUserSelection())
                return;

            var selectedUser = GetSelectedUser();
            if (!ConfirmAction($"{selectedUser.FullName} kullanıcısının banını kaldırmak istediğinizden emin misiniz?", 
                "Ban Kaldırma Onayı"))
                return;

            ExecuteUserAction(() => _userController.UnbanUser(selectedUser.Id, selectedUser.FullName),
                "Kullanıcının banı başarıyla kaldırıldı.", 
                "Ban kaldırma işlemi başarısız oldu.");
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateUserSelection()
        {
            if (usersListView.SelectedItems.Count == 0)
            {
                DialogService.ShowWarning("Lütfen bir kullanıcı seçin.");
                return false;
            }
            return true;
        }

        private User GetSelectedUser()
        {
            var selectedItem = usersListView.SelectedItems[0];
            int userId = Convert.ToInt32(selectedItem.SubItems[0].Text);
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        private bool ConfirmAction(string message, string title)
        {
            return DialogService.ShowConfirmation(message, title);
        }

        private void ExecuteUserAction(Func<bool> action, string successMessage, string errorMessage)
        {
            try
            {
                if (action())
                {
                    DialogService.ShowInfo(successMessage);
                    LoadUsers();
                }
                else
                {
                    DialogService.ShowError(errorMessage);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowError(ex.Message);
            }
        }
    }
}
