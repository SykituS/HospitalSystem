using Administration;
using BusinessAdministration;
using System;

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

        protected void BtnEditEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeEditPage.aspx?Id=" + employeeId);
        }
    }
}