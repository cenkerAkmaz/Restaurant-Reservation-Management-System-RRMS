using System;
using System.Drawing;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;
using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Data;
using RestoranRezervasyonSistemi.Services;

namespace RestoranRezervasyonSistemi
{
    public partial class MainForm : Form
    {
        public string AktifKullaniciMail { get; set; }
        public User CurrentUser { get; set; }

        private readonly TableController _tableController;
        private readonly ReservationController _reservationController;
        private readonly TableService _tableService;
        private readonly ToolTip _toolTip;

        public MainForm()
        {
            _tableController = new TableController();
            _reservationController = new ReservationController();
            _tableService = new TableService(_tableController, _reservationController);
            _toolTip = CreateToolTip();
            InitializeComponent();
        }

        private ToolTip CreateToolTip()
        {
            return new ToolTip
            {
                AutoPopDelay = 8000,
                InitialDelay = 400,
                ReshowDelay = 200,
                ShowAlways = true
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTables();
            SetupUserManagementButton();
        }

        private void SetupUserManagementButton()
        {
            if (CurrentUser?.Role != "Admin")
            {
                btnUserManagement.Visible = false;
                return;
            }

            btnUserManagement.Click += (s, ev) => {
                using (var userManagement = new UserManagementForm())
                {
                    userManagement.ShowDialog();
                }
            };
        }

        public void LoadTables()
        {
            flpMasalar.Controls.Clear();

            var tableButtonInfos = _tableService.GetTableButtonInfos();

            foreach (var tableInfo in tableButtonInfos)
            {
                var button = CreateTableButton(tableInfo);
                flpMasalar.Controls.Add(button);
            }

            flpMasalar.Refresh();
        }

        private Button CreateTableButton(TableButtonInfo tableInfo)
        {
            var table = tableInfo.Table;
            
            var button = new Button
            {
                Text = FormatButtonText(table),
                Name = $"btnMasa{table.Id}",
                Size = new Size(TableConstants.ButtonSize, TableConstants.ButtonSize),
                BackColor = tableInfo.ButtonColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", TableConstants.ButtonFontSize, FontStyle.Bold)
            };

            _toolTip.SetToolTip(button, tableInfo.TooltipText);
            button.Click += (s, ev) => HandleTableClick(table);

            return button;
        }

        private string FormatButtonText(Table table)
        {
            return $"{table.TableName}\n{table.Location}\n({table.Capacity} Kişilik)";
        }

        private void HandleTableClick(Table table)
        {
            using (var rezervasyonDetay = new RezervasyonDetay())
            {
                rezervasyonDetay.SecilenMasaAd = table.TableName;
                rezervasyonDetay.SecilenMasaId = table.Id;
                rezervasyonDetay.GirisYapanAdminMail = this.AktifKullaniciMail;
                rezervasyonDetay.AktifKullanici = this.CurrentUser;
                rezervasyonDetay.SecilenMasaKapasite = table.Capacity;

                rezervasyonDetay.ShowDialog();
            }

            LoadTables();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void pnlTableArea_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}