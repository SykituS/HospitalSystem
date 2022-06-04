﻿using Administration;
using System;
namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class EditUserStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
            if (MySession.Current.TempStatus == "Active")
                Label1.Text = "Are you sure you want to deactivate the selected user?";
            else
                Label1.Text = "Are you sure you want to activate the selected user?";
        }

        protected void BtnAccept_Click(object sender, EventArgs e)
        {
            MySession.Current.TempStatus = (string)UserManagement.UpdateUserStatus(MySession.Current.TempLogin, MySession.Current.TempStatus).Rows[4]["St_Status_Name"];

            Response.Redirect("UserEditPage.aspx?Id=" + MySession.Current.TempLogin);

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEditPage.aspx?Id=" + MySession.Current.TempLogin);
        }
    }
}