using GPromice.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPromice.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]  
        public ActionResult Cart()
        {
            var userId = User.Identity.GetUserId();
            var cartProducts = (from c in context.Carts
                                where c.MemberId == userId 
                                select c).ToList();
            return PartialView(cartProducts);
        }

    }
}