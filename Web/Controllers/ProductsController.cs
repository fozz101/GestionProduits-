using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using Data.Infrastructure;
using Service;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        private GetProduitsContext db = new GetProduitsContext();
        private UnitOfWork unitWork = new UnitOfWork();
        private ServiceProduct serviceProduct = new ServiceProduct();

        // GET: Products
        public ActionResult Index()
        {
            //var products = db.Products.Include(p => p.category);
            //var products = unitWork.GetRepository<Product>().GetAll().ToList();

            var products = serviceProduct.GetAll().ToList();
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            //Product product = unitWork.GetRepository<Product>().GetById(id);
            Product product = serviceProduct.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(serviceProduct.unitofwork.DataContext.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,DateProd,Description,Name,Price,Quantity,ImageName,City,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                serviceProduct.Create(product);
                serviceProduct.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(serviceProduct.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(serviceProduct.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,DateProd,Description,Name,Price,Quantity,ImageName,City,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(product).State = EntityState.Modified;
               serviceProduct.Update(product);
                //db.SaveChanges();
                serviceProduct.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(serviceProduct.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = serviceProduct.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = serviceProduct.GetById(id);
            serviceProduct.Delete(product);
            serviceProduct.Commit();
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
