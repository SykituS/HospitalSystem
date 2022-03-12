using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("AdministratorPage.aspx");
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("CancelationPage.aspx");
        }
    }
}