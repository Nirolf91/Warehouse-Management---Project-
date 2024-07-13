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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void IdentificareBunuri(object sender, EventArgs e)
        {
            // Creează o instanță a formularului IdentificareBunuri
            IdentificareBunuri identificareBunuriForm = new IdentificareBunuri();

            // Afișează formularul IdentificareBunuri
            identificareBunuriForm.Show();
        }


        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void IdentificareAmenintari(object sender, EventArgs e)
        {
            IdentificareAmenintari identificareAmenintariForm = new IdentificareAmenintari();
            identificareAmenintariForm.Show();
        }

        private void IdentificareVulnerabilitati_Click(object sender, EventArgs e)
        {
            IdentificareVulnerabilitati identificareVulnerabilitatiForm = new IdentificareVulnerabilitati();
            identificareVulnerabilitatiForm.Show(); 
        }

        private void IdentificareRiscuri_Click(object sender, EventArgs e)
        {
            IdentificareRiscuri identificareRiscuriForm = new IdentificareRiscuri();
            identificareRiscuriForm.Show();
        }

        private void TratareRiscuri_Click(object sender, EventArgs e)
        {
            TratareRiscuri tratareRiscuriForm = new TratareRiscuri();
            tratareRiscuriForm.Show();  
        }


        private void IstoricEvaluari_Click(object sender, EventArgs e)
        {
            IstoricEvaluari istoricEvaluariForm = new IstoricEvaluari();
            istoricEvaluariForm.Show(); 
        
        }


        private void Log_out_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
