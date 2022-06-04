using Administration;
using System;

namespace GUI.Pages.PateintManagementStaffPages
{
    public partial class PatientManagementPanelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MainPages/CancelationPage");
        }
    }
}