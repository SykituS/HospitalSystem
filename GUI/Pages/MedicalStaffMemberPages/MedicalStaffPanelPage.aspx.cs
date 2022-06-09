using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doctor;

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

            /*GetAppoitments getAppoitments = new GetAppoitments();
            List<DateTime> days_with_visits = getAppoitments.Get_Dates();
            foreach (DateTime data in days_with_visits)
                Calendar1.SelectedDates.Add(data);  */
            GetAppoitments getAppointments = new GetAppoitments();
            List<DateTime> days_with_visit = getAppointments.Get_Dates();
            foreach (DateTime data in days_with_visit)
                Cal_appointments.SelectedDates.Add(data);



        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MainPages/CancelationPage");
        }

        protected void BtnPatientList_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofPatients");
        }

        protected void Btn_visits_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofVisits");
        }

        
        protected void Cal_appointments_SelectionChanged(object sender, EventArgs e)
        {

            string selected_date = Cal_appointments.SelectedDate.ToString("yyyy-MM-dd");
            //DateTime day = Cal_appointments.SelectedDate;

            Gv_appointments.DataSource = Reception.VisitsManagement.LoadVisitDetails(selected_date);
            Gv_appointments.DataBind();
            //Response.Redirect("AppointmentDetails");
            
        }

        protected void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/HeadAdministrator/AdministratorMainPanel");

        }
    }
}