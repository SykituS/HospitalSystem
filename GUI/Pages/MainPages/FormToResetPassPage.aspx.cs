using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;

namespace GUI
{
    public partial class FormToResetPassPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {

            if (!EmailSendingClass.IsValidEmail(TBEmail.Text))
                return;

            LabelSendInfo.Visible = true;
            ResetPassSys.SendMail(TBLogin.Text, TBEmail.Text);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void TBEmail_TextChanged(object sender, EventArgs e)
        {
            if (EmailSendingClass.IsValidEmail(TBEmail.Text))
                BtnOk.Enabled = true;
            else
                BtnOk.Enabled = false;
        }
    }
}