﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MatriculaAcademica.Models;

namespace MatriculaAcademica.Controllers
{
    public class LoginController : Controller
    {
        private readonly MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sucesso
        public ActionResult Sucesso()
        {
            return View();
        }

        // GET: Erro
        public ActionResult Erro()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string login, string senha)
        {
            try
            {
                var usuario = db.Usuario.Where(u => u.login == login).FirstOrDefault();

                if (usuario != null)
                {
                    if (usuario.senha == senha)
                    {
                        Session["nome"] = usuario.login;
                        Session["tipo"] = usuario.tipo;
                        Session["id_usuario"] = usuario.id_usuario;
                        Session["dataAtual"] = DateTime.Now.ToString("yyyy-MM-dd");
                        ViewBag.Status = "200";
                        return RedirectToAction("index", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Status = e;
                return View("Index");
            }
            ViewBag.Status = "Invalido";
            return View("Index");
        }

        // Sair
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}