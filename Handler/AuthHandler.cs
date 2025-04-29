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
		public static bool InsertUser(string email, string username, string password, string gender, string dob)
		{
			MsUser newUser = FactoryClass.CreateUser(username, password, email, DateTime.Parse(dob), gender);
            return MsUserRepository.PostNewUser(newUser);
        }


	}
}