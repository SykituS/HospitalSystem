using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.MedicalStaffMemberPages
{
    public partial class MedicalStaffPanelPage : System.Web.UI.Page
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

        protected void BtnPatientList_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientList");
        }
    }
}