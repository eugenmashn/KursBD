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
        [HttpGet]
        [HttpPost]
        public IActionResult Kupt( SortCapitan sortCapitan)
        {
            var ListDataCap = EFRepositoryStaff.Get(i => i.Position == "Капітан").ToList();
            if (sortCapitan.Expirions != 0) 
            {
                ListDataCap = EFRepositoryStaff.Get(i => i.Position == "Капітан" && i.Experience == sortCapitan.Expirions).ToList();
                if (sortCapitan.ArravedDate != default(DateTime))
                {
                    ListDataCap = EFRepositoryStaff.Get(i => i.Position == "Капітан" && i.Experience == sortCapitan.Expirions && i.Arrived == sortCapitan.ArravedDate ).ToList();

                }
            }
            if (sortCapitan.ArravedDate != default(DateTime))
            {
                ListDataCap = EFRepositoryStaff.Get(i => i.Position == "Капітан" &&  i.Arrived == sortCapitan.ArravedDate).ToList();

            }
            var ListData = new List<Capitan>();
           
            foreach (var i in ListDataCap)
            {
                ListData.Add(
                        new Capitan
                        {
                            Name = i.FirstName,
                            LastName = i.LastName,
                            Experitions = i.Experience,
                            Arraved = i.Arrived
                        });
            } 
            ViewBag.ListCupt = ListData;
            return View();
        }
        public IActionResult Staff()
        {
            ViewBag.Ship = EFRepositoryShip.Get();
            ViewBag.City = EFRepositoryCity.Get();
            ViewBag.Staff = EFRepositoryStaff.IncludeGet(i => i.City).ToList();

            ViewBag.Staff = EFRepositoryStaff.IncludeGet( i => i.Ship).ToList();
            return View();
        }
        public IActionResult AddStaff()
        {
            ViewBag.Ship = EFRepositoryShip.Get().ToList();
          ;
            return View();
        }

        [HttpPost]
        public IActionResult AddStaff( StaffPerson staff )
        {
            
                var UpStaff = EFRepositoryStaff.FindById(staff.PersonId);
                if (UpStaff != null)
                {
                    UpStaff.Phone = staff.Phone;
                    UpStaff.Position = staff.Position;
                    UpStaff.Salary = staff.Salary;
                    UpStaff.ShipId = staff.ShipId;
                    UpStaff.Experience = staff.Experience;
                    UpStaff.CityId = staff.CityId;
                    UpStaff.BirstDay = staff.BirstDay;
                    UpStaff.stat = staff.stat;
                    UpStaff.Arrived = staff.Arrived;
                   
                    EFRepositoryStaff.Update(UpStaff);
                }
                else
                {
                    EFRepositoryStaff.Create(staff);
                }
           
            return Redirect("/Staff/Staff");
        }


    }
}