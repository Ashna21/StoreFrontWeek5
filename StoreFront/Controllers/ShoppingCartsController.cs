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
    public class ShoppingCartsController : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();
#region Actions

        //Add to cart
        public ActionResult AddToCart(int ?productId, int ?userId)
        {
            if (userId != null)
            {
                //check if the user has a cart
                var hasCart = hasShoppingCart(userId);
                //Create a new cart for the user, if the user does not have a cart
                if (hasCart == false)
                {
                    var userCart = new ShoppingCart();
                    userCart.UserID = userId ?? default(int);
                    userCart.DateCreated = DateTime.Now;
                    db.ShoppingCarts.Add(userCart);
                    db.SaveChanges();

                    ShoppingCart cart = getCart(userId);
                    var cartId = cart.ShoppingCartID;
                    Session["cartId"] = cartId;
                    return RedirectToAction("AddProduct", "ShoppingCarts", new { cartId = cartId, productId = productId });
                }
                //if the user has a cart, add the product to the cart!
                else
                {
                    ShoppingCart cart = getCart(userId);
                    var cartId = cart.ShoppingCartID;
                    Session["cartId"] = cartId;
                    return RedirectToAction("AddProduct", "ShoppingCarts", new { cartId = cartId, productId = productId });
                }
            }
            else
            {
                 return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult AddProduct(int cartId, int productId)
        {
            Session["cartId"] = cartId;
            Product product = getProduct(productId);

            if (db.ShoppingCartProducts.Any(p => p.ProductID == productId && p.ShoppingCartID == cartId))
            {
                ShoppingCartProduct cartProduct = getCartProductById(cartId, productId);
                cartProduct.Quantity = cartProduct.Quantity + 1;
                cartProduct.Price = cartProduct.Price + getProductPrice(productId);
                db.SaveChanges();
                Session["quantity"] = getQuantity(cartId);
            }
            else
            {
                var cartProduct = new ShoppingCartProduct();


                cartProduct.ShoppingCartID = cartId;
                cartProduct.ProductID = product.ProductID;
                cartProduct.ProductName = product.ProductName;
                cartProduct.Price = product.Price;
                cartProduct.DateCreated = DateTime.Now;
                cartProduct.Quantity = cartProduct.Quantity + 1;
                db.ShoppingCartProducts.Add(cartProduct);
                db.SaveChanges();

                Session["quantity"] = getQuantity(cartId);
            }

            return RedirectToAction("Welcome", "Users");
        }

        public ActionResult CartView(int ?cartId)
        {
            var _cartId = cartId ?? default(int);
            List<ShoppingCartProduct> cart = getCartProduct(_cartId);
            if (cart != null)
            {
                decimal price = (from p in db.ShoppingCartProducts where p.ShoppingCartID == cartId select p.Price).Sum();
                ViewBag.price = price;
                Session["quantity"] = getQuantity(_cartId);
                return View(cart);
            }
            else
            {
                Session["quantity"] = 0;
                Session["EmptyCart"] = "Your Cart is Empty";
                return View(cart);
            }
           
        }

        public ActionResult Delete(int productId, int cartId)
        {
            ShoppingCartProduct cartProduct = getCartProductById(cartId, productId);
            db.ShoppingCartProducts.Remove(cartProduct);
            db.SaveChanges();
           
            return RedirectToAction("CartView", new { _cartId = cartId });
        }

        public ActionResult UpdateQuantity(int productId, int cartId, int quant)
        {
            ShoppingCartProduct product = getCartProductById(cartId, productId);
            product.Quantity = quant;
            db.SaveChanges();

            return RedirectToAction("CartView", new { _cartId = cartId });
        }
#endregion


#region Helper Functions 
        //function to check if a user has shopping cart.
        private bool hasShoppingCart(int? userId)
        {
            var cart = (from c in db.ShoppingCarts where c.UserID == userId select c).FirstOrDefault();
            if (cart != null)
                return true;
            else
                return false;
        }

        //function to retreive the shoppping cart.
        private ShoppingCart getCart(int? userId)
        {
            var cart = (from c in db.ShoppingCarts where c.UserID == userId select c).FirstOrDefault();
            return cart;
        }

        //function to get the product.
        private Product getProduct(int productId)
        {
            var product = (from p in db.Products where p.ProductID == productId select p).FirstOrDefault();
            return product;
        }

        //gets the products in the cart
        private List<ShoppingCartProduct> getCartProduct(int cartId)
        {
            var cartProduct = (from p in db.ShoppingCartProducts where p.ShoppingCartID == cartId select p).ToList();
        
            return cartProduct;
        }

        //gets just the product with the product id
        private ShoppingCartProduct getCartProductById(int cartId, int productId)
        {
            ShoppingCartProduct productById = (from p in db.ShoppingCartProducts where p.ShoppingCartID == cartId && p.ProductID == productId select p).First();
            return productById; 
        }

        //gets the number of products in the cart
        private int getQuantity(int cartId)
        {
            int quantity = (from p in db.ShoppingCartProducts where p.ShoppingCartID == cartId select p.Quantity).Sum();
            return quantity;
        }

        //get a product to delete
        private ShoppingCartProduct getCartProductToDelete(int cartId, int productId)
        {
            ShoppingCartProduct productToDelete = (from p in db.ShoppingCartProducts where p.ShoppingCartID == cartId && p.ProductID == productId select p).FirstOrDefault();
            return productToDelete;
        }
        //gets the price of a product
        private decimal getProductPrice(int productId)
        {
            Product product = getProduct(productId);
            decimal price = product.Price;
            return price;
        }

#endregion
    }
}
