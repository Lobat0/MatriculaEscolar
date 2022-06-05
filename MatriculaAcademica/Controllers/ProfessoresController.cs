using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MatriculaAcademica.Models;

namespace MatriculaAcademica.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: Professores
        public ActionResult Index()
        {
            if (Session["tipo"] != null)
            {
                return View(db.Professor.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Professores/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["tipo"] != null)
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
            return RedirectToAction("Index", "Home");
        }

        // GET: Professores/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Professores/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_professor,nome_professor,CPF,telefone")] Professor professor)
        {
            if (Session["tipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (db.Professor.Any(a1 => a1.CPF.Equals(professor.CPF)))
                    {
                        //variavel do erro de cadastro duplicado
                        Session["errodb.Msg"] = "Erro: Cadastro com itens duplicados";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        try
                        {
                            db.Professor.Add(professor);
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Professores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["tipo"] != null)
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
            return RedirectToAction("Index", "Home");
        }

        // POST: Professores/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_professor,nome_professor,CPF,telefone")] Professor professor)
        {
            if (Session["tipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Entry(professor).State = EntityState.Modified;
                        db.SaveChanges();
                        Session["susdb.Msg"] = "Sucesso: Edição efetuada";
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        Session["errodb.Msg"] = "Erro: Edição com itens duplicados";
                        Console.WriteLine(e);
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Professores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["tipo"] != null)
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
            return RedirectToAction("Index", "Home");
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["tipo"] != null)
            {
                try
                {
                    Professor professor = db.Professor.Find(id);
                    db.Professor.Remove(professor);
                    db.SaveChanges();
                    Session["susdb.Msg"] = "Sucesso: item excluido";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Session["errodb.Msg"] = "Erro: Item com referências não pode ser deletado";
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
