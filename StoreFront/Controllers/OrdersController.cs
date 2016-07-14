using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SFData.data;

namespace StoreFront.Controllers
{
    public class OrdersController : Controller
    {
        OrdersRepository _orderRepo = new OrdersRepository();
        CartsRespository _cartRepo = new CartsRespository();
        //Checkout
        public ActionResult checkout(int cartId)
        {
            Address address = _orderRepo.getAddressWithCartId(cartId);
            if (address != null)
            {
                return View("checkout", address);
            }
            else
                return PartialView("AddressPartial");
        }
        //retreives the shipping address based on the selected address
        public ActionResult shippingAddress(int selectedAddress)
        {
            _orderRepo.setShippingAddress(selectedAddress);
            Address shippingAddress = _orderRepo.getAddressWithAddressId(selectedAddress);
            Session["shipping"] = shippingAddress.AddressID;
            return RedirectToAction("checkout2");
        }
        //final checkout page with address details and cart details
        public ActionResult checkout2()
        {
                return View("checkout2");
        }
        //view for cart details to be rendered in checkout2
        public ActionResult cartDetails(int _cartId)
        {
            List<ShoppingCartProduct> cart = _cartRepo.getCart(_cartId);
            return View(cart);
        }
        //view for shippingAddressDetails to be rendered in checkout2
        public ActionResult shippingAddressDetails(int _addressId)
        {
            Address address = _orderRepo.getAddressWithAddressId(_addressId);
            return View(address);
        }
        //place order
        public ActionResult placeOrder(int cartId)
        {
            _orderRepo.AddOrder(cartId);
            return View("thankyou");
        }
        //Add user address
        public ActionResult AddAddress(Address address, int cartId)
        {
            if (ModelState.IsValid)
            {
                _orderRepo.AddAddress(address,cartId);
                return View("checkout", address);
            }
            else
                return null;
        }
        //Shows the address form to add a new address
        public ActionResult AddressForm()
        {
            return View("AddressPartial");
        }
        // Gets all the orders
        public ActionResult Index()
        {
            List<Order> orders = _orderRepo.GetOrder();
            return View(orders);
        }
        //Gets order details front page
        public ActionResult OrderDetails(int orderId)
        {
            Session["OrderID"] = orderId;
            Order _order = _orderRepo.GetOrderByID(orderId);
            return View("details", _order);
        }
        //gets general order details
        public ActionResult GeneralOrderDetails(int orderId)
        {
            Order order = _orderRepo.GetOrderByID(orderId);
            return View("GeneralOrderDetails",order);
        }
        //gets address details for a particular order
        public ActionResult AddressDetails(int addressId)
        {
            List<Address> address = _orderRepo.getAllAddressById(addressId);
            return View("AddressDetails", address);
        }
        //gets product details
        public ActionResult OrderProductDetails(int orderId)
        {
            int cartId = _orderRepo.getCartId(orderId);
            List<ShoppingCartProduct> cart = _orderRepo.getCartProduct(cartId);
            return View(cart);
        }
    }
}