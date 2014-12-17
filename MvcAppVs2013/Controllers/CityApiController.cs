using System.Collections.Generic;
using System.Web.Http;
using MvcAppVs2013.Models;

namespace MvcAppVs2013.Controllers
{
    public class CityApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<City> GetCities()
        {
            var cities = new List<City>
            {
                new City() {Id = 1, IsActive = true, Name = "Pune", Review = 9.9},
                new City() {Id = 2, IsActive = true, Name = "Delhi", Review = 5.9}
            };
            return cities;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}