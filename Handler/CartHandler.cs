// Handler/CartHandler.cs
using System;
using System.Data;
using FinalProjectPSD.Repository;

namespace FinalProjectPSD.Handler
{
    public class CartHandler
    {
        private CartRepository cartRepository;

        public CartHandler()
        {
            cartRepository = new CartRepository();
        }

        public DataTable GetCartItems(int userId)
        {
            return cartRepository.GetCartItems(userId);
        }

        public void UpdateCartItemQuantity(int userId, int jewelId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }
            cartRepository.UpdateCartItemQuantity(userId, jewelId, quantity);
        }

        public void RemoveCartItem(int userId, int jewelId)
        {
            cartRepository.RemoveCartItem(userId, jewelId);
        }

        public void ClearCart(int userId)
        {
            cartRepository.ClearCart(userId);
        }

        public void Checkout(int userId, string paymentMethod)
        {
            if (string.IsNullOrEmpty(paymentMethod))
            {
                throw new ArgumentException("Payment method must be selected");
            }
            cartRepository.Checkout(userId, paymentMethod);
        }
    }
}
