using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SFData.data
{
  
    public class OrdersRepository
    { 
       
        StoreFrontEntities1 db = new StoreFrontEntities1();

        //Gets order by ID
        public Order GetOrderByID(int id)
        {
            Order order = db.Orders.Where(x => x.OrderID.Equals(id)).FirstOrDefault();
            if (order != null)
                return order;
            else
                return null;
        }
        //Gets all orders
        public List<Order> GetOrder()
        {
            List<Order> orders = db.Orders.ToList();
            return orders;

        }
        //Adds an order 
        public void AddOrder(int cartId)
        {
            var userId = getUserId(cartId);
            var newOrder = new Order();
            newOrder.UserID = userId;
            newOrder.AddressID = getAddressId(userId);
            newOrder.Total = getOrderTotal(userId);
            newOrder.DateCreated = DateTime.Now;
            newOrder.StatusID = 2;

            db.Orders.Add(newOrder);
            db.SaveChanges();

        }
        //updates the address to shipping address in checkout
        public void setShippingAddress(int addressId)
        {
            Address _address = getAddressWithAddressId(addressId);
            _address.IsShipping = true;
            db.SaveChanges();
        }
        //Adds an address
        public void AddAddress(Address address, int cartId)
        {
            address.UserID = getUserId(cartId);
            address.DateCreated = DateTime.Now;
            db.Addresses.Add(address);
            db.SaveChanges();
        }

#region Helper Fuctions
        //get userId from cartId
        public int getUserId(int cartId)
        {
            var id = (from d in db.ShoppingCarts where d.ShoppingCartID == cartId select d.UserID).FirstOrDefault();
            return id;
        }

        //check if the user has an address
        public bool ValidAddress(int userId)
        {
            var hasAddress = getAddressId(userId);
           if(hasAddress > 0)
                return true;
            else
                return false;
        }

        //get addressId from userId
        private int getAddressId(int userId)
        {
            var id = (from d in db.Addresses where d.UserID == userId select d.AddressID).FirstOrDefault();
            return id;
        }

        //get a user's order total
        private decimal getOrderTotal(int userId)
        {
            var cartId = (from c in db.ShoppingCarts where c.UserID == userId select c.ShoppingCartID).FirstOrDefault();
            decimal total = (from t in db.ShoppingCartProducts where t.ShoppingCartID == cartId select t.Price).Sum();
            return total;
        }

        //get userId from addressId
        public int getUserIdByAddressId(int addressId)
        {
            int userId = (from c in db.Addresses where c.AddressID == addressId select c.UserID).FirstOrDefault();
            return userId;
        }

        //gets all the addresses associated to a user
        public List<Address> getAllAddressById(int addressId)
        {
            int userId = getUserIdByAddressId(addressId);
            List<Address> address = (from c in db.Addresses where c.UserID == userId select c).ToList();
            return address;
        }

        //gets the address by addressId
        public Address getAddressById(int addressId)
        {
            Address address = (from c in db.Addresses where c.AddressID == addressId select c).FirstOrDefault();
            return address;
        }

        //gets the address from cartId
        public Address getAddressWithCartId(int cartId)
        {
            int userId = (from c in db.ShoppingCarts where c.ShoppingCartID == cartId select c.UserID).FirstOrDefault();
            int addressId = getAddressId(userId);
            Address address = getAddressById(addressId);
            return address;
        }

        //gets the addressId from cartId
        public int getAddressIdByCartId(int cartId)
        {
            int userId = (from c in db.ShoppingCarts where c.ShoppingCartID == cartId select c.UserID).FirstOrDefault();
            int addressId = getAddressId(userId);
            return addressId;
        }
        
        //gets one address by addressId
        public Address getAddressWithAddressId(int addressId)
        {
            Address address = (from c in db.Addresses where c.AddressID == addressId select c).FirstOrDefault();
            return address;
        }
        //gets the products in the cart
        public List<ShoppingCartProduct> getCartProduct(int cartId)
        {
            var cartProduct = (from p in db.ShoppingCartProducts where p.ShoppingCartID == cartId select p).ToList();
            return cartProduct;
        }
        //gets the cartId
        public int getCartId(int orderId)
        {
            int userId = (from p in db.Orders where p.OrderID == orderId select p.UserID).FirstOrDefault();
            int cartId = (from p in db.ShoppingCarts where p.UserID == userId select p.ShoppingCartID).FirstOrDefault();
            return cartId;
        }
        #endregion

    }


}
