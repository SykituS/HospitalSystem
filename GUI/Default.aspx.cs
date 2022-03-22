using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnCancel.Attributes.Add("OnClick", "window.close();");
            //CancelUnexpectedRePost();
            if (!this.IsPostBack)
            {
                CancelUnexpectedRePost();
            }

            //Checking whether the user is already logged in
            if (Administation.MySession.Current.IsLogged)
            {
                if (LogSys.CheckPosition())
                    Response.Redirect("AdministratorPage.aspx");

                Response.Redirect("EmployeePage.aspx");
            }

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            CancelUnexpectedRePost();

            //Starting the login process 
            LogSys.LoginToSystem(TBLogin.Text, TBPassword.Text);

            //Checking whether the user has successfully logged in
            if (LogSys.CheckIfLogged())
            {
                if (LogSys.CheckPosition())
                    Response.Redirect("AdministratorPage.aspx");

                Response.Redirect("EmployeePage.aspx");
            }

            LabelWarnings.Visible = true;
            LabelWarnings.Text = LogSys.WrongAttempt();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            
        }
        protected void BtnResetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormToResetPassPage.aspx");

        }

        private void CancelUnexpectedRePost()
        {
            if (LogSys.GetAttempNumber() < 3)
            {
                LabelWarnings.Visible = true;
                LabelWarnings.Text = LogSys.GetAttempText();
            }

            string clientCode = _repostcheckcode.Value;

            //Get Server Code from session (Or Empty if null)
            string serverCode = Session["_repostcheckcode"] as string;

            if (!IsPostBack || clientCode.Equals(serverCode))
            {
                //Codes are equals - The action was initiated by the user
                //Save new code (Can use simple counter instead Guid)
                string code = Guid.NewGuid().ToString();
                _repostcheckcode.Value = code;
                Session["_repostcheckcode"] = code;
            } else
            {
                //Unexpected action - caused by F5 (Refresh) button
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

    }
}