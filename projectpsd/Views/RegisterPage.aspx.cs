using System;
using System.Web.UI;
using projectpsd.Handlers;
using projectpsd.Utils;

namespace projectpsd.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        private readonly AuthHandler authHandler;

        public RegisterPage()
        {
            authHandler = new AuthHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.IsLoggedIn())
                {
                    Response.Redirect("~/Views/Jewels/Home.aspx"); // KOREKSI PATH
                    return;
                }
            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (!Page.IsValid)
            {
                return;
            }

            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string gender = rblGender.SelectedValue;
            DateTime dob;

            if (!DateTime.TryParse(txtDateOfBirth.Text, out dob))
            {
                lblErrorMessage.Text = "Invalid Date of Birth format.";
                return;
            }

            string result = authHandler.RegisterUser(email, username, password, confirmPassword, gender, dob);

            if (result == "Registration successful.")
            {
                Response.Redirect("~/Views/LoginPage.aspx?reg=success");
            }
            else
            {
                lblErrorMessage.Text = result;
            }
        }
    }
}