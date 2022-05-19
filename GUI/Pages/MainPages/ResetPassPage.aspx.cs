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
            //Geting login and email from URL
            MySession.Current.Login = Request.QueryString["login"]; 
            MySession.Current.Email = Request.QueryString["email"];

            //Checking if user should be on this page
            if (!ResetPassSys.CheckStatus(MySession.Current.Login, MySession.Current.Email))
                Response.Redirect("~/Pages/MainPages/InvalidPage");

            //Showing information for what user is password changing
            LabelInfo.Text = "Change password for " + MySession.Current.Login;
        }
      
        protected void BtnOk_Click(object sender, EventArgs e)
        {

            //Getting result of validation
            string result = ResetPassSys.PasswordValidation(TBNewPass.Text, TBConfirmNewPass.Text);

            if (result.Equals("OK"))
            {
                //changing password and closing page
                ResetPassSys.ResetPassword(TBNewPass.Text, TBConfirmNewPass.Text, MySession.Current.Login);
                Response.Redirect("Default.aspx");
            }
            else
            {
                //showing what went wrong with validation
                LabelCriteria.Text = result;
            }

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //canceling password change
            Response.Redirect("CancelationPasswordPage.aspx");
        }

        protected void TBNewPass_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        protected void TBConfirmNewPass_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }
        private void Validation()
        {
            //FronEnd validation that checks whether passwords are the same
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