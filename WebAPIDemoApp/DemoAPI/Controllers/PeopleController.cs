using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class PeopleController : ApiController
    {
        private Person[] people = new Person[3];
        public PeopleController()
        {
            //stub out a database call
            people[0] = new Person { ID = 1, FirstName = "Joe", LastName = "Herro" };
            people[1] = new Person { ID = 2, FirstName = "Lynne", LastName = "Herro" };
            people[2] = new Person { ID = 3, FirstName = "Eva", LastName = "Herro" };
        }
        // GET: api/People
        public IEnumerable<Person> Get()
        {
            return people;
        }

        //[Route("api/People/GetFirstNames/{userId:int}/{age:int}")]
        [Route("api/People/GetFirstNames")]
        [HttpGet]
        public List<string> GetFirstNames()
        {
            List<string> output = new List<string>();

            foreach (Person p in people)
            {
                output.Add(p.FirstName);
            }

            return output;  
        }

        // GET: api/People/5
        [HttpGet]
        public Person Get(int id)
        {
            return people.Where<Person>(x => x.ID == id).FirstOrDefault();
        }

        // POST: api/People
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/People/5
        [HttpPost]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        [HttpPost]
        public void Delete(int id)
        {

        }
    }
}
