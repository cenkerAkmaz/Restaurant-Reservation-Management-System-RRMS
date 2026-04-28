using System;
using System.Drawing;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;
using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Data;
using RestoranRezervasyonSistemi.Services;

namespace RestoranRezervasyonSistemi.Views
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
            try
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
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Null reference hatası (masa yüklenirken): {ex.Message}\n\nVeritabanı bağlantısını kontrol edin.", "Null Reference Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Masalar yüklenirken hata oluştu: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                // Null kontrolleri
                if (table == null)
                {
                    MessageBox.Show("Masa bilgisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(this.AktifKullaniciMail))
                {
                    MessageBox.Show("Kullanıcı mail adresi bulunamadı. Lütfen tekrar giriş yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var rezervasyonDetay = new RezervasyonDetay())
                {
                    rezervasyonDetay.SecilenMasaAd = table.TableName ?? "Bilinmeyen Masa";
                    rezervasyonDetay.SecilenMasaId = table.Id;
                    rezervasyonDetay.GirisYapanAdminMail = this.AktifKullaniciMail;
                    rezervasyonDetay.AktifKullanici = this.CurrentUser;
                    rezervasyonDetay.SecilenMasaKapasite = table.Capacity;

                    rezervasyonDetay.ShowDialog();
                }

                LoadTables();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Null reference hatası: {ex.Message}\n\nLütfen tüm alanların dolu olduğundan emin olun.", "Null Reference Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Masa tıklanırken hata oluştu: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void pnlTableArea_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}