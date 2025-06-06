using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using projectpsd.Model;

namespace projectpsd.Repositories
{
    public class CartRepository : BaseRepository<Cart>
    {
        public Cart GetCartItemByUserIdAndJewelId(int userId, int jewelId)
        {
            return db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
        }

        public List<Cart> GetUserCart(int userId)
        {
            return db.Carts.Include(c => c.MsJewel)
                           .Include(c => c.MsJewel.MsCategory)
                           .Include(c => c.MsJewel.MsBrand)
                           .Where(c => c.UserID == userId)
                           .ToList();
        }

        public void ClearUserCart(int userId)
        {
            var userCartItems = db.Carts.Where(c => c.UserID == userId);
            db.Carts.RemoveRange(userCartItems);
            db.SaveChanges();
        }

        public void DeleteCartItem(int userId, int jewelId)
        {
            var cartItem = GetCartItemByUserIdAndJewelId(userId, jewelId);
            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
        }
    }
}