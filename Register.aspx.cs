﻿using MyBank;
using MyBank.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBank.MyMail;
namespace MyBank
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                DataTable dataTable = AdminLogic.GetBranches();
                branches.DataSource = dataTable;
                branches.DataValueField = "id";
                branches.DataTextField = "name";
                branches.DataBind();
                branches.Items.Insert(0, "---select branch---");
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            var nm = name.Value;
            var ag = age.Value;
            var gn = gender.Value;
            var em = email.Value;
            var ps = password.Value;
            var ad = address.Value;
            var branch = branches.SelectedValue;
            if (UserLogic.checkCustomer(em).Rows.Count!=0)
            {
                Response.Write("<script>alert('customer already exist....!')</script>");
                return;
            }
            int userid = UserLogic.addCustomer(nm, ag, gn, em, ps, ad, branch);
            DataRow row = AdminLogic.getBranch(branch).Rows[0];
            string branchData = $"{ row["code"]} | {row["name"]} | {row["address"]}";
            new SendMails().registerMail(userid.ToString(), nm, gn, em, ad, branchData);
            Response.Write("<script>alert('customer registeration successfully....!')</script>");          
        }
    }
}
