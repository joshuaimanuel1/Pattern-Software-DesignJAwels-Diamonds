using System;
using projectpsd.Model;
using projectpsd.Repositories;
using projectpsd.Factories;
using projectpsd.Utils;

namespace projectpsd.Handlers
{
    public class AuthHandler
    {
        private UserRepository userRepository;

        public AuthHandler()
        {
            userRepository = new UserRepository();
        }

        public string RegisterUser(string email, string username, string password, string confirmPassword, string gender, DateTime dob)
        {

            if (!ValidationHelper.IsValidEmail(email))
            {
                return "Email must be a valid email format.";
            }
            if (userRepository.GetUserByEmail(email) != null)
            {
                return "Email must be unique in the user database.";
            }

            if (!ValidationHelper.IsLengthBetween(username, 3, 25))
            {
                return "Username must be between 3 to 25 characters (inclusive).";
            }
            if (userRepository.GetUserByUsername(username) != null)
            {
                return "Username already exists.";
            }

            if (!ValidationHelper.IsAlphanumeric(password) || !ValidationHelper.IsLengthBetween(password, 8, 20))
            {
                return "Password must be alphanumeric and 8 to 20 characters (inclusive).";
            }

            if (password != confirmPassword)
            {
                return "Confirm Password must be the same as password.";
            }

            if (string.IsNullOrWhiteSpace(gender) || (gender != "Male" && gender != "Female"))
            {
                return "Gender must be chosen using radio button and must be Male or Female.";
            }

            if (!ValidationHelper.IsDateOfBirthEarlierThan2010(dob))
            {
                return "Date of Birth must be earlier than 01/01/2010.";
            }

           
            MsUser newUser = UserFactory.CreateNewCustomer(email, username, password, gender, dob);

            userRepository.Add(newUser);

            return "Registration successful.";
        }

        public MsUser LoginUser(string email, string password, bool rememberMe)
        {

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            MsUser user = userRepository.GetUserByEmail(email);

            if (user != null && SecurityHelper.VerifyPassword(password, user.UserPassword))
            {
                
                SessionManager.SetCurrentUser(user);

                
                if (rememberMe)
                {
                    CookieManager.SetRememberMeCookie(user.UserEmail, user.UserPassword);
                }
                else
                {
                    CookieManager.ClearRememberMeCookie();
                }

                return user;
            }

            return null;
        }

        public void LogoutUser()
        {
            SessionManager.ClearSession();
            CookieManager.ClearRememberMeCookie();
        }

        public MsUser TryAutoLoginFromCookie()
        {
            var cookie = CookieManager.GetRememberMeCookie();
            if (cookie != null)
            {
                string email = cookie["Email"];
                string hashedPassword = cookie["PasswordHash"];

                MsUser user = userRepository.GetUserByEmailAndPassword(email, hashedPassword);

                if (user != null)
                {
                    SessionManager.SetCurrentUser(user);
                    return user;
                }
            }
            return null;
        }
    }
}