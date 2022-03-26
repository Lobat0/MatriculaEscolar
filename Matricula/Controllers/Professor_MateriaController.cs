using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matricula.Models;

namespace Matricula.Controllers
{
    public class Professor_MateriaController : Controller
    {
        private MatriculaEntities db = new MatriculaEntities();

        // GET: Professor_Materia
        public ActionResult Index()
        {
            var professor_Materia = db.Professor_Materia.Include(p => p.Materia).Include(p => p.Professor);
            return View(professor_Materia.ToList());
        }

        // GET: Professor_Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor_Materia professor_Materia = db.Professor_Materia.Find(id);
            if (professor_Materia == null)
            {
                return HttpNotFound();
            }
            return View(professor_Materia);
        }

        // GET: Professor_Materia/Create
        public ActionResult Create()
        {
            ViewBag.id_materia = new SelectList(db.Materia, "id_materia", "nome");
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "situacao");
            return View();
        }

        // POST: Professor_Materia/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_professor_materia,id_professor,id_materia")] Professor_Materia professor_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Professor_Materia.Add(professor_Materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_materia = new SelectList(db.Materia, "id_materia", "nome", professor_Materia.id_materia);
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "situacao", professor_Materia.id_professor);
            return View(professor_Materia);
        }

        // GET: Professor_Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor_Materia professor_Materia = db.Professor_Materia.Find(id);
            if (professor_Materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_materia = new SelectList(db.Materia, "id_materia", "nome", professor_Materia.id_materia);
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "situacao", professor_Materia.id_professor);
            return View(professor_Materia);
        }

        // POST: Professor_Materia/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_professor_materia,id_professor,id_materia")] Professor_Materia professor_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor_Materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_materia = new SelectList(db.Materia, "id_materia", "nome", professor_Materia.id_materia);
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "situacao", professor_Materia.id_professor);
            return View(professor_Materia);
        }

        // GET: Professor_Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor_Materia professor_Materia = db.Professor_Materia.Find(id);
            if (professor_Materia == null)
            {
                return HttpNotFound();
            }
            return View(professor_Materia);
        }

        // POST: Professor_Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor_Materia professor_Materia = db.Professor_Materia.Find(id);
            db.Professor_Materia.Remove(professor_Materia);
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
