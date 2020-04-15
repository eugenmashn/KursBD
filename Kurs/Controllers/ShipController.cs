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
        public IEFRepository<Visits> EFRepositoryVisits;
        public ShipController(IEFRepository<Ship> eFRepositoryShip, IEFRepository<City> eFRepositoryCity, IEFRepository<Country> eFRepositoryCountries, IEFRepository<Port> eFRepositoryPort, IEFRepository<Weather> eFRepositoryWeather, IEFRepository<Visits> eFRepositoryVisits)
        {
            EFRepositoryShip = eFRepositoryShip;
            EFRepositoryCity = eFRepositoryCity;
            EFRepositoryCountries = eFRepositoryCountries;
            EFRepositoryPort = eFRepositoryPort;
            EFRepositoryWeather = eFRepositoryWeather;
            EFRepositoryVisits = eFRepositoryVisits;


        }
        
        [HttpGet]
        [HttpPost]
        public IActionResult Ships(ShipSort shipSort)
        {
            if( shipSort.Lenght != 0)
            {
                if(shipSort.Witch != 0) 
                {
                    ViewBag.Ships = EFRepositoryShip.IncludeGet(i => i.Port).Where(i => i.Lenght < shipSort.Lenght).ToList();
                    return View();
                }
            
                ViewBag.Ships = EFRepositoryShip.IncludeGet(i => i.Port).Where(i=>i.Lenght<shipSort.Lenght && i.Witch <shipSort.Witch).ToList();
                return View();
            }
            if (shipSort.Witch != 0)
            {
                ViewBag.Ships = EFRepositoryShip.IncludeGet(i => i.Port).Where(i => i.Lenght < shipSort.Witch).ToList();
                return View();
            }
            ViewBag.Ships = EFRepositoryShip.IncludeGet(i => i.Port).ToList();
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Visits()
        {

            ViewBag.Visits = EFRepositoryVisits.IncludeGet(i => i.Ship).ToList();
            ViewBag.Ship = EFRepositoryShip.Get().ToList();
            return View();
        }
        [HttpGet]
        public IActionResult AddVisit()
        {
            ViewBag.Ship = EFRepositoryShip.Get().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddVisit(Visits visits)
        {
            ViewBag.Ship = EFRepositoryShip.Get().ToList();
            EFRepositoryVisits.Create(visits);
            return Redirect("/Ship/Visits");
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
            return Redirect("/Ship/Ships");
        }
        
    }
}