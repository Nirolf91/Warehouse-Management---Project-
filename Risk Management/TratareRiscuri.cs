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
    public partial class TratareRiscuri : Form
    {
        public TratareRiscuri()
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

                    // Creează comanda SQL pentru a selecta toate înregistrările din tabela CONTRAMASURI
                    string selectQuery = "SELECT * FROM CONTRAMASURI";
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
            // Deschide formularul pentru introducerea unui nou rând
            using (IntroducereRandTratare form = new IntroducereRandTratare())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Creează un nou rând în DataTable-ul asociat DataGridView-ului
                        DataRow newRow = ((DataTable)dataGridView1.DataSource).NewRow();

                        // Populează rândul nou cu datele introduse de utilizator
                        newRow["Cod_Risc"] = form.CodRisc;
                        newRow["Metoda_de_tratare"] = form.MetodaTratare;
                        newRow["Categorie_contramasuri"] = form.CategorieContramasuri;
                        newRow["Tratat"] = form.Tratat;

                        // Adaugă rândul nou în DataTable-ul asociat DataGridView-ului
                        ((DataTable)dataGridView1.DataSource).Rows.Add(newRow);

                        // Inserează rândul nou în baza de date
                        using (OracleConnection connection = new DbConnect().GetConnection())
                        {
                            // Deschide conexiunea
                            connection.Open();

                            // Creează comanda SQL pentru inserarea unui nou rând în tabela CONTRAMASURI
                            string insertQuery = "INSERT INTO CONTRAMASURI (Cod_Risc, Metoda_de_tratare, Categorie_contramasuri, Tratat) VALUES (:codRisc, :metodaTratare, :categorieContramasuri, :tratat)";
                            using (OracleCommand command = new OracleCommand(insertQuery, connection))
                            {
                                // Setează valorile parametrilor pentru noul rând
                                command.Parameters.Add(":codRisc", OracleDbType.Decimal).Value = newRow["Cod_Risc"];
                                command.Parameters.Add(":metodaTratare", OracleDbType.Varchar2).Value = newRow["Metoda_de_tratare"];
                                command.Parameters.Add(":categorieContramasuri", OracleDbType.Varchar2).Value = newRow["Categorie_contramasuri"];
                                command.Parameters.Add(":tratat", OracleDbType.Varchar2).Value = newRow["Tratat"];

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
        }


        private new void Update_Click(object sender, EventArgs e)
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
                        // Creează comanda SQL pentru actualizarea rândului în tabela CONTRAMASURI
                        string updateQuery = "UPDATE CONTRAMASURI SET Metoda_de_tratare = :metodaTratare, " +
                            "Categorie_contramasuri = :categorieContramasuri, Tratat = :tratat WHERE Cod_Risc = :codRisc";

                        using (OracleCommand command = new OracleCommand(updateQuery, connection))
                        {
                            // Setează valorile parametrilor pentru actualizare
                            command.Parameters.Add(":metodaTratare", OracleDbType.Varchar2).Value = row["Metoda_de_tratare"];
                            command.Parameters.Add(":categorieContramasuri", OracleDbType.Varchar2).Value = row["Categorie_contramasuri"];
                            command.Parameters.Add(":tratat", OracleDbType.Varchar2).Value = row["Tratat"];
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

                            // Creează comanda SQL pentru ștergerea rândului din tabela CONTRAMASURI
                            string deleteQuery = "DELETE FROM CONTRAMASURI WHERE Cod_Risc = :codRisc";
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

        private void textBox_Nume_risc_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Tratat_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_MetodeTratare_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_CategorieContramasuri_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_CodRisc_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            try
            {
                // Obține textul introdus în fiecare text box
                string metodaTratare = textBox_MetodeTratare.Text;
                string categorieContramasuri = textBox_CategorieContramasuri.Text;
                string tratat = textBox_Tratat.Text;
                string codRiscText = textBox_CodRisc.Text;

                // Construiește expresia de filtrare
                StringBuilder filterExpression = new StringBuilder();

                // Adaugă condiții pentru fiecare coloană, folosind operatori logici
                if (!string.IsNullOrEmpty(metodaTratare))
                {
                    filterExpression.Append($"Metoda_de_tratare LIKE '%{metodaTratare}%' AND ");
                }

                if (!string.IsNullOrEmpty(categorieContramasuri))
                {
                    filterExpression.Append($"Categorie_contramasuri LIKE '%{categorieContramasuri}%' AND ");
                }

                if (!string.IsNullOrEmpty(tratat))
                {
                    filterExpression.Append($"Tratat = '{tratat}' AND ");
                }

                if (!string.IsNullOrEmpty(codRiscText))
                {
                    if (int.TryParse(codRiscText, out int codRisc))
                    {
                        filterExpression.Append($"Cod_Risc = {codRisc} AND ");
                    }
                    else
                    {
                        MessageBox.Show("Valoarea introdusă pentru Cod Risc nu este validă. Vă rugăm să introduceți un număr.");
                        return;
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

        private void TratareRiscuri_Load(object sender, EventArgs e)
        {

        }
    }
}




