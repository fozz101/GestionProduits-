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
using Service;
namespace Web.Controllers
{
    public class FacturesController : Controller
    {
        private GetProduitsContext db = new GetProduitsContext();
        private ServiceFacture serviceFacture = new ServiceFacture();

        // GET: Factures
        public ActionResult Index()
        {
            var factures = db.Factures.Include(f => f.Client).Include(f => f.Product);
            return View(factures.ToList());
        }

        // GET: Factures/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.Factures.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Cin", "Email");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Description");
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateAchat,ClientId,ProductId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Factures.Add(facture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Cin", "Email", facture.ClientId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Description", facture.ProductId);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public ActionResult Edit(int productId , int clientId , DateTime dateAchat )
        {
            if ((productId == 0) || (clientId == 0) )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.Factures.Where(a => a.ProductId == productId && a.ClientId == clientId && a.DateAchat == dateAchat).FirstOrDefault();
            if (facture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = db.Clients.Where(a => a.Cin ==clientId).FirstOrDefault().Prenom;
            ViewBag.ProductId = db.Products.Where(p => p.ProductId == productId).FirstOrDefault().Name;
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateAchat,ClientId,ProductId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Cin", "Email", facture.ClientId).FirstOrDefault();
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Description", facture.ProductId);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public ActionResult Delete(int productId, int clientId, DateTime dateAchat)
        {
            if ((productId == 0) || (clientId == 0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = serviceFacture.getFactureById(productId, clientId, dateAchat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int productId, int clientId, DateTime dateAchat)
        {
            Facture facture = serviceFacture.getFactureById(productId, clientId, dateAchat);
            db.Factures.Remove(facture);
            db.SaveChanges();
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
