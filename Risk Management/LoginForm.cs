using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Risk_Management
{
    public partial class LoginForm : Form
    {
        DbConnect connect = new DbConnect();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            // Obține utilizatorul și parola introduse de utilizator
            string utilizator = TextBox_username.Text;
            string parola = TextBox_password.Text;

            // Creează obiectul de conexiune
            DbConnect dbConnect = new DbConnect();
            OracleConnection connection = dbConnect.GetConnection();

            try
            {
                // Deschide conexiunea
                connection.Open();

                // Creează comanda SQL
                string selectQuery = "SELECT * FROM Organizatie WHERE UTILIZATOR = :utilizator AND PAROLA = :parola";
                OracleCommand command = new OracleCommand(selectQuery, connection);
                command.Parameters.Add("utilizator", OracleDbType.Varchar2).Value = utilizator;
                command.Parameters.Add("parola", OracleDbType.Varchar2).Value = parola;

                // Creează adaptorul de date și umple tabelul
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Verifică rezultatul interogării
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Utilizator autentificat cu succes!");

                    // Deschide formularul principal dacă autentificarea este reușită
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Autentificare eșuată. Utilizator sau parolă incorectă.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la conectare: " + ex.Message);
            }
            finally
            {
                // Închide conexiunea
                connection.Close();
            }
        }


        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.DeepSkyBlue;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Evenimentul CheckedChanged a fost declanșat.");

            // Verifică dacă butonul "Show Password" este bifat sau nu
            if (checkBox1.Checked)
            {
                // Dacă este bifat, afișează parola
                TextBox_password.UseSystemPasswordChar = false;
                Console.WriteLine("Parola ar trebui să fie acum vizibilă.");
            }
            else
            {
                // Dacă nu este bifat, ascunde parola
                TextBox_password.UseSystemPasswordChar = true;
                Console.WriteLine("Parola ar trebui să fie acum ascunsă.");
            }
        }

        private void TextBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}