using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;

namespace GUI
{
	public partial class CancelationPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            LogSys.LogoutFromSystem();
            Response.Redirect("Default.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (LogSys.CheckPosition())
                Response.Redirect("AdministratorPage.aspx");

            Response.Redirect("EmployeePage.aspx");

        }
    }
}