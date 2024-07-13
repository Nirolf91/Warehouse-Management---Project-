using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Risk_Management
{
    public partial class IntroducereRandAmenintari : Form
    {
        // Proprietăți pentru informațiile despre amenințări
        public string Amenintare { get; set; }
        public decimal CodBun { get; set; }
        public string NivelMinim { get; set; }
        public string NivelMaxim { get; set; }

        public IntroducereRandAmenintari()
        {
            InitializeComponent();
        }

        public void label_Amenintare_Click(object sender, EventArgs e)
        {

        }

        public void label_Cod_bun_Click(object sender, EventArgs e)
        {

        }

        public void label_Nivel_minim_Click(object sender, EventArgs e)
        {

        }

        public void label_Nivel_maxim_Click(object sender, EventArgs e)
        {

        }

        public void button_Ok_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Nivel_maxim_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Ok_Click_1(object sender, EventArgs e)
        {
            // Salvăm valorile introduse în proprietăți
            Amenintare = textBox_Amenintare.Text;

            if (decimal.TryParse(textBox_CodBun.Text, out decimal codBun))
            {
                CodBun = codBun;
                NivelMinim = textBox_Nivel_minim.Text;
                NivelMaxim = textBox_Nivel_maxim.Text;

                if (ValidareCodBun(CodBun))
                {
                    // Setăm rezultatul formularului ca OK și închidem formularul
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Codul bun introdus nu există în tabela BUNURI.", "Eroare de validare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Codul bun trebuie să fie un număr valid.", "Eroare de validare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidareCodBun(decimal codBun)
        {
            try
            {
                using (OracleConnection connection = new DbConnect().GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM BUNURI WHERE Cod_Bun = :codBun";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = codBun;
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la validarea codului bun: " + ex.Message);
                return false;
            }
        }
    }
}
