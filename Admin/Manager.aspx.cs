using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBank.Admin
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showData();
            }
        }

        protected void managers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            managers.EditIndex = e.NewEditIndex;
            showData();
            string id = managers.DataKeys[e.NewEditIndex].Values["id"].ToString();
            DropDownList branches = (managers.Rows[e.NewEditIndex].FindControl("branches") as DropDownList);
            branches.DataSource = AdminLogic.GetBranches();
            branches.DataValueField = "id";
            branches.DataTextField = "name";
            branches.DataBind();
            branches.Items.Insert(0, "---select branch---");
            string branchId = AdminLogic.GetManager(id).Rows[0]["branchid"].ToString();
            branches.Items.FindByValue(branchId).Selected = true;
        }

        protected void managers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            

            string id = managers.DataKeys[e.RowIndex].Values["id"].ToString();
            string name = (managers.Rows[e.RowIndex].FindControl("txtname") as TextBox).Text;
            string branchid = (managers.Rows[e.RowIndex].FindControl("branches") as DropDownList).SelectedValue;

            if (AdminLogic.selectBranch(branchid).Rows.Count != 0)
            {
                Response.Write("<script>alert('branch already assigned....!')</script>");
                return;
            }

            AdminLogic.updateManager(id,name,branchid);
            managers.EditIndex = -1;
            showData();
        }

        void showData()
        {
            DataTable dataTable = AdminLogic.GetManagers();
            managers.DataSource = dataTable;
            managers.DataBind();
        }

        protected void managers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            managers.EditIndex = -1;
            showData();
        }
    }
}