using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Risk_Management
{
    public partial class IdentificareBunuri : Form
    {
        public IdentificareBunuri()
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

                    // Creează comanda SQL pentru a selecta toate înregistrările din tabelul BUNURI
                    string selectQuery = "SELECT * FROM BUNURI";
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
                Console.WriteLine("Eroare la conectare: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Acest eveniment nu va mai fi utilizat, deoarece nu mai este necesar să faci clic pe celule pentru a afișa datele
        }

        private void IdentificareBunuri_Load(object sender, EventArgs e) {
            // Umple DataGridView-ul cu date în momentul încărcării formularului
            FillDataGridView();
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
                            // Creează comanda SQL pentru actualizarea rândului în tabelul BUNURI
                            string updateQuery = "UPDATE BUNURI SET NUME_BUN = :numeBun, COD_PROIECT = :codProiect, " +
                                "IMPACT_MINIM = :impactMinim, IMPACT_MAXIM = :impactMaxim, DOMENIU_CATEGORIE = :domeniuCategorie, " +
                                "COST = :cost, COST_DE_REDUCERE = :costDeReducere WHERE COD_BUN = :codBun";

                            using (OracleCommand command = new OracleCommand(updateQuery, connection))
                            {
                                // Setează valorile parametrilor pentru actualizare
                                command.Parameters.Add(":numeBun", OracleDbType.Varchar2).Value = row["NUME_BUN"];
                                command.Parameters.Add(":codProiect", OracleDbType.Decimal).Value = row["COD_PROIECT"];
                                command.Parameters.Add(":impactMinim", OracleDbType.Decimal).Value = row["IMPACT_MINIM"];
                                command.Parameters.Add(":impactMaxim", OracleDbType.Decimal).Value = row["IMPACT_MAXIM"];
                                command.Parameters.Add(":domeniuCategorie", OracleDbType.Varchar2).Value = row["DOMENIU_CATEGORIE"];
                                command.Parameters.Add(":cost", OracleDbType.Decimal).Value = row["COST"];
                                command.Parameters.Add(":costDeReducere", OracleDbType.Decimal).Value = row["COST_DE_REDUCERE"];
                                command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = row["COD_BUN"];

                                // Execută comanda SQL pentru actualizarea rândului
                                int rowsUpdated = command.ExecuteNonQuery();

                                // Verifică dacă actualizarea a fost realizată cu succes
                                if (rowsUpdated > 0)
                                {
                                    Console.WriteLine("Rândul a fost actualizat cu succes.");
                                }
                                else
                                {
                                    Console.WriteLine("Eroare la actualizarea rândului.");
                                }
                            }
                        }
                    }

                    // Confirmă modificările
                    using (OracleCommand commitCommand = new OracleCommand("COMMIT", connection))
                    {
                        commitCommand.ExecuteNonQuery();
                    }
                }

                // Reîmprospătează DataGridView-ul
                FillDataGridView();

                MessageBox.Show("Datele au fost actualizate cu succes în baza de date.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la actualizarea datelor în baza de date: " + ex.Message);
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
                if (selectedRow.Cells["COD_BUN"].Value != null)
                {
                    // Obține valoarea cheii primare a rândului selectat
                    string codBun = selectedRow.Cells["COD_BUN"].Value.ToString();

                    // Șterge rândul selectat din DataGridView
                    dataGridView1.Rows.Remove(selectedRow);

                    // Șterge rândul selectat din baza de date
                    try
                    {
                        using (OracleConnection connection = new DbConnect().GetConnection())
                        {
                            // Deschide conexiunea
                            connection.Open();

                            // Creează comanda SQL pentru ștergerea rândului din tabelul BUNURI
                            string deleteQuery = "DELETE FROM BUNURI WHERE COD_BUN = :codBun";
                            using (OracleCommand command = new OracleCommand(deleteQuery, connection))
                            {
                                // Setează valoarea parametrului pentru cheia primară a rândului de șters
                                command.Parameters.Add(":codBun", OracleDbType.Varchar2).Value = codBun;

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

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                // Eliminați codul pentru a obține valoarea secvenței în C#
                // decimal codBun = new DbConnect().GetNextSequenceValue();

                // Creează o nouă instanță a formularului Introducere__Rand
                Introducere_Rand introducereRandForm = new Introducere_Rand();

                // Afișează formularul Introducere__Rand fără să trimiteți valoarea codBun
                if (introducereRandForm.ShowDialog() == DialogResult.OK)
                {
                    // Preia datele introduse în formular
                    string numeBun = introducereRandForm.NumeBun;
                    decimal codProiect = introducereRandForm.CodProiect;
                    decimal impactMinim = introducereRandForm.ImpactMinim;
                    decimal impactMaxim = introducereRandForm.ImpactMaxim;
                    string domeniuCategorie = introducereRandForm.DomeniuCategorie;
                    decimal cost = introducereRandForm.Cost;
                    decimal costDeReducere = introducereRandForm.CostDeReducere;

                    // Creează un nou rând în DataTable-ul asociat DataGridView-ului
                    DataRow newRow = ((DataTable)dataGridView1.DataSource).NewRow();

                    // Populează rândul nou cu datele preluate din formularul Introducere__Rand
                    newRow["NUME_BUN"] = numeBun;
                    newRow["COD_PROIECT"] = codProiect;
                    newRow["IMPACT_MINIM"] = impactMinim;
                    newRow["IMPACT_MAXIM"] = impactMaxim;
                    newRow["DOMENIU_CATEGORIE"] = domeniuCategorie;
                    newRow["COST"] = cost;
                    newRow["COST_DE_REDUCERE"] = costDeReducere;

                    // Inserează rândul nou în baza de date
                    using (OracleConnection connection = new DbConnect().GetConnection())
                    {
                        // Deschide conexiunea
                        connection.Open();

                        // Creează comanda SQL pentru inserarea unui nou rând în tabelul BUNURI
                        string insertQuery = "INSERT INTO BUNURI (NUME_BUN, COD_PROIECT, IMPACT_MINIM, IMPACT_MAXIM, DOMENIU_CATEGORIE, COST, COST_DE_REDUCERE) " +
                            "VALUES (:numeBun, :codProiect, :impactMinim, :impactMaxim, :domeniuCategorie, :cost, :costDeReducere)";

                        using (OracleCommand command = new OracleCommand(insertQuery, connection))
                        {
                            // Setează valorile parametrilor pentru noul rând
                            command.Parameters.Add(":numeBun", OracleDbType.Varchar2).Value = numeBun;
                            command.Parameters.Add(":codProiect", OracleDbType.Decimal).Value = codProiect;
                            command.Parameters.Add(":impactMinim", OracleDbType.Decimal).Value = impactMinim;
                            command.Parameters.Add(":impactMaxim", OracleDbType.Decimal).Value = impactMaxim;
                            command.Parameters.Add(":domeniuCategorie", OracleDbType.Varchar2).Value = domeniuCategorie;
                            command.Parameters.Add(":cost", OracleDbType.Decimal).Value = cost;
                            command.Parameters.Add(":costDeReducere", OracleDbType.Decimal).Value = costDeReducere;

                            // Execută comanda SQL pentru inserarea rândului nou
                            int rowsInserted = command.ExecuteNonQuery();

                            // Verifică dacă inserarea a fost realizată cu succes
                            if (rowsInserted > 0)
                            {
                                // Reîmprospătează DataGridView pentru a reflecta noul rând inserat
                                FillDataGridView();

                                MessageBox.Show("Rândul a fost adăugat cu succes în baza de date.");
                            }
                            else
                            {
                                MessageBox.Show("Eroare la adăugarea rândului în baza de date.");
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



        private void Edit_Click(object sender, EventArgs e)
        {
            // Verifică dacă un rând este selectat în DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obține rândul selectat
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Afișează un formular de editare cu datele rândului selectat
                // În acest formular, utilizatorul poate edita valorile câmpurilor
                // După editare, salvează datele actualizate în baza de date
                // sau actualizează direct valorile în DataGridView și salvează automat în baza de date
                // în funcție de preferințele tale de implementare
                // De asemenea, asigură-te că tipurile de date ale valorilor editate sunt corecte
            }
            else
            {
                MessageBox.Show("Selectează un rând pentru a-l edita.");
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


        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Schimbă culoarea textului la negru în timpul editării
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Resetează culoarea textului la culoarea implicită după editare
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }


        private void textBox_Nume_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Impact_minim_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void comboBox_Domeniu_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Impact_maxim_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Cost_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Cost_de_reducere_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            try
            {
                // Obține textul introdus în fiecare text box și valoarea selectată în combobox
                string numeBun = textBox_Nume.Text;
                string impactMinim = textBox_Impact_minim.Text;
                string domeniuCategorie = comboBox_Domeniu.SelectedItem?.ToString();
                string impactMaxim = textBox_Impact_maxim.Text;
                string cost = textBox_Cost.Text;
                string costDeReducere = textBox_Cost_de_reducere.Text;

                // Construiește expresia de filtrare
                StringBuilder filterExpression = new StringBuilder();

                // Adaugă condiții pentru fiecare coloană, folosind operatori logici
                if (!string.IsNullOrEmpty(numeBun))
                {
                    filterExpression.Append($"NUME_BUN LIKE '%{numeBun}%' AND ");
                }

                if (!string.IsNullOrEmpty(impactMinim))
                {
                    filterExpression.Append($"IMPACT_MINIM >= {impactMinim} AND ");
                }

                if (!string.IsNullOrEmpty(domeniuCategorie))
                {
                    filterExpression.Append($"DOMENIU_CATEGORIE = '{domeniuCategorie}' AND ");
                }

                if (!string.IsNullOrEmpty(impactMaxim))
                {
                    filterExpression.Append($"IMPACT_MAXIM <= {impactMaxim} AND ");
                }

                if (!string.IsNullOrEmpty(cost))
                {
                    filterExpression.Append($"COST <= {cost} AND ");
                }

                if (!string.IsNullOrEmpty(costDeReducere))
                {
                    filterExpression.Append($"COST_DE_REDUCERE <= {costDeReducere} AND ");
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

        private void panel_button_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label_Nume_Click(object sender, EventArgs e)
        {

        }

        private void label_Impact_minim_Click(object sender, EventArgs e)
        {

        }

        private void label_Impact_maxim_Click(object sender, EventArgs e)
        {

        }

        private void label_Domeniu_Click(object sender, EventArgs e)
        {

        }

        private void label_Cost_Click(object sender, EventArgs e)
        {

        }

        private void label_Cost_de_reducere_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}