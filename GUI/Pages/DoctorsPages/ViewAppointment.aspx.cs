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

namespace GUI
{
    public partial class ViewAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            foreach (DateTime data in GetAppoitments.Get_Dates())
                Calendar1.SelectedDates.Add(data);

            Calendar1.Visible = true;

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime day = Calendar1.SelectedDate;

            GridView1.DataSource = GetAppoitments.Get_Info_Appointment(day);
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

            DateTime day = Calendar1.SelectedDate;

            GridView1.DataSource = GetAppoitments.Get_Info_Appointment(day);
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

            GridView2.DataSource = AppoitmentDetails.Get_Details(cell);
            GridView2.DataBind();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);

            }

        }
    }
}