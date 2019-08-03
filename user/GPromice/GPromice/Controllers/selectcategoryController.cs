using GPromice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPromice.Controllers
{
    public class selectcategoryController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: selectcategory
        public ActionResult laptop()
        {

            return View(context.Products.Where(d=>d.CategoryID==1).ToList());
        }
        public ActionResult camera()
       
            {

                return View(context.Products.Where(d => d.CategoryID == 2).ToList());
            }
        public ActionResult tablet()
        {
            return View(context.Products.Where(d => d.CategoryID == 3).ToList());
        }
        public ActionResult headphone()
        {
            return View(context.Products.Where(d => d.CategoryID == 4).ToList());
        }
        public ActionResult printer()
        {
            return View(context.Products.Where(d => d.CategoryID == 5).ToList());
        }
        public ActionResult tv()
        {
            return View(context.Products.Where(d => d.CategoryID == 6).ToList());
        }
        public ActionResult mobile()
        {
            return View(context.Products.Where(d => d.CategoryID == 7).ToList());
        }
        public ActionResult computer()
        {
            return View(context.Products.Where(d => d.CategoryID == 8).ToList());
        }
        public ActionResult watch()
        {
            return View(context.Products.Where(d => d.CategoryID == 9).ToList());
        }
        public ActionResult videoGames()
        {
            return View(context.Products.Where(d => d.CategoryID == 10).ToList());
        }
    }
}