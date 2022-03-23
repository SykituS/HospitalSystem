using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administation;
using Administration;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnCancel.Attributes.Add("OnClick", "window.close()");

            if (!this.IsPostBack)
            {
                CancelUnexpectedRePost();
            }

            //Checking whether the user is already logged in
            if (LogSys.CheckIfLogged())
                Response.Redirect("AdministratorPage.aspx");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            CancelUnexpectedRePost();
            //Starting the login process 
            LogSys.LoginToSystem(TBLogin.Text, TBPassword.Text);

            //Checking whether the user has successfully logged in
            if (LogSys.CheckIfLogged())
            {
                if (LogSys.CheckPosition())
                    Response.Redirect("AdministratorPage.aspx");

                Response.Redirect("EmployeePage.aspx");
            }

            int attempt = MySession.Current.Attempt;
            if (attempt > 1)
            {
                attempt--;
                MySession.Current.Attempt = attempt;
                LabelWarnings.Visible = true;
                LabelWarnings.Text = LogSys.GetAttempTextTry();

            }
            else
            {
                attempt--;
                MySession.Current.Attempt = attempt;
                LabelWarnings.Text = LogSys.GetAttempTextTry();
                BtnLogin.Enabled = false;
                TBPassword.Enabled = false;
                TBLogin.Enabled = false;
                Session["Timer"] = DateTime.Now.AddMinutes(1).ToString();
                LabelWarnings.Visible = false;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //Cancelling the process of logging in
            TBLogin.Text = "";
            TBPassword.Text = "";
        }
        protected void BtnResetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormToResetPassPage.aspx");

        }

        private void CancelUnexpectedRePost()
        {
            int attempt = 3;

            if (attempt < 3)
            {
                LabelWarnings.Visible = true;
                LabelWarnings.Text = LogSys.GetAttempTextTry();
            }

            string clientCode = _repostcheckcode.Value;

            string serverCode = Session["_repostcheckcode"] as string;

            if (!IsPostBack || clientCode.Equals(serverCode))
            {
                string code = Guid.NewGuid().ToString();
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
            int attempt = (int)MySession.Current.Attempt;
            if (attempt == 0)
            {
                int seconds = (Int32)(DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalSeconds + 0.5);
                if (seconds >= 0)
                {
                    string textTime = string.Format(" {0}m {1}s", seconds / 60, seconds % 60);
                    LabelWarnings.Text = LogSys.GetAttempTextBlock(textTime);
                    litMsg.Text = LogSys.GetAttempTextBlock(textTime);

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
    }
}