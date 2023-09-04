using MyBank;
using MyBank.MyMail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MyBank
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            var em = email.Value;
            var ps = password.Value;
            DataTable table = UserLogic.checkCustomer(em);
            string userIpAddress = Request.UserHostAddress;

            if (table.Rows.Count != 0)
            {
                string userid = table.Rows[0]["id"].ToString();
                string pass = table.Rows[0]["password"].ToString();
                if (pass == ps)
                {
                    new SendMails().loginMail(em, userIpAddress, "success");
                    UserLogic.addloginRecord(userid, "success", userIpAddress);
                    Session["UserId"] = userid;
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    UserLogic.addloginRecord(userid, "failed", userIpAddress);
                    new SendMails().loginMail(em, userIpAddress, "failed");
                    Response.Write("<script>alert('Invalid Password....!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Email....!')</script>");
            }
        }
    }
}