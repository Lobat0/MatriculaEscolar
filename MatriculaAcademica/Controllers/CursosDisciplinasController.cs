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
    public class CursosDisciplinasController : Controller
    {
        private MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: CursosDisciplinas
        public ActionResult Index()
        {
            var cursoDisciplina = db.CursoDisciplina.Include(c => c.Curso).Include(c => c.Disciplina);
            return View(cursoDisciplina.ToList());
        }

        // GET: CursosDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
            if (cursoDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(cursoDisciplina);
        }

        // GET: CursosDisciplinas/Create
        public ActionResult Create()
        {
            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso");
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
            return View();
        }

        // POST: CursosDisciplinas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_curso_disciplina,id_curso,id_disciplina")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.CursoDisciplina.Add(cursoDisciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", cursoDisciplina.id_curso);
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", cursoDisciplina.id_disciplina);
            return View(cursoDisciplina);
        }

        // GET: CursosDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
            if (cursoDisciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", cursoDisciplina.id_curso);
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", cursoDisciplina.id_disciplina);
            return View(cursoDisciplina);
        }

        // POST: CursosDisciplinas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_curso_disciplina,id_curso,id_disciplina")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoDisciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", cursoDisciplina.id_curso);
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", cursoDisciplina.id_disciplina);
            return View(cursoDisciplina);
        }

        // GET: CursosDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
            if (cursoDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(cursoDisciplina);
        }

        // POST: CursosDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
            db.CursoDisciplina.Remove(cursoDisciplina);
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
