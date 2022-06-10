using Administration;
using System;

namespace GUI
{
    public partial class AdministratorPanelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (MySession.Current.Position == "Administrator_of_all")
            {
                BtnBackToMenu.Visible = true;
                BtnBackToMenu.Enabled = true;
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MainPages/CancelationPage");
        }

        protected void BtnUserManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserManagementPages/UserManagementPage");
        }

        protected void BtnEmpManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeManagement/EmployeesManagementPage");
        }

        protected void BtnOfficesManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficesManagement/OfficesManagementPage");
        }

        protected void BtnSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("SettingPanelPage");
        }

        protected void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/HeadAdministrator/AdministratorMainPanel");
        }

        protected void BtnSpecializationManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpecializationManagementPages/SpecializationManagementPage");
        }

        protected void BtnCalendarPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar/CalendarPage");
        }
    }
}