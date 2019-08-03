using GPromice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPromice.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Category
        public ActionResult SelectCategory()
        {
            List<Category> Categories = context.Categories.Where(i => i.IsDelete == false).ToList();
            return View(Categories);
        }
        public ActionResult updateProuduct(int cat)
        {
          
            return View();
        }

    }
}