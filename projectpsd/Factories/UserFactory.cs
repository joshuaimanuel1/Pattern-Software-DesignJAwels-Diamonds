using System;
using projectpsd.Model;
using projectpsd.Utils;

namespace projectpsd.Factories
{
    public static class UserFactory
    {
        public static MsUser CreateNewCustomer(string email, string username, string password, string gender, DateTime dob)
        {
            string hashedPassword = SecurityHelper.HashPassword(password);

            return new MsUser
            {
                UserEmail = email,
                UserName = username,
                UserPassword = hashedPassword,
                UserGender = gender,
                UserDOB = dob,
                UserRole = "Customer"
            };
        }

        public static MsUser UpdatePassword(MsUser existingUser, string newPassword)
        {
            if (existingUser == null) throw new ArgumentNullException(nameof(existingUser));

            existingUser.UserPassword = SecurityHelper.HashPassword(newPassword);
            return existingUser;
        }
    }
}