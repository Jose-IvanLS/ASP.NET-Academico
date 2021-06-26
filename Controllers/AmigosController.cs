using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATVitor.Models;
using ATVitor.Services;
using ATVitor.Database;

namespace ATVitor.Controllers {
    public class AmigosController : Controller {
        //static List<Amigo> amigos = new List<Amigo>();

        private AmigosDb db;

        public AmigosController(AmigosDb db) {
            this.db = db;
        }

        [HttpGet]
        [Route("/amigos/cadastrar")]
        public IActionResult CadastrarAmigo() {
            return View();
        }

        [HttpGet]
        [Route("/amigos/listar")]
        public ActionResult ListarAmigos(string nome) {
            var service = new AmigosService(db);
            List<Amigo> amigos = service.ListarAmigos(nome);
            return View(amigos);
        }

        [HttpPost]
        public ActionResult CadastrandoAmigo(string nome, string sobrenome, DateTime aniversario) {
            var service = new AmigosService(db);
            service.CadastrarAmigo(nome, sobrenome, aniversario);
            return Redirect("/amigos/listar");
        }

        [HttpGet]
        [Route("/amigos/excluir")]
        public ActionResult ExcluirAmigoGet(int id) {
            var service = new AmigosService(db);
            var amigo = service.BuscarPelo(id);
            return View("ExcluirAmigo", amigo);
        }
        [HttpPost]
        [Route("/amigos/excluir")]
        public ActionResult ExcluirAmigoPost(int id) {
            var service = new AmigosService(db);
            service.ExcluirAmigo(id);
            return Redirect("/amigos/listar");
        }

        [HttpGet]
        [Route("/amigos/editar")]
        public ActionResult EditarAmigoGet(int id) {
            var service = new AmigosService(db);
            var amigo = service.BuscarPelo(id);
            return View("EditarAmigo", amigo);
        }

        [HttpPost]
        [Route("/amigos/editar")]
        public ActionResult EditarAmigoPost(int id, string nome, string sobrenome, DateTime aniversario) {
            var service = new AmigosService(db);
            service.EditarAmigo(id, nome, sobrenome, aniversario);
            return Redirect("/amigos/listar");
        }
    }
}