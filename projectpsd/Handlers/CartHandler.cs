using System;
using System.Collections.Generic;
using System.Linq;
using projectpsd.Model;
using projectpsd.Repositories;
using projectpsd.Factories;
using projectpsd.Utils;

namespace projectpsd.Handlers
{
    public class CartHandler
    {
        private CartRepository cartRepository;
        private JewelRepository jewelRepository; 

        public CartHandler()
        {
            cartRepository = new CartRepository();
            jewelRepository = new JewelRepository();
        }

        
        public List<Cart> GetUserCartItems(int userId)
        {
            return cartRepository.GetUserCart(userId);
        }

        
        public string AddJewelToCart(int userId, int jewelId, int quantity)
        {
            if (quantity <= 0)
            {
                return "Quantity must be more than 0.";
            }

            MsJewel jewel = jewelRepository.GetById(jewelId);
            if (jewel == null)
            {
                return "Jewel not found.";
            }

            
            Cart existingCartItem = cartRepository.GetCartItemByUserIdAndJewelId(userId, jewelId);

            if (existingCartItem != null)
            {
                
                existingCartItem = CartFactory.UpdateCartQuantity(existingCartItem, existingCartItem.Quantity + quantity);
                cartRepository.Update(existingCartItem);
                return "Quantity updated in cart.";
            }
            else
            {
                
                Cart newCartItem = CartFactory.CreateCartItem(userId, jewelId, quantity);
                cartRepository.Add(newCartItem);
                return "Jewel added to cart.";
            }
        }

        
        public string UpdateCartItemQuantity(int userId, int jewelId, int newQuantity)
        {
            if (newQuantity <= 0)
            {
                return "Quantity must be numeric and more than 0.";
            }

            Cart cartItem = cartRepository.GetCartItemByUserIdAndJewelId(userId, jewelId);
            if (cartItem == null)
            {
                return "Cart item not found.";
            }

            cartItem = CartFactory.UpdateCartQuantity(cartItem, newQuantity);
            cartRepository.Update(cartItem);
            return "Cart item quantity updated.";
        }

        
        public string RemoveCartItem(int userId, int jewelId)
        {
            Cart cartItem = cartRepository.GetCartItemByUserIdAndJewelId(userId, jewelId);
            if (cartItem == null)
            {
                return "Cart item not found.";
            }

            
            cartRepository.DeleteCartItem(userId, jewelId);
            return "Cart item removed.";
        }

        
        public string ClearUserCart(int userId)
        {
            cartRepository.ClearUserCart(userId);
            return "Cart cleared successfully.";
        }

        
        public string CheckoutCart(int userId, string paymentMethod)
        {
            if (string.IsNullOrWhiteSpace(paymentMethod))
            {
                return "Payment method must be selected.";
            }

            List<Cart> cartItems = cartRepository.GetUserCart(userId);
            if (!cartItems.Any())
            {
                return "Your cart is empty. Cannot checkout.";
            }

            
            TransactionHeader newHeader = TransactionFactory.CreateTransactionHeader(userId, paymentMethod);

            
            List<TransactionDetail> newDetails = TransactionFactory.CreateTransactionDetails(cartItems);

            
            TransactionRepository transactionRepository = new TransactionRepository();
            transactionRepository.AddNewTransaction(newHeader, newDetails);

            
            cartRepository.ClearUserCart(userId);

            return "Checkout successful!";
        }
    }
}