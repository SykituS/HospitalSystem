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
            string result = ResetPassSys.PasswordValidation(TbNewPass.Text, TbConfirmPass.Text);

            if (result.Equals("OK"))
            {   
                //changing password and closing page
                ResetPassSys.ResetPassword(TbNewPass.Text, TbConfirmPass.Text, MySession.Current.TempLogin);
                TbNewPass.Text= MySession.Current.TempPass;
                EditUser.EditUsers(MySession.Current.TempLogin);
            }
            else
            {
                //showing what went wrong with validation
                LabelCriteria.Text = result;
            }
            
        }

        protected void Btnstatus_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditUserStatus.aspx?Id=" + MySession.Current.TempLogin);
            
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserManagementPage");
        }
    }
}