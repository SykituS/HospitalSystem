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
    public partial class PatientDetailsPage : System.Web.UI.Page
    {
        string patientId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            patientId = Request.QueryString["Id"];

            Gv_PatientDetails.DataSource = Reception.Reception.LoadPatientDetails(patientId);
            Gv_PatientDetails.DataBind();
        }

        protected void Btn_cancel_edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofPatients.aspx");
        }
    }
}