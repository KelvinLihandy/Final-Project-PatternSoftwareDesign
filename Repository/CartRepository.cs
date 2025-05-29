using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.Repository
{
    public class CartRepository
    {
        private static DatabaseJewel db = Singleton.GetDatabase();

        public DataTable GetCartItems(int userId)
        {
            // Query cart items using Entity Framework
            var cartItems = (from cart in db.Carts
                             join jewel in db.MsJewels on cart.JewelID equals jewel.JewelID
                             join brand in db.MsBrands on jewel.BrandID equals brand.BrandID
                             where cart.UserID == userId
                             select new
                             {
                                 Id = jewel.JewelID,
                                 Name = jewel.JewelName,
                                 Price = jewel.JewelPrice,
                                 Brand = brand.BrandName,
                                 Quantity = cart.Quantity,
                                 Subtotal = jewel.JewelPrice * cart.Quantity
                             }).ToList();

            // Convert to DataTable
            DataTable result = new DataTable();
            result.Columns.Add("Id", typeof(int));
            result.Columns.Add("Name", typeof(string));
            result.Columns.Add("Price", typeof(decimal));
            result.Columns.Add("Brand", typeof(string));
            result.Columns.Add("Quantity", typeof(int));
            result.Columns.Add("Subtotal", typeof(decimal));

            foreach (var item in cartItems)
            {
                result.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Price,
                    item.Brand,
                    item.Quantity,
                    item.Subtotal
                );
            }

            return result;
        }

        public void UpdateCartItemQuantity(int userId, int jewelId, int quantity)
        {
            Cart cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public void RemoveCartItem(int userId, int jewelId)
        {
            Cart cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);

            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
        }

        public void ClearCart(int userId)
        {
            var cartItems = db.Carts.Where(c => c.UserID == userId).ToList();

            foreach (var item in cartItems)
            {
                db.Carts.Remove(item);
            }

            db.SaveChanges();
        }

        public void Checkout(int userId, string paymentMethod)
        {
            // Get all cart items for the user
            var cartItems = (from cart in db.Carts
                             join jewel in db.MsJewels on cart.JewelID equals jewel.JewelID
                             where cart.UserID == userId
                             select new
                             {
                                 JewelId = jewel.JewelID,
                                 Quantity = cart.Quantity
                             }).ToList();

            if (cartItems.Any())
            {
                // Create transaction header
                TransactionHeader header = new TransactionHeader
                {
                    UserID = userId,
                    TransactionDate = DateTime.Now,
                    PaymentMethod = paymentMethod,
                    TransactionStatus = "Payment Pending" // Default status
                };

                db.TransactionHeaders.Add(header);
                db.SaveChanges(); // Save to get the generated TransactionID

                // Create transaction details
                foreach (var item in cartItems)
                {
                    TransactionDetail detail = new TransactionDetail
                    {
                        TransactionID = header.TransactionID,
                        JewelID = item.JewelId,
                        Quantity = item.Quantity
                    };

                    db.TransactionDetails.Add(detail);
                }

                db.SaveChanges(); // Save all transaction details

                // Clear the user's cart after successful checkout
                ClearCart(userId);
            }
        }
    }
}
