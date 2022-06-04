using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserStatusUpdateConfirmPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySession.Current.TempLogin = Request.QueryString["login"];
            MySession.Current.TempStatus = Request.QueryString["status"];

            if (MySession.Current.TempStatus == "Active")
                Label1.Text = "Are you sure you want to deactivate the selected user?";
            else
                Label1.Text = "Are you sure you want to activate the selected user?";
        }

        protected void BtnAccept_Click(object sender, EventArgs e)
        {
            UserManagement.UpdateUserStatus(MySession.Current.TempLogin, MySession.Current.TempStatus);

            MySession.Current.TempLogin = null;
            MySession.Current.TempStatus = null;

            Response.Redirect("UserManagementPage");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserManagementPage");
        }
    }
}