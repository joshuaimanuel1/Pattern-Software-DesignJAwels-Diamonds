using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using projectpsd.Handlers;
using projectpsd.Utils;
using projectpsd.Model;

namespace projectpsd.Views.Profile
{
    public partial class Profile : System.Web.UI.Page
    {
        private readonly UserHandler userHandler;
        private int currentUserId;

        public Profile()
        {
            userHandler = new UserHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
 
            if (!SessionManager.IsLoggedIn())
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            currentUserId = SessionManager.GetCurrentUserId();

            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
        {
            MsUser user = userHandler.GetUserProfile(currentUserId);

            if (user != null)
            {
                lblUsername.Text = user.UserName;
                lblEmail.Text = user.UserEmail;
                lblGender.Text = user.UserGender;
                lblDateOfBirth.Text = user.UserDOB.ToShortDateString(); 
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "User profile not found.";
            }
        }

        protected void ValidateNewPassword(object source, ServerValidateEventArgs args)
        {
            string newPassword = args.Value;
            args.IsValid = ValidationHelper.IsAlphanumeric(newPassword) && ValidationHelper.IsLengthBetween(newPassword, 8, 25);
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!Page.IsValid)
            {
                return;
            }

            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmNewPassword = txtConfirmNewPassword.Text;

            
            string result = userHandler.ChangePassword(currentUserId, oldPassword, newPassword, confirmNewPassword);

            if (result == "Password changed successfully.")
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = result;

                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmNewPassword.Text = "";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = result;
            }
        }
    }
}