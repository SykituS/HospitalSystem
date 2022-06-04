using Administration;
using BusinessAdministration;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EmployeeEditPage : System.Web.UI.Page
    {
        string employeeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            employeeId = Request.QueryString["Id"];
            int id = Convert.ToInt32(employeeId);
            DataTable empDetails = EmployeesManagement.LoadEmpDetails(employeeId);

            if (!IsPostBack)
            {
                DdlRoles.DataSource = EmployeesManagement.LoadRoles();
                DdlRoles.DataValueField = "PO_Id_Position";
                DdlRoles.DataTextField = "PO_Name";
                DdlRoles.DataBind();

                TxbName.Text = empDetails.Rows[0]["EM_Name"].ToString();
                TxbSurname.Text = empDetails.Rows[0]["EM_Surname"].ToString();
                TxbEmail.Text = empDetails.Rows[0]["EM_Email"].ToString();
                TxbPesel.Text = empDetails.Rows[0]["EM_Pesel"].ToString();

                DateTime dateOfBirth = (DateTime)empDetails.Rows[0]["EM_Date_of_birth"];
                TxbDob.Text = dateOfBirth.ToString("yyyy-MM-dd");

                TxbAddress.Text = empDetails.Rows[0]["EM_Correspondence_address"].ToString();
                TxbPhoneNumber.Text = empDetails.Rows[0]["EM_Phone_number"].ToString();
            }

            if (EmployeesManagement.GetEmployeeStatus(id) == 1)
                BtnStatus.Text = "Deactivate";

            if (EmployeesManagement.GetEmployeeStatus(id) == 2)
                BtnStatus.Text = "Reactivate";

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeesManagementPage.aspx");
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            byte position = Convert.ToByte(DdlRoles.SelectedValue);
            byte sex = Convert.ToByte(DdlSex.SelectedValue);

            if (IsEmailNameValid(TxbEmail.Text, TxbName.Text) && IsPeselBirthValid(TxbPesel.Text, Convert.ToDateTime(TxbDob.Text)) && IsPeselSexValid(TxbPesel.Text, Convert.ToInt32(DdlSex.SelectedValue)) && IsPhoneNumberValid(TxbPhoneNumber.Text) && IsEmailDomainValid(TxbEmail.Text))
            {
                Employee employee = new Employee(TxbName.Text, TxbSurname.Text, TxbEmail.Text, TxbPesel.Text, TxbDob.Text, TxbAddress.Text, position, TxbPhoneNumber.Text, sex, TxbSecName.Text);

                employee.UpdateEmployeeToDb(Convert.ToInt32(employeeId));

                LblEdited.Text = "Employee's data changed";

                TxbName.Text = "";
                TxbSecName.Text = "";
                TxbSurname.Text = "";
                TxbEmail.Text = "";
                TxbPesel.Text = "";
                TxbDob.Text = "";
                TxbAddress.Text = "";
                DdlRoles.SelectedIndex = 0;
                TxbPhoneNumber.Text = "";
                DdlSex.SelectedIndex = 0;
            }

        }

        protected void BtnStatus_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(employeeId);

            if (EmployeesManagement.GetEmployeeStatus(id) == 1)
            {
                string deactivationPageStatus = "EmployeeDeactivationPage.aspx?Id=" + employeeId;
                Response.Redirect(deactivationPageStatus);
            }

            if (EmployeesManagement.GetEmployeeStatus(id) == 2)
            {
                string reactivationPageStatus = "EmployeeReactivationPage.aspx?Id=" + employeeId;
                Response.Redirect(reactivationPageStatus);
            }
        }


        protected void EmailValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (IsEmailNameValid(args.Value, TxbName.Text) && IsEmailDomainValid(args.Value))
                return;

            args.IsValid = false;
        }
        protected void PeselValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (IsPeselBirthValid(args.Value, Convert.ToDateTime(TxbDob.Text)) && IsPeselSexValid(args.Value, Convert.ToInt32(DdlSex.SelectedValue)))
                return;

            args.IsValid = false;
        }
        protected void PhoneNumberValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (IsPhoneNumberValid(args.Value))
                return;

            args.IsValid = false;
        }

        private bool IsEmailNameValid(string email, string name)
        {
            if (email == "")
                return true;

            return email.ToLower().Contains(name.ToLower());
        }

        private bool IsEmailDomainValid(string email)
        {
            return email.Contains("eksocmed.com");
        }

        private bool IsPeselBirthValid(string pesel, DateTime dateOfBirth)
        {
            string shortDateOfBirth = dateOfBirth.ToString("yyMMdd");
            shortDateOfBirth.Replace("/", "");

            string peselFirstSixChars = pesel.Substring(0, 6);

            return shortDateOfBirth == peselFirstSixChars;
        }

        private bool IsPeselSexValid(string pesel, int sex)
        {
            int penultimateDigit = Convert.ToInt32(pesel.Substring(9, 1));

            if (sex == 1)
                return penultimateDigit % 2 != 0;

            if (sex == 2)
                return penultimateDigit % 2 == 0;

            return true;
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            if (phoneNumber.Length == 9)
            {
                foreach (char c in phoneNumber)
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
