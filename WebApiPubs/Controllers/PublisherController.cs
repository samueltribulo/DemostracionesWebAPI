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
    public class PublisherController : ControllerBase
    {
        public readonly pubsContext context;
        public PublisherController(pubsContext context) { 
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Publisher>> Get() {

            return context.Publishers.ToList();

        }

        [HttpGet("{id}")]

        public ActionResult<Publisher> GetById(string id) {

            return context.Publishers.SingleOrDefault(p => p.PubId == id);
        }

        [HttpPost]
        public ActionResult<Publisher> Insert(Publisher publisher)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Publishers.Add(publisher);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Publisher> Update(string id, Publisher publisher) {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Entry(publisher).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {

            var publisher = context.Publishers.SingleOrDefault(p => p.PubId == id);

            if(publisher == null)
            {
                return NotFound();
            }

            context.Publishers.Remove(publisher);
            context.SaveChanges();

            return Ok();

        }

    }
}
