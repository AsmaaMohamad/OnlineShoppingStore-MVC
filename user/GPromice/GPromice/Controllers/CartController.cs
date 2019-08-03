using GPromice.Models;
using GPromice.VM.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPromice.Controllers

{
   
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session["cart"] as List<CartVm> ?? new List<CartVm>();
            if(cart.Count==0||Session["cart"]==null)
            {
                ViewBag.Message = "Your Cart Is Empty.";
                return View();
            }
            decimal? total = 0m;
            foreach(var item in cart)
            {
                total += item.Total;
            }
            ViewBag.GrandTotal = total;
            return View(cart);
        }
        public ActionResult CartPartial()
        {
            CartVm model = new CartVm();
            int? qty = 0;
            decimal? price = 0m;
            if (Session["cart"] != null)
            {
                var list = (List<CartVm>)Session["cart"];

                foreach (var item in list)
                {
                    qty += item.Quantity;
                    price += item.Quantity * item.Price;
                }
            }
            else
            {
                model.Quantity = 0;
                model.Price = 0m;
            }
            
            return PartialView(model);
        }
        
       public ActionResult AddToCartPartial(int id)
        {
            List<CartVm> cart = Session["cart"] as List<CartVm> ?? new List<CartVm>();
            CartVm model = new CartVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Product product = db.Products.Find(id);
                var productInCart = cart.FirstOrDefault(x => x.ProductID == id);

                if(productInCart == null)
                {
                    cart.Add(new CartVm()
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        Quantity = 1,
                        Price = product.Price,
                        ProductImage = product.ProductImage
                    });
                }else
                {
                    productInCart.Quantity++;
                }
            }

            int qty = 0;
            decimal? price = 0m;
            foreach(var item in cart)
            {
                qty += item.Quantity;
                price += item.Quantity * item.Price;
            }
            model.Quantity = qty;
            model.Price = price;

            Session["cart"] = cart;
            Product product1 = db.Products.Find(id);
            Cart cart1 = new Cart()
            {
                ProductId= product1.ProductID
                

            };
            db.Carts.Add(cart1);
            db.SaveChanges();
            return RedirectToAction("SelectProuduct", "Prouduct");
        }
    }
}