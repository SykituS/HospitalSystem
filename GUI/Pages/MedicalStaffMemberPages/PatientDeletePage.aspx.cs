using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;

namespace GUI.Pages.MedicalStaffMemberPages
{
    public partial class PatientDeletePage : System.Web.UI.Page
    {
        string patientId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofPatients.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int patient = Convert.ToInt32(patientId);

            Reception.Patient.DeletePatientFromDB(patient);

            Response.Redirect("ListofPatients.aspx");
            
        }

        
    }
}