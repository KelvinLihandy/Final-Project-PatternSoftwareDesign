using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;

namespace FinalProjectPSD.Handler
{
    public class JewelDetailHandler
    {
        public static MsJewel GetJewelById(int id)
        {
            return JewelDetailRepository.GetJewelById(id);
        }

        public static string AddToCart(int userId, int jewelId)
        {
            return JewelDetailRepository.AddToCart(userId, jewelId);
        }

        public static string DeleteJewel(int id)
        {
            return JewelDetailRepository.DeleteJewel(id);
        }
    }
}

