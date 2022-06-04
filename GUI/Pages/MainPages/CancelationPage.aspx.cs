using Administration;
using System;

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
            Response.Redirect("~/Pages/MainPages/Default.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            switch (MySession.Current.Position)
            {
                case "Administrator_of_all":
                    Response.Redirect("~/Pages/HeadAdministrator/AdministratorMainPanel");
                    break;
                case "administrator":
                    Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
                    break;
                case "doctor":
                    Response.Redirect("~/Pages/Doctorspages/DoctorPanelPage");
                    break;
                case "medical clinic staff member":
                    Response.Redirect("~/Pages/medicalStaffMemberPages/MedicalStaffPanelPage");
                    break;
                case "patient management staff":
                    Response.Redirect("~/Pages/PatientManagementStaffPages/PatientManagementPanelPage");
                    break;
                case "manager":
                    Response.Redirect("~/Pages/ManagerPages/ManagerPanelPage");
                    break;
            }

        }
    }
}