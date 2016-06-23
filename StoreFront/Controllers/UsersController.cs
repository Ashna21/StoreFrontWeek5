using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.Models;
using System.Web.Security;

namespace StoreFront.Controllers
{
    public class UsersController : Controller
    {

        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // Login Action
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Login(User user)
        {
            var query = (from u in db.Users where u.UserName == user.UserName select u).FirstOrDefault();
           
            if (db.Users.Any(x => x.UserName == user.UserName && x.EmailAddress == user.EmailAddress))
            {
                string usr = user.UserName;
                Session["name"] = usr;
                Session["id"] = query.UserID;
   
                if (query.IsAdmin == true)
                {
                    return RedirectToRoute("~/Default.aspx");
                }
                else
                {
                    return RedirectToAction("Welcome");
                }
            }
            else
                return View("Index");
        }

        //Register Action
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.DateCreated = DateTime.Now;
                user.IsAdmin = false;
                user.DateModified = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult AutoComplete(string term)
        {
            var product = db.Products
                            .Where(r => r.ProductName.StartsWith(term))
                             .Take(10)
                             .Select(r => new
                             {
                                 label = r.ProductName
                             });
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        //Welcome Page
        public ActionResult Welcome(string searchTerm = null)
        {

            //var product = db.Products.OrderBy(r => r.ProductName).Where(r => r.ProductName.Contains(searchTerm) || r => searchTerm == null).Select r;
            var product = from r in db.Products
                          orderby r.ProductName ascending
                          where (r.ProductName.Contains(searchTerm) || searchTerm == null)
            select r;
            if(Request.IsAjaxRequest())
            {
                return PartialView("ProductsList", product);
            }
            return View(product.ToList());
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return View("Index");
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return View("Index");
            }
            return View(user);
        }
    }
}
