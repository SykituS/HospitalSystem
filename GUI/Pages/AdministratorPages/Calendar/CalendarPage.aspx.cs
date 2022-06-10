using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAdministration;

namespace GUI
{
    public partial class CalendarPage : System.Web.UI.Page
    {
        DataTable generatedCalendar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                UpdateYears(DdlYears);
        }

        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(DdlYears.SelectedValue);
            int month = Convert.ToInt32(DdlMonths.SelectedValue);

            generatedCalendar = GenerateCalendar(year, month);

            UpdateDaysForFilter(DdlFilterDays);

            GvCalendar.DataSource = generatedCalendar;
            GvCalendar.DataBind();
        }

        protected void DdlFilterDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvCalendar.DataSource = FilterDataView(DdlFilterDays);
            GvCalendar.DataBind();
        }

        protected void BtnBackToMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
        }

        //UpdateYears fills dropdownlist with years from now to 5 years back to 5 years ahead (e.g. today is 2022 so it will generate 2017-2027)
        private void UpdateYears(DropDownList ddl)
        {
            int year = DateTime.Now.Year;
            for (int i = year - 5; i <= year + 5; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                ddl.Items.Add(li);
            }
            ddl.Items.FindByText(year.ToString()).Selected = true;
        }

        //UpdateDaysForFilter fills our dropdownlist with days so we can filter by them
        private void UpdateDaysForFilter(DropDownList ddl)
        {
            ddl.Items.Clear();
            ListItem all = new ListItem("All", "0");
            ddl.Items.Add(all);

            DataView view = new DataView(generatedCalendar);
            DataTable distinctDays = view.ToTable(true, "Date");

            foreach (DataRow row in distinctDays.Rows)
            {
                DateTime date = Convert.ToDateTime(row["Date"]);

                ListItem li = new ListItem(date.ToString("dd"), date.ToString("yyy/MM/dd"));
                ddl.Items.Add(li);
            }
        }

        //FilterDataView method generates new calendar which is filtered by selected day
        private DataView FilterDataView(DropDownList ddlDays)
        {
            int year = Convert.ToInt32(DdlYears.SelectedValue);
            int month = Convert.ToInt32(DdlMonths.SelectedValue);

            DataView dv = new DataView(GenerateCalendar(year, month));
            string selectedDate = ddlDays.SelectedValue;

            if (selectedDate != "0")
                dv.RowFilter = string.Format("Date = '{0}'", selectedDate);

            return dv;
        }

        //GenerateCalendar method generates new calendar with the selected year and month
        private DataTable GenerateCalendar(int year, int month)
        {
            DataTable dt;

            BusinessAdministration.Calendar calendar = new BusinessAdministration.Calendar(year, month);
            dt = calendar.GenerateCalendarForMonth();

            return dt;
        }
    }
}