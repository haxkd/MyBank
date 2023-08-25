using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using System.Net;
using System.Xml.Linq;
using System.Data;

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

        public static int addBranch(string name, string code,string address)
        {
            connection.Open();
            string query = $"INSERT INTO Branch(name,code,address) VALUES ('{name}','{code}','{address}') ";
            SqlCommand cmd = new SqlCommand(query, connection);
            var x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }

        public static DataTable GetBranches()
        {
            connection.Open();
            string query = $"SELECT * FROM Branch";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            connection.Close();
            return dt;
        }

        public static int addManager(string name, string branchid)
        {
            connection.Open();
            string query = $"INSERT INTO Manager(name,branchid) VALUES ('{name}','{branchid}') ";
            SqlCommand cmd = new SqlCommand(query, connection);
            var x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }
        public static DataTable GetManagers()
        {
            connection.Open();
            string query = $"SELECT * FROM Manager";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            connection.Close();
            return dt;
        }

        public static DataTable GetManager(string id)
        {
            connection.Open();
            string query = $"SELECT * FROM Manager WHERE id='{id}'";
            SqlDataAdapter dr = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            dr.Fill(table);
            connection.Close();
            return table;
        }

        public static void updateManager(string id,string name, string branchid)
        {
            connection.Open();
            string query = $"UPDATE Manager SET name='{name}',branchid='{branchid}' WHERE id='{id}'";
            SqlCommand cmd = new SqlCommand (query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }



    }
}