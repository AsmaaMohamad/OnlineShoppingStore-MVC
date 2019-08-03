using GPromice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GPromice.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping'
        ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ActionResult shop(shippingDetail ship)
        {
            // var name=  System.Web.HttpContext.Current.User.Identity.Name;
            //  var id = context.Users.Where(d => d.UserName == name).Select(u => u.Id).FirstOrDefault();
            var name = User.Identity.Name;
            var id = User.Identity.GetUserId();
            ship.MemberName = name;
            context.shippingDetails.Add(ship);
            context.SaveChanges();
            return View();
        }
    }
}