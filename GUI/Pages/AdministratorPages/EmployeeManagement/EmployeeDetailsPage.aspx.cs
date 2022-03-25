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
    public partial class EmployeeDetailsPage : System.Web.UI.Page
    {
        string employeeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            employeeId = Request.QueryString["Id"];

            DetailsViewEmployee.DataSource = EmployeesManagement.LoadEmpDetails(employeeId);
            DetailsViewEmployee.DataBind();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeesManagementPage.aspx");
        }
    }
}