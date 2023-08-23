using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;

namespace MyBank.Admin
{
    public class UserLogic
    {
        static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public static int addCustomer(string name, string age,string gender,string email,string password,string address,string branchid)
        {
            connection.Open();
            string date = DateTime.Now.ToString();

            string query = "INSERT INTO Customer(name,age,gender,email,password,address,branchid,balance,openOn,status,maxAmount,minAmount)"+
                $"VALUES ('{name}','{age}','{gender}','{email}','{password}','{address}','{branchid}','0','{date}','active','10000','1000')";
            SqlCommand cmd = new SqlCommand(query,connection);
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }

        public static bool checkCustomer(string email)
        {
            connection.Open();
            string query = $"SELECT * FROM Customer WHERE email='{email}'";
            SqlDataReader dr = new SqlCommand(query, connection).ExecuteReader();
            if (dr.Read())
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
    }
}