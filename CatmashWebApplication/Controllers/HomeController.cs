using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatmashWebApplication.Models;
using Microsoft.Extensions.Configuration;
using CatmashWebApplication.Facade;
using CatmashWebApplication.Util;

namespace CatmashWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly ServiceFacade _service;

        public HomeController(IConfiguration configuration, ServiceFacade service)
        {
            _configuration = configuration;
            ApplicationSettings.WebApiUrl = _configuration.GetSection("MySettings").GetSection("WebApiBaseUrl").Value;
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ranking()
        {
            return View(_service.GetCat().GetAll());
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
