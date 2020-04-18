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
        public IEFRepository<Port> EFRepositoryPort;
        public IEFRepository<Country> EFRepositoryCountries;
        public HomeController(ILogger<HomeController> logger, IEFRepository<Ship> eFRepositoryShip, IEFRepository<City> eFRepositoryCity, IEFRepository<Country> eFRepositoryCountries, IEFRepository<Port> eFRepositoryPort)
        {
            _logger = logger;
            EFRepositoryShip = eFRepositoryShip;
            EFRepositoryCity = eFRepositoryCity;
            EFRepositoryCountries = eFRepositoryCountries;
            EFRepositoryPort = eFRepositoryPort;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityAndCountry()
        {
            var Data = EFRepositoryPort.IncludeGet(i => i.City).ToList();
            var Country = EFRepositoryCountries.Get();
            var DataCountry = new List<ViewCount>();
            foreach (var i in Data)
            {
                string CountryName = Country.First(k => k.CountryId == i.City.CountryId).Name;
                var DataType = DataCountry.FirstOrDefault(l => l.typeOfPort == i.TypePort && l.Name == CountryName);
                if (DataType != null)
                {
                    DataCountry.Remove(DataType);
                    DataType.Coun++;
                    DataCountry.Add(DataType);
                }
                else
                {
                    
                    DataType = new ViewCount()
                    {
                        Name = CountryName,
                        Coun = 1,
                        typeOfPort = i.TypePort,
                        CountId =Guid.NewGuid()
                    };
                    DataCountry.Add(DataType);
                }
            }

            return View(DataCountry);
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
