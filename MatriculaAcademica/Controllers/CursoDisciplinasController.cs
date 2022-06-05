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
        private readonly MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: CursoDisciplinas
        public ActionResult Index()
        {
            if (Session["tipo"] != null)
            {
                ViewBag.id_curso = new MultiSelectList(db.Curso, "id_curso", "nome_curso", "turno");
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");

                var cursoDisciplina = db.CursoDisciplina.Include(c => c.Curso).Include(c => c.Disciplina);
                return View(cursoDisciplina.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursoDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    Session["errodb.Msg"] = "Erro: ID da disciplina não encontrado.";
                    return RedirectToAction("Index", "Cursos");
                }
                CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
                if (cursoDisciplina == null)
                {
                    Session["errodb.Msg"] = "Erro: Disciplina não encontrada.";
                    return RedirectToAction("Index", "Cursos");
                }
                return View(cursoDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursoDisciplinas/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                ViewBag.id_curso = new MultiSelectList(db.Curso, "id_curso", "nome_curso", "turno");
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
                return View();
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
                if (ModelState.IsValid)
                {

                    var condicao = db.CursoDisciplina.Where(u => u.id_curso == cursoDisciplina.id_curso && u.id_disciplina == cursoDisciplina.id_disciplina).FirstOrDefault();
                    if (condicao != null)
                    {
                        //variavel do erro de cadastro duplicado
                        Session["errodb.Msg"] = "Erro: Cadastro com itens duplicados";
                        return RedirectToAction("Disciplinas", new { id = cursoDisciplina.id_curso });
                    }
                    else
                    {
                        try
                        {
                            db.CursoDisciplina.Add(cursoDisciplina);
                            db.SaveChanges();
                            Session["susdb.Msg"] = "Sucesso: Cadastro efetuado";
                            return RedirectToAction("Disciplinas", new { id = cursoDisciplina.id_curso });
                        }
                        catch (Exception e)
                        {
                            Session["errodb.Msg"] = e.Message;
                            return RedirectToAction("Disciplinas", new { id = cursoDisciplina.id_curso });
                        }
                    }
                }

                ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", cursoDisciplina.id_curso);
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", cursoDisciplina.id_disciplina);
                return View(cursoDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursoDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    Session["errodb.Msg"] = "Erro: Curso/Disciplinas não encontrados";
                    return RedirectToAction("Index");
                }
                CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
                if (cursoDisciplina == null)
                {
                    Session["errodb.Msg"] = "Erro: Curso/Disciplinas não encontrados";
                    return RedirectToAction("Index");
                }
                ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", cursoDisciplina.id_curso);
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", cursoDisciplina.id_disciplina);
                return View(cursoDisciplina);
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
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Entry(cursoDisciplina).State = EntityState.Modified;
                        db.SaveChanges();
                        Session["susdb.Msg"] = "Sucesso: Edição efetuada";
                        return RedirectToAction("Disciplinas", new { id = cursoDisciplina.id_curso });
                    }
                    catch (Exception e)
                    {
                        Session["errodb.Msg"] = e.Message;
                        Console.WriteLine(e);
                        return RedirectToAction("Disciplinas", new { id = cursoDisciplina.id_curso });
                    }

                }
                ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "nome_curso", cursoDisciplina.id_curso);
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", cursoDisciplina.id_disciplina);
                return View(cursoDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursoDisciplinas/Disciplinas/5
        public ActionResult Disciplinas(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    Session["errodb.Msg"] = "Erro: Curso/Disciplinas não encontrados";
                    return RedirectToAction("Index", "Cursos");
                }
                Curso curso = db.Curso.Find(id);
                if (curso == null)
                {
                    Session["errodb.Msg"] = "Erro: Curso/Disciplinas não encontrados";
                    return RedirectToAction("Index", "Cursos");
                }
                IEnumerable<Disciplina> disciplinas = curso.CursoDisciplina.Select(cd => cd.Disciplina);
                ViewBag.disciplinas = disciplinas;
                ViewBag.curso = curso;
                
                ViewBag.id_curso = new MultiSelectList(db.Curso, "id_curso", "nome_curso", "turno");
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");

                return View(disciplinas);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CursoDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    Session["errodb.Msg"] = "Erro: Curso/Disciplinas não encontrados";
                    return RedirectToAction("Index", "Cursos");
                }
                CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
                if (cursoDisciplina == null)
                {
                    Session["errodb.Msg"] = "Erro: Curso/Disciplinas não encontrados";
                    return RedirectToAction("Index", "Cursos");
                }
                return View(cursoDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: CursoDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["tipo"] != null)
            {
                try
                {
                    CursoDisciplina cursoDisciplina = db.CursoDisciplina.Find(id);
                    db.CursoDisciplina.Remove(cursoDisciplina);
                    db.SaveChanges();
                    Session["susdb.Msg"] = "Sucesso: item excluido";
                    return RedirectToAction("Disciplinas", new { id = cursoDisciplina.id_curso });
                }
                catch (Exception e)
                {
                    Session["errodb.Msg"] = "Erro: Item com referências não pode ser deletado";
                    Console.WriteLine(e);
                    return RedirectToAction("Index", "Cursos");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: CursoDisciplinas/DeleteSemId/5
        [HttpPost, ActionName("DeleteSemId")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSemId(int id_curso, int id_disciplina)
        {
            if (Session["tipo"] != null)
            {
                try
                {
                    CursoDisciplina cursoDisciplina = db.CursoDisciplina.Where(cd => cd.id_curso == id_curso && cd.id_disciplina == id_disciplina).FirstOrDefault();
                    db.CursoDisciplina.Remove(cursoDisciplina);
                    db.SaveChanges();
                    Session["susdb.Msg"] = "Sucesso: item excluido";
                    return RedirectToAction("Disciplinas", new { id = cursoDisciplina.id_curso });
                }
                catch (Exception e)
                {
                    Session["errodb.Msg"] = "Erro: Item com referências não pode ser deletado";
                    Console.WriteLine(e);
                    return RedirectToAction("Disciplinas", new { id = id_curso });
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
