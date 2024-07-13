using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Risk_Management
{
    public partial class IntroducereRandRisc : Form
    {
        // Proprietăți pentru a stoca valorile introduse de utilizator
        public string NumeRisc { get; private set; }
        public int CodBun { get; private set; }
        public int NivelRisc { get; private set; }
        public decimal ProbabilitateAparitie { get; private set; }
        public string NaturaRisc { get; private set; }
        public int CodRisc { get; private set; }
        public DateTime Data { get; private set; }

        public IntroducereRandRisc()
        {
            InitializeComponent();
        }

        private void IntroducereRandRisc_Load(object sender, EventArgs e)
        {

        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                // Preia datele introduse de utilizator
                NumeRisc = textBox_NumeRisc.Text;
                CodBun = int.Parse(textBox_CodBun.Text);
                NivelRisc = int.Parse(textBox_NivelulRiscului.Text);
                ProbabilitateAparitie = decimal.Parse(textBox_ProbabilitateaAparitiei.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
                NaturaRisc = textBox_NaturaRiscului.Text;
                CodRisc = int.Parse(textBox_CodRisc.Text);

                // Preia data din TextBox și asigură-te că este în formatul corect
                Data = DateTime.ParseExact(textBox_Data.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                // Setează dialogul ca Ok și închide formularul
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la preluarea datelor: " + ex.Message);
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            // Închide formularul cu DialogResult.Cancel
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label_CodBun_Click(object sender, EventArgs e)
        {

        }

        private void label_NumeRisc_Click(object sender, EventArgs e)
        {

        }

        private void label_NivelulRiscului_Click(object sender, EventArgs e)
        {

        }

        private void label_ProbabilitateaDeAparitie_Click(object sender, EventArgs e)
        {

        }

        private void label_NaturaRiscului_Click(object sender, EventArgs e)
        {

        }

        private void label_CodRisc_Click(object sender, EventArgs e)
        {

        }

        private void textBox_NivelulRiscului_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Data_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Data_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
