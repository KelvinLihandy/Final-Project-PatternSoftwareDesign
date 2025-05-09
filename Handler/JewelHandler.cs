using FinalProjectPSD.Factory;
using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace FinalProjectPSD.Handler
{
    public class JewelHandler
    {

        public static bool InsertJewel(string name, int categoryId, int brandId, int price, int year)
        {
            MsJewel newJewel = FactoryClass.CreateJewel(name, categoryId, brandId, price, year);
            return MsJewelRepository.PostNewJewel(newJewel);
        }

        public static List<MsJewel> GetAllJewels()
        {
            return MsJewelRepository.GetAllJewels();
        }

        public static MsJewel GetJewelById(int jewelId)
        {
            if (jewelId <= 0)
            {
                throw new ArgumentException("Jewel ID must be greater than zero.");
            }

            MsJewel jewel = MsJewelRepository.GetJewelById(jewelId);

            if (jewel == null)
            {
                throw new Exception("Jewel not found.");
            }

            return jewel;
        }

        public static bool UpdateJewel(int jewelId, string name, int categoryId, int brandId, int price, int year)
        {
            if (jewelId <= 0)
            {
                throw new ArgumentException("Jewel ID must be greater than zero.");
            }

            MsJewel existingJewel = MsJewelRepository.GetJewelById(jewelId);

            if (existingJewel == null)
            {
                throw new Exception("Jewel not found.");
            }

            existingJewel.JewelName = name;
            existingJewel.CategoryID = categoryId;
            existingJewel.BrandID = brandId;
            existingJewel.JewelPrice = price;
            existingJewel.JewelReleaseYear = year;

            return MsJewelRepository.UpdateJewel(existingJewel);
        }
    }
}