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
            if (!LogSys.CheckIfLogged())
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            LogSys.Logout();
            Response.Redirect("Default.aspx");

        }
    }
}