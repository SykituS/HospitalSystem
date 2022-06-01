﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAdministration;
using Administration;

namespace GUI
{
    public partial class EmployeeAddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            if (!IsPostBack)
            {
                DdlRoles.DataSource = EmployeesManagement.LoadRoles();
                DdlRoles.DataValueField = "PO_Id_Position";
                DdlRoles.DataTextField = "PO_Name";
                DdlRoles.DataBind();
            }

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

                employee.InsertEmployeeToDb();

                LblAdded.Text = "Employee added";

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