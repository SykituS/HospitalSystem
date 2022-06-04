using Administration;
using BusinessAdministration;
using System;

namespace GUI.Pages.AdministratorPages.EmployeeManagement
{
    public partial class EmployeeDeactivationPage : System.Web.UI.Page
    {
        string employeeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            employeeId = Request.QueryString["Id"];
            BtnEditStatusEmp.Enabled = false;
        }
        protected void BtnDeactivation_Click(object sender, EventArgs e)
        {
            BtnDeactivation.Enabled = false;
            BtnEditStatusEmp.Enabled = true;
        }

        protected void BtnEditStatusEmp_Click(object sender, EventArgs e)
        {
            if (BtnDeactivation.Enabled == false)
            {
                Employee employee = new Employee(2);

                employee.UpdateStatusEmplyeeToDb(Convert.ToInt32(employeeId));

                Response.Redirect("EmployeesManagementPage.aspx");
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeesManagementPage.aspx");
        }
    }
}