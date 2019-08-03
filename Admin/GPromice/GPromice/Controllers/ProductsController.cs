using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GPromice;
using GPromice.Models;
using System.IO;

namespace GPromice.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CatID", "CatName");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductID,ProductName,CategoryID,IsActive,IsDelete,CreatedDate,ModifiedDate,ProductImage,Quantity,Price")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //if (file != null)
                //{
                    var InputFileName = Path.GetFileName(file.FileName);
                    //var ServerSavePath = Path.Combine(Server.MapPath("~/Content/Images/") + InputFileName);
                    ////Save file to server folder  
                    //file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    // ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";

                    ProductVM productVM = new ProductVM
                    {
                        imagefile = file

                    };
                    product.ProductImage = "/Content/Images/"+ InputFileName;
                    //  db.ImagesProduct.Add(ImageProductObject);
                    // db.SaveChanges();
                    //db.Products.Add(product);
                    //db.SaveChanges();
                    // return RedirectToAction("Index");
                    //ViewData["ProductID"] = product.ProductId;
                    //return View("Create");
                }
            //}

            ViewBag.CategoryID = new SelectList(db.Categories, "CatID", "CatName", product.CategoryID);
            db.Products.Add(product);
            db.SaveChanges();
            return View(product);
        }
        

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CatID", "CatName", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,ProductName,CategoryID,IsActive,IsDelete,CreatedDate,ModifiedDate,ProductImage,Quantity,Price")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var InputFileName = Path.GetFileName(file.FileName);
                var ServerSavePath = Path.Combine(Server.MapPath("~/Content/Images/") + InputFileName);
                //Save file to server folder  
                file.SaveAs(ServerSavePath);
                //assigning file uploaded status to ViewBag for showing message to user.  
                // ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";

                ProductVM productVM = new ProductVM
                {
                    imagefile = file

                };
                product.ProductImage = "/Content/Images/" + InputFileName;
                
                db.Entry(product).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CatID", "CatName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
