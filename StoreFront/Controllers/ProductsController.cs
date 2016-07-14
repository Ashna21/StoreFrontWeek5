using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SFData.data;
using System.IO;

namespace StoreFront.Controllers
{
    public class ProductsController : Controller
    {
        private InventoryRespository _invrepo = new InventoryRespository();
        // Search Action
        public ActionResult Index()
        {
            List<Product> products = _invrepo.GetAllProducts();
            return View(products);
        }

        public ActionResult EditProduct(int productId)
        {
            Product product = _invrepo.GetProduct(productId);
            return View("ProductAdmin", product);
        }

        public ActionResult updateProduct(Product product , int oldProductId, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), pic);

                file.SaveAs(path);
                string newPath = "~/images/" + pic;

                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}
                _invrepo.updateProduct(product, oldProductId, newPath);
                return null;
            }
            else
            {
                string path = "~/images/noimage.png";
                _invrepo.updateProduct(product, oldProductId, path);
                return null;
            }

        }
    }
}
