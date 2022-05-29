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
    public class MatriculasController : Controller
    {
        private MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: Matriculas
        public ActionResult Index()
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    var matricula = db.Matricula.Include(m => m.Aluno).Include(m => m.Curso).Include(m => m.Usuario);
                    return View(matricula.ToList());
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Matriculas/Details/5
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
                    Matricula matricula = db.Matricula.Find(id);
                    if (matricula == null)
                    {
                        return HttpNotFound();
                    }
                    return View(matricula);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "nome_aluno");
                    ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso");
                    ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "login");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
            
        }

        // POST: Matriculas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_matricula,data_matricula,id_curso,id_aluno,id_usuario")] Matricula matricula)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            db.Matricula.Add(matricula);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                            return RedirectToAction("Index");
                        }
                    }

                    ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "nome_aluno", matricula.id_aluno);
                    ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", matricula.id_curso);
                    ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "login", matricula.id_usuario);
                    return View(matricula);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Matriculas/Edit/5
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
                    Matricula matricula = db.Matricula.Find(id);
                    if (matricula == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "nome_aluno", matricula.id_aluno);
                    ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", matricula.id_curso);
                    ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "login", matricula.id_usuario);
                    return View(matricula);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Matriculas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_matricula,data_matricula,id_curso,id_aluno,id_usuario")] Matricula matricula)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(matricula).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "nome_aluno", matricula.id_aluno);
                    ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", matricula.id_curso);
                    ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "login", matricula.id_usuario);
                    return View(matricula);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Matriculas/Delete/5
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
                    Matricula matricula = db.Matricula.Find(id);
                    if (matricula == null)
                    {
                        return HttpNotFound();
                    }
                    return View(matricula);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    Matricula matricula = db.Matricula.Find(id);
                    db.Matricula.Remove(matricula);
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
