using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jogoEmprestado.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace jogoEmprestado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected IActionResult<Jogo> _jogo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new Jogo
            {
                consolePc = "PC",
                nome = "maxpayne",
                entrega = DateTime.Now.AddDays(7)
            };

            // ViewData[Envia];

            //foi mal
            //if(_jogo != null)
            //{
           Envia(model);
            //}
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Envia(Jogo jogo)
        {    if(ModelState.IsValid)
            {
            
                try
                {
                    if (jogo.entrega >= DateTime.Now && jogo.entrega != null)
                    {
                        View(jogo);
                    }
                
                    return (ViewBag.jogo);
                }
                catch(Exception e)
                {
                    throw new Exception("erro");
                }
            }
            else
            {
                return (View("obrigado", jogo));
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
