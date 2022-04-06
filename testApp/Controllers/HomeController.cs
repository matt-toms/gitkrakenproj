using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

        private readonly Settings _settings;

        //public HomeController(ILogger<HomeController> logger, imyservice myservice, Settings settings)


        public HomeController(ILogger<HomeController> logger, imyservice myservice, IOptionsMonitor<Settings> settingsMonitor)
        {
            _logger = logger;
            _myservice = myservice;
            _settings = settingsMonitor.CurrentValue;
        }

        public IActionResult Index()
        {

            // string c = DataSettingsManager.Loadsettings().ConnectionString;


            // string d = DataSettingsManager.Loadsettings().ConnectionString;

            var url = _settings.imagefolder;



            Product id = _myservice.GetProducts();

            return View();
        }

        public IActionResult Privacy()
        {
            string c = DataSettingsManager.Loadsettings().ConnectionString;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
