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
    }
}