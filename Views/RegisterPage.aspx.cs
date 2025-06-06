using projectpsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectpsd.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string Email = EmailTextBox.Text.Trim();
            string Username = UsernameTextBox.Text.Trim();
            string Password = PasswordTextBox.Text.Trim();
            string confirmPassword = ConfirmPasswordTextBox.Text.Trim();
            string Gender = GenderRadioButtonList.SelectedValue;
            DateTime dob;

            List<string> list = new List<string>();
            if (string.IsNullOrEmpty(Email) || !Email.Contains("@") || !Email.Contains("."))
            {
                list.Add("Email must be a valid format.");
            }
            else if (db.MsUsers.Any(u => u.UserEmail == Email))
            {
                list.Add("Email already registered.");
            }

            if (Username.Length < 3 || Username.Length > 25)
            {
                list.Add("Username must be between 3 - 25 characters.");
            }

            if (Password.Length < 8 || Password.Length > 20 || !Password.All(char.IsLetterOrDigit))
            {
                list.Add("Password must be an alphanumerical and between 8 - 20 characters");
            }

            if (Password ! = confirmPassword)
            {
                list.Add("Password does not match.");
            }

            if (Gender != "Male" && Gender != "Female")
            {
                list.Add("Gender must be choosen.");
            }

            if (!DateTime.TryParse(DOBTextBox.Text, out dob))
            {
                list.Add("Enter a valid Date of Birth");
            }
            else if (dob >= new DateTime(2010, 1, 1))
            {
                list.Add("Date of Birth must be earlier than 01/01/2010");
            }

            if (list.Count > 0)
            {
                ValidationLabel.Text = string.Join("<br/>", list);
                return;
            }
            else
            {
                ValidationLabel.Text = "Successfull";
                MsUser user = new MsUser();
                user.UserName = Username;
                user.UserPassword = Password;
                user.UserGender = Gender;
                user.UserEmail = EmailTextBox.Text;
                user.UserDOB = dob;
                user.UserRole = "Customer";

                try
                {
                    db.MsUsers.Add(user);
                    db.SaveChanges();
                    Response.Redirect("Login.aspx");
                }
                catch (Exception ex)
                {
                    ValidationLabel.Text = "Error occured: " + ex.Message;
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}