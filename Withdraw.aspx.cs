using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBank
{
    public partial class Withdraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            if (Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {

            string id = Session["UserId"].ToString();
            int withdrawAmount = int.Parse(amount.Value);

            DataRow user = UserLogic.getCutsomer(id).Rows[0];

            int balance = int.Parse(user["balance"].ToString());
            int minAmount = int.Parse(user["minAmount"].ToString());
            int maxAmount = int.Parse(user["maxAmount"].ToString());

            if ((balance - withdrawAmount) < minAmount)
            {
                Response.Write("<script>alert('insufficient balance....!')</script>");
                return;
            }

            if (withdrawAmount>maxAmount)
            {
                Response.Write($"<script>alert('yout maximum withdraw limit is {maxAmount} ....!')</script>");
                return;
            }


            int newAmount = balance- withdrawAmount;

            int x = UserLogic.withdrawAmount(withdrawAmount, newAmount, id);
            if (x > -1)
            {
                Response.Write("<script>alert('amount withdraw successfully....!')</script>");
            }
            else
            {
                Response.Write("<script>alert('amount withdraw failed....!')</script>");
            }
        }
    }
}