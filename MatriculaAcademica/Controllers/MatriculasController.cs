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
            ViewBag.id_aluno = new MultiSelectList(db.Curso, "id_curso", "nome_aluno", "CPF");
            ViewBag.id_curso = new MultiSelectList(db.Curso, "id_curso", "nome_curso", "turno");

            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "Admin"))
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
                if (string.Equals(permissao, "Admin"))
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
                if (string.Equals(permissao, "Admin"))
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
                if (string.Equals(permissao, "Admin"))
                {
                    if (ModelState.IsValid)
                    {

                        var condicao = db.Matricula.Where(u => u.id_curso == matricula.id_curso && u.id_aluno == matricula.id_aluno).FirstOrDefault();
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
                                db.Matricula.Add(matricula);
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

                    ViewBag.id_aluno = new MultiSelectList(db.Curso, "id_curso", "nome_aluno", "CPF");
                    ViewBag.id_curso = new MultiSelectList(db.Curso, "id_curso", "nome_curso", "turno");
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
                if (string.Equals(permissao, "Admin"))
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
                if (string.Equals(permissao, "Admin"))
                {
                    //if (ModelState.IsValid)
                    //{
                    //    db.Entry(matricula).State = EntityState.Modified;
                    //    db.SaveChanges();
                    //    return RedirectToAction("Index");
                    //}

                    if (ModelState.IsValid)
                    {
                        var condicao = db.Matricula.Where(u => u.id_curso == matricula.id_curso && u.id_aluno == matricula.id_aluno).FirstOrDefault();
                        if (condicao != null)
                        {
                            //variavel do erro de alteração duplicada
                            Session["errodb.Msg"] = "Erro: Edição com itens iguais";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            try
                            {
                                db.Entry(matricula).State = EntityState.Modified;
                                db.SaveChanges();
                                Session["susdb.Msg"] = "Sucesso: Edição efetuada";
                                return RedirectToAction("Index");
                            }
                            catch (Exception e)
                            {
                                Session["errodb.Msg"] = e.Message;
                                Console.WriteLine(e);
                                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                            }
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

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "Admin"))
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
                if (string.Equals(permissao, "Admin"))
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
