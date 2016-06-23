using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreFront.Data;
using StoreFront.Models;
using System.Data.Linq;

namespace StoreFront.Controllers
{
    public class CustomerBaseController : Controller
    {
        //Constructor to the customerBase
        DataContext context;
        public CustomerBaseController()
        {
            this.context = new DataContext(SFDataContext.connection);
        }

        // GET: CustomerBase
        public ActionResult Index()
        {
            Table<CustomerBase> users = context.GetTable<CustomerBase>();
            return View(users);
        }
    }
}