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
            MySession.Current.Login = Request.QueryString["login"];
            MySession.Current.Email = Request.QueryString["email"];

            if (!ResetPassSys.CheckStatus(MySession.Current.Login, MySession.Current.Email))
                Response.Redirect("~/Pages/MainPages/InvalidPage");


            LabelInfo.Text = "Change password for " + MySession.Current.Login;
        }
      
        protected void BtnOk_Click(object sender, EventArgs e)
        {
            string result = ResetPassSys.PasswordValidation(TBNewPass.Text, TBConfirmNewPass.Text);

            if (result.Equals("OK"))
            {
                ResetPassSys.ResetPassword(TBNewPass.Text, MySession.Current.Login);
                Response.Redirect("Default.aspx");
            }
            else
            {
                LabelCriteria.Text = result;
            }

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CancelationPasswordPage.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (TBNewPass.Text.Count() >= 1)
            {
                if (TBNewPass.Text.Length == TBConfirmNewPass.Text.Length)
                {
                    BtnOk.Enabled = true;
                }
                else
                    BtnOk.Enabled = false;
            }
        }
    }
}