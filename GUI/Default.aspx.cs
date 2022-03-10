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
            //On load check if user is already logged to the system
            if (LogSys.CheckIfLogged())
                Response.Redirect("About.aspx");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //Starting login process
            LogSys.LoginToSystem(TBLogin.Text, TBPassword.Text);

            //Checking results of login process
            if (LogSys.CheckIfLogged())
                Response.Redirect("About.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //Canceling login process
            TBLogin.Text = "";
            TBPassword.Text = "";
        }
    }
}