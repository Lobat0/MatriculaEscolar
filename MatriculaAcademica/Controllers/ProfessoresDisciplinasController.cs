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
        private MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: ProfessoresDisciplinas
        public ActionResult Index()
        {
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
            ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor");

            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    var professorDisciplina = db.ProfessorDisciplina.Include(p => p.Disciplina).Include(p => p.Professor);
                    return View(professorDisciplina.ToList());
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
                    ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ProfessoresDisciplinas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_professor_disciplina,id_professor,id_disciplina")] ProfessorDisciplina professorDisciplina)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ProfessoresDisciplinas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_professor_disciplina,id_professor,id_disciplina")] ProfessorDisciplina professorDisciplina)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ProfessoresDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
                    db.ProfessorDisciplina.Remove(professorDisciplina);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index", "Home");
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
