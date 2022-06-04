using Administration;
using System;

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