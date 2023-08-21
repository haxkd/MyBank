using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MyBank.Admin
{
    public class AdminLogic
    {
       static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        public static bool checkAdmin(string email, string password)
        {
            connection.Open();
            string query = $"SELECT * FROM AdminLogin WHERE email='{email}' and password='{password}'";
            SqlCommand cmd = new SqlCommand(query,connection);
            SqlDataReader reader= cmd.ExecuteReader();
            if(reader.Read())
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
    }
}