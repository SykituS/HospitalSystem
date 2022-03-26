using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ResetPassPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            string login = Session["username"].ToString();
            LabelInfo.Text = "Change password for " + login + " user";
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {

        }
    }
}