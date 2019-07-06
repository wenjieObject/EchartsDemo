using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EchartsDemo.Models;

namespace EchartsDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            var connectionString = appSettingsJson["MssqlConnectionString"];

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
