using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAdministration;
using Administration;

namespace GUI
{
    public partial class EmployeesManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            {
                GvEmployees.DataSource = EmployeesManagement.LoadEmps();
                GvEmployees.DataBind();

                DdlRoles.DataSource = EmployeesManagement.LoadRoles();
                DdlRoles.DataValueField = "PO_Id_Position";
                DdlRoles.DataTextField = "PO_Name";
                DdlRoles.DataBind();
            }
        }

        protected void GvEmployees_Sorting(object sender, GridViewSortEventArgs e)
        {
            GvEmployees.DataSource = EmployeesManagement.SortDataView(e, DdlRoles, DdlStatus);
            GvEmployees.DataBind();
        }

        protected void DdlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvEmployees.DataSource = EmployeesManagement.FilterDataView(DdlRoles, DdlStatus);
            GvEmployees.DataBind();
        }

        protected void DdlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvEmployees.DataSource = EmployeesManagement.FilterDataView(DdlRoles, DdlStatus);
            GvEmployees.DataBind();
        }

        protected void GvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvEmployees.Rows[index];
                string detailsPageId = "EmployeeDetailsPage.aspx?Id=" + row.Cells[0].Text;

                Response.Redirect(detailsPageId);
            }
        }

        protected void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeAddPage.aspx");
        }

        protected void BtnBackToMain_Click(object sender, EventArgs e)
        {
            //Button which returns to the main page
            Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
        }

        protected void GvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}