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
    public class CursoDisciplinasController : Controller
    {
        private MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: CursoDisciplinas
        public ActionResult Index()
        {
            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso");
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");

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

        // GET: CursoDisciplinas/Details/5
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

        // GET: CursoDisciplinas/Create
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

        // POST: CursoDisciplinas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_curso,id_disciplina")] CursoDisciplina cursoDisciplina)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    //if (ModelState.IsValid)
                    //{
                    //    db.CursoDisciplina.Add(cursoDisciplina);
                    //    db.SaveChanges();
                    //    return RedirectToAction("Index");
                    //}

                    if (ModelState.IsValid)
                    {
                        var condicao = db.CursoDisciplina.Where(u => u.id_curso == cursoDisciplina.id_curso && u.id_disciplina == cursoDisciplina.id_disciplina).FirstOrDefault();

                        if (condicao != null)
                        {
                            //variavel do erro de cadastro duplicado
                            Session["errodb.Msg"] = "Erro: Cadastro com itens duplicados";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            try
                            {
                                db.CursoDisciplina.Add(cursoDisciplina);
                                db.SaveChanges();
                                Session["susdb.Msg"] = "Sucesso: Cadastro efetuado";
                                return RedirectToAction("Index");
                            }
                            catch (Exception e)
                            {
                                Session["errodb.Msg"] = e.Message;
                                return RedirectToAction("Index");
                            }
                        }
                    }

                    ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", cursoDisciplina.id_curso);
                    ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", cursoDisciplina.id_disciplina);
                    return View(cursoDisciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursoDisciplinas/Edit/5
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

        // POST: CursoDisciplinas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: CursoDisciplinas/Delete/5
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

        // POST: CursoDisciplinas/Delete/5
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
