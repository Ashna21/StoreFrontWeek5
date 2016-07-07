using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StoreFront.Data;

namespace StoreFront.Controllers
{
    public class OrdersController : Controller
    {
        private OrderRepository _orderRepo = new Data.OrderRepository();

        // GET: Orders
        public ActionResult Index()
        {
            List<StoreFront.Data.Order1> orders;
            orders = _orderRepo.GetOrder();
            return View(orders);
        }

        //add an order 
        public void addOrder(int cartId)
        {
            _orderRepo.AddOrder(cartId);
        }
    }
}



