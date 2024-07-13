using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Risk_Management
{
    internal class DbConnect
    {
        private string connectionString = "Data Source=localhost:1521/orcl;User Id=system;Password=Nirolf918;";

        public OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }

        public void TestConnection()
        {
            OracleConnection connection = GetConnection();
            try
            {
                connection.Open();
                Console.WriteLine("Conexiunea la baza de date Oracle a fost realizată cu succes!");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la conectare: " + ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }

        public decimal GetNextSequenceValue()
        {
            decimal nextValue = 0;
            try
            {
                using (OracleConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT identificareBunuri_seq.NEXTVAL FROM DUAL";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        nextValue = Convert.ToDecimal(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la obținerea valorii din secvență: " + ex.Message);
            }
            return nextValue;
        }

   
    }


}