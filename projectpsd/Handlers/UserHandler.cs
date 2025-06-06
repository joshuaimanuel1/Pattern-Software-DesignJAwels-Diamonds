using System;
using projectpsd.Model;
using projectpsd.Repositories;
using projectpsd.Factories;
using projectpsd.Utils;

namespace projectpsd.Handlers
{
    public class UserHandler
    {
        private UserRepository userRepository;

        public UserHandler()
        {
            userRepository = new UserRepository();
        }

        public MsUser GetUserProfile(int userId)
        {
            return userRepository.GetById(userId);
        }


        public string ChangePassword(int userId, string oldPassword, string newPassword, string confirmPassword)
        {
            MsUser user = userRepository.GetById(userId);

            if (user == null)
            {
                return "User not found.";
            }

           
            if (!SecurityHelper.VerifyPassword(oldPassword, user.UserPassword))
            {
                return "Old Password must be the same as the current password.";
            }

            
            if (!ValidationHelper.IsAlphanumeric(newPassword) || !ValidationHelper.IsLengthBetween(newPassword, 8, 25))
            {
                return "New Password length must be 8 to 25 characters and alphanumeric.";
            }

            
            if (newPassword != confirmPassword)
            {
                return "Confirm Password must be the same with new password.";
            }

            MsUser updatedUser = UserFactory.UpdatePassword(user, newPassword);

            
            userRepository.Update(updatedUser);

            return "Password changed successfully.";
        }
    }
}