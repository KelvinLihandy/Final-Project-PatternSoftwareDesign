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
	public class JewelController
	{
        public static string ValidateName(string name)
        {
            return (name.Length >= 3 && name.Length <= 25) ? "" : "Must be between 3 to 25 characters (inclusive)";
        }
        public static string ValidateCategory(string category)
        {
            List<MsCategory> categoryList = MsCategoryRepository.GetCategories();
            return categoryList.Any(c => c.CategoryName == category) ? "" : "Must be selected from a dropdown list of category names.";
        }
        public static string ValidateBrand(string brand)
        {
            List<MsBrand> brandList = MsBrandRepository.GetBrands();
            return brandList.Any(b => b.BrandName == brand) ? "" : "Must be selected from a dropdown list of brands.";
        }
        public static object[] ValidatePrice(string priceString)
        {
            if (!int.TryParse(priceString, out int price))
            {
                return  new object[] { "Must be a number and more than $25" };
            }
            return new object[] { price >= 25 ? "" : "Must be a number and more than $25", price };
        }
        public static object[] ValidateYear(string yearString)
        {
            if (!int.TryParse(yearString, out int year))
            {
                return new object[] { "Must be a number and less than the current year." };
            }
            return new object[] { year < DateTime.Now.Year ? "" : "Must be a number and less than the current year.", year };
        }
    }
}