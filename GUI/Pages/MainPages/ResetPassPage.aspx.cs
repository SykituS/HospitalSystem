using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;

namespace GUI
{
    public partial class ResetPassPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string login = Request.QueryString["login"];
            string email = Request.QueryString["email"];

            if (ResetPassSys.CheckStatus(login, email))
                Response.Redirect("~/Pages/MainPages/InvalidPage");


            LabelInfo.Text = "Change password for " + login + " " + email;
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {

        }
    }
}