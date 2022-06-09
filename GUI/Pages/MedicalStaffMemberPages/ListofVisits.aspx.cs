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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");


            Gv_visits.DataSource = Reception.VisitsManagement.LoadVisits();
            Gv_visits.DataBind();
            /* Gv_patients.DataSource = Reception.LoadPats();
            Gv_patients.DataBind(); */
        }

        protected void Btn_addvisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddVisit");
        }

        protected void Btn_filter_Click(object sender, EventArgs e)
        {
            Gv_visits.DataSource = Reception.VisitsManagement.FilterVisits(Tbx_patient.Text, Tbx_pesel.Text, Tbx_date.Text, Tbx_specialization.Text, Tbx_doctor.Text);
            Gv_visits.DataBind();
        }

        protected void Gv_visits_Sorting(object sender, GridViewSortEventArgs e)
        {
            Gv_visits.DataSource = Reception.VisitsManagement.SortVisits(e, Tbx_patient.Text, Tbx_pesel.Text, Tbx_date.Text, Tbx_specialization.Text, Tbx_doctor.Text);
            Gv_visits.DataBind();
        }

        protected void Btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicalStaffPanelPage");
        }
    }
}