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
    public partial class IntroducereRandTratare : Form
    {
        public decimal CodRisc { get; private set; }
        public string MetodaTratare { get; private set; }
        public string CategorieContramasuri { get; private set; }
        public string Tratat { get; private set; }

        public IntroducereRandTratare()
        {
            InitializeComponent();
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            // Preia valorile introduse de utilizator
            CodRisc = Convert.ToDecimal(textBox_CodRisc.Text);
            MetodaTratare = textBox_MetodaTratare.Text;
            CategorieContramasuri = textBox_CategorieContramasuri.Text;
            Tratat = textBox_Tratat.Text;

            // Setează DialogResult pentru a indica că utilizatorul a apăsat OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void button_Cancel_Click_1(object sender, EventArgs e)
        {
            // Setează DialogResult pentru a indica că utilizatorul a apăsat Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
