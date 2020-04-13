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
    public class ShipController : Controller
    {
        public IEFRepository<Ship> EFRepositoryShip;
        public IEFRepository<City> EFRepositoryCity;
        public IEFRepository<Country> EFRepositoryCountries;
        public IEFRepository<Port> EFRepositoryPort;
        public IEFRepository<Weather> EFRepositoryWeather;
        public ShipController(IEFRepository<Ship> eFRepositoryShip, IEFRepository<City> eFRepositoryCity, IEFRepository<Country> eFRepositoryCountries, IEFRepository<Port> eFRepositoryPort, IEFRepository<Weather> eFRepositoryWeather)
        {
            EFRepositoryShip = eFRepositoryShip;
            EFRepositoryCity = eFRepositoryCity;
            EFRepositoryCountries = eFRepositoryCountries;
            EFRepositoryPort = eFRepositoryPort;
            EFRepositoryWeather = eFRepositoryWeather;
          
        }
        
        [HttpGet]
        public IActionResult Ships()
        {
            ViewBag.Ships = EFRepositoryShip.IncludeGet(i => i.Port).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult AddShip()
        {
            ViewBag.Ports = EFRepositoryPort.IncludeGet( i => i.City);
            return View();
        }

        [HttpPost]
        public IActionResult AddShip(ShipView ship)
        {

            Ship newShip = new Ship();
            newShip.Name = ship.Name;
            newShip.Lenght = ship.Lenght;
            newShip.color = ship.color;
            newShip.PortId =Guid.Parse(ship.portPrip);
            newShip.ShipId = Guid.NewGuid();
            newShip.Witch = ship.Witch;
            newShip.TypeShip = ship.TypeShip;
            EFRepositoryShip.Create(newShip);
            return Redirect("Ship/Ships");
        }
        
    }
}