using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MatriculaAcademica.Models;

namespace MatriculaAcademica.Controllers
{
    public class AlunosController : Controller
    {
        private readonly MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: Alunos
        public ActionResult Index()
        {
            if (Session["tipo"] != null)
            {
                return View(db.Aluno.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("Error");
                }
                Aluno aluno = db.Aluno.Find(id);
                if (aluno == null)
                {
                    return HttpNotFound();
                }
                return View(aluno);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Alunos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_aluno,nome_aluno,CPF,nascimento")] Aluno aluno)
        {
            if (Session["tipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (db.Aluno.Any(a1 => a1.CPF.Equals(aluno.CPF)))
                    {
                        //variavel do erro de cadastro duplicado
                        Session["errodb.Msg"] = "Erro: Cadastro com itens duplicados";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        try
                        {
                            db.Aluno.Add(aluno);
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

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("Error");
                }
                try
                {
                    Aluno aluno = db.Aluno.Find(id);
                    if (aluno == null)
                    {
                        return HttpNotFound();
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Session["errodb.Msg"] = e.Message;
                    Console.WriteLine(e);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Alunos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_aluno,nome_aluno,CPF,nascimento")] Aluno aluno)
        {
            if (Session["tipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Entry(aluno).State = EntityState.Modified;
                        db.SaveChanges();
                        Session["susdb.Msg"] = "Sucesso: Edição efetuada";
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        Session["errodb.Msg"] = "Erro: Edição com itens iguais";
                        Console.WriteLine(e);
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("Error");
                }
                Aluno aluno = db.Aluno.Find(id);
                if (aluno == null)
                {
                    return HttpNotFound();
                }

            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["tipo"] != null)
            {
                try
                {
                    Aluno aluno = db.Aluno.Find(id);
                    db.Aluno.Remove(aluno);
                    db.SaveChanges();
                    Session["susdb.Msg"] = "Sucesso: item excluido";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Session["errodb.Msg"] = "Erro: Item com referências não pode ser deletado";
                    Console.WriteLine(e);
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
