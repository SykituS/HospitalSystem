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
            LabelSendInfo.Visible = true;
            LabelSendInfo.Text = ResetPassSys.SendMail(TBLogin.Text, TBEmail.Text);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (TBEmail.Text.Contains("@"))
                BtnOk.Enabled = true;
            else
                BtnOk.Enabled = false;
        }

        
    }
}