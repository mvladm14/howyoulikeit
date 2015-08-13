using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using howyoulikeit.Models;
using howyoulikeit.Models.myevent;

namespace howyoulikeit.Controllers
{
    public class MyEventsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: MyEvents
        public ActionResult Index()
        {
            return View(db.MyEvents.ToList());
        }

        // GET: MyEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyEvent myEvent = db.MyEvents.Find(id);
            if (myEvent == null)
            {
                return HttpNotFound();
            }
            return View(myEvent);
        }

        // GET: MyEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MyEventId,UserId,Name,Location")] MyEvent myEvent)
        {
            if (ModelState.IsValid)
            {
                db.MyEvents.Add(myEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myEvent);
        }

        // GET: MyEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyEvent myEvent = db.MyEvents.Find(id);
            if (myEvent == null)
            {
                return HttpNotFound();
            }
            return View(myEvent);
        }

        // POST: MyEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MyEventId,UserId,Name,Location")] MyEvent myEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myEvent);
        }

        // GET: MyEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyEvent myEvent = db.MyEvents.Find(id);
            if (myEvent == null)
            {
                return HttpNotFound();
            }
            return View(myEvent);
        }

        // POST: MyEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyEvent myEvent = db.MyEvents.Find(id);
            db.MyEvents.Remove(myEvent);
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
