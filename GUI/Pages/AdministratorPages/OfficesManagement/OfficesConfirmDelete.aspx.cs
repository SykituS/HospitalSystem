using Administration;
using BusinessAdministration;
using System;

namespace GUI.Pages.AdministratorPages.OfficesManagement
{
    public partial class OfficesConfirmDelete : System.Web.UI.Page
    {
        string roomNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            roomNumber = Request.QueryString["Room"];

            LblConfirmText.Text = "Are you sure you want delete room " + roomNumber + "?";
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficesManagementPage");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int room = Convert.ToInt32(roomNumber);

            Office.DeleteOfficeFromDb(room);

            Response.Redirect("OfficesManagementPage");
        }
    }
}