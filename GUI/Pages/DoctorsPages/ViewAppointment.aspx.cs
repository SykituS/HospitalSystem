using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doctor;
using System.Data;
using Administration;


namespace GUI
{
    public partial class ViewAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            foreach (DateTime data in GetAppoitments.Get_Dates())
                Calendar1.SelectedDates.Add(data);

            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime day = Calendar1.SelectedDate;

            GridView1.DataSource = GetAppoitments.Get_Info_Appointment(day);
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            
            DateTime day = Calendar1.SelectedDate;

            //pierwsza proba sortowania

            //SortDirection ez = SortDirection.Ascending;
            //string sortField = GridView1.Attributes["CurrentSortField"];

            //if (ez == SortDirection.Ascending)
            //{
            //    ez = SortDirection.Descending;
            //}
            //else
            //{
            //    ez = SortDirection.Ascending;
            //}
            //GridView1.Sort(sortField, ez);

            GridView1.DataSource = GetAppoitments.Get_Info_Appointment(day);
            GridView1.DataBind();
        }

        protected void BtnBackToMainPage_Click(object sender, EventArgs e)
        {
            //Button which returns to the main page
            Response.Redirect("DoctorPanelPage");
        }

        //druga proba sortowania

        //private void SortGridview(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        //{
        //    sortField = e.SortExpression;
        //    sortDirection = e.SortDirection;

        //    if (gridView.Attributes["CurrentSortField"] != null && gridView.Attributes["CurrentSortDirection"] != null)
        //    {
        //        if (sortField == gridView.Attributes["CurrentSortField"])
        //        {
        //            if (gridView.Attributes["CurrentSortDirection"] == "ASC")
        //            {
        //                sortDirection = SortDirection.Descending;
        //            }
        //            else
        //            {
        //                sortDirection = SortDirection.Ascending;
        //            }
        //        }

        //        gridView.Attributes["CurrentSortField"] = sortField;
        //        gridView.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
        //    }
        //}



    }
}