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
    public partial class Introducere_Rand : Form
    {
        private IdentificareBunuri parentForm;

        public Introducere_Rand(IdentificareBunuri parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        // Proprietăți pentru a prelua datele introduse în formulare
        public string NumeBun => textBox_NumeBun.Text;
        public decimal CodProiect => decimal.Parse(textBox_CodProiect.Text);
        public decimal ImpactMinim => decimal.Parse(textBox_Impact_minim.Text);
        public decimal ImpactMaxim => decimal.Parse(textBox_Impact_maxim.Text);
        public string DomeniuCategorie => comboBox_Domeniu_categorie.Text;
        public decimal Cost => decimal.Parse(textBox_Cost.Text);
        public decimal CostDeReducere => decimal.Parse(textBox_Cost_de_reducere.Text);

        public Introducere_Rand()
        {
            InitializeComponent();
        }

        private void Introducere__Rand_Load(object sender, EventArgs e)
        {
            // Acesta este un eveniment de încărcare a formularului; nu face nimic în acest moment
        }

        // Evenimente pentru click pe etichete; în prezent nu fac nimic
        private void label_Nume_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }

        // Evenimente pentru schimbarea textului în textBox-uri; în prezent nu fac nimic
        private void textBox_NumeBun_TextChanged(object sender, EventArgs e) { }
        private void textBox_CodProiect_TextChanged(object sender, EventArgs e) { }
        private void textBox_Impact_minim_TextChanged(object sender, EventArgs e) { }
        private void textBox_Impact_maxim_TextChanged(object sender, EventArgs e) { }
        private void comboBox_Domeniu_categorie_TextChanged(object sender, EventArgs e) { }
        private void textBox_Cost_TextChanged(object sender, EventArgs e) { }
        private void textBox_Cost_de_reducere_TextChanged(object sender, EventArgs e) { }

        // Evenimente pentru click pe butoane
        private void button1_Click(object sender, EventArgs e)
        {
            // Nu face nimic în prezent, utilizăm butoanele `OK` și `Cancel`
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Nu face nimic în prezent, utilizăm butoanele `OK` și `Cancel`
        }
        public decimal CodBun { get; set; }

        // Eveniment pentru click pe butonul OK
        private void button_Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Eveniment pentru click pe butonul Cancel
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBox_Domeniu_categorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
