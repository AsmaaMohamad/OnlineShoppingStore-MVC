using GPromice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPromice.Controllers
{
    public class PreviewCategroyController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: PreviewCategroy
        public ActionResult Preview()
        {
            List<Category> Categories = context.Categories.Where(i => i.IsDelete == false).ToList();
            return View(Categories);
        }
    }
}