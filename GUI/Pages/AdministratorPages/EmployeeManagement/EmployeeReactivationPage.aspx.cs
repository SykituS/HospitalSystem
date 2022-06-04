using Administration;
using BusinessAdministration;
using System;

namespace GUI.Pages.AdministratorPages.EmployeeManagement
{
    public partial class EmployeeReactivationPage : System.Web.UI.Page
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
        protected void BtnReactivation_Click(object sender, EventArgs e)
        {
            BtnReactivation.Enabled = false;
            BtnEditStatusEmp.Enabled = true;
        }

        protected void BtnEditStatusEmp_Click(object sender, EventArgs e)
        {
            if (BtnReactivation.Enabled == false)
            {
                Employee employee = new Employee(1);

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