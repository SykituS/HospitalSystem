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
                Gv_patients.DataSource = Reception.FilterDataView(Tbx_name.Text, Tbx_surname.Text, Tbx_pesel.Text, ChBx_visit.Checked);
                Gv_patients.DataBind();
        }

        protected void Gv_patients_Sorting(object sender, GridViewSortEventArgs e)
        {
            Gv_patients.DataSource = Reception.SortDataView(e, Tbx_name.Text, Tbx_surname.Text, Tbx_pesel.Text, ChBx_visit.Checked);
            Gv_patients.DataBind();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicalStaffPanelPage");
        }

        
        protected void Gv_patients_RowCommand(object sneder, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = Gv_patients.Rows[index];
                string detailsPageId = "PatientDetailsPage.aspx?Id=" + row.Cells[0].Text;

                Response.Redirect(detailsPageId);
            }
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = Gv_patients.Rows[index];
                string editPageId = "PatientEditPage.aspx?Id=" + row.Cells[0].Text;

                Response.Redirect(editPageId);
            }
            if (e.CommandName == "Status")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = Gv_patients.Rows[index];
                int id = Convert.ToInt32(row.Cells[0].Text);
                int status = Reception.GetPatientStatus(id);

                if(status == 1)
                {
                    string deactivationPageStatus = "PatientDeactivationPage.aspx?Id=" + row.Cells[0].Text;
                    Response.Redirect(deactivationPageStatus);
                }
                if (status == 2)
                {
                    string reactivativationPageStatus = "PatientReactivationPage.aspx?Id=" + row.Cells[0].Text;
                    Response.Redirect(reactivativationPageStatus);
                    
                }
                
            }
            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = Gv_patients.Rows[index];
                string deletePageId = "PatientDeletePage.aspx?Id=" + row.Cells[0].Text;
                Response.Redirect(deletePageId);
            }
        }

        protected void Btn_addpat_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientAddPage.aspx");
        }

       
      
    }
}