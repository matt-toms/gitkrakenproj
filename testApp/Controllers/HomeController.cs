using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using testApp.Code;
using testApp.Models;

namespace testApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly imyservice _myservice;


        public HomeController(ILogger<HomeController> logger, imyservice myservice)
        {
            _logger = logger;
            _myservice = myservice;
        }

        public IActionResult Index()
        {
            // new comment
            // myservice ms = new myservice();

            Product id = _myservice.GetProducts();


            return View();
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
