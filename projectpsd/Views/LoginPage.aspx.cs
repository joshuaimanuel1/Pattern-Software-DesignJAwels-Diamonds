using System;
using System.Web.UI;
using projectpsd.Handlers;
using projectpsd.Utils;
using projectpsd.Model;

namespace projectpsd.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private readonly AuthHandler authHandler;

        public LoginPage()
        {
            authHandler = new AuthHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.IsLoggedIn())
                {
                    Response.Redirect("~/Views/Jewels/Home.aspx");
                    return;
                }

                MsUser autoLoggedInUser = authHandler.TryAutoLoginFromCookie();
                if (autoLoggedInUser != null)
                {
                    Response.Redirect("~/Views/Jewels/Home.aspx");
                }
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin(false);
        }

        protected void BtnLoginAdmin_Click(object sender, EventArgs e)
        {
            PerformLogin(true);
        }

        private void PerformLogin(bool isAdminLoginAttempt)
        {
            lblErrorMessage.Text = "";

            if (!Page.IsValid)
            {
                return;
            }

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            bool rememberMe = chkRememberMe.Checked;

            MsUser loggedInUser = authHandler.LoginUser(email, password, rememberMe);

            if (loggedInUser != null)
            {

                if (isAdminLoginAttempt && loggedInUser.UserRole != "Admin")
                {
                    lblErrorMessage.Text = "Access denied. This login option is only for Administrators.";
                    authHandler.LogoutUser();
                    return;
                }


                Response.Redirect("~/Views/Jewels/Home.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Incorrect email or password.";
            }
        }
    }
}