using Administration;
using System;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserAddAcceptPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            Label1.Text = "Do you want to add user for " + MySession.Current.EmployeeName + "??";
        }

        protected void BtnAccept_Click(object sender, EventArgs e)
        {
            AddUser.AddNewUser(MySession.Current.IdEmployee);
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserManagementPage");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserAddPage");
        }
    }
}