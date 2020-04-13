using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.GenericRepozitory;
using Data.Models;
using Kurs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    public class PortController : Controller
    {

        public IEFRepository<Ship> EFRepositoryShip;
        public IEFRepository<City> EFRepositoryCity;
        public IEFRepository<Country> EFRepositoryCountries;
        public IEFRepository<Port> EFRepositoryPort;
        public IEFRepository<Weather> EFRepositoryWeather;
        public PortController( IEFRepository<Ship> eFRepositoryShip, IEFRepository<City> eFRepositoryCity, IEFRepository<Country> eFRepositoryCountries, IEFRepository<Port> eFRepositoryPort, IEFRepository<Weather> eFRepositoryWeather)
        {    
            EFRepositoryShip = eFRepositoryShip;
            EFRepositoryCity = eFRepositoryCity;
            EFRepositoryCountries = eFRepositoryCountries;
            EFRepositoryPort = eFRepositoryPort;
            EFRepositoryWeather = eFRepositoryWeather;
        }
        [HttpGet]
        [HttpPost]
        public IActionResult AllPort( SortPort sortPort )
        {
            if (sortPort.Depth == 0 && sortPort .CountPrichal == 0)
            {
                ViewBag.AllPort = EFRepositoryPort.IncludeGet(i => i.Weathers);
            }
            else
            {
                ViewBag.AllPort = EFRepositoryPort.Get(i => i.CountPrichal >= sortPort.CountPrichal && i.Depth >= sortPort.Depth)
                    .ToList();
            }
            return View();
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Weather(SortWeather sortWeather)
        {
            ViewBag.Port = EFRepositoryPort.Get();
            if (sortWeather.PortId != Guid.Empty)
            {
                if (sortWeather.Date != default(DateTime))
                {
                    ViewBag.Weather = EFRepositoryWeather.IncludeGet(i => i.Port).Where(i => i.Port.PortId == sortWeather.PortId && i.Date == sortWeather.Date);
                    return View();
                }
                ViewBag.Weather = EFRepositoryWeather.IncludeGet(i => i.Port).Where(i =>i.Port.PortId == sortWeather.PortId);
                return View();

            }
            else 
            {
                if (sortWeather.Date != default(DateTime))
                {
                    ViewBag.Weather = EFRepositoryWeather.IncludeGet(i => i.Port).Where(i => i.Date == sortWeather.Date);
                    return View();
                }
                
                ViewBag.Weather = EFRepositoryWeather.IncludeGet(i=>i.Port);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddWeather()
        {
            ViewBag.Port = EFRepositoryPort.Get();
            return View();
        }
       
        [HttpPost]
        public IActionResult AddWeather(Weather weather)
        {
            weather.WeatherId = Guid.NewGuid();
            EFRepositoryWeather.Create(weather);
            return Redirect("/Port/Weather");
        }

        [HttpGet]
        public IActionResult AddPort()
        {
            ViewBag.Cities = EFRepositoryCity.Get();
            return View();
        }
        [HttpPost]

        public IActionResult AddPort(Port port)
        {
            port.PortId = Guid.NewGuid();
            EFRepositoryPort.Create(port);
            return Redirect("/Port/AllPort");
        }
    }
}