using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Risk_Management
{
    public partial class IstoricEvaluari : Form
    {
        public IstoricEvaluari()
        {
            InitializeComponent();
            FillDataGridView();
        }

        private void IstoricEvaluari_Load(object sender, EventArgs e)
        {
            this.button_Export.Click += new EventHandler(button_Export_Click);

        }

        private void FillDataGridView()
        {
            try
            {
                // Creează o conexiune la baza de date
                using (OracleConnection connection = new DbConnect().GetConnection())
                {
                    // Deschide conexiunea
                    connection.Open();

                    // Creează comanda SQL pentru a selecta datele dorite
                    string selectQuery = @"
                        SELECT 
                            B.Nume_Bun AS Nume_Bun,
                            V.Vulnerabilitate AS Vulnerabilitate,
                            A.Amenintare AS Amenintare,
                            R.Nume_Risc AS Nume_Risc,
                            B.Impact_minim || '-' || B.Impact_maxim AS Impact,
                            R.Probabilitatea_de_aparitie AS Probabilitate,
                            R.Natura_riscului AS Natura_Riscului,
                            C.Tratat AS Tratat
                        FROM 
                            BUNURI B
                        JOIN 
                            RISCURI R ON B.Cod_Bun = R.Cod_Bun
                        JOIN 
                            AMENINTARI A ON B.Cod_Bun = A.Cod_Bun
                        JOIN 
                            VULNERABILITATI V ON B.Cod_Bun = V.Cod_Bun
                        JOIN 
                            CONTRAMASURI C ON R.Cod_Risc = C.Cod_Risc";

                    // Adaugă filtrul doar pentru câmpurile care sunt completate
                    if (!string.IsNullOrEmpty(textBox_Nume.Text))
                    {
                        selectQuery += $" WHERE B.Nume_Bun LIKE '%{textBox_Nume.Text}%'";
                    }
                    if (!string.IsNullOrEmpty(textBox_Bunuri.Text))
                    {
                        selectQuery += $" AND A.Amenintare LIKE '%{textBox_Bunuri.Text}%'";
                    }
                    // Continuă pentru celelalte câmpuri de filtrare

                    using (OracleCommand command = new OracleCommand(selectQuery, connection))
                    {
                        // Creează adaptorul de date și umple tabelul
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            // Atribuie sursa de date a DataGridView-ului
                            dataGridView1.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la conectare: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Adaugă aici codul dorit pentru manipularea evenimentului
            // Această metodă este apelată atunci când se face clic pe conținutul unei celule din DataGridView
        }


        private void button_Filtrare_Click(object sender, EventArgs e)
        {
            // Reîncarcă DataGridView-ul cu datele filtrate
            FillDataGridView();
        }

        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            try
            {
                // Creează un StringBuilder pentru a construi conținutul CSV
                StringBuilder csvContent = new StringBuilder();

                // Adaugă antetele coloanelor în CSV
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    csvContent.Append(column.HeaderText + ",");
                }
                csvContent.AppendLine();

                // Adaugă datele din fiecare rând în CSV
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        csvContent.Append(cell.Value + ",");
                    }
                    csvContent.AppendLine();
                }

                // Scrie conținutul CSV în fișierul specificat
                File.WriteAllText(filePath, csvContent.ToString());

                MessageBox.Show("Datele au fost exportate cu succes în format CSV.", "Export reușit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la exportul datelor: " + ex.Message, "Eroare export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            // Afișează un dialog pentru selectarea locației de salvare a fișierului
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obține calea fișierului selectat
                string filePath = saveFileDialog.FileName;

                // Exportă datele în fișierul CSV
                ExportToCSV(dataGridView1, filePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox_Nume_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Bunuri_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Nivel_minim_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Nivel_maxim_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
