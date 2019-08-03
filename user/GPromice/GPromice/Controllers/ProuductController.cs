using GPromice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPromice.Controllers
{
    
        
    public class ProuductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Prouduct
        public ActionResult SelectProuduct()
        {
            List<Product> products = context.Products.Where(i => i.IsDelete == false).ToList();
            return View(products);
        }
        
    }
}