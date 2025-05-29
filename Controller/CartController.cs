// Controller/CartController.cs
using System;
using System.Data;
using FinalProjectPSD.Handler;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.Controller
{
    public class CartController
    {
        private CartHandler cartHandler;

        public CartController()
        {
            cartHandler = new CartHandler();
        }

        public DataTable GetCartItems(int userId)
        {
            DataTable dt = cartHandler.GetCartItems(userId);

            foreach (DataRow row in dt.Rows)
            {
                string items = string.Join(", ", row.ItemArray);
                System.Diagnostics.Debug.WriteLine($"Row data: {items}");
            }

            return dt;
        }

        public string UpdateCartItemQuantity(int userId, int jewelId, string quantityStr)
        {
            try
            {
                if (!int.TryParse(quantityStr, out int quantity))
                {
                    return "Quantity must be a valid number";
                }

                if (quantity <= 0)
                {
                    return "Quantity must be greater than 0";
                }

                cartHandler.UpdateCartItemQuantity(userId, jewelId, quantity);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Error updating cart: " + ex.Message;
            }
        }

        public string RemoveCartItem(int userId, int jewelId)
        {
            try
            {
                cartHandler.RemoveCartItem(userId, jewelId);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Error removing item: " + ex.Message;
            }
        }

        public string ClearCart(int userId)
        {
            try
            {
                cartHandler.ClearCart(userId);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Error clearing cart: " + ex.Message;
            }
        }

        public string Checkout(int userId, string paymentMethod)
        {
            try
            {
                if (string.IsNullOrEmpty(paymentMethod) || paymentMethod == "0")
                {
                    return "Please select a payment method";
                }

                cartHandler.Checkout(userId, paymentMethod);
                return string.Empty; 
            }
            catch (Exception ex)
            {
                return "Error processing checkout: " + ex.Message;
            }
        }
    }
}
