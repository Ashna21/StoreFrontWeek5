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
        //Add order
        public ActionResult placeOrder(int cartId)
        {
            Address address = _orderRepo.getAddressWithCartId(cartId);
            if (address != null)
            {
                _orderRepo.AddOrder(cartId);
                return View("checkout", address);
            }
            else
                return PartialView("AddressPartial");
        }
        //Add user address
        public ActionResult AddAddress(Address address, int cartId)
        {
            if (ModelState.IsValid)
            {
                _orderRepo.AddAddress(address,cartId);
                _orderRepo.AddOrder(cartId);
                return View("checkout", address);
            }
            else
                return null;
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
            Address address = _orderRepo.getAddressById(addressId);
            return View("AddressDetails", address);
        }
    }
}