using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAdministration;

namespace GUI
{
    public partial class EmployeesManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GvEmployees.DataSource = EmployeesManagement.LoadEmps();
            GvEmployees.DataBind();

            if (!IsPostBack)
            {
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

    }
}