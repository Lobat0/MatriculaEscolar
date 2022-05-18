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
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    var cursoDisciplina = db.CursoDisciplina.Include(c => c.Curso).Include(c => c.Disciplina);
                    return View(cursoDisciplina.ToList());
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursosDisciplinas/Details/5
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
                    CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
                    if (cursoDisciplina == null)
                    {
                        return HttpNotFound();
                    }
                    return View(cursoDisciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursosDisciplinas/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso");
                    ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: CursosDisciplinas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_curso_disciplina,id_curso,id_disciplina")] CursoDisciplina cursoDisciplina)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursosDisciplinas/Edit/5
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
                    CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
                    if (cursoDisciplina == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", cursoDisciplina.id_curso);
                    ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", cursoDisciplina.id_disciplina);
                    return View(cursoDisciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: CursosDisciplinas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_curso_disciplina,id_curso,id_disciplina")] CursoDisciplina cursoDisciplina)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursosDisciplinas/Delete/5
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
                    CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
                    if (cursoDisciplina == null)
                    {
                        return HttpNotFound();
                    }
                    return View(cursoDisciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: CursosDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
                    db.CursoDisciplina.Remove(cursoDisciplina);
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
