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
    public class ProfessoresDisciplinasController : Controller
    {
        private MatriculaAcademicadbEntities db = new MatriculaAcademicadbEntities();

        // GET: ProfessoresDisciplinas
        public ActionResult Index()
        {
            var professorDisciplina = db.ProfessorDisciplina.Include(p => p.Disciplina).Include(p => p.Professor);
            return View(professorDisciplina.ToList());
        }

        // GET: ProfessoresDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
            if (professorDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(professorDisciplina);
        }

        // GET: ProfessoresDisciplinas/Create
        public ActionResult Create()
        {
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor");
            return View();
        }

        // POST: ProfessoresDisciplinas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_professor_disciplina,id_professor,id_disciplina")] ProfessorDisciplina professorDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.ProfessorDisciplina.Add(professorDisciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professorDisciplina.id_disciplina);
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor", professorDisciplina.id_professor);
            return View(professorDisciplina);
        }

        // GET: ProfessoresDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
            if (professorDisciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professorDisciplina.id_disciplina);
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor", professorDisciplina.id_professor);
            return View(professorDisciplina);
        }

        // POST: ProfessoresDisciplinas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_professor_disciplina,id_professor,id_disciplina")] ProfessorDisciplina professorDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professorDisciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professorDisciplina.id_disciplina);
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor", professorDisciplina.id_professor);
            return View(professorDisciplina);
        }

        // GET: ProfessoresDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
            if (professorDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(professorDisciplina);
        }

        // POST: ProfessoresDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
            db.ProfessorDisciplina.Remove(professorDisciplina);
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
