using MetadataExtractor;
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
        private readonly IOptionsMonitor<Settings> settingsMonitor;
        private readonly string test;
        private readonly Settings _settings;



        //public HomeController(ILogger<HomeController> logger, imyservice myservice, Settings settings)


        public HomeController(ILogger<HomeController> logger, imyservice myservice, IOptionsMonitor<Settings> settingsMonitor)
        {

            _logger = logger;
            _myservice = myservice;
            this.settingsMonitor = settingsMonitor;
            _settings = settingsMonitor.CurrentValue;
        }






        public IActionResult Index()
        {


            var imagePath = @"C:\inetpub\wwwroot\testApp\testApp\wwwroot\images\alw.jpg";

            var directories = ImageMetadataReader.ReadMetadata(imagePath);

            return View(directories);
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
