using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFData.data
{
    public class CartsRespository
    {
        StoreFrontEntities1 db = new StoreFrontEntities1();

        public List<ShoppingCartProduct> getCart(int cartId)
        {
            List<ShoppingCartProduct> cart = (from c in db.ShoppingCartProducts where c.ShoppingCartID == cartId select c).ToList();
            return cart;
        }
    }
}
