using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Repository
{
	public class MsJewelRepository
	{
		private static DatabaseJewel db = Singleton.GetDatabase();

		public static bool PostNewJewel(MsJewel newJewel)
		{
			db.MsJewels.Add(newJewel);
			return db.SaveChanges() > 0;
		}

		//public static MsUser GetUserByEmail(string email)
		//{
		//	return (from user in db.MsUsers where user.UserEmail.Equals(email) select user).FirstOrDefault();
		//      }

		//public static MsUser GetUser(string email, string password)
		//{
		//	return (from user in db.MsUsers where user.UserEmail.Equals(email) && user.UserPassword.Equals(password) select user).FirstOrDefault();
		//}
		//public static MsJewel GetJewels
	}
}