using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;
using Reception;

namespace Reception
{
    public partial class PatientList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            Gv_patients.DataSource = Reception.LoadPats();
            Gv_patients.DataBind();
        }

        
        protected void Btn_filter_Click(object sender, EventArgs e)
        {
            Gv_patients.DataSource = Reception.FilterDataView(Tbx_name.Text, Tbx_surname.Text, Tbx_pesel.Text);
            Gv_patients.DataBind();
        }

        protected void Gv_patients_Sorting(object sender, GridViewSortEventArgs e)
        {
            Gv_patients.DataSource = Reception.SortDataView(e, Tbx_name.Text, Tbx_surname.Text, Tbx_pesel.Text);
            Gv_patients.DataBind();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicalStaffPanelPage");
        }
    }
}