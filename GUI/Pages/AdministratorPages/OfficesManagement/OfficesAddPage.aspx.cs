using Administration;
using BusinessAdministration;
using System;
using System.Web.UI.WebControls;

namespace GUI.Pages.AdministratorPages.OfficesManagement
{
    public partial class OfficesAddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            {
                DdlSpecialization.DataSource = BusinessAdministration.OfficesManagement.LoadSpecialisation();
                DdlSpecialization.DataValueField = "ID_Specialisation";
                DdlSpecialization.DataTextField = "Name";
                DdlSpecialization.DataBind();
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            byte specialisation = Convert.ToByte(DdlSpecialization.SelectedValue);
            string plenary = DdlPlenary.SelectedValue;
            string status = DdlStatus.SelectedValue;
            string renumerated = DdlRenumerated.SelectedValue;

            if (IsRoomNumberValid(TxbOfficeNumber.Text))
            {
                Office office = new Office(TxbOfficeNumber.Text, specialisation, plenary, status, renumerated);

                office.InsertOfficeToDb();

                LblAdded.Text = "Office added";

                TxbOfficeNumber.Text = "";
                DdlSpecialization.SelectedIndex = 0;
                DdlPlenary.SelectedIndex = 0;
                DdlStatus.SelectedIndex = 0;
                DdlRenumerated.SelectedIndex = 0;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficesManagementPage");
        }

        protected void RoomNumberValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (IsRoomNumberValid(args.Value))
                return;

            args.IsValid = false;
        }

        private bool IsRoomNumberValid(string roomNumber)
        {
            if (roomNumber.Length == 3)
            {
                foreach (char c in roomNumber)
                {
                    if (!char.IsDigit(c))
                        return false;
                }

                return true;
            }

            return false;
        }
    }
}