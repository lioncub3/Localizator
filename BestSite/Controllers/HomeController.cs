using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestSite.Models;
using System.Globalization;
using Microsoft.Extensions.Localization;

namespace BestSite.Controllers
{
    public class HomeController : Controller
    {
        public IStringLocalizer<HomeController> Localizer { get; }

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            Localizer = localizer;
        }
        public IActionResult Index()
        {
            //CultureInfo.CurrentCulture = new CultureInfo("uk-Ua");
            //CultureInfo.CurrentUICulture = new CultureInfo("uk-Ua");

            //string name = CultureInfo.CurrentCulture.Name;
            
            //return Content($"{name}");

            return Content(Localizer["Hello world"]);
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
