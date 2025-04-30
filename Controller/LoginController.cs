using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace FinalProjectPSD.Controller
{
	public class LoginController
	{
        private static MsUser user;
        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return "Email is required";
            else
            {
                user = MsUserRepository.GetUserByEmail(email);
                if (user == null) return "Email does not exist";
            }
            return "";
            
        }
        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return "Password is required";
            else if (password.Equals(user.UserPassword) == false) return "Incorrect password";
            return "";
        }
    }
}