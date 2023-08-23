using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBank.Admin
{
    public partial class Branch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getBranches();
            }
        }

        public void getBranches()
        {
            DataTable tbl = AdminLogic.GetBranches();
            branches.DataSource = tbl;
            branches.DataBind();
        }
    }
}