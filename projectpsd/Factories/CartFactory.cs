using System;
using projectpsd.Model;

namespace projectpsd.Factories
{
    public static class CartFactory
    {
        public static Cart CreateCartItem(int userId, int jewelId, int quantity)
        {
            return new Cart
            {
                UserID = userId,
                JewelID = jewelId,
                Quantity = quantity
            };
        }

        public static Cart UpdateCartQuantity(Cart existingCartItem, int newQuantity)
        {
            if (existingCartItem == null) throw new ArgumentNullException(nameof(existingCartItem));

            existingCartItem.Quantity = newQuantity;
            return existingCartItem;
        }
    }
}