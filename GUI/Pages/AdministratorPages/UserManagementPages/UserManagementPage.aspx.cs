using System;
using Administration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.UserManagementPages
{
    public partial class UserManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            {
                GridViewUsers.DataSource = UserManagement.GetUsersFromDB();
                GridViewUsers.DataBind();

                DropDownListPosition.DataSource = UserManagement.GetPostionsFromDB();
                DropDownListPosition.DataBind();
                DropDownListPosition.DataTextField = "PO_Name";
                DropDownListPosition.DataValueField = "PO_Name";
                DropDownListPosition.DataBind();

                DropDownListPosition.Items.Add("All");
                DropDownListPosition.SelectedValue = "All";
            }
        }

        protected void GridViewUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridViewUsers.DataSource = UserManagement.SortDataView(e, TBNameFirst.Text, TBNameSecond.Text, DropDownListPosition.SelectedValue);
            GridViewUsers.DataBind();
        }

        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
                return;
            string s = e.CommandName;

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewUsers.Rows[index];

            Button btn = (Button)e.CommandSource;

            if (e.CommandName == "ChangeStatus")
            {
                GridViewUsers.DataSource = UserManagement.UpdateUserStatus(row.Cells[0].Text, btn.Text);
                GridViewUsers.DataBind();
            }

            if (e.CommandName == "EditUser")
            {
                Console.Write(e.CommandName);
            }
        }

        protected void Sort(object sender, EventArgs e)
        {
            GridViewUsers.DataSource = UserManagement.GetUsersFromDB(TBNameFirst.Text, TBNameSecond.Text, DropDownListPosition.SelectedValue);
            GridViewUsers.DataBind();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //Button which returns to the main page
            Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
        }
    }
}