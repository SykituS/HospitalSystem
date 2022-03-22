using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administation;

namespace GUI
{
    public partial class FormToResetPassPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            ResetPassSys.SendMail(TBLogin.Text.Trim(), TBEmail.Text.Trim());
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
                Response.Redirect("Default.aspx");

        }
    }
}