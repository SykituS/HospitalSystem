﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAdministration;
using Administration;
using System.Data;

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
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeesManagementPage.aspx");
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            string sex = DdlSex.SelectedValue;

            if (sex == "")
            {
                string pesel = TxbPesel.Text;
                int penUltimateNumber = Convert.ToInt32(pesel.Substring(pesel.Length - 2, 1));

                if (penUltimateNumber % 2 == 0)
                    sex = "2";
                else
                    sex = "1";
            }

            if (IsEmailValid(TxbEmail.Text, TxbName.Text) && IsPeselValid(TxbPesel.Text))
            {
                Employee employee = new Employee(Convert.ToInt32(employeeId), TxbName.Text, TxbSurname.Text, TxbEmail.Text, TxbPesel.Text, TxbDob.Text, TxbAddress.Text, DdlRoles.SelectedValue, TxbPhoneNumber.Text, sex);

                employee.UpdateEmployeeToDb();

                LblEdited.Text = "Employee's data changed";

                TxbName.Text = "";
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

            if (IsEmailValid(args.Value, TxbName.Text))
                return;

            args.IsValid = false;
        }
        protected void PeselValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (IsPeselValid(TxbPesel.Text))
                return;

            args.IsValid = false;
        }

        private bool IsEmailValid(string email, string name)
        {
            if (email == "")
                return true;

            if (email.ToLower().Contains(name.ToLower()))
                return true;

            return false;
        }

        private bool IsPeselValid(string pesel)
        {
            DateTime dateOfBirth = Convert.ToDateTime(TxbDob.Text);
            string shortDateOfBirth = dateOfBirth.ToString("yyMMdd");
            shortDateOfBirth.Replace("/", "");

            string peselFirstSixChars = pesel.Substring(0, 6);

            if (shortDateOfBirth == peselFirstSixChars)
                return true;

            return false;
        }

    }
}
