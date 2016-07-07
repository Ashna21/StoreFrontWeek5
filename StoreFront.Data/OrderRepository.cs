using StoreFront.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreFront.Data
{
    public class OrderRepository
    {
        StoreFrontDataEntities data = new StoreFrontDataEntities();
        
//GetOrderById
        public Data.Order1 GetOrderById( int id)
        {
            if (data.Order1.Any(x => x.OrderID.Equals(id)))
            {
                Data.Order1 order = data.Order1.Where(x => x.OrderID.Equals(id)).FirstOrDefault();
                return order;
            }
            else
                return null;
        }

//GetOrder
        public List<Data.Order1> GetOrder()
        {
            List<Data.Order1> orders = data.Order1.ToList();
            return orders;

        }

        public void AddOrder(int cartId)
        {
            var userId = getUserId(cartId);
            var newOrder = new Order1();
            newOrder.UserID = userId;
            newOrder.AddressID = getAddressId(userId);
            newOrder.Total = getOrderTotal(userId);
            newOrder.DateCreated = DateTime.Now;
            newOrder.StatusID = 2;
            //newOrder.OrderDate = DateTime.Now;

            data.Order1.Add(newOrder);
            data.SaveChanges();

        }


        #region helper function
        //function to get the user from a cartId
        private int getUserId(int? cartId)
        {
            var Id = (from d in data.ShoppingCart1 where d.ShoppingCartID == cartId select d.UserID).FirstOrDefault();
            return Id;
        }
        //function to get the UserID
        private int getAddressId(int? userId)
        {
            var Id = (from d in data.Address12 where d.UserID == userId select d.AddressID).FirstOrDefault();
            return Id;
        }

        //function to get orderTotal
        private decimal getOrderTotal(int? userId)
        {
            var cartId = (from c in data.ShoppingCart1 where c.UserID == userId select c.ShoppingCartID).FirstOrDefault();
            decimal total = (from t in data.ShoppingCartProduct1 where t.ShoppingCartID == cartId select t.Price).Sum();
            return total;
        }
        #endregion
    }

}
