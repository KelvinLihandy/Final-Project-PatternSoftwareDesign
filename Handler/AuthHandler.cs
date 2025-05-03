using FinalProjectPSD.Factory;
using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Handler
{
	public class AuthHandler
	{
		public static List<MsUser> GetUsers()
		{
			return MsUserRepository.GetUsers();
		}

		public static MsUser GetUser(string email, string password = null)
		{
			return MsUserRepository.GetUser(email, password);
		}

		public static bool InsertUser(string email, string username, string password, string gender, string dob)
		{
			MsUser newUser = FactoryClass.CreateUser(username, password, email, DateTime.Parse(dob), gender);
            return MsUserRepository.PostNewUser(newUser);
        }


	}
}