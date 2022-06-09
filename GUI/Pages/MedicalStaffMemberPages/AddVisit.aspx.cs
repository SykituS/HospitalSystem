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
    public partial class WebForm4 : System.Web.UI.Page
    {
        string patientId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
            string spec = Convert.ToString(Ddl_specialization.SelectedItem);
            if (!IsPostBack)
            {
                Ddl_patient.DataSource = Reception.Reception.Patients();
                Ddl_patient.DataValueField = "Id_Patients";
                Ddl_patient.DataTextField = "Patient";
                Ddl_patient.DataBind();
                Ddl_specialization.DataSource = Reception.Reception.Specialization();
                Ddl_specialization.DataValueField = "ID_Specialisation";
                Ddl_specialization.DataTextField = "Name";
                Ddl_specialization.DataBind();
                Ddl_doctor.DataSource = Reception.Reception.Doctors();
                Ddl_doctor.DataValueField = "ID_Doctor";
                Ddl_doctor.DataTextField = "Doctor";
                Ddl_doctor.DataBind();
                Ddl_office.DataSource = Reception.Reception.Office();
                Ddl_office.DataValueField = "Of_id_office";
                Ddl_office.DataTextField = "Of_office_number";
                Ddl_office.DataBind();
            }
        }

        protected void Btn_addappointment_Click(object sender, EventArgs e)
        {
            //patientid = Request.QueryString["Id"];
            //int id = Convert.ToInt32(patientId);
            string patient = Convert.ToString(Ddl_patient.SelectedValue);
            DateTime date = Convert.ToDateTime(Tbx_date.Text);
            TimeSpan time = TimeSpan.Parse(Tbx_time.Text);
            string doctor = Convert.ToString(Ddl_doctor.SelectedValue);
            string specialization = Convert.ToString(Ddl_specialization.SelectedValue);
            int office = Convert.ToInt32(Ddl_office.SelectedValue);
            try
            {
                
                if (Tbx_date.Text.Equals("") || !Reception.Visits.ValidateDateOfVisit(date))
                {
                    Lbl_errorwarning.Text = "Empty or incorrect date of visit";
                    return;
                }
                if (Tbx_time.Text.Equals("") || !Reception.Visits.ValidateTimeOfVisit(time, date))
                {
                    Lbl_errorwarning.Text = "Empty or incorrect time of visit";
                    return;
                }
            }
            catch (Exception)
            {
                Lbl_errorwarning.Text = "Error";
                return;
            }

            Lbl_added.Text = "Appointmend added";

            Visits visit = new Visits(patient, date, time, doctor, office);
            visit.AddVisitToDb();
        }

        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofVisits.aspx");
        }
    }
}