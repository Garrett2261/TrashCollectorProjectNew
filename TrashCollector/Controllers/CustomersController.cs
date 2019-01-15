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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index(string dayOfWeek)
        {
            List<Customers> customer = new List<Customers>();
            ApplicationUser user = new ApplicationUser();
            var username = User.Identity.Name;
            var userRole = db.Users.Where(m => m.UserName == username).Select(m => m.UserRole).FirstOrDefault();
            if (userRole == "Customer")
            {
                var currentUsername = User.Identity.Name;
                var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
                var customerIds = db.Customers.Where(m => m.ApplicationUserId == currentUser).Select(m => m.Id).ToList();

                foreach (int id in customerIds)
                {
                    var currentCustomer = db.Customers.Where(m => m.Id == id).First();
                    customer.Add(currentCustomer);
                }
                return View(customer);
            }
            else if (userRole == "Employee")
            {
                if (dayOfWeek == "Monday")
                {
                    
                    var currentUsername = User.Identity.Name;
                    var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
                    var employee = db.Employees.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
                    var employeeZipCode = employee.ZipCode;
                    var customers = db.Customers.Where(c => c.ZipCode == employeeZipCode).Where(c => c.PickupDay == "Monday").ToList();
                    return View(customers);
                }
                else if (dayOfWeek == "Tuesday")
                {
                    var currentUsername = User.Identity.Name;
                    var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
                    var employee = db.Employees.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
                    var employeeZipCode = employee.ZipCode;
                    var customers = db.Customers.Where(c => c.ZipCode == employeeZipCode).Where(c => c.PickupDay == "Tuesday").ToList();
                    return View(customers);
                }
                else if (dayOfWeek == "Wednesday")
                {
                    var currentUsername = User.Identity.Name;
                    var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
                    var employee = db.Employees.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
                    var employeeZipCode = employee.ZipCode;
                    var customers = db.Customers.Where(c => c.ZipCode == employeeZipCode).Where(c => c.PickupDay == "Wednesday").ToList();
                    return View(customers);
                }
                else if (dayOfWeek == "Thursday")
                {
                    var currentUsername = User.Identity.Name;
                    var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
                    var employee = db.Employees.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
                    var employeeZipCode = employee.ZipCode;
                    var customers = db.Customers.Where(c => c.ZipCode == employeeZipCode).Where(c => c.PickupDay == "Thursday").ToList();
                    return View(customers);
                }
                else if (dayOfWeek == "Friday")
                {
                    var currentUsername = User.Identity.Name;
                    var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
                    var employee = db.Employees.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
                    var employeeZipCode = employee.ZipCode;
                    var customers = db.Customers.Where(c => c.ZipCode == employeeZipCode).Where(c => c.PickupDay == "Friday").ToList();
                    return View(customers);
                }
                else
                {
                    var currentUsername = User.Identity.Name;
                    var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).FirstOrDefault();
                    var employee = db.Employees.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
                    var employeeZipCode = employee.ZipCode;
                    var dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();
                    var customerPickups = db.Customers.Where(c => c.ZipCode == employeeZipCode).Where(c => c.PickupDay == dayOfTheWeek).ToList();
                    return View(customerPickups);
                }
            }
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }
       

        // GET: Customers/Create
        public ActionResult Create()
        {
            var currentUsername = User.Identity.Name;
            var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).First();
            Customers customer = new Customers
            {
                ApplicationUserId = currentUser
            };

            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PickupDay,Date,SuspensionStartDate,SuspensionEndDate,ZipCode,ApplicationUserId,PickupBill,PickupStatus")] Customers customers)
        {
                if (ModelState.IsValid)
                {
                    customers.PickupBill = 0.00;
                    customers.PickupStatus = null;
                    db.Customers.Add(customers);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            return View(customers);
        }

        

        
        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            var username = User.Identity.Name;
            var userRole = db.Users.Where(m => m.UserName == username).Select(m => m.UserRole).FirstOrDefault();
            if (userRole == "Employee")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customers customers = db.Customers.Find(id);
                if (customers == null)
                {
                    return HttpNotFound();
                }
                return View(customers);
            }
            else if(userRole == "Customer")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customers customers = db.Customers.Find(id);
                if (customers == null)
                {
                    return HttpNotFound();
                }
                return View(customers);
            }
            else
            {
                return RedirectToAction("Index");
            }   
            
        }
        
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PickupDay,Date,SuspensionStartDate,SuspensionEndDate,ZipCode,PickupBill,PickupStatus")] Customers customers)
        {
            ApplicationUser user = new ApplicationUser();
            var username = User.Identity.Name;
            var userRole = db.Users.Where(m => m.UserName == username).Select(m => m.UserRole).FirstOrDefault();
            var sameCustomer = db.Customers.Where(c => c.Id == customers.Id).FirstOrDefault();
            if (userRole == "Employee")
            {
                //sameCustomer.PickupBill = customers.PickupBill;
                sameCustomer.PickupStatus = customers.PickupStatus;
                if(customers.PickupStatus == true)
                {
                    customers.PickupBill = 25.00;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //if(ModelState.IsValid)
                //{
                //    customers.PickupBill += 25.00;
                //    customers.PickupStatus = true;
                //    db.Entry(customers).State = EntityState.Modified;
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                //else
                //{
                //    return View(customers);
                //}
                
            }
            else if (userRole == "Customer")
            {
                sameCustomer.FirstName = customers.FirstName;
                sameCustomer.LastName = customers.LastName;
                sameCustomer.PickupDay = customers.PickupDay;
                sameCustomer.Date = customers.Date;
                sameCustomer.SuspensionStartDate = customers.SuspensionStartDate;
                sameCustomer.SuspensionEndDate = customers.SuspensionEndDate;
                sameCustomer.ZipCode = customers.ZipCode;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");


        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
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
