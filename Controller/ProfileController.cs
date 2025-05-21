using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Handler;
using FinalProjectPSD.Model;


namespace FinalProjectPSD.Controller
{
    public class ProfileController
    {
        public static MsUser GetUser(int userId)
        {
            return ProfileHandler.GetUserById(userId);
        }

        public static string ChangePassword(int userId, string oldPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "All fields must be filled.";
            }

            if (newPassword.Length < 8 || newPassword.Length > 25 || !newPassword.All(char.IsLetterOrDigit))
            {
                return "New password must be 8-25 alphanumeric characters.";
            }

            if (newPassword != confirmPassword)
            {
                return "New password and confirmation do not match.";
            }

            return ProfileHandler.ChangePassword(userId, oldPassword, newPassword);
        }
    }
}
