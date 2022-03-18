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
            
            CancelUnexpectedRePost();

            //Checking whether the user is already logged in
            if (LogSys.CheckIfLogged())
                Response.Redirect("AdministratorPage.aspx");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
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
            //Cancelling the process of logging in
            TBLogin.Text = "";
            TBPassword.Text = "";
        }

        private void CancelUnexpectedRePost()
        {
            if (LogSys.GetAttempNumber() < 3)
            {
                LabelWarnings.Visible = true;
                LabelWarnings.Text = LogSys.GetAttempText();
            }

            string clientCode = _repostcheckcode.Value;

            string serverCode = Session["_repostcheckcode"] as string;

            if (!IsPostBack || clientCode.Equals(serverCode))
            {
                string code = Guid.NewGuid().ToString();
                _repostcheckcode.Value = code;
                Session["_repostcheckcode"] = code;
            } else
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void BtnResetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormToResetPassPage.aspx");

        }
    }
}