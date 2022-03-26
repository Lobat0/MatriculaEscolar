using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matricula.Models;

namespace Matricula.Controllers
{
    public class SolicitacaosController : Controller
    {
        private MatriculaEntities db = new MatriculaEntities();

        // GET: Solicitacaos
        public ActionResult Index()
        {
            var solicitacao = db.Solicitacao.Include(s => s.Funcionario);
            return View(solicitacao.ToList());
        }

        // GET: Solicitacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = db.Solicitacao.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        // GET: Solicitacaos/Create
        public ActionResult Create()
        {
            ViewBag.id_funcionario = new SelectList(db.Funcionario, "id_funcionario", "situacao");
            return View();
        }

        // POST: Solicitacaos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_solicitacao,id_funcionario,tipo_documento,data_pedido,data_emissao")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                db.Solicitacao.Add(solicitacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_funcionario = new SelectList(db.Funcionario, "id_funcionario", "situacao", solicitacao.id_funcionario);
            return View(solicitacao);
        }

        // GET: Solicitacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = db.Solicitacao.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_funcionario = new SelectList(db.Funcionario, "id_funcionario", "situacao", solicitacao.id_funcionario);
            return View(solicitacao);
        }

        // POST: Solicitacaos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_solicitacao,id_funcionario,tipo_documento,data_pedido,data_emissao")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_funcionario = new SelectList(db.Funcionario, "id_funcionario", "situacao", solicitacao.id_funcionario);
            return View(solicitacao);
        }

        // GET: Solicitacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = db.Solicitacao.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        // POST: Solicitacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitacao solicitacao = db.Solicitacao.Find(id);
            db.Solicitacao.Remove(solicitacao);
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
