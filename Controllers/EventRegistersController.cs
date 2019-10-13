using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032AssVer2.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032AssVer2.Controllers
{
    [Authorize]
    public class EventRegistersController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: EventRegisters
        public ActionResult Index()
        {
            var eventRegisters = db.EventRegisters.Include(e => e.Customer).Include(e => e.Event);
            return View(eventRegisters.ToList());
        }

        // GET: EventRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegister eventRegister = db.EventRegisters.Find(id);
            if (eventRegister == null)
            {
                return HttpNotFound();
            }
            return View(eventRegister);
        }

        // GET: EventRegisters/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name");
            return View();
        }

        // POST: EventRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Create([Bind(Include = "Id,EventId")] EventRegister eventRegister)
        {
            eventRegister.RegisterDate = DateTime.Now.ToString();
            var userId = User.Identity.GetUserId();
            var customers = db.Customers.Where(c => c.UserId == userId).ToList();
            var customerId = customers[0].Id;
            eventRegister.CustomerId = customerId;
            if (ModelState.IsValid)
            {

                db.EventRegisters.Add(eventRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", eventRegister.CustomerId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventRegister.EventId);
            return View(eventRegister);
        }

        // GET: EventRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegister eventRegister = db.EventRegisters.Find(id);
            if (eventRegister == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", eventRegister.CustomerId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventRegister.EventId);
            return View(eventRegister);
        }

        // POST: EventRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegisterDate,CustomerId,EventId")] EventRegister eventRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", eventRegister.CustomerId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventRegister.EventId);
            return View(eventRegister);
        }

        // GET: EventRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegister eventRegister = db.EventRegisters.Find(id);
            if (eventRegister == null)
            {
                return HttpNotFound();
            }
            return View(eventRegister);
        }

        // POST: EventRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            EventRegister eventRegister = db.EventRegisters.Find(id);
            db.EventRegisters.Remove(eventRegister);
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
