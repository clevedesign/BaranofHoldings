using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            if (ValidateUser(Login1.UserName, Login1.Password))
            {
                FormsAuthentication.SetAuthCookie(Login1.UserName, Login1.RememberMeSet);

                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                }
                else
                {
                    Response.Redirect("/");
                }
            }
            else
            {
                Literal txtErrMsg = Login1.FindControl("FailureText") as Literal;
                txtErrMsg.Text = "Log in failed. Please check your username and password.";
                e.Cancel = true;
            }
        }

        private bool ValidateUser(string userName, string password)
        {
            bool isValid = false;
            string user = ConfigurationManager.AppSettings["userName"];
            string pwd = ConfigurationManager.AppSettings["password"];

            if (userName.Equals(user, StringComparison.OrdinalIgnoreCase) && password.Equals(pwd))
            {
                isValid = true;
            }

            return isValid;
        }
    }
}