using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administration;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserAddAcceptPage : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

          
            }

        protected void BtnAccept_Click(object sender, EventArgs e)
        {
            AddUser.AddNewUser(MySession.Current.TempIdEmployee);
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserManagementPage");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserAddPage");
        }
    }
}