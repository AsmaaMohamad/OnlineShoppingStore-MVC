using GPromice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPromice.Controllers
{
    public class FillterController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Fillter
        public ActionResult Index(string ProductName)
        {
            var proddet = context.Products.Where(p => p.ProductName.Contains(ProductName)).ToList();


            return View(proddet);
        }
    }
}