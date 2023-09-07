using MyBank.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyBank.Manager
{
    public class ManagerLogic
    {
        static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public static DataTable checkManager(string email)
        {
            connection.Open();
            string query = $"SELECT * FROM Manager WHERE email='{email}'";
            SqlDataAdapter dr = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            dr.Fill(table);
            connection.Close();
            return table;
        }

        public static DataTable getCustomersofManager(string ManagerId)
        {
            string query = $"select Customer.id as id, Customer.name as name, status from Customer join Manager on Manager.branchid=Customer.branchid where Manager.id='{ManagerId}'";
            connection.Open();
            SqlDataAdapter dr = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            dr.Fill(table);
            connection.Close();
            return table;
        }

        public static void updateCutsomerStatus(string id,string status)
        {
            if(status== "--select status--")
            {
                return;
            }
            string query = $"UPDATE Customer SET status='{status}' WHERE id='{id}'";
            connection.Open();
            new SqlCommand(query,connection).ExecuteNonQuery();
            connection.Close();
        }

    }
}