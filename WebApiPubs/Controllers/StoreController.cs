using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApiPubs.Models;

namespace WebApiPubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly pubsContext context;

        public StoreController(pubsContext context)
        {
            this.context = context;
        }


        [HttpGet]

        public ActionResult<IEnumerable<Stores>> Get()
        {

            return context.Stores.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Stores> Get(string id)
        {

            return context.Stores.SingleOrDefault(s => s.StorId == id);

        }

        [HttpPost]

        public ActionResult<Stores> Post(Stores store)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Stores.Add(store);
            context.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]

        public ActionResult<Stores> Put(string id,[FromBody] Stores store)
        {

            if (!ModelState.IsValid || id != store.StorId)
            {
                return BadRequest();
            }

            context.Entry(store).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Stores> Delete(string id)
        {

            var store = context.Stores.FirstOrDefault(s => s.StorId == id);

            if (store == null)
            {
                return NotFound();
            }

            context.Stores.Remove(store);
            context.SaveChanges();

            return NoContent();
        }

        [HttpGet("name/{name}")]
        public ActionResult<Stores> GetByName(string name)
        {

            var store = context.Stores.FirstOrDefault(s => s.StorName == name);

            if (store == null) return NotFound();

            return store;
        }

        [HttpGet("zip/{zip}")]
        public ActionResult<IEnumerable<Stores>> GetByZip(string zip)
        {

            var store = context.Stores.Where(s => s.Zip == zip).ToList();

            if (store == null) return NotFound();

            return store;
        }

        [HttpGet("listado/{city}/{state}")]
        public ActionResult<IEnumerable<Stores>> GetByZip(string city, string state)
        {

            var stores = (
                    from a in context.Stores
                    where a.City == city && a.State == state
                    select a
                ).ToList();

            if (stores[0] == null) return NotFound();

            return stores;
        }

    }
}
