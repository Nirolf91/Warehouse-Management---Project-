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
    public partial class IdentificareAmenintari : Form
    {
        public IdentificareAmenintari()
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

            // Creează comanda SQL pentru a selecta toate înregistrările din tabela AMENINTARI
            string selectQuery = "SELECT * FROM AMENINTARI";
            using (OracleCommand command = new OracleCommand(selectQuery, connection))
            {
                // Creează adaptorul de date și umple tabelul
                using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Setează coloanele explicit (opțional)
                    dataGridView1.Columns.Clear();
                    foreach (DataColumn column in table.Columns)
                    {
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = column.ColumnName,
                            DataPropertyName = column.ColumnName,
                            HeaderText = column.ColumnName
                        });
                    }

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
            try
            {
                // Creează o nouă instanță a formularului IntroducereRandAmenintari
                IntroducereRandAmenintari introducereRandForm = new IntroducereRandAmenintari();

                // Afișează formularul IntroducereRandAmenintari
                if (introducereRandForm.ShowDialog() == DialogResult.OK)
                {
                    // Preia datele introduse în formular
                    string amenintare = introducereRandForm.Amenintare;
                    decimal codBun = introducereRandForm.CodBun;
                    string nivelMinim = introducereRandForm.NivelMinim;
                    string nivelMaxim = introducereRandForm.NivelMaxim;

                    // Creează un nou rând în DataTable-ul asociat DataGridView-ului
                    DataRow newRow = ((DataTable)dataGridView1.DataSource).NewRow();

                    // Populează rândul nou cu datele preluate din formularul IntroducereRandAmenintari
                    newRow["Amenintare"] = amenintare;
                    newRow["Cod_Bun"] = codBun;
                    newRow["Nivel_minim"] = nivelMinim;
                    newRow["Nivel_maxim"] = nivelMaxim;

                    // Inserează rândul nou în baza de date
                    using (OracleConnection connection = new DbConnect().GetConnection())
                    {
                        // Deschide conexiunea
                        connection.Open();

                        // Creează comanda SQL pentru inserarea unui nou rând în tabela AMENINTARI
                        string insertQuery = "INSERT INTO AMENINTARI (Amenintare, Cod_Bun, Nivel_minim, Nivel_maxim) " +
                                             "VALUES (:amenintare, :codBun, :nivelMinim, :nivelMaxim)";

                        using (OracleCommand command = new OracleCommand(insertQuery, connection))
                        {
                            // Setează valorile parametrilor pentru noul rând
                            command.Parameters.Add(":amenintare", OracleDbType.Varchar2).Value = amenintare;
                            command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = codBun;
                            command.Parameters.Add(":nivelMinim", OracleDbType.Varchar2).Value = nivelMinim;
                            command.Parameters.Add(":nivelMaxim", OracleDbType.Varchar2).Value = nivelMaxim;

                            // Execută comanda SQL pentru inserarea rândului nou
                            int rowsInserted = command.ExecuteNonQuery();

                            // Verifică dacă inserarea a fost realizată cu succes
                            if (rowsInserted > 0)
                            {
                                // Adaugă rândul nou în DataTable-ul asociat DataGridView-ului
                                ((DataTable)dataGridView1.DataSource).Rows.Add(newRow);

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

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifică dacă un rând este selectat în DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obține rândul selectat
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Obține valorile din rândul selectat
                    string amenintare = selectedRow.Cells["Amenintare"].Value.ToString();
                    decimal codBun = Convert.ToDecimal(selectedRow.Cells["Cod_Bun"].Value);
                    string nivelMinim = selectedRow.Cells["Nivel_minim"].Value.ToString();
                    string nivelMaxim = selectedRow.Cells["Nivel_maxim"].Value.ToString();

                    // Actualizează înregistrarea corespunzătoare din baza de date
                    using (OracleConnection connection = new DbConnect().GetConnection())
                    {
                        // Deschide conexiunea
                        connection.Open();

                        // Creează comanda SQL pentru actualizarea înregistrării în tabela AMENINTARI
                        string updateQuery = "UPDATE AMENINTARI SET Amenintare = :amenintare, " +
                            "Nivel_minim = :nivelMinim, Nivel_maxim = :nivelMaxim WHERE Cod_Bun = :codBun";

                        using (OracleCommand command = new OracleCommand(updateQuery, connection))
                        {
                            // Setează valorile parametrilor pentru actualizare
                            command.Parameters.Add(":amenintare", OracleDbType.Varchar2).Value = amenintare;
                            command.Parameters.Add(":nivelMinim", OracleDbType.Varchar2).Value = nivelMinim;
                            command.Parameters.Add(":nivelMaxim", OracleDbType.Varchar2).Value = nivelMaxim;
                            command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = codBun;

                            // Execută comanda SQL pentru actualizare
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
                else
                {
                    MessageBox.Show("Nu este selectat niciun rând pentru actualizare.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la conectare: " + ex.Message);
            }
        }


        // Funcție pentru verificarea dacă valoarea pentru COD_BUN există în tabela Bunuri
        private bool CodBunExists(OracleConnection connection, decimal codBun)
        {
            try
            {
                // Creează comanda SQL pentru a verifica existența valorii pentru COD_BUN în tabela Bunuri
                string selectQuery = "SELECT COUNT(*) FROM Bunuri WHERE COD_BUN = :codBun";
                using (OracleCommand command = new OracleCommand(selectQuery, connection))
                {
                    command.Parameters.Add(":codBun", OracleDbType.Decimal).Value = codBun;
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la verificarea existenței valorii pentru COD_BUN în tabela Bunuri: " + ex.Message);
                return false;
            }
        }



        private void Delete_Click(object sender, EventArgs e)
        {
            // Verifică dacă un rând este selectat în DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obține rândul selectat
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Verifică dacă celula cu cheia primară este null sau DBNull
                if (selectedRow.Cells["Cod_Bun"].Value != null && selectedRow.Cells["Cod_Bun"].Value != DBNull.Value)
                {
                    // Obține valoarea cheii primare a rândului selectat
                    decimal codBun = Convert.ToDecimal(selectedRow.Cells["Cod_Bun"].Value);

                    // Șterge rândul selectat din DataGridView
                    dataGridView1.Rows.Remove(selectedRow);

                    // Șterge rândul selectat din baza de date
                    try
                    {
                        using (OracleConnection connection = new DbConnect().GetConnection())
                        {
                            // Deschide conexiunea
                            connection.Open();

                            // Creează comanda SQL pentru ștergerea rândului din tabela AMENINTARI
                            string deleteQuery = "DELETE FROM AMENINTARI WHERE Cod_Bun = :codBun";
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



        private void Edit_Click(object sender, EventArgs e)
        {

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
                     

        private void textBox_Nume_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }
      

        private void textBox_Nivel_minim_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBox_Nivel_maxim_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }



        private void textBox_Bunuri_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            try
            {
                // Obține textul introdus în fiecare text box și valoarea selectată în combobox
                string bunuri = textBox_Bunuri.Text;
                string nume = textBox_Nume.Text;
                string nivelMinim = textBox_Nivel_minim.Text;
                string nivelMaxim = textBox_Nivel_maxim.Text;

                // Construiește expresia de filtrare
                StringBuilder filterExpression = new StringBuilder();

              

                if (!string.IsNullOrEmpty(bunuri))
                {
                    filterExpression.Append($"Cod_Bun = {bunuri} AND ");
                }

                if (!string.IsNullOrEmpty(nume))
                {
                    filterExpression.Append($"AMENINTARE LIKE '%{nume}%' AND ");
                }

                if (!string.IsNullOrEmpty(nivelMinim))
                {
                    filterExpression.Append($"Nivel_minim >= {nivelMinim} AND ");
                }

                if (!string.IsNullOrEmpty(nivelMaxim))
                {
                    filterExpression.Append($"Nivel_maxim <= {nivelMaxim} AND ");
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

      
        private void label_Nume_amenintare_Click(object sender, EventArgs e)
        {

        }

        private void label_Bunuri_Click(object sender, EventArgs e)
        {

        }

        private void label_Nivel_minim_Click(object sender, EventArgs e)
        {

        }

        private void label_Nivel_maxim_Click(object sender, EventArgs e)
        {

        }

        private void IdentificareAmenintari_Load(object sender, EventArgs e)
        {

        }
    }
}
