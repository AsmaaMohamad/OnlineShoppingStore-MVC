using Newtonsoft.Json;
using GPromice.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPromice.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Dashboard()
        {
            //List<Category> Categories = .GetRepositoryInstance<Category>().GetAllRecordIQueryable().Where(i => i.IsDelete == false).ToList();
            //List<Product> products = unitOfWork.GetRepositoryInstance<Product>().GetAllRecordIQueryable().Where(i => i.IsDelete == false).ToList();
            return View();
        }
        public ActionResult Categories()
        {
            List<Category> Categories = context.Categories.Where(i => i.IsDelete == false).ToList();
            return View(Categories);
        }
        public ActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            
            return View();
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            Category category = context.Categories.FirstOrDefault(d => d.CatID == id);
            return View(category);
        }
        public ActionResult EditCategory(int id, Category cat)
        {
            try
            {
                //Get Old reference from Context
               Category oldCat =
                    context.Categories.FirstOrDefault(d => d.CatID == id); ;
                //Updat eData Dept ==>Html
                oldCat.CatName= cat.CatName;
                oldCat.IsActive =cat.IsActive;
                oldCat.IsDelete = cat.IsDelete;
                context.SaveChanges();
                return View("EditCategory");
            }
            catch
            {
                return View(cat);
            }
        }
        public ActionResult DeleteCategory(int id, Category cat)
        {
            try
            {
                //Get Old reference from Context
                Category oldCat =
                     context.Categories.FirstOrDefault(d => d.CatID == id); ;
               
                oldCat.IsActive = false;
                oldCat.IsDelete = true;
                
                context.SaveChanges();
                return RedirectToAction("Categories");
            }
            catch
            {
                return View(cat);
            }
        }
        public ActionResult DetailsCategory(int id)
        {
            Category category = context.Categories.FirstOrDefault(d => d.CatID == id);
            return View(category);
        }
        public ActionResult product()
        {
            List<Product> products = context.Products.Where(i => i.IsDelete == false).ToList();
            return View(products);
        }
        
        //public ActionResult CreateProduct(Product product)
        //{
            
        //   Product product1 = new Product
        //    {
        //        ProductName = product.ProductName,
        //        IsActive = product.IsActive,
        //        IsDelete = product.IsDelete,
        //        CreatedDate = product.CreatedDate,
        //        ModifiedDate = product.ModifiedDate,
        //        ProductImage = product.ProductImage,
        //        Quantity = product.Quantity,
        //        Price = product.Price,
        //        CategoryID 

        //    };

        //    context.Products.Add(product1);
        //    context.SaveChanges();

        //    return View();
        //}

    }
}