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
    public class Aluno_MateriaController : Controller
    {
        private MatriculaEntities db = new MatriculaEntities();

        // GET: Aluno_Materia
        public ActionResult Index()
        {
            var aluno_Materia = db.Aluno_Materia.Include(a => a.Aluno).Include(a => a.Materia);
            return View(aluno_Materia.ToList());
        }

        // GET: Aluno_Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno_Materia aluno_Materia = db.Aluno_Materia.Find(id);
            if (aluno_Materia == null)
            {
                return HttpNotFound();
            }
            return View(aluno_Materia);
        }

        // GET: Aluno_Materia/Create
        public ActionResult Create()
        {
            ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "id_pessoa");
            ViewBag.id_materia = new SelectList(db.Materia, "id_materia", "nome");
            return View();
        }

        // POST: Aluno_Materia/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_aluno_materia,id_aluno,id_materia")] Aluno_Materia aluno_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Aluno_Materia.Add(aluno_Materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "id_pessoa", aluno_Materia.id_aluno);
            ViewBag.id_materia = new SelectList(db.Materia, "id_materia", "nome", aluno_Materia.id_materia);
            return View(aluno_Materia);
        }

        // GET: Aluno_Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno_Materia aluno_Materia = db.Aluno_Materia.Find(id);
            if (aluno_Materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "id_pessoa", aluno_Materia.id_aluno);
            ViewBag.id_materia = new SelectList(db.Materia, "id_materia", "nome", aluno_Materia.id_materia);
            return View(aluno_Materia);
        }

        // POST: Aluno_Materia/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_aluno_materia,id_aluno,id_materia")] Aluno_Materia aluno_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno_Materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "id_pessoa", aluno_Materia.id_aluno);
            ViewBag.id_materia = new SelectList(db.Materia, "id_materia", "nome", aluno_Materia.id_materia);
            return View(aluno_Materia);
        }

        // GET: Aluno_Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno_Materia aluno_Materia = db.Aluno_Materia.Find(id);
            if (aluno_Materia == null)
            {
                return HttpNotFound();
            }
            return View(aluno_Materia);
        }

        // POST: Aluno_Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno_Materia aluno_Materia = db.Aluno_Materia.Find(id);
            db.Aluno_Materia.Remove(aluno_Materia);
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
