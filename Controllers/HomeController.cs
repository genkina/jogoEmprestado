using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jogoEmprestado.Models;
using Microsoft.AspNetCore.Hosting.Server;

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
           // ViewData[Envia];

            //foi mal
            if(_jogo != null)
            {
                Envia((Jogo)_jogo);
            }
            return View();
        }
        [HttpPost]
        public HttpPostAttribute Envia(Jogo jogo)
        {
            try
            {
                if (jogo.entrega > DateTime.Now && jogo.entrega != null)
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
