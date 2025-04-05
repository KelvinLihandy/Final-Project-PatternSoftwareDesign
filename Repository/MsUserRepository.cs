using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Repository
{
	public class MsUserRepository
	{
		private static DatabaseJewel db = Singleton.GetDatabase();

		public static void PostNewUser(MsUser newUser)
		{
			db.MsUsers.Add(newUser);
			db.SaveChanges();
		}
		
		public static MsUser GetUserByEmail(string email)
		{
			return (from user in db.MsUsers where user.UserEmail.Equals(email) select user).FirstOrDefault();
        }

		public static MsUser GetUser(string email, string password)
		{
			return (from user in db.MsUsers where user.UserEmail.Equals(email) && user.UserPassword.Equals(password) select user).FirstOrDefault();
		}
	}
}