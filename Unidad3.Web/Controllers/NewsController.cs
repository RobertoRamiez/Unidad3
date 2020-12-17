using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unidad3.Web.Models;

namespace Unidad3.Web.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News
        public ActionResult Index()
        {
            var novedades = db.Novedades.Include(a => a.Genere);
            return View(novedades.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.Novedades.Include(a => a.Genere).
                Include(a => a.Desarrollador).Where(a => a.Id == id).
                SingleOrDefault();
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // GET: News/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Nombre");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(New @new, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Update/Novedad/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (file != null)
                {
                    file.SaveAs(path + file.FileName);
                    @new.Photo = file.FileName;
                }

                db.Novedades.Add(@new);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Nombre", @new.GenreId);
            return View(@new);
        }

        // GET: News/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.Novedades.Find(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Nombre", @new.GenreId);
            return View(@new);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,DateTime,GenreId")] New @new)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@new).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Nombre", @new.GenreId);
            return View(@new);
        }

        // GET: News/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.Novedades.Find(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            New @new = db.Novedades.Find(id);
            db.Novedades.Remove(@new);
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
