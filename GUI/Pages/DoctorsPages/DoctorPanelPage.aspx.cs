using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.DoctorsPages
{
    public partial class DoctorPanelPage : System.Web.UI.Page
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

        protected void BtnEmpManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAppointment");

        }

        protected void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/HeadAdministrator/AdministratorMainPanel");

        }
    }
}