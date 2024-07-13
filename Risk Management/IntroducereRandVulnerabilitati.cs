using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Risk_Management
{
    public partial class IntroducereRandVulnerabilitati : Form
    {
        public decimal CodBun { get; private set; }
        public string Vulnerabilitate { get; private set; }
        public string Nivel { get; private set; }
        public IntroducereRandVulnerabilitati()
        {
            InitializeComponent();
        }

        private void label_Cod_bun_Click(object sender, EventArgs e)
        {

        }

        private void label_Vulnerabilitate_Click(object sender, EventArgs e)
        {

        }

        private void label_Nivel_Click(object sender, EventArgs e)
        {

        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                // Preia datele introduse de utilizator
                CodBun = decimal.Parse(textBox_CodBun.Text);
                Vulnerabilitate = textBox_Vulnerabilitate.Text;
                Nivel = comboBox_Nivel.Text;

                // Setează dialogul ca Ok și închide formularul
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la preluarea datelor: " + ex.Message);
            }

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {

            // Închide formularul fără a seta dialogul ca Ok
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
