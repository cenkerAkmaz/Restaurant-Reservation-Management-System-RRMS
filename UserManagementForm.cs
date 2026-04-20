using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;
using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Services;

namespace RestoranRezervasyonSistemi
{
    public partial class UserManagementForm : Form
    {
        private readonly UserController _userController;
        private List<User> _users;

        // UI Controls
        private Panel mainPanel;
        private Label titleLabel;
        private ListView usersListView;
        private Panel buttonsPanel;
        private Button banButton;
        private Button unbanButton;
        private Button refreshButton;
        private Button closeButton;

        public UserManagementForm()
        {
            InitializeComponent();
            _userController = new UserController();
            LoadUsers();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Kullanıcı Yönetimi";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Main panel
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            // Title label
            titleLabel = new Label
            {
                Text = "Kullanıcı Yönetimi",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                Location = new Point(20, 20),
                Size = new Size(200, 30),
                AutoSize = true
            };

            // Users listview
            usersListView = new ListView
            {
                Location = new Point(20, 70),
                Size = new Size(740, 400),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            usersListView.Columns.Add("ID", 50);
            usersListView.Columns.Add("Kullanıcı Adı", 120);
            usersListView.Columns.Add("Tam Ad", 150);
            usersListView.Columns.Add("E-posta", 180);
            usersListView.Columns.Add("Rol", 80);
            usersListView.Columns.Add("Durum", 80);
            usersListView.Columns.Add("Telefon", 120);

            // Buttons panel
            buttonsPanel = new Panel
            {
                Location = new Point(20, 490),
                Size = new Size(740, 40),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            // Ban button
            banButton = new Button
            {
                Text = "Banla",
                Location = new Point(0, 0),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                UseVisualStyleBackColor = false
            };
            banButton.FlatAppearance.BorderSize = 0;
            banButton.Click += BanButton_Click;

            // Unban button
            unbanButton = new Button
            {
                Text = "Ban Kaldır",
                Location = new Point(110, 0),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                UseVisualStyleBackColor = false
            };
            unbanButton.FlatAppearance.BorderSize = 0;
            unbanButton.Click += UnbanButton_Click;

            // Refresh button
            refreshButton = new Button
            {
                Text = "Yenile",
                Location = new Point(220, 0),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                UseVisualStyleBackColor = false
            };
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.Click += RefreshButton_Click;

            // Close button
            closeButton = new Button
            {
                Text = "Kapat",
                Location = new Point(640, 0),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                UseVisualStyleBackColor = false,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) => this.Close();

            // Add controls to buttonsPanel
            buttonsPanel.Controls.AddRange(new Control[] { banButton, unbanButton, refreshButton, closeButton });

            // Add controls to mainPanel
            mainPanel.Controls.AddRange(new Control[] { titleLabel, usersListView, buttonsPanel });

            // Add main panel to form
            this.Controls.Add(mainPanel);

            this.ResumeLayout(false);
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
