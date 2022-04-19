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
        string login ;
        protected void Page_Load(object sender, EventArgs e)
        {
             login = Request.QueryString["login"];
            string email = Request.QueryString["email"];

            if (ResetPassSys.CheckStatus(login, email))
                Response.Redirect("~/Pages/MainPages/InvalidPage");


            LabelInfo.Text = "Change password for " + login;
        }
      
        protected void BtnOk_Click(object sender, EventArgs e)
        {
            string NewPassword = TBNewPass.Text;
            if (TBNewPass.Text.Length == TBConfirmNewPass.Text.Length)
            {
                if (TBNewPass.Text.Length >= 8 && TBNewPass.Text.Length <= 15)
                {
                    if (TBNewPass.Text.Any(char.IsUpper) && TBNewPass.Text.Any(char.IsDigit) && TBNewPass.Text.Any(char.IsPunctuation))
                    {
                        LabelInfo.Text = "Passowrd changed";
                        ResetPassSys.ResetPassword(NewPassword, login);

                    }
                    else
                        LabelInfo.Text = "Password must include at least one lowercase, uppercase, numbers and special characters";
                }
                else
                    LabelInfo.Text = "Incorrect password length";
            }
            else
                LabelInfo.Text = "Passwords do not match";
        }
    }
}