using MyBank.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace MyBank
{
    public class UserLogic
    {
        static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public static int addCustomer(string name, string age, string gender, string email, string password, string address, string branchid)
        {
            connection.Open();
            string date = DateTime.Now.ToString();
            string query = "INSERT INTO Customer(name,age,gender,email,password,address,branchid,balance,openOn,status,maxAmount,minAmount)" +
                $"VALUES ('{name}','{age}','{gender}','{email}','{password}','{address}','{branchid}','0','{date}','active','10000','1000')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }

       
        public static DataTable checkCustomer(string email)
        {
            connection.Open();
            string query = $"SELECT * FROM Customer WHERE email='{email}'";
            SqlDataAdapter dr = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            dr.Fill(table);
            connection.Close();
            return table;
        }

        public static DataTable getCutsomer(string id)
        {
            connection.Open();
            string query = $"SELECT * FROM Customer WHERE id='{id}'";
            SqlDataAdapter dr = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            dr.Fill(table);
            connection.Close();
            return table;
        }

        public static int depositeAmount(int Amount, int newAmount,string id) {
            connection.Open();
            string query = $"UPDATE Customer SET balance='{newAmount}' WHERE id='{id}';"
                + $"INSERT INTO transactions(amount,toAccount,remark) VALUES('{Amount}','{id}','deposite')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }

        public static int withdrawAmount(int Amount, int newAmount, string id)
        {
            connection.Open();
            string query = $"UPDATE Customer SET balance='{newAmount}' WHERE id='{id}';"
                + $"INSERT INTO transactions(amount,fromAccount,remark) VALUES('{Amount}','{id}','withdraw')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }

        public static int transferAmount(int Amount, int toAmount,int fromAmount,string toId, string fromId)
        {
            connection.Open();
            string query = 
                $"UPDATE Customer SET balance='{fromAmount}' WHERE id='{fromId}';"
                +$"UPDATE Customer SET balance='{toAmount}' WHERE id='{toId}';"
                + $"INSERT INTO transactions(amount,fromAccount,toAccount,remark) VALUES('{Amount}',{fromId},'{toId}','transfer')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }


        public static DataTable getTransactions(string UserId)
        {
            DataTable tables = new DataTable();
            connection.Open();
            string query = $"SELECT * FROM transactions WHERE fromAccount='{UserId}' or toAccount='{UserId}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            sqlData.Fill(tables);
            connection.Close();


            DataTable table = new DataTable();

            table.Columns.AddRange(new DataColumn[6] {
                            new DataColumn("SrNo"),
                            new DataColumn("TId"),
                            new DataColumn("Remark"),
                            new DataColumn("Amount"),
                            new DataColumn("Date"),
                            new DataColumn("Info")
                        });


            DataRow row;
            int srno = 1;
            foreach (DataRow rows in tables.Rows)
            {
                string remark = rows["remark"].ToString();
                string remarks = rows["remark"].ToString();
                string info = "";
                string fromAccount = rows["fromAccount"].ToString();
                string toAccount = rows["toAccount"].ToString();

                if (fromAccount == UserId)
                {
                    info = "db";
                    if (remark == "transfer")
                    {
                        remarks = "transfer - " + toAccount;
                    }
                }
                else if (toAccount == UserId)
                {
                    info = "cr";
                    if (remark == "transfer")
                    {
                        remarks = "transfer - " + fromAccount;
                    }
                }
                row = table.NewRow();
                row["SrNo"] = srno;
                row["TId"] = rows["id"];
                row["Amount"] = rows["amount"];
                row["Date"] = rows["date"];
                row["Remark"] = remarks;
                row["Info"] = info;
                table.Rows.Add(row);
                srno++;
            }
            return table;
        }

    }
}