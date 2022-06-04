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
    public class DisciplinasController : Controller
    {
        private MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: Disciplinas
        public ActionResult Index()
        {
            if (Session["tipo"] != null)
            {
                return View(db.Disciplina.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Disciplinas/Details/5
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
                    Disciplina disciplina = db.Disciplina.Find(id);
                    if (disciplina == null)
                    {
                        return HttpNotFound();
                    }
                    return View(disciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Disciplinas/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "Admin"))
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Disciplinas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_disciplina,nome_disciplina")] Disciplina disciplina)
        {

            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "Admin"))
                {
                    if (ModelState.IsValid)
                    {
                        if (db.Disciplina.Any(a1 => a1.nome_disciplina.Equals(disciplina.nome_disciplina)))
                        {
                            //variavel do erro de cadastro duplicado
                            Session["errodb.Msg"] = "Erro: Cadastro com itens duplicados";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            try
                            {
                                db.Disciplina.Add(disciplina);
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

                    return View(disciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Disciplinas/Edit/5
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
                    Disciplina disciplina = db.Disciplina.Find(id);
                    if (disciplina == null)
                    {
                        return HttpNotFound();
                    }
                    return View(disciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Disciplinas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_disciplina,nome_disciplina")] Disciplina disciplina)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "Admin"))
                {
                    if (ModelState.IsValid)
                    {
                        if (db.Disciplina.Any(a1 => a1.nome_disciplina.Equals(disciplina.nome_disciplina)))
                        {
                            //variavel do erro de alteração duplicada
                            Session["errodb.Msg"] = "Erro: Edição com itens iguais";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            try
                            {
                                db.Entry(disciplina).State = EntityState.Modified;
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
                    return View(disciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Disciplinas/Delete/5
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
                    Disciplina disciplina = db.Disciplina.Find(id);
                    if (disciplina == null)
                    {
                        return HttpNotFound();
                    }
                    return View(disciplina);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "Admin"))
                {
                    try
                    {   
                        Disciplina disciplina = db.Disciplina.Find(id);
                        db.Disciplina.Remove(disciplina);
                        db.SaveChanges();
                        Session["susdb.Msg"] = "Sucesso: item excluido";
                        return RedirectToAction("Index");
                    }
                    catch(Exception e)
                    {
                        Session["errodb.Msg"] = "Erro: Item com referências não pode ser deletado";
                        Console.WriteLine(e);
                        return RedirectToAction("Index");
                    }
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
