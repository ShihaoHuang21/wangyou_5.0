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
    public class wenzController : Controller
    {
        private WangYouBKEntities db = new WangYouBKEntities();

        //
        // GET: /wenz/

        public ActionResult Index()
        {
            var wenzhang = db.WenZhang.Include(w => w.WanZhangType);
            return View(wenzhang.ToList());
        }

        //
        // GET: /wenz/Details/5

        public ActionResult Details(int id = 0)
        {
            WenZhang wenzhang = db.WenZhang.Find(id);
            if (wenzhang == null)
            {
                return HttpNotFound();
            }
            return View(wenzhang);
        }

        //
        // GET: /wenz/Create

        public ActionResult Create()
        {
            ViewBag.wenzhangTypeID = new SelectList(db.WanZhangType, "WenZhangTypeID", "WenZhangTypeNmae");
            return View();
        }

        //
        // POST: /wenz/Create

        [HttpPost]
        public ActionResult Create(WenZhang wenzhang)
        {
            if (ModelState.IsValid)
            {
                db.WenZhang.Add(wenzhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.wenzhangTypeID = new SelectList(db.WanZhangType, "WenZhangTypeID", "WenZhangTypeNmae", wenzhang.wenzhangTypeID);
            return View(wenzhang);
        }

        //
        // GET: /wenz/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WenZhang wenzhang = db.WenZhang.Find(id);
            if (wenzhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.wenzhangTypeID = new SelectList(db.WanZhangType, "WenZhangTypeID", "WenZhangTypeNmae", wenzhang.wenzhangTypeID);
            return View(wenzhang);
        }

        //
        // POST: /wenz/Edit/5

        [HttpPost]
        public ActionResult Edit(WenZhang wenzhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wenzhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.wenzhangTypeID = new SelectList(db.WanZhangType, "WenZhangTypeID", "WenZhangTypeNmae", wenzhang.wenzhangTypeID);
            return View(wenzhang);
        }

        //
        // GET: /wenz/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WenZhang wenzhang = db.WenZhang.Find(id);
            if (wenzhang == null)
            {
                return HttpNotFound();
            }
            return View(wenzhang);
        }

        //
        // POST: /wenz/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WenZhang wenzhang = db.WenZhang.Find(id);
            db.WenZhang.Remove(wenzhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}