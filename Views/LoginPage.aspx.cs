using projectpsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectpsd.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserEmail"] != null && Request.Cookies["UserPassword"] != null)
                {
                    string Email = Request.Cookies["UserEmail"].Value;
                    string Password = Request.Cookies["UserPassword"].Value;

                    var user = db.MsUsers.FirstOrDefault(u => u.UserEmail == Email && u.UserPassword == Password);
                    if (user != null)
                    {
                        Session["user"] = user;
                        Session["role"] = user.UserRole;
                        Session["userID"] = user.UserID;
                        Response.Redirect("HomePage.aspx");
                    }
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string Email = EmailTextBox.Text.Trim();
            string Password = PasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorLabel.Text = "Email and Password must be filled.";
                return;
            }

            var user = db.MsUsers.FirstOrDefault(u => u.UserEmail == Email);
            if (user == null)
            {
                ErrorLabel.Text = "Email is not registered, please Register";
                return;
            }

            if (user.UserPassword != Password)
            {
                ErrorLabel.Text = "Incorrect Password";
                return;
            }

            // Login Success
            Session["user"] = user;
            Session["role"] = user.UserRole;
            Session["userID"] = user.UserID;

            // saving cookies authomaticly if remember me button is checked
            if (RememberCheckBox.Checked)
            {
                HttpCookie emailCookie = new HttpCookie("UserEmail", Email);
                HttpCookie passCookie = new HttpCookie("UserPassword", Password);

                emailCookie.Expires = DateTime.Now.AddDays(7);
                passCookie.Expires = DateTime.Now.AddDays(7);

                Response.Cookies.Add(emailCookie);
                Response.Cookies.Add(passCookie);
            }
            Response.Redirect("HomePage.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }
    }
}