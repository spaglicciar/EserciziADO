using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziADO.Helpers
{
    public static class DbHelper
    {
        private static SqlConnection connection;

        private static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }

        private static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }

        public static DataSet GetPersone()
        {
            SqlCommand command = new SqlCommand("SELECT Persona_ID, Nome, Cognome, DataDiNascita FROM Persona", GetConnection());
            DataSet persone = new DataSet();

            SqlDataAdapter dataAdpater = new SqlDataAdapter(command);
            dataAdpater.Fill(persone);

            return persone;
        }

        public static void InsertPersona(Persona p)
        {
            SqlConnection conn = GetConnection();
            SqlCommand command = new SqlCommand(
                "INSERT INTO Persona (Persona_ID, Nome, Cognome, DataDiNascita) " +
                "VALUES (@Persona_ID, @Nome, @Cognome, @DataDiNascita)", conn);

            command.Parameters.Add("@Persona_ID", SqlDbType.UniqueIdentifier).Value = p.Persona_ID;
            command.Parameters.Add("@Nome", SqlDbType.VarChar, 255).Value = p.Nome;
            command.Parameters.Add("@Cognome", SqlDbType.VarChar, 255).Value = p.Cognome;
            command.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = p.DataDiNascita;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
