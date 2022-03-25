using Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Preventing non logged user to get to this site
            if (!LogSys.CheckIfLogged())
                Response.Redirect("~/Pages/MainPages/Default");

            //Dynamic label that show postion of logged employee
            LabelPostion.Text = "<h1>You are logged as " + MySession.Current.Position + " </h1>";
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MainPages/CancelationPage");
        }

        protected void BtnDoctorPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoctorsPages/DoctorPage");
        }
    }
}