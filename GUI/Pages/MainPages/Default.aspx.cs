using Administration;
using System;
using System.Web.UI;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Checking whether the page has not been refreshed
            if (!this.IsPostBack)
                CancelUnexpectedRePost();

            //Checking whether the user is already logged in
            if (LogSys.CheckIfLogged())
            {
                switch (MySession.Current.Position)
                {
                    case "administrator":
                        Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
                        break;
                    case "doctor":
                        Response.Redirect("~/Pages/Doctorspages/DoctorPanelPage");
                        break;
                    case "medical clinic staff member":
                        Response.Redirect("~/Pages/medicalStaffMemberPages/MedicalStaffPanelPage");
                        break;
                    case "patient management staff":
                        Response.Redirect("~/Pages/PatientManagementStaffPages/PatientManagementPanelPage");
                        break;
                    case "manager":
                        Response.Redirect("~/Pages/ManagerPages/ManagerPanelPage");
                        break;
                }
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            MySession.Current.SetTime = SettingsPanel.ShowTime();
            //Cancel the side effects of refreshing the page
            CancelUnexpectedRePost();

            //Starting the login process 
            LogSys.LoginToSystem(TBLogin.Text, TBPassword.Text);

            //Checking whether the user has successfully logged in
            if (LogSys.CheckIfLogged())
            {
                if (MySession.Current.ForcedPasswordChange == 1)
                {
                    Response.Redirect("ForcedPasswordChangePage");
                }

                switch (MySession.Current.Position)
                {
                    case "Administrator_of_all":
                        Response.Redirect("~/Pages/HeadAdministrator/AdministratorMainPanel");
                        break;
                    case "administrator":
                        Response.Redirect("~/Pages/AdministratorPages/AdministratorPanelPage");
                        break;
                    case "doctor":
                        Response.Redirect("~/Pages/Doctorspages/DoctorPanelPage");
                        break;
                    case "medical clinic staff member":
                        Response.Redirect("~/Pages/medicalStaffMemberPages/MedicalStaffPanelPage");
                        break;
                    case "patient management staff":
                        Response.Redirect("~/Pages/PatientManagementStaffPages/PatientManagementPanelPage");
                        break;
                    case "manager":
                        Response.Redirect("~/Pages/ManagerPages/ManagerPanelPage");
                        break;
                }
            }

            if (MySession.Current.Attempt > 1)
            {
                MySession.Current.Attempt--;
                LabelWarnings.Visible = true;
                LabelWarnings.Text = LogSys.GetAttempTextTry();
            }
            else
            {
                MySession.Current.Attempt--;
                LabelWarnings.Text = LogSys.GetAttempTextTry();

                BtnLogin.Enabled = false;
                TBPassword.Enabled = false;
                TBLogin.Enabled = false;
                LabelWarnings.Visible = false;
            }
        }

        protected void BtnResetPassword_Click(object sender, EventArgs e)
        {
            //Redirecting to the website with the password reset form
            Response.Redirect("FormToResetPassPage.aspx");
        }

        private void CancelUnexpectedRePost()
        {
            if (MySession.Current.Attempt < 3)
            {
                LabelWarnings.Visible = true;
                LabelWarnings.Text = LogSys.GetAttempTextTry();
            }

            if (MySession.Current.Attempt <= 0)
            {
                LabelWarnings.Visible = false;
                BtnLogin.Enabled = false;
                TBPassword.Enabled = false;
                TBLogin.Enabled = false;
            }

            /* Function that prevents side effect of page refreshing 
             * On the first start-up both clientCode and serverCode are empty
             * The Guid function creates a new "register" of the page
            */

            string clientCode = _repostcheckcode.Value;

            string serverCode = Session["_repostcheckcode"] as string;

            //Checking whether the page has not been refreshed or whether the clientCode string equals serverCode string
            if (!IsPostBack || clientCode.Equals(serverCode))
            {
                //Creating a string with the current page register
                string code = Guid.NewGuid().ToString();

                //Inserting the string above into the values below
                _repostcheckcode.Value = code;
                Session["_repostcheckcode"] = code;
            }
            else
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (MySession.Current.Attempt <= 0)
            {
                if (MySession.Current.SetTime >= 0)
                {
                    string textTime = string.Format(" {0}m {1}s", MySession.Current.SetTime / 60, MySession.Current.SetTime % 60);
                    LabelWarnings.Text = LogSys.GetAttempTextBlock(textTime);
                    litMsg.Text = LogSys.GetAttempTextBlock(textTime);
                    MySession.Current.SetTime--;
                }
                else
                {
                    Session["redirect"] = "yes";
                    LabelWarnings.Text = "";
                    MySession.Current.Attempt = 3;

                    BtnLogin.Enabled = true;
                    TBPassword.Enabled = true;
                    TBLogin.Enabled = true;
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            string strScript = "window.close();";
            ScriptManager.RegisterStartupScript(this, typeof(string), "key", strScript, true);
        }
    }
}