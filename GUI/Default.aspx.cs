using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administation;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checking whether the user is already logged in
            if (LogSys.CheckIfLogged())
                Response.Redirect("About.aspx");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //Starting the login process 
            LogSys.LoginToSystem(TBLogin.Text, TBPassword.Text);

            //Checking whether the user has successfully logged in
            if (LogSys.CheckIfLogged())
                Response.Redirect("About.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //Cancelling the process of logging in
            TBLogin.Text = "";
            TBPassword.Text = "";
        }
    }
}