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
            ViewBag.Ports = EFRepositoryPort.Get();
            var ListData = EFRepositoryShip.IncludeGet(i => i.Port).ToList();

            if ( shipSort.Lenght != 0)
            {



                ListData = ListData.Where(i=>i.Lenght<shipSort.Lenght ).ToList();
                
            }
            if (shipSort.Witch != 0)
            {
                ListData = ListData.Where(i => i.Witch < shipSort.Witch).ToList();
                
            }
            if (shipSort.CountStaff != 0)
            {
                ListData = ListData.Where(i => i.CountStaff == shipSort.CountStaff).ToList();
            }

            ViewBag.Ships =ListData;
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Prichal( SortPrichal sortPrichal)
        {
            var visits = EFRepositoryVisits.IncludeGet(i => i.Port).ToList();
            var Visits = EFRepositoryVisits.IncludeGet(i => i.Ship).ToList();
            ViewBag.Visits = Visits;
            ViewBag.Port = EFRepositoryPort.Get().ToList();
            ViewBag.Ship = EFRepositoryShip.Get().ToList();
            var Data = new List<Prichal>();
            foreach(var i in Visits)
            {
                Data.Add(new Models.Prichal
                {
                    NamePort = i.Port.Name,
                    NameShip = i.Ship.Name,
                    NumberPrich = i.NumberPrich,
                    Date = i.DateArrival,
                    WaterTon = i.Ship.CountWater,
                    DateOf = i.DateDeparture
                });
            }
            if(sortPrichal.Data != default(DateTime))
            {

                Data = Data.Where(i => i.Date <= sortPrichal.Data && i.DateOf >= sortPrichal.Data).ToList();
                foreach (var i in Data)
                {
                    i.Date = sortPrichal.Data;
                }

            }

            if (sortPrichal.ShipWater != 0)
            {

               Data = Data.Where(i => i.WaterTon == sortPrichal.ShipWater).ToList();
            }
            ViewBag.Data = Data;
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Visits()

        {
            var visits = EFRepositoryVisits.IncludeGet(i => i.Port).ToList();

            var Visits = EFRepositoryVisits.IncludeGet(i => i.Ship ).ToList();
            ViewBag.Visits = Visits;
            ViewBag.Port = EFRepositoryPort.Get().ToList();
            ViewBag.Ship = EFRepositoryShip.Get().ToList();
            return View();
        }
        [HttpGet]
        public IActionResult AddVisit()
        {
            ViewBag.Ship = EFRepositoryShip.Get().ToList();
            ViewBag.Port = EFRepositoryPort.Get().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddVisit(Visits visits)
        {           
            ViewBag.Ship = EFRepositoryShip.Get().ToList();

            var UpDatVis = EFRepositoryVisits.FindById(visits.VisitsId);
            if (UpDatVis != null)
            {
                UpDatVis.DateArrival = visits.DateArrival;
                UpDatVis.DateDeparture = visits.DateDeparture;
                UpDatVis.NumberPrich = visits.NumberPrich;
                UpDatVis.PortId = visits.PortId;
                UpDatVis.ShipId = visits.ShipId;
                EFRepositoryVisits.Update(UpDatVis);
            }
            else 
            {
                EFRepositoryVisits.Create(visits);
            }
           
            return Redirect("/Ship/Visits");
        }

        [HttpGet]
        public IActionResult AddShip()
        {
            ViewBag.Ports = EFRepositoryPort.IncludeGet( i => i.City);
            return View();
        }

        [HttpPost]
        public IActionResult AddShip(Ship ship)
        {

            var newShip = EFRepositoryShip.FindById(ship.ShipId);
            if (newShip != null)
            { 
                newShip.Name = ship.Name;
                newShip.Lenght = ship.Lenght;
                newShip.color = ship.color;
                newShip.PortId =ship.PortId;
                
                newShip.Witch = ship.Witch;
                newShip.TypeShip = ship.TypeShip;
                newShip.CountStaff = ship.CountStaff;
                newShip.CountWater = ship.CountWater;
                EFRepositoryShip.Update(newShip);
            }
            else
            {
                EFRepositoryShip.Create(ship);
            }
            
            
            return Redirect("/Ship/Ships");
        }
        
    }
}