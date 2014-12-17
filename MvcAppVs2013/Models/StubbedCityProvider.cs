using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace MvcAppVs2013.Models
{
    public class StubbedCityProvider
    {
        public StubbedCityProvider()
        {
            if (InSessionCities.Count == 0)
            {
                InSessionCities.Add(new City() {Id = 1, IsActive = true, Name = "Pune", Review = 9.9});
                InSessionCities.Add(new City() {Id = 2, IsActive = true, Name = "Mumbai", Review = 5.9});
                InSessionCities.Add(new City() {Id = 3, IsActive = true, Name = "Bangalore", Review = 6.9});

            }
        }
        public List<City> InSessionCities
        {
            get
            {
                if (HttpContext.Current.Session["Cities"] == null)
                {
                    HttpContext.Current.Session["Cities"] = new List<City>();
                }
                return (List<City>) HttpContext.Current.Session["Cities"];
            }
            set
            {
                HttpContext.Current.Session["Cities"] = value;
            }
        }

        public void Add(City city)
        {
            if (city.Id == 0 && InSessionCities.Count == 0)
            {
                city.Id = 1;
            }
            else
            {
                city.Id = InSessionCities.Count + 1;
            }
            InSessionCities.Add(city);
        }

        public void Update(City city)
        {
            if (InSessionCities.Any(a => a.Id == city.Id))
            {

                InSessionCities.Remove(InSessionCities.First(a => a.Id == city.Id));
                Add(city);
            }
        }

    }
}