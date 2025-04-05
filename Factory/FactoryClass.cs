using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Factory
{
    public class FactoryClass
    {
        public static MsJewel CreateJewel(int brandId, int categoryId, string name, int price, int releaseYear)
        {
            MsJewel newJewel = new MsJewel
            {
                BrandID = brandId,
                CategoryID = categoryId,
                JewelName = name,
                JewelPrice = price,
                JewelReleaseYear = releaseYear
            };
            return newJewel;
        }
        public static MsUser CreateUser(string name, string pass, string email, DateTime dob, string gender, string role = "customer")
        {
            MsUser newUser = new MsUser
            {
                UserName = name,
                UserPassword = pass,
                UserEmail = email,
                UserDOB = dob.Date,
                UserGender = gender,
                UserRole = role
            };
            return newUser;
        }
    }
}