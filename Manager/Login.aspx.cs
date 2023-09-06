using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBank.Manager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string em = email.Value;
            string pass = password.Value;


            DataTable table = ManagerLogic.checkManager(em);
            if (table.Rows.Count != 0)
            {
                string password = table.Rows[0]["password"].ToString();
                if (password == pass)
                {
                    Session["ManagerId"] = table.Rows[0]["id"].ToString();
                    Response.Redirect("Dashboard.aspx") ;
                }
                else
                {
                    Response.Write("<script>alert('wrong password');</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('wrong email');</script>");
            }


        }
    }
}