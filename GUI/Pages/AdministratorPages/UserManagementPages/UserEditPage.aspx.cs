using System;
using Administration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserEditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            MySession.Current.TempLogin = Request.QueryString["Id"];
            Btnstatus.Text = EditUser.GetStatus(MySession.Current.TempLogin);
            TbLogin.Text = MySession.Current.TempLogin;
            MySession.Current.TempStatus= EditUser.GetStatus(MySession.Current.TempLogin);
        }

        protected void BtnAccept_Click(object sender, EventArgs e)
        {
            //Getting result of validation
            ResetPassSys.ResetPassword(MySession.Current.TempPass, MySession.Current.TempPass, MySession.Current.TempLogin);
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserManagementPage");

        }

        protected void Btnstatus_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditUserStatus.aspx?Id=" + MySession.Current.TempLogin);
            
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserManagementPage");
        }

        protected void Btnpass_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUserPass.aspx?Id=" + MySession.Current.TempLogin);
        }
    }
}