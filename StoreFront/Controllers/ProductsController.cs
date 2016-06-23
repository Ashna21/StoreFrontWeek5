using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.Models;

namespace StoreFront.Controllers
{
    public class ProductsController : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // Search Action
        public ActionResult Index()
        {
            if (Session["name"] != null)
            {
                return View();
            }
            else
                return View("~/Controllers/UsersController/Index");
            
        }
       
        public ActionResult Details(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                return HttpNotFound();
            }
            else if ( !db.Products.Any(x => x.ProductName.Contains(search)))
            {
                return HttpNotFound();
            }
            else
            {
                return View(db.Products.Where(x => x.ProductName.Contains(search)).ToList());
            }
        }

      
    }
}
