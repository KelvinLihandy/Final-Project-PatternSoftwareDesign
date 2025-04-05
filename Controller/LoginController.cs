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
        public static bool ValidateEmail(string email)
        {
            user = MsUserRepository.GetUserByEmail(email);
            return (string.IsNullOrWhiteSpace(email) || (user  == null));
        }
        public static bool ValidatePassword(string password)
        {
            return (string.IsNullOrWhiteSpace(password) || password.Equals(user.UserPassword) == false);
        }
    }
}