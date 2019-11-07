using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wangyou.Models;

namespace wangyou.Controllers
{
    public class HoutaiController : Controller
    {
        private WangYouBKEntities db = new WangYouBKEntities();

        //
        // GET: /Houtai/
        public ActionResult kuang()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(db.bk_users.ToList());
        }

        //
        // GET: /Houtai/Details/5

        public ActionResult Details(int id = 0)
        {
            bk_users bk_users = db.bk_users.Find(id);
            if (bk_users == null)
            {
                return HttpNotFound();
            }
            return View(bk_users);
        }

        //
        // GET: /Houtai/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Houtai/Create

        [HttpPost]
        public ActionResult Create(bk_users bk_users)
        {
            if (ModelState.IsValid)
            {
                db.bk_users.Add(bk_users);
                db.SaveChanges();
                return RedirectToAction("kuang", "Houtai");
            }

            return View(bk_users);
        }

        //
        // GET: /Houtai/Edit/5

        public ActionResult Edit(int id = 0)
        {
            bk_users bk_users = db.bk_users.Find(id);
            if (bk_users == null)
            {
                return HttpNotFound();
            }
            return View(bk_users);
        }

        //
        // POST: /Houtai/Edit/5

        [HttpPost]
        public ActionResult Edit(bk_users bk_users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bk_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("kuang", "Houtai");
            }
            return View(bk_users);
        }

        //
        // GET: /Houtai/Delete/5

        public ActionResult Delete(int id = 0)
        {
            bk_users bk_users = db.bk_users.Find(id);
            if (bk_users == null)
            {
                return HttpNotFound();
            }
            return View(bk_users);
        }

        //
        // POST: /Houtai/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bk_users bk_users = db.bk_users.Find(id);
            db.bk_users.Remove(bk_users);
            db.SaveChanges();
            return RedirectToAction("kuang", "Houtai");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}