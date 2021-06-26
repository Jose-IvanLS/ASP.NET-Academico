using ATVitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ATVitor.Services;
using ATVitor.Database;

namespace ATVitor.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private AmigosDb db;

        public HomeController(ILogger<HomeController> logger, AmigosDb db) {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index() {
            var service = new AmigosService(db);
            List<Amigo> amigos = service.ListarAmigos();
            return View(amigos);
            
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
