using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyBank.Admin;
using System.Reflection.Emit;

namespace MyBank.Manager
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ManagerId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                getCustomers();
            }
        }

        protected void getCustomers()
        {
            DataTable tables = ManagerLogic.getCustomersofManager(Session["ManagerId"].ToString());

            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] {
                            new DataColumn("SrNo"),
                            new DataColumn("id"),
                            new DataColumn("name"),
                            new DataColumn("status"),
                        });

            DataRow row;
            int srno = 1;
            foreach (DataRow rows in tables.Rows)
            {
                row = table.NewRow();
                row["SrNo"] = srno;
                row["id"] = rows["id"];
                row["name"] = rows["name"];
                row["status"] = rows["status"];
                table.Rows.Add(row);
                srno++;
            }
            customers.DataSource = table;
            customers.DataBind();
        }

        protected void customers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            customers.EditIndex = e.NewEditIndex;
            getCustomers();
            DropDownList statuses = (customers.Rows[e.NewEditIndex].FindControl("statuses") as DropDownList);
            statuses.Items.Insert(0, "--select status--");
            statuses.Items.Insert(1, "active");
            statuses.Items.Insert(2, "freeze");
            statuses.Items.Insert(3, "block");
            string id = customers.DataKeys[e.NewEditIndex].Values["id"].ToString();
            string status = UserLogic.getCutsomer(id).Rows[0]["status"].ToString();

            ListItem l = statuses.Items.FindByValue(status);
            if (l != null)
            {
                l.Selected = true;
            }
        }

        protected void customers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = customers.DataKeys[e.RowIndex].Values["id"].ToString();
            string status = (customers.Rows[e.RowIndex].FindControl("statuses") as DropDownList).SelectedValue;
            ManagerLogic.updateCutsomerStatus(id, status);
            customers.EditIndex = -1;
            getCustomers();
        }

        protected void customers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            customers.EditIndex = -1;
            getCustomers();
        }
    }
}