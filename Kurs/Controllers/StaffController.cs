using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.GenericRepozitory;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    public class StaffController : Controller
    {
        public IEFRepository<Ship> EFRepositoryShip;
        public IEFRepository<City> EFRepositoryCity;
        public IEFRepository<Country> EFRepositoryCountries;
        public IEFRepository<Port> EFRepositoryPort;
        public IEFRepository<Weather> EFRepositoryWeather;
        public IEFRepository<Visits> EFRepositoryVisits;
        public IEFRepository<StaffPerson> EFRepositoryStaff;
        public StaffController(IEFRepository<Ship> eFRepositoryShip, IEFRepository<City> eFRepositoryCity, IEFRepository<Country> eFRepositoryCountries, IEFRepository<Port> eFRepositoryPort, IEFRepository<Weather> eFRepositoryWeather, IEFRepository<Visits> eFRepositoryVisits, IEFRepository<StaffPerson> eFRepositoryStaff)
        {
            EFRepositoryShip = eFRepositoryShip;
            EFRepositoryCity = eFRepositoryCity;
            EFRepositoryCountries = eFRepositoryCountries;
            EFRepositoryPort = eFRepositoryPort;
            EFRepositoryWeather = eFRepositoryWeather;
            EFRepositoryVisits = eFRepositoryVisits;
            EFRepositoryStaff = eFRepositoryStaff;

        }

        public IActionResult Staff()
        {
            ViewBag.Staff = EFRepositoryStaff.IncludeGet(i => i.City).ToList();

            ViewBag.Staff = EFRepositoryStaff.IncludeGet( i => i.Ship).ToList();
            return View();
        }
        public IActionResult AddStaff()
        {
            ViewBag.Ship = EFRepositoryShip.Get().ToList();
            ViewBag.City = EFRepositoryCity.Get();
            return View();
        }

        [HttpPost]
        public IActionResult AddStaff( StaffPerson staff )
        {
            EFRepositoryStaff.Create(staff);
            return Redirect("/Staff/Staff");
        }


    }
}