using Administration;
using System;

namespace GUI.Pages
{
    public partial class AdministratorMainPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MainPages/CancelationPage");
        }

        protected void BtnAdministrator_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
        }

        protected void BtnDoctors_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Doctorspages/DoctorPanelPage");
        }

        protected void BtnMedicalStaffMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/medicalStaffMemberPages/MedicalStaffPanelPage");
        }
    }
}