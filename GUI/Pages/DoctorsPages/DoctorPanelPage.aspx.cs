using Administration;
using System;

namespace GUI.Pages.DoctorsPages
{
    public partial class DoctorPanelPage : System.Web.UI.Page
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

        protected void BtnEmpManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAppointment");

        }
    }
}