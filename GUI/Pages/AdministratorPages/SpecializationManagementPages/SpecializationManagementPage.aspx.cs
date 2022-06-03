using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.SpecializationManagementPages
{
    public partial class SpecializationManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
        }

        protected void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
        }
    }
}