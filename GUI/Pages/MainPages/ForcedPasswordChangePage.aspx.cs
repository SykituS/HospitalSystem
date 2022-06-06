using Administration;
using System;

namespace GUI.Pages.MainPages
{
    public partial class ForcedPasswordChangePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnContiune_Click(object sender, EventArgs e)
        {
            string result = ResetPassSys.PasswordValidation(TBNewPassword.Text, TBConfirmNewPassword.Text);
            if (result.Equals("OK"))
            {
                ResetPassSys.ResetPassword(TBNewPassword.Text, TBConfirmNewPassword.Text, MySession.Current.Login);
                ResetPassSys.ForcePasswordChange(MySession.Current.Login, 0);
                MySession.Current.ForcedPasswordChange = 0;
                Response.Redirect("~/Pages/MainPages/Default");

            }
            else
                LabelWarning.Text = result;
        }
    }
}