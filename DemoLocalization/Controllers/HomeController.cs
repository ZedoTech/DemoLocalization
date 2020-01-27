using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using DemoLocalization.Models;
using DemoLocalization.Middlewares;
using DemoLocalization.Models.DataTransferObjects;

namespace DemoLocalization.Controllers
{
    [MiddlewareFilter(typeof(CultureMiddleware))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(DemoLocalizationDTO para)
        {
            if (ModelState.IsValid)
            {
                TempData["result"] = "<h4 class='text-success'>Post data is Valid</h4>";
            }
            else
            {
                TempData["result"] = "<h4 class='text-danger'>Post data not valid</h4>";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
