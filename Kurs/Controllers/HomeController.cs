using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kurs.Models;
using Data.GenericRepozitory;
using Data.Models;

namespace Kurs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IEFRepository<Ship> EFRepositoryShip;
        public IEFRepository<City> EFRepositoryCity;
        public IEFRepository<Country> EFRepositoryCountries;
        public HomeController(ILogger<HomeController> logger, IEFRepository<Ship> eFRepositoryShip, IEFRepository<City> eFRepositoryCity, IEFRepository<Country> eFRepositoryCountries)
        {
            _logger = logger;
            EFRepositoryShip = eFRepositoryShip;
            EFRepositoryCity = eFRepositoryCity;
            EFRepositoryCountries = eFRepositoryCountries;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityAndCountry()
        {

            return View(EFRepositoryCity.IncludeGet(i => i.Country));
        }
        [HttpGet]
        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            Country NewCountry = country;
            NewCountry.CountryId = Guid.NewGuid();
            EFRepositoryCountries.Create(NewCountry);
            return Redirect("/Home/CityAndCountry");
        }
        [HttpGet]
        public IActionResult AddCity()
        {
            ViewBag.Countries = EFRepositoryCountries.Get();
            return View();
        }
        [HttpPost]
        public IActionResult AddCity(City city)
        {


            EFRepositoryCity.Create(city);
            return Redirect("/Home/CityAndCountry");
        }
        public JsonResult GetCities()
        {

            return Json(EFRepositoryCity.Get());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
