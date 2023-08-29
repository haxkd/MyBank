using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBank
{
    public partial class Transactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }

            string UserId = Session["UserId"].ToString();

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
            foreach (DataRow rows in UserLogic.getTransactions(UserId).Rows)
            {
                

                string remark = rows["remark"].ToString();
                string remarks = rows["remark"].ToString();
                string info = "";
                string fromAccount = rows["fromAccount"].ToString();
                string toAccount = rows["toAccount"].ToString();

                if (fromAccount==UserId)
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

            transaction.DataSource = table;
            transaction.DataBind();

        }
    }
}