using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Administration;


namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserAddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            {
                DropDownList.DataSource = AddUser.dropdownlist();
                DropDownList.DataBind();

                DropDownList.DataTextField = "Employees_Without_User";

                DropDownList.DataValueField = "EM_Id_Employee";
                DropDownList.DataBind();
            }
        }


        protected void BtnAddNewUser_Click(object sender, EventArgs e)
        {
            MySession.Current.EmployeeName = DropDownList.SelectedItem.ToString();
            MySession.Current.IdEmployee = int.Parse(DropDownList.SelectedValue);
            Response.Redirect("UserAddAcceptPage.aspx?Id=" + MySession.Current.IdEmployee);


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserManagementPage");

        }
    }
    }
