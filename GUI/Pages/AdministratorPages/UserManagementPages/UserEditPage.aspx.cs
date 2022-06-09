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
            TbLogin.Text = MySession.Current.TempLogin;
       //     MySession.Current.TempLogin = Request.QueryString["Id"];
            if (MySession.Current.FirstLoad != 0)
            {
                Btnstatus.Text=MySession.Current.TempStatus;
            }
            else
            {
                Btnstatus.Text = EditUser.GetStatus(MySession.Current.TempLogin);

                MySession.Current.TempStatus = EditUser.GetStatus(MySession.Current.TempLogin);
                MySession.Current.FirstLoad = +1;
            }
        }

        protected void BtnAccept_Click(object sender, EventArgs e)
        {
            //Getting result of validation
            if (MySession.Current.TempPass != null)
            {
                ResetPassSys.ResetPassword(MySession.Current.TempPass, MySession.Current.TempPass, MySession.Current.TempLogin);
                ResetPassSys.ForcePasswordChange(MySession.Current.TempLogin, 1);
            }
            EditUser.EditUsers(MySession.Current.TempLogin);
            MySession.Current.TempStatus = (string)EditUser.UpdateUserEditStatus(MySession.Current.TempLogin, MySession.Current.TempStatus).Rows[4]["St_Status_Name"];

            EditUser.ClearEdit();
            Response.Redirect("UserDetailsPage.aspx?Id=" + MySession.Current.TempLogin);


        }

        protected void Btnstatus_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditUserStatus.aspx?Id=" + MySession.Current.TempLogin);
            
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {   
            
                Response.Redirect("UserEditCancel.aspx?Id=" + MySession.Current.TempLogin);
           
        }

        protected void Btnpass_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUserPass.aspx?Id=" + MySession.Current.TempLogin);
        }
    }
}