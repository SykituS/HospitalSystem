using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;
using Reception;

namespace GUI.Pages.MedicalStaffMemberPages
{
    public partial class PatientDeactivationPage : System.Web.UI.Page
    {
        string patientId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            patientId = Request.QueryString["Id"];
        }

        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofPatients");
        }

        protected void Btn_deactivate_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient(2);

            patient.UpdateStatusToDB(Convert.ToInt32(patientId));

            Response.Redirect("ListofPatients");
        }
    }
}