using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Risk_Management
{
    public partial class IdentificareRiscuri : Form
    {
        public IdentificareRiscuri()
        {
            InitializeComponent();
            FillDataGridView();
            // Setează culoarea textului pentru celulele editabile
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
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

                    // Creează comanda SQL pentru a selecta toate înregistrările din tabela RISCURI
                    string selectQuery = @"
                 SELECT 
                    R.Nume_Risc,
                    B.Nume_Bun AS ""Bun"",
                    B.Cod_Bun,
                    R.Nivelul_riscului,
                    R.Probabilitatea_de_aparitie,
                    R.Natura_riscului,
                    R.Cod_Risc,
                    R.Data_Evaluare 
                FROM 
                    BUNURI B
                JOIN 
                    RISCURI R ON B.Cod_Bun = R.Cod_Bun";

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


        private void Insert_Click(object sender, EventArgs e)
        {
            // Deschide formularul de introducere a unui nou rând
            IntroducereRandRisc introducereForm = new IntroducereRandRisc();

            // Verifică dacă utilizatorul a apăsat pe Ok în formularul de introducere
            if (introducereForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Creează un nou rând în DataTable-ul asociat DataGridView-ului
                    DataRow newRow = ((DataTable)dataGridView1.DataSource).NewRow();

                    // Populează rândul nou cu datele introduse în formular
                    newRow["Nume_Risc"] = introducereForm.NumeRisc;
                    newRow["Cod_Bun"] = introducereForm.CodBun;
                    newRow["Nivelul_riscului"] = introducereForm.NivelRisc;
                    newRow["Probabilitatea_de_aparitie"] = introducereForm.ProbabilitateAparitie;
                    newRow["Natura_riscului"] = introducereForm.NaturaRisc;
                    newRow["Cod_Risc"] = introducereForm.CodRisc;
                    newRow["Data_Evaluare"] = introducereForm.Data;

                    // Adaugă rândul nou în DataTable-ul asociat DataGridView-ului
                    ((DataTable)dataGridView1.DataSource).Rows.Add(newRow);

                    // Inserează rândul nou în baza de date
                    using (OracleConnection connection = new DbConnect().GetConnection())
                    {
                        // Deschide conexiunea
                        connection.Open();

                        // Creează comanda SQL pentru inserarea rândului în tabela RISCURI
                        string insertQuery = "INSERT INTO RISCURI (Nume_Risc, Cod_Bun, Nivelul_riscului, " +
                            "Probabilitatea_de_aparitie, Natura_riscului, Cod_Risc, Data_Evaluare) VALUES (:numeRisc, :codBun, " +
                            ":nivelRisc, :probabilitateAparitie, :naturaRisc, :codRisc, :data)";

                        using (OracleCommand command = new OracleCommand(insertQuery, connection))
                        {
                            // Setează valorile parametrilor pentru inserare
                            command.Parameters.Add(":numeRisc", OracleDbType.Varchar2).Value = introducereForm.NumeRisc;
                            command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = introducereForm.CodBun;
                            command.Parameters.Add(":nivelRisc", OracleDbType.Decimal).Value = introducereForm.NivelRisc;
                            command.Parameters.Add(":probabilitateAparitie", OracleDbType.Decimal).Value = introducereForm.ProbabilitateAparitie;
                            command.Parameters.Add(":naturaRisc", OracleDbType.Varchar2).Value = introducereForm.NaturaRisc;
                            command.Parameters.Add(":codRisc", OracleDbType.Decimal).Value = introducereForm.CodRisc;
                            command.Parameters.Add(":data_Evaluare", OracleDbType.Date).Value = introducereForm.Data;

                            // Execută comanda SQL pentru inserarea rândului
                            int rowsInserted = command.ExecuteNonQuery();

                            // Verifică dacă inserarea a fost realizată cu succes
                            if (rowsInserted > 0)
                            {
                                MessageBox.Show("Datele au fost inserate cu succes în baza de date.");
                            }
                            else
                            {
                                MessageBox.Show("Eroare la inserarea datelor în baza de date.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la conectare: " + ex.Message);
                }
            }
        }


        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                // Obține tabelul asociat DataGridView-ului
                DataTable dataTable = (DataTable)dataGridView1.DataSource;

                // Actualizează datele din tabel în baza de date
                using (OracleConnection connection = new DbConnect().GetConnection())
                {
                    // Deschide conexiunea
                    connection.Open();

                    // Ciclează prin fiecare rând din tabel
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Converteste nivelul riscului în decimal, dacă este posibil
                        if (decimal.TryParse(row["Nivelul_riscului"].ToString(), out decimal nivelRiscDecimal))
                        {
                            // Creează comanda SQL pentru actualizarea rândului în tabela RISCURI
                            string updateQuery = "UPDATE RISCURI SET Nume_Risc = :numeRisc, Nivelul_riscului = :nivelRisc, " +
                                "Probabilitatea_de_aparitie = :probabilitateAparitie, Natura_riscului = :naturaRisc WHERE Cod_Risc = :codRisc";

                            using (OracleCommand command = new OracleCommand(updateQuery, connection))
                            {
                                // Adaugă parametrii pentru actualizare
                                command.Parameters.Add(":numeRisc", OracleDbType.Varchar2).Value = row["Nume_Risc"];
                                command.Parameters.Add(":nivelRisc", OracleDbType.Decimal).Value = nivelRiscDecimal;
                                command.Parameters.Add(":probabilitateAparitie", OracleDbType.Decimal).Value = decimal.Parse(row["Probabilitatea_de_aparitie"].ToString());
                                command.Parameters.Add(":naturaRisc", OracleDbType.Varchar2).Value = row["Natura_riscului"];
                                command.Parameters.Add(":codRisc", OracleDbType.Decimal).Value = row["Cod_Risc"];

                                // Execută comanda SQL pentru actualizarea rândului
                                int rowsUpdated = command.ExecuteNonQuery();

                                // Verifică dacă actualizarea a fost realizată cu succes
                                if (rowsUpdated > 0)
                                {
                                    MessageBox.Show("Datele au fost actualizate cu succes în baza de date.");
                                }
                                else
                                {
                                    MessageBox.Show("Eroare la actualizarea datelor în baza de date.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nivelul riscului trebuie să fie un număr valid.", "Eroare de validare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la conectare: " + ex.Message);
            }
        }





        private void Delete_Click(object sender, EventArgs e)
        {
            // Verifică dacă un rând este selectat în DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obține rândurile selectate
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Verifică dacă celula cu cheia primară este null
                if (selectedRow.Cells["Cod_Risc"].Value != null)
                {
                    // Obține valoarea cheii primare a rândului selectat
                    string codRisc = selectedRow.Cells["Cod_Risc"].Value.ToString();

                    // Șterge rândul selectat din DataGridView
                    dataGridView1.Rows.Remove(selectedRow);

                    // Șterge rândul selectat din baza de date
                    try
                    {
                        using (OracleConnection connection = new DbConnect().GetConnection())
                        {
                            // Deschide conexiunea
                            connection.Open();

                            // Creează comanda SQL pentru ștergerea rândului din tabela RISCURI
                            string deleteQuery = "DELETE FROM RISCURI WHERE Cod_Risc = :codRisc";
                            using (OracleCommand command = new OracleCommand(deleteQuery, connection))
                            {
                                // Setează valoarea parametrului pentru cheia primară a rândului de șters
                                command.Parameters.Add(":codRisc", OracleDbType.Decimal).Value = codRisc;

                                // Execută comanda SQL pentru ștergerea rândului
                                int rowsDeleted = command.ExecuteNonQuery();

                                // Verifică dacă ștergerea a fost realizată cu succes
                                if (rowsDeleted > 0)
                                {
                                    MessageBox.Show("Rândul a fost șters cu succes din baza de date.");
                                }
                                else
                                {
                                    MessageBox.Show("Eroare la ștergerea rândului din baza de date.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la conectare: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Eroare: Nu s-a putut identifica cheia primară a rândului selectat.");
                }
            }
            else
            {
                MessageBox.Show("Nu este selectat niciun rând pentru ștergere.");
            }
        }

        private void Export_Click(object sender, EventArgs e)
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

                try
                {
                    // Creează un StringBuilder pentru a construi conținutul CSV
                    StringBuilder csvContent = new StringBuilder();

                    // Adaugă antetele coloanelor în CSV
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        csvContent.Append(column.HeaderText + ",");
                    }
                    csvContent.AppendLine();

                    // Adaugă datele din fiecare rând în CSV
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            csvContent.Append(cell.Value + ",");
                        }
                        csvContent.AppendLine();
                    }

                    // Scrie conținutul CSV în fișierul selectat
                    File.WriteAllText(filePath, csvContent.ToString());

                    MessageBox.Show("Datele au fost exportate cu succes în format CSV.", "Export reușit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la exportul datelor: " + ex.Message, "Eroare export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_NumeRisc_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Bun_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Natura_riscului_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Nivelul_riscului_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Probabilitatea_de_aparitie_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void label_CodBun_Click(object sender, EventArgs e)
        {

        }

        private void textBox_CodBun_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Data_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            try
            {
                // Obține textul introdus în fiecare text box și valoarea selectată în combobox
                string numeRisc = textBox_NumeRisc.Text;
                string nivelRisc = textBox_Nivelul_riscului.Text;
                string naturaRisc = textBox_Natura_riscului.Text;
                string probabilitateAparitieText = textBox_Probabilitatea_de_aparitie.Text;
                string codBunText = textBox_CodBun.Text;
                string dataEvaluareText = textBox_Data.Text;

                // Construiește expresia de filtrare
                StringBuilder filterExpression = new StringBuilder();

                // Adaugă condiții pentru fiecare coloană, folosind operatori logici
                if (!string.IsNullOrEmpty(numeRisc))
                {
                    filterExpression.Append($"Nume_Risc LIKE '%{numeRisc}%' AND ");
                }

                // Verifică dacă nivelul riscului este un număr valid
                if (!string.IsNullOrEmpty(nivelRisc) && int.TryParse(nivelRisc, out int nivelRiscInt))
                {
                    filterExpression.Append($"Nivelul_riscului >= {nivelRiscInt} AND ");
                }

                if (!string.IsNullOrEmpty(naturaRisc))
                {
                    filterExpression.Append($"Natura_riscului = '{naturaRisc}' AND ");
                }

                // Verifică dacă probabilitatea de apariție este un număr valid
                if (!string.IsNullOrEmpty(probabilitateAparitieText))
                {
                    // Înlocuiește virgula cu punctul pentru a asigura recunoașterea corectă a valorii numerice
                    probabilitateAparitieText = probabilitateAparitieText.Replace(',', '.');

                    // Adaugă probabilitatea de apariție în expresia de filtrare
                    filterExpression.Append($"Probabilitatea_de_aparitie <= {probabilitateAparitieText} AND ");
                }

                // Verifică dacă codBunText este un număr decimal valid sau este gol
                if (!string.IsNullOrEmpty(codBunText))
                {
                    if (decimal.TryParse(codBunText, out decimal codBun))
                    {
                        filterExpression.Append($"Cod_Bun = {codBun} AND ");
                    }
                    else
                    {
                        MessageBox.Show("Codul bunului trebuie să fie un număr decimal valid.", "Eroare de validare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Întrerupe metoda dacă codul bunului nu este un număr decimal valid
                    }
                }

                // Verifică dacă dataEvaluareText este în format de dată valid
                if (!string.IsNullOrEmpty(dataEvaluareText))
                {
                    if (DateTime.TryParseExact(dataEvaluareText, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataEvaluare))
                    {
                        filterExpression.Append($"Data_Evaluare = #{dataEvaluare.ToShortDateString()}# AND ");
                    }
                    else
                    {
                        MessageBox.Show("Data evaluării trebuie să fie în formatul 'yyyy-MM-dd'.", "Eroare de validare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Întrerupe metoda dacă data evaluării nu este într-un format de dată valid
                    }
                }

                // Elimină ultimul "AND" din expresia de filtrare
                if (filterExpression.Length > 0)
                {
                    filterExpression.Length -= 5;
                }

                // Aplică filtrul asupra datelor din DataGridView
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = filterExpression.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la filtrare: " + ex.Message);
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            VulnerabilitatiGrafic vulnerabilitatiGraficForm = new VulnerabilitatiGrafic(this.dataGridView1);
            vulnerabilitatiGraficForm.ShowDialog();
        }

      
    }
}
