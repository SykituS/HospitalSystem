using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administation;

namespace GUI
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checking whether the user is logged in
            if (!LogSys.CheckIfLogged())
                Response.Redirect("Default.aspx");
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            //Logging the user out of the system
            LogSys.LogoutFromSystem();
            Response.Redirect("Default.aspx");

        }
    }
}