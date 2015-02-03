using MySql.Data.MySqlClient;
using SciFusion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Data_Access
{
    public class DBUtility
    {
        bool isLoginValid = false;


        public UserLogin AuthenticateLogin(String username, String password)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.IsLoginValid = false;

            MySqlConnection connection = new MySqlConnection(DBConstants.connectionString);
            connection.Open();
            var count = "0";

            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "select researcher_researcherid from login where username = '" + username + "' and password = '" + password + "'";
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                userLogin.ResearcherId = reader2.GetInt32(0);
            }
            reader2.Close();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select count(*) from login where username = '" + username + "' and password = '" + password + "'";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                count = reader.GetString(0);
            }

            if (count == "1")
            {
                isLoginValid = true;
            }
            userLogin.IsLoginValid = isLoginValid;
            reader.Close();

            return userLogin;
        }
    }
}