using System;
using System.Drawing;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;
using RestoranRezervasyonSistemi.Models;

namespace RestoranRezervasyonSistemi
{
    public partial class MainForm : Form
    {
        public string AktifKullaniciMail { get; set; }
        public User CurrentUser { get; set; }

        private readonly TableController _tableController = new TableController();
        private readonly ReservationController _reservationController = new ReservationController();
        private readonly ToolTip _toolTip = new ToolTip
        {
            AutoPopDelay = 8000,
            InitialDelay = 400,
            ReshowDelay = 200,
            ShowAlways = true
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MasalariYukle();
        }

        public void MasalariYukle()
        {
            
            flpMasalar.Controls.Clear();

            var masalar = _tableController.GetAllTables();

            foreach (var masa in masalar)
            {
                Button btn = new Button();

                
                string durum = (masa.Status ?? "").ToString().Trim();

                
                TimeSpan suAnkiSaat = DateTime.Now.TimeOfDay; 

                
                if (masa.ReservationTime != null)
                {
                    TimeSpan rezSaati = (TimeSpan)masa.ReservationTime;

                    // Rezervasyona 30 dakika kala kırmızı yap (Bilgisayar saati bazlı)
                    if (suAnkiSaat >= rezSaati.Add(TimeSpan.FromMinutes(-30)) &&
                        suAnkiSaat <= rezSaati.Add(TimeSpan.FromMinutes(150)))
                    {
                        btn.BackColor = Color.Firebrick; // KIRMIZI
                    }
                    else
                    {
                        btn.BackColor = Color.ForestGreen; // YEŞİL
                    }
                }
                else
                {
                    btn.BackColor = Color.ForestGreen; // YEŞİL
                }

                btn.Text = $"{masa.TableName}\n{masa.Location}\n({masa.Capacity} Kişilik)";
                btn.Name = "btnMasa" + masa.Id;
                btn.Size = new Size(120, 120);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Hover bilgisi: sonraki rezervasyon + en erken uygun saat (2.5 saat kuralıyla)
                var today = DateTime.Today;
                var now = DateTime.Now.TimeOfDay;
                var next = _reservationController.GetNextReservationTime(masa.Id, today, now);
                var earliest = _reservationController.GetEarliestAvailableTime(masa.Id, today, now);

                var nextText = next.HasValue ? next.Value.ToString(@"hh\:mm") : "Yok";
                var earliestText = earliest.ToString(@"hh\:mm");

                var tooltip = $"{masa.TableName}\nKonum: {masa.Location}\nKapasite: {masa.Capacity}\n" +
                              $"Sonraki rezervasyon: {nextText}\n" +
                              $"En erken uygun saat: {earliestText}\n" +
                              $"Oturma süresi: 2.5 saat";

                _toolTip.SetToolTip(btn, tooltip);

                
                btn.Click += (s, ev) => {
                    RezervasyonDetay detay = new RezervasyonDetay();
                    detay.SecilenMasaAd = masa.TableName;
                    detay.SecilenMasaId = masa.Id;
                    detay.GirisYapanAdminMail = this.AktifKullaniciMail;
                    detay.AktifKullanici = this.CurrentUser;
                    detay.SecilenMasaKapasite = masa.Capacity;

                    detay.ShowDialog(); // Formu açar ve kapanana kadar bekler

                    // Form kapandıktan sonra masaları tekrar yükle
                    MasalariYukle();
                };

                
                flpMasalar.Controls.Add(btn);
            }

            
            flpMasalar.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MasalariYukle();
        }

        private void pnlTableArea_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}