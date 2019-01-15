using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickupStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickupStatus
        public ActionResult Index()
        {
            var pickupStatus = db.PickupStatus.Include(p => p.Customers);
            return View(pickupStatus.ToList());
        }

        // GET: PickupStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupStatus pickupStatus = db.PickupStatus.Find(id);
            if (pickupStatus == null)
            {
                return HttpNotFound();
            }
            return View(pickupStatus);
        }

        // GET: PickupStatus/Create
        public ActionResult Create()
        {
            var currentUsername = User.Identity.Name;
            var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
            var employee = db.Employees.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
            var employeeZipCode = employee.ZipCode;
            var dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();
            var customerPickups = db.Customers.Where(c => c.ZipCode == employeeZipCode).Where(c => c.PickupDay == dayOfTheWeek).ToList();
            ViewBag.CustomerId = new SelectList(customerPickups, "Id", "FirstName");
            return View();
        }

        // POST: PickupStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,StatusOfPickup")] PickupStatus pickupStatus)
        {
            if (ModelState.IsValid)
            {
                db.PickupStatus.Add(pickupStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var currentUsername = User.Identity.Name;
            var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
            var employee = db.Employees.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
            var employeeZipCode = employee.ZipCode;
            var dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();
            var customerPickups = db.Customers.Where(c => c.ZipCode == employeeZipCode).Where(c => c.PickupDay == dayOfTheWeek).ToList();
            ViewBag.CustomerId = new SelectList(customerPickups, "Id", "FirstName", pickupStatus.CustomerId);
            return View(pickupStatus);
        }

        // GET: PickupStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupStatus pickupStatus = db.PickupStatus.Find(id);
            if (pickupStatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", pickupStatus.CustomerId);
            return View(pickupStatus);
        }

        // POST: PickupStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,StatusOfPickup")] PickupStatus pickupStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickupStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", pickupStatus.CustomerId);
            return View(pickupStatus);
        }

        // GET: PickupStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupStatus pickupStatus = db.PickupStatus.Find(id);
            if (pickupStatus == null)
            {
                return HttpNotFound();
            }
            return View(pickupStatus);
        }

        // POST: PickupStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickupStatus pickupStatus = db.PickupStatus.Find(id);
            db.PickupStatus.Remove(pickupStatus);
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
