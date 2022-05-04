using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MatriculaAcademica.Models;

namespace MatriculaAcademica.Controllers
{
    public class ProfessoresController : Controller
    {
        private MatriculaAcademicadbEntities db = new MatriculaAcademicadbEntities();

        // GET: Professores
        public ActionResult Index()
        {
            var professor = db.Professor.Include(p => p.Disciplina);
            return View(professor.ToList());
        }

        // GET: Professores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professor.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professores/Create
        public ActionResult Create()
        {
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
            return View();
        }

        // POST: Professores/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_professor,nome_professor,CPF,telefone,id_disciplina")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professor.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professor.id_disciplina);
            return View(professor);
        }

        // GET: Professores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professor.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professor.id_disciplina);
            return View(professor);
        }

        // POST: Professores/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_professor,nome_professor,CPF,telefone,id_disciplina")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professor.id_disciplina);
            return View(professor);
        }

        // GET: Professores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professor.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Professor.Find(id);
            db.Professor.Remove(professor);
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
