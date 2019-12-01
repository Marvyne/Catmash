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
using CatmashWebApplication.ViewModel;

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
            return View(_service.GetCat().GetAll());
        }

        public IActionResult Vote(ViewModelVote cats)
        {
            Cat winner, loser;
            if (cats.cat1 == cats.winner)
            {
                winner = _service.GetCat().Get(cats.cat1);
                loser = _service.GetCat().Get(cats.cat2);
            }
            else if (cats.cat2 == cats.winner)
            {
                winner = _service.GetCat().Get(cats.cat2);
                loser = _service.GetCat().Get(cats.cat1);
            }
            else
            {
                return RedirectToAction("Index");
            }
            Cat[] competitors = _service.GetDuel().ResultOfDuel(winner, loser);
            _service.GetCat().Updated(competitors[0]);
            _service.GetCat().Updated(competitors[1]);
            return RedirectToAction("Index");
        }

        public IActionResult Ranking()
        {
            ViewBag.rank = 0;
            return View(_service.GetCat().GetAll().OrderByDescending(x => x.Score));
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
