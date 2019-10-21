using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziADO.Helpers
{
    public static class DbHelper
    {
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
                    connection = new SqlConnection(connectionString);
                }
                return connection;
            }
        }

        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }



    }
}
