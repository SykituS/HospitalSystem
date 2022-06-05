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
                //Adding data to the gridView
                GridViewUsers.DataSource = UserManagement.GetUsersFromDB();
                GridViewUsers.DataBind();

                //Adding data to the DropDownList and setting default choose to "All"
                DropDownListPosition.DataSource = UserManagement.GetPostionsFromDB();
                DropDownListPosition.DataBind();
                DropDownListPosition.DataTextField = "PO_Name";
                DropDownListPosition.DataValueField = "PO_Name";
                DropDownListPosition.DataBind();

                DropDownListPosition.Items.Add("All");
                DropDownListPosition.SelectedValue = "All";
            }
        }

        //Sorting gridView
        protected void GridViewUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridViewUsers.DataSource = UserManagement.SortDataView(e, TBNameFirst.Text, TBNameSecond.Text, DropDownListPosition.SelectedValue);
            GridViewUsers.DataBind();
        }

        //GridView button's click functions
        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
                return;

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewUsers.Rows[index];

            //Button "change status" click
            if (e.CommandName == "ChangeStatus")
            {
                Button btn = (Button)e.CommandSource;
                Response.Redirect("UserStatusUpdateConfirmPage.aspx?login=" + row.Cells[0].Text + "&status=" + btn.Text);
            }

            //Button "Edit user" click
            if (e.CommandName == "EditUser")
            {
                    MySession.Current.TempStatus = row.Cells[4].Text;
                    string detailsPageId = "UserDetailsPage.aspx?Id=" + row.Cells[0].Text;
                    Response.Redirect(detailsPageId);
            }
        }

        //Filtering GridView
        protected void FilterGridView(object sender, EventArgs e)
        {
            GridViewUsers.DataSource = UserManagement.GetUsersFromDB(TBNameFirst.Text, TBNameSecond.Text, DropDownListPosition.SelectedValue);
            GridViewUsers.DataBind();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //Button which returns to the main page
            Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
        }

        protected void BtnAddNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/UserManagementPages/UserAddPage");
        }

        protected void GridViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySession.Current.Login = GridViewUsers.SelectedRow.Cells[0].Text;
        }
    }
}