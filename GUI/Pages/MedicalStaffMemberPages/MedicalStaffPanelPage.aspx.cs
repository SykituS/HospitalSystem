using Administration;
using System;

namespace GUI.Pages.MedicalStaffMemberPages
{
    public partial class MedicalStaffPanelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            //Head admin option
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

        protected void BtnPatientList_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientList");
        }

        protected void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/HeadAdministrator/AdministratorMainPanel");
        }
    }
}