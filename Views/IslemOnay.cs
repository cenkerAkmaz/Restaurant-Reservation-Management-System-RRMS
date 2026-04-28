using System;
using System.Windows.Forms;

namespace RestoranRezervasyonSistemi.Views
{
    public partial class IslemOnay : Form
    {
        public string GonderilenKod { get; set; }
        public IslemOnay()
        {
            InitializeComponent();
        }

        private void IslemOnay_Load(object sender, EventArgs e)
        {

        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            if (txtOnayKodu.Text == GonderilenKod)
            {
                this.DialogResult = DialogResult.OK; // Ana forma "başarılı" bilgisi gönderir
                this.Close();
            }
            else
            {
                MessageBox.Show("Hatalı kod girdiniz!");
            }
        }
    }
}
