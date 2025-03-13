using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Factory
{
    public class Factory
    {
        public static MsJewel createJewel(int brandId, int categoryId, string name, int price, int releaseYear)
        {
            MsJewel newJewel = new MsJewel();
            newJewel.BrandID = brandId;
            newJewel.CategoryID = categoryId;
            newJewel.JewelName = name;
            newJewel.JewelPrice = price;
            newJewel.JewelReleaseYear = releaseYear;
            return newJewel;
        }
        public static MsUser createUser(string name, string pass, string email, DateTime dob, string gender, string role)
        {
            MsUser newUser = new MsUser();
            newUser.UserName = name;
            newUser.UserPassword = pass;
            newUser.UserEmail = email;
            newUser.UserDOB = dob;
            newUser.UserGender = gender;
            return newUser;
        }
    }
}