using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Data_Access
{
    public class ConnectionManager
    {
        MySqlConnection connection;
        public MySqlConnection getConnection()
        {
            try
            {
                connection = new MySqlConnection(DBConstants.connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return connection;
        }
        public void closeConnection()
        {
            connection.Close();
        }

    }
}