namespace RestoranRezervasyonSistemi
{
    partial class UserManagementForm
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
            this.SuspendLayout();

            // Form properties
            this.Text = "Kullanıcı Yönetimi";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            // Main panel
            this.mainPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.usersListView = new System.Windows.Forms.ListView();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.banButton = new System.Windows.Forms.Button();
            this.unbanButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();

            // mainPanel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.SuspendLayout();

            // titleLabel
            this.titleLabel.Text = "Kullanıcı Yönetimi";
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Size = new System.Drawing.Size(200, 30);
            this.titleLabel.AutoSize = true;

            // usersListView
            this.usersListView.Location = new System.Drawing.Point(20, 70);
            this.usersListView.Size = new System.Drawing.Size(740, 400);
            this.usersListView.View = System.Windows.Forms.View.Details;
            this.usersListView.FullRowSelect = true;
            this.usersListView.GridLines = true;
            this.usersListView.BackColor = System.Drawing.Color.White;
            this.usersListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usersListView.Name = "usersListView";

            // Add columns
            this.usersListView.Columns.Add("ID", 50);
            this.usersListView.Columns.Add("Kullanıcı Adı", 120);
            this.usersListView.Columns.Add("Tam Ad", 150);
            this.usersListView.Columns.Add("E-posta", 180);
            this.usersListView.Columns.Add("Rol", 80);
            this.usersListView.Columns.Add("Durum", 80);
            this.usersListView.Columns.Add("Telefon", 120);

            // buttonsPanel
            this.buttonsPanel.Location = new System.Drawing.Point(20, 490);
            this.buttonsPanel.Size = new System.Drawing.Size(740, 40);
            this.buttonsPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // banButton
            this.banButton.Text = "Banla";
            this.banButton.Location = new System.Drawing.Point(0, 0);
            this.banButton.Size = new System.Drawing.Size(100, 35);
            this.banButton.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.banButton.ForeColor = System.Drawing.Color.White;
            this.banButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.banButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.banButton.UseVisualStyleBackColor = false;
            this.banButton.FlatAppearance.BorderSize = 0;

            // unbanButton
            this.unbanButton.Text = "Ban Kaldır";
            this.unbanButton.Location = new System.Drawing.Point(110, 0);
            this.unbanButton.Size = new System.Drawing.Size(100, 35);
            this.unbanButton.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.unbanButton.ForeColor = System.Drawing.Color.White;
            this.unbanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unbanButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.unbanButton.UseVisualStyleBackColor = false;
            this.unbanButton.FlatAppearance.BorderSize = 0;

            // refreshButton
            this.refreshButton.Text = "Yenile";
            this.refreshButton.Location = new System.Drawing.Point(220, 0);
            this.refreshButton.Size = new System.Drawing.Size(100, 35);
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.FlatAppearance.BorderSize = 0;

            // closeButton
            this.closeButton.Text = "Kapat";
            this.closeButton.Location = new System.Drawing.Point(640, 0);
            this.closeButton.Size = new System.Drawing.Size(100, 35);
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.closeButton.FlatAppearance.BorderSize = 0;

            // Add controls to buttonsPanel
            this.buttonsPanel.Controls.AddRange(new System.Windows.Forms.Control[] { 
                this.banButton, this.unbanButton, this.refreshButton, this.closeButton });

            // Add controls to mainPanel
            this.mainPanel.Controls.AddRange(new System.Windows.Forms.Control[] { 
                this.titleLabel, this.usersListView, this.buttonsPanel });

            // Add main panel to form
            this.Controls.Add(this.mainPanel);

            // Set up event handlers
            this.banButton.Click += new System.EventHandler(this.BanButton_Click);
            this.unbanButton.Click += new System.EventHandler(this.UnbanButton_Click);
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button banButton;
        private System.Windows.Forms.Button unbanButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button closeButton;
    }
}
