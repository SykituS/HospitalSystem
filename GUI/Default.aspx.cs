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
            if (LogSys.CheckIfLogged())
            {
                Response.Redirect("About.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            LogSys.LoginToSystem(TBLogin.Text, TBPassword.Text);

            if (LogSys.CheckIfLogged())
            {
                Response.Redirect("About.aspx");
            }
        }
    }
}