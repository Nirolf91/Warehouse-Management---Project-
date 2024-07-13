using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Risk_Management
{
    public partial class IdentificareVulnerabilitati : Form
    {
        public IdentificareVulnerabilitati()
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

                    // Creează comanda SQL pentru a selecta datele necesare din tabelele VULNERABILITATI și BUNURI
                    string selectQuery = @"
                SELECT b.Nume_Bun AS Bunuri, v.*
                FROM VULNERABILITATI v
                JOIN BUNURI b ON v.Cod_Bun = b.Cod_Bun
            ";

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
            // Acest eveniment nu va mai fi utilizat, deoarece nu mai este necesar să faci clic pe celule pentru a afișa datele
        }

        private void IdentificareVulnerabilitati_Load(object sender, EventArgs e)
        {
            // Umple DataGridView-ul cu date în momentul încărcării formularului
            FillDataGridView();
        }


        private void Insert_Click(object sender, EventArgs e)
        {
            // Deschide formularul de introducere a unui nou rând
            IntroducereRandVulnerabilitati introducereForm = new IntroducereRandVulnerabilitati();

            // Verifică dacă utilizatorul a apăsat pe Ok în formularul de introducere
            if (introducereForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Creează un nou rând în DataTable-ul asociat DataGridView-ului
                    DataTable dataTable = (DataTable)dataGridView1.DataSource;
                    DataRow newRow = dataTable.NewRow();

                    // Populează rândul nou cu datele introduse în formular
                    newRow["Cod_Bun"] = introducereForm.CodBun;
                    newRow["Vulnerabilitate"] = introducereForm.Vulnerabilitate;
                    newRow["Nivel"] = introducereForm.Nivel;

                    // Adaugă rândul nou în DataTable-ul asociat DataGridView-ului
                    dataTable.Rows.Add(newRow);

                    // Inserează rândul nou în baza de date
                    using (OracleConnection connection = new DbConnect().GetConnection())
                    {
                        // Deschide conexiunea
                        connection.Open();

                        // Creează comanda SQL pentru inserarea unui nou rând în tabela VULNERABILITATI
                        string insertQuery = "INSERT INTO VULNERABILITATI (Cod_Bun, Vulnerabilitate, Nivel) VALUES (:codBun, :vulnerabilitate, :nivel)";
                        using (OracleCommand command = new OracleCommand(insertQuery, connection))
                        {
                            // Setează valorile parametrilor pentru noul rând
                            command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = newRow["Cod_Bun"];
                            command.Parameters.Add(":vulnerabilitate", OracleDbType.Varchar2).Value = newRow["Vulnerabilitate"];
                            command.Parameters.Add(":nivel", OracleDbType.Varchar2).Value = newRow["Nivel"];

                            // Execută comanda SQL pentru inserarea rândului nou
                            int rowsInserted = command.ExecuteNonQuery();

                            // Verifică dacă inserarea a fost realizată cu succes
                            if (rowsInserted > 0)
                            {
                                MessageBox.Show("Rândul a fost adăugat cu succes în baza de date.");
                            }
                            else
                            {
                                MessageBox.Show("Eroare la adăugarea rândului în baza de date.");
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
                        if (row.RowState == DataRowState.Modified)
                        {
                            // Creează comanda SQL pentru actualizarea rândului în tabela VULNERABILITATI
                            string updateQuery = "UPDATE VULNERABILITATI SET Vulnerabilitate = :vulnerabilitate, Nivel = :nivel WHERE Cod_Bun = :codBun";

                            using (OracleCommand command = new OracleCommand(updateQuery, connection))
                            {
                                // Setează valorile parametrilor pentru actualizare
                                command.Parameters.Add(":vulnerabilitate", OracleDbType.Varchar2).Value = row["Vulnerabilitate"];
                                command.Parameters.Add(":nivel", OracleDbType.Varchar2).Value = row["Nivel"];
                                command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = row["Cod_Bun"];

                                // Execută comanda SQL pentru actualizarea rândului
                                int rowsUpdated = command.ExecuteNonQuery();

                                // Verifică dacă actualizarea a fost realizată cu succes
                                if (rowsUpdated <= 0)
                                {
                                    MessageBox.Show("Eroare la actualizarea datelor în baza de date.");
                                }
                            }
                        }
                    }

                    MessageBox.Show("Datele au fost actualizate cu succes în baza de date.");
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
                // Obține rândul selectat
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Verifică dacă celula cu cheia primară este null
                if (selectedRow.Cells["Cod_Bun"].Value != null)
                {
                    // Obține valoarea cheii primare a rândului selectat
                    string codBun = selectedRow.Cells["Cod_Bun"].Value.ToString();

                    // Șterge rândul selectat din DataGridView
                    dataGridView1.Rows.Remove(selectedRow);

                    // Șterge rândul selectat din baza de date
                    try
                    {
                        using (OracleConnection connection = new DbConnect().GetConnection())
                        {
                            // Deschide conexiunea
                            connection.Open();

                            // Creează comanda SQL pentru ștergerea rândului din tabela VULNERABILITATI
                            string deleteQuery = "DELETE FROM VULNERABILITATI WHERE Cod_Bun = :codBun";
                            using (OracleCommand command = new OracleCommand(deleteQuery, connection))
                            {
                                // Setează valoarea parametrului pentru cheia primară a rândului de șters
                                command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = codBun;

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

        private void comboBox_Nomenclator_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();

        }

        private void textBox_Vulnerabilitate_TextChanged(object sender, EventArgs e)
        {
            FilterData();

        }

        private void comboBox_Nivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();

        }

        private void textBox_Bun_TextChanged(object sender, EventArgs e)
        {
            FilterData();

        }

        private void FilterData()
        {
            try
            {
                // Obține valorile introduse în controalele de interfață utilizator
                string codBun = textBox_Bun.Text;
                string vulnerabilitate = textBox_Vulnerabilitate.Text;
                string nivel = comboBox_Nivel.SelectedItem?.ToString(); // Actualizare aici

                // Construiește expresia de filtrare
                StringBuilder filterExpression = new StringBuilder();

                // Adaugă condiții pentru fiecare coloană, folosind operatori logici
                if (!string.IsNullOrEmpty(codBun))
                {
                    filterExpression.Append($"Cod_Bun = {codBun} AND ");
                }

                if (!string.IsNullOrEmpty(vulnerabilitate))
                {
                    filterExpression.Append($"Vulnerabilitate LIKE '%{vulnerabilitate}%' AND ");
                }

                if (!string.IsNullOrEmpty(nivel))
                {
                    // Adaugăm ghilimele simple în jurul valorii pentru a asigura interpretarea corectă
                    filterExpression.Append($"Nivel = '{nivel}' AND "); // Actualizare aici
                }

                // Elimină ultimul "AND" din expresia de filtrare
                if (filterExpression.Length > 0)
                {
                    filterExpression.Length -= 5;
                }

                // Aplică filtrul asupra datelor din DataGridView
                dataGridView1.DataSource = FilterDataTable(filterExpression.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la filtrare: " + ex.Message);
            }
        }


        private DataTable FilterDataTable(string filterExpression)
        {
            DataTable dataTable = ((DataTable)dataGridView1.DataSource).Clone();
            DataRow[] filteredRows = ((DataTable)dataGridView1.DataSource).Select(filterExpression);
            foreach (DataRow row in filteredRows)
            {
                dataTable.ImportRow(row);
            }
            return dataTable;
        }


    }
}