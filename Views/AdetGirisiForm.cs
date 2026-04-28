using System;
using System.Windows.Forms;

namespace RestoranRezervasyonSistemi.Views
{
    public partial class AdetGirisiForm : Form
    {
        public int SecilenAdet { get; private set; }

        public AdetGirisiForm(int mevcutAdet)
        {
            InitializeComponent();
            nmrAdet.Value = mevcutAdet;
            SecilenAdet = mevcutAdet;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            SecilenAdet = (int)nmrAdet.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
