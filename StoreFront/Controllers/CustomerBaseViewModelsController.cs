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
    public class CustomerBaseViewModelsController : Controller
    {
        private CustomerBaseViewModelContext db = new CustomerBaseViewModelContext();

        // GET: CustomerBaseViewModels
        public ActionResult Index()
        {
            return View(db.CustomerBaseViewModels.ToList());
        }

        // GET: CustomerBaseViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerBaseViewModel customerBaseViewModel = db.CustomerBaseViewModels.Find(id);
            if (customerBaseViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerBaseViewModel);
        }

        // GET: CustomerBaseViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerBaseViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName")] CustomerBaseViewModel customerBaseViewModel)
        {
            if (ModelState.IsValid)
            {
                db.CustomerBaseViewModels.Add(customerBaseViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerBaseViewModel);
        }

        // GET: CustomerBaseViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerBaseViewModel customerBaseViewModel = db.CustomerBaseViewModels.Find(id);
            if (customerBaseViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerBaseViewModel);
        }

        // POST: CustomerBaseViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName")] CustomerBaseViewModel customerBaseViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerBaseViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerBaseViewModel);
        }

        // GET: CustomerBaseViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerBaseViewModel customerBaseViewModel = db.CustomerBaseViewModels.Find(id);
            if (customerBaseViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerBaseViewModel);
        }

        // POST: CustomerBaseViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerBaseViewModel customerBaseViewModel = db.CustomerBaseViewModels.Find(id);
            db.CustomerBaseViewModels.Remove(customerBaseViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
