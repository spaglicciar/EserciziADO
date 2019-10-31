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

        public static int DeletePersona(Lavoratore l)
        {
            int result = 0;

            string deleteQuery =
                "Delete from Lavoratori " +
                "WHERE ID = @Persona_ID";

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = deleteQuery
            };

            cmd.Parameters.AddWithValue("@Persona_ID", l.Persona_ID);

            cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

        public static void SvuotaTabella(string tabella)
        {
            string deleteQuery =
                string.Format("Delete from {0}", tabella);

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = deleteQuery
            };

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static int UpdatePersona(Lavoratore l)
        {
            int result = 0;

            string updateQuery = 
                "UPDATE Lavoratori SET " +
                "Nome = @Nome, " +
                "Cognome = @Cognome, " +
                "DataDiNascita = @DataDiNascita, " +
                "Retribuzione = @Retribuzione, " +
                "DataDiAssunzione = @DataDiAssunzione, " +
                "Tipo = @Tipo " +
                "WHERE ID = @Persona_ID";

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = updateQuery
            };

            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNascita;
            cmd.Parameters.Add("@Retribuzione", SqlDbType.Float).Value = l.Retribuzione;
            cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = l.DataDiAssunzione;
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = l.Tipo;

            cmd.Parameters.AddWithValue("@Persona_ID", l.Persona_ID);

            cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

        public static void InsertPersona(Lavoratore l)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),

                CommandType = CommandType.Text,

                CommandText = "INSERT INTO Lavoratori" +
                "(ID, Nome, Cognome, DataDiNascita, Retribuzione, DataDiAssunzione, Tipo) " +
                "VALUES" +
                "(@ID, @Nome, @Cognome, @DataDiNascita, @Retribuzione, @DataDiAssunzione, @Tipo)"
            };

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = l.Persona_ID;
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNascita;
            cmd.Parameters.Add("@Retribuzione", SqlDbType.Float).Value = l.Retribuzione;
            cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = l.DataDiAssunzione;
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = l.Tipo;

            cmd.Connection.Open();

            int result = cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            Console.WriteLine("{0} rows affected!", result);
        }

        public static DataSet GetPersone()
        {
            DataSet result = new DataSet();

            string selectQuery = "SELECT ID, Nome, Cognome, DataDiNascita," +
                "Retribuzione, DataDiAssunzione, Tipo FROM Lavoratori";

            SqlCommand cmd = new SqlCommand(selectQuery, GetConnection());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);

            return result;
        }
    }
}
