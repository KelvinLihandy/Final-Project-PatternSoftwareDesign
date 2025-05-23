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

		public static bool PostNewUser(MsUser newUser)
		{
			db.MsUsers.Add(newUser);
			return db.SaveChanges() > 0;
		}
		public static List<MsUser> GetUsers()
		{
			return (from user in db.MsUsers select user).ToList();
		}
		
		public static MsUser GetUser(string email, string password = null)
		{
			return (from user in db.MsUsers 
					where user.UserEmail.Equals(email) && (password == null || user.UserPassword.Equals(password)) 
					select user).FirstOrDefault();
		}

		public static MsUser GetUserById(int id)
		{
            return (from user in db.MsUsers
                    where user.UserID == id
                    select user).FirstOrDefault();
        }
	}
}