using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdministration
{
    public class Calendar
    {
        private int year;
        private int month;
        private TimeSpan startHour = new TimeSpan(7, 0, 0); //Clinic starts at 7:00
        private TimeSpan endHour = new TimeSpan(20, 0, 0); //Clinic ends at 20:00

        public Calendar(int year, int month)
        {
            this.year = year;
            this.month = month;
        }

        public DataTable GenerateCalendarForMonth()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Start Hour");
            dt.Columns.Add("Finish Hour");

            int day = 1;

            TimeSpan hour;
            TimeSpan breakHour;
            DataRow dr;

            //This loop works from the first day of the month to the last
            while (day <= DateTime.DaysInMonth(year, month))
            {
                hour = startHour;
                breakHour = hour + TimeSpan.FromHours(4d); //Break is scheduled in 4 hours so we increment our start hour by 4 hours

                //This loop works from the first hour of work to the last
                while (hour < endHour)
                {
                    //If the day is Sunday, stop generating hours for this day (clinic works from Monday to Saturday)
                    if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Sunday)
                        break;

                    dr = dt.NewRow();

                    dr["Date"] = new DateTime(year, month, day).ToString("yyy/MM/dd");

                    dr["Start Hour"] = hour.ToString(@"hh\:mm"); //Start of visit
                    hour += TimeSpan.FromMinutes(20d); //Our hour increments by 20 minutes (standard time of visit)
                    dr["Finish Hour"] = hour.ToString(@"hh\:mm"); //End of visit

                    //Check if there's a break (every four hour between 7:00 and 20:00)
                    if (hour == breakHour)
                    {
                        hour += TimeSpan.FromMinutes(20d); //Break takes 20 minutes so we increment our hour by 20 minutes
                        breakHour += TimeSpan.FromHours(4d); //Next break is scheduled in 4 hours so we increment our break hour by 4 hours
                    }
                    dt.Rows.Add(dr);
                }
                day++; //End of the day so we increment our day by 1
            }
            return dt;
        }
    }
}
