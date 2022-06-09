using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doctor;
using System.Data;
using Administration;
using System.Drawing;
using FluentValidation.Results;
using System.Threading;
using System.Globalization;

namespace GUI
{
    public partial class ViewAppointment : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
            Label1.Visible = false;
            Label2.Visible = false;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetAppoitments getAppoitments = new GetAppoitments();
            List<DateTime> days_with_visits = getAppoitments.Get_Dates();
            foreach (DateTime data in days_with_visits)
                Calendar1.SelectedDates.Add(data);

            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            

            DateTime day = Calendar1.SelectedDate;

            GetAppoitments getAppoitments = new GetAppoitments();
            GridView1.DataSource = getAppoitments.Get_Info_Appointment(day);
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

            DateTime day = Calendar1.SelectedDate;

            GetAppoitments getAppoitments = new GetAppoitments();
            GridView1.DataSource = getAppoitments.Get_Info_Appointment(day);
            GridView1.DataBind();

            DataTable m_DataTable = GridView1.DataSource as DataTable;

            if (m_DataTable != null)
            {
                DataView m_DataView = new DataView(m_DataTable);
                SortingExpression = e.SortExpression + " " + (SortingExpression.Contains("ASC") ? "DESC" : "ASC");
                m_DataView.Sort = SortingExpression;

                GridView1.DataSource = m_DataView;
                GridView1.DataBind();
            }
        }

        protected void BtnBackToMainPage_Click(object sender, EventArgs e)
        {
            //Button which returns to the main page
            Response.Redirect("DoctorPanelPage");
        }

        public string SortingExpression
        {
            get
            {
                if (this.ViewState["SortExpression"] == null)
                    return "";
                else
                    return (string)this.ViewState["SortExpression"];
            }

            set
            {
                this.ViewState["SortExpression"] = value;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = ColorTranslator.FromHtml("White");

                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    
                    //row.ToolTip = string.Empty;
                    //string dane;
                    //dane = row.Cells[2].Text;
                    //Label1.Text = dane;

                }

                //Label1.Visible = true;

            }

            int cell = Int32.Parse(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);




            AppoitmentDetails appoitmentDetails = new AppoitmentDetails();
            DataTable dt = new DataTable();
            dt = appoitmentDetails.Get_Details(cell);
            TextBox1.Text = dt.Rows[0]["Name"].ToString();
            TextBox2.Text = dt.Rows[0]["Surname"].ToString();
            TextBox3.Text = dt.Rows[0]["Phone_number"].ToString();
            TextBox7.Text = dt.Rows[0]["Pesel"].ToString();
            TextBox4.Text = dt.Rows[0]["AD_appointment_description"].ToString();
            //RefExamination.Text = dt.Rows[0]["AD_referral"].ToString();

            Button5.Visible = true;

            GetAppoitments getAppoitments = new GetAppoitments();
            getAppoitments.Get_Doctor_ID();


            AppoitmentDetails patients_visits = new AppoitmentDetails();
            DataTable d = new DataTable();
            d = patients_visits.All_appoitments_of_current_patient(cell);

            ListBox1.Items.Clear();
            foreach (DataRow item in d.Rows)
            {
                DateTime date = DateTime.Parse(item["Ap_appoitment_day"].ToString());
                DateTime time = DateTime.Parse(item["Ap_appoitment_time"].ToString());
                var id = int.Parse(item["Ap_id_appoitment"].ToString());
                //id_wizyt.Add(id);
                
                ListBox1.Items.Add("Date of visit: "+date.ToString("yyyy-MM-dd") + " " + time.ToString("HH:mm:ss"));
            }

        }
        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Button7.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            Button5.Enabled = false;

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            DateTime Date = DateTime.Parse(TextBox6.Text);
            DateTime Hour = DateTime.Parse(TextBox5.Text);

            DateTime combined = Date.Date.Add(Hour.TimeOfDay);
            int cell = Int32.Parse(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            AppoitmentDetails appoitmentDetails = new AppoitmentDetails();
            
            appoitmentDetails.Add_New_Appoitment(combined,cell);

            Button7.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            Button5.Enabled = true;


        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bt_add_prescription(object sender, EventArgs e)
        {   Label1.Visible = true;
            Label1.Text = string.Empty; 
            Prescription prescription = new Prescription(PrescMedicine.Text, PrescSurname.Text);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            if (result.IsValid == false)
            {
                Label1.ForeColor = Color.Red;
                
                foreach (ValidationFailure failure in result.Errors)
                       Label1.Text = failure.ErrorMessage;
                    
            }
            else
            {
                Label1.Text = "Correct";
                Label1.ForeColor = Color.Green;
                AppoitmentDetails appoitmentDetails = new AppoitmentDetails();
                int cell = Int32.Parse(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
                appoitmentDetails.Add_prescription(cell,PrescMedicine.Text + PrescSurname.Text);
                PrescMedicine.Text = string.Empty;
                PrescSurname.Text = string.Empty;
                
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            int cell = Int32.Parse(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);

            AppoitmentDetails appoitmentDetails = new AppoitmentDetails();
            appoitmentDetails.Adding_Results(cell, TextBox4.Text);
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int cell = Int32.Parse(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            AppoitmentDetails appoitmentDetails = new AppoitmentDetails();
            DataTable dt = new DataTable();
            dt = appoitmentDetails.All_appoitments_of_current_patient(cell);
            
           
           TextBox4.Text = dt.Rows[ListBox1.SelectedIndex]["AD_appointment_description"].ToString();
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GridView1_SelectedIndexChanged(sender, e);
        }

        protected void RefExamination_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {


            


            Label2.Visible = true;
            Label2.Text = string.Empty;
            Referrals referal = new Referrals(RefExamination.Text);
            Referral_Validation validator = new Referral_Validation();
            ValidationResult result = validator.Validate(referal);

            if (result.IsValid == false)
            {
                Label2.ForeColor = Color.Red;

                foreach (ValidationFailure failure in result.Errors)
                    Label2.Text = failure.ErrorMessage;

            }
            else
            {
                Label2.Text = "Correct";
                Label2.ForeColor = Color.Green;
                int cell = Int32.Parse(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
                AppoitmentDetails appoitmentDetails = new AppoitmentDetails();
                appoitmentDetails.Add_refferal(cell, RefExamination.Text);
                RefExamination.Text = string.Empty;
            }

            
        }
    }
}