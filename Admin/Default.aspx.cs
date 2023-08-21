using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBank.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["adminId"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}