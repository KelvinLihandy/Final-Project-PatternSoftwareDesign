using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.Repository
{
    public class JewelDetailRepository
    {
        private static DatabaseJewel db = new DatabaseJewel();

        public static MsJewel GetJewelById(int id)
        {
            return db.MsJewels.FirstOrDefault(j => j.JewelID == id);
        }

        public static string DeleteJewel(int id)
        {
            MsJewel jewel = db.MsJewels.FirstOrDefault(j => j.JewelID == id);
            if (jewel == null) return "Jewel not found.";

            db.MsJewels.Remove(jewel);
            db.SaveChanges();
            return "Jewel deleted successfully.";
        }

        public static string AddToCart(int userId, int jewelId)
        {
            Cart cart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cart != null)
            {
                cart.Quantity += 1;
            }
            else
            {
                cart = new Cart
                {
                    UserID = userId,
                    JewelID = jewelId,
                    Quantity = 1
                };
                db.Carts.Add(cart);
            }

            db.SaveChanges();
            return "Item added to cart.";
        }
    }
}
