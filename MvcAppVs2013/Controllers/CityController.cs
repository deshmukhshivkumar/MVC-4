using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcAppVs2013.Filters;
using MvcAppVs2013.Models;

namespace MvcAppVs2013.Controllers
{
    [Log]
    public class CityController : Controller
    {
        public StubbedCityProvider cityStub
        {
            get { return new StubbedCityProvider(); }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(cityStub.InSessionCities);
        }

        [HttpGet]
        public IEnumerable<City> GetCities()
        {
            var cities = new List<City>
            {
                new City() {Id = 1, IsActive = true, Name = "Pune", Review = 9.9},
                new City() {Id = 2, IsActive = true, Name = "Delhi", Review = 5.9}
            };
            return cities;
        }

        [HttpGet]
        public JsonResult GetCitiesJson()
        {
            var cities = new List<City>
            {
                new City() {Id = 1, IsActive = true, Name = "Pune", Review = 9.9},
                new City() {Id = 2, IsActive = true, Name = "Delhi", Review = 5.9}
            };
            return Json(new
            {
                city = cities
            },JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new City(){ });
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(City city)
        {
            if (ModelState.IsValid)
            {
                cityStub.Add(city);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Create(City city)
        {
            if(ModelState.IsValid)
            {
                cityStub.Add(city);
                return RedirectToAction("Index");                  
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var city = cityStub.InSessionCities.First(a => a.Id == id);
            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                cityStub.Update(city);
                return RedirectToAction("Index");
            }
            return View();
        }
    }


     
  
}