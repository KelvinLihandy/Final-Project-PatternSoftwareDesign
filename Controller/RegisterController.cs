using FinalProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace FinalProjectPSD.Controller
{
	public class RegisterController
	{
		public static bool ValidateEmail(string email)
		{
            const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
			return (string.IsNullOrWhiteSpace(email) || Regex.IsMatch(email, emailPattern) == false || MsUserRepository.GetUserByEmail(email) != null);
        }
		public static bool ValidateUserName(string username)
        {
            return (string.IsNullOrWhiteSpace(username) || username.Length < 3 || username.Length > 25);

        }
        public static bool ValidatePassword(string password)
        {
            const string passPattern = @"^[a-zA-Z0-9]+$";
            return (string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 20 || Regex.IsMatch(password, passPattern) == false);
        }
        public static bool ValidateConfirm(string password, string confirm)
        {
            return (string.IsNullOrWhiteSpace(confirm) || String.Equals(password, confirm) == false);
        }
        public static bool ValidateGender(string gender)
        {
            return (string.IsNullOrEmpty(gender) || !(gender.Equals("male") || gender.Equals("female")));
        }
        public static bool ValidateDob(string dob)
        {
            DateTime minDate = new DateTime(2010, 1, 1);
            DateTime dobConv;
            return (string.IsNullOrEmpty(dob) || !DateTime.TryParse(dob, out dobConv) || dobConv >= minDate);

        }
    }
}