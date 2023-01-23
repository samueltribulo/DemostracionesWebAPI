using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //Inyección de dependecia --------- inicia

        //Propiedad
        private readonly DBLibrosContext context;

        //Constructor
        public AutorController(DBLibrosContext context)
        {
            this.context = context;
        }

        //Inyeccion de dependencias---------- fin
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)
        {

            Autor autor = (from a in context.Autores
                           where a.AutorId == id
                           select a
                           ).SingleOrDefault();

            return autor;

        }

        [HttpGet("filtro/{edad}")]
        public ActionResult<IEnumerable<Autor>> GetByEdad(int edad)
        {

            List<Autor> autorList = (
                from a in context.Autores
                where a.Edad == edad
                select a
                ).ToList();

            return autorList;

        }

        [HttpPost]
        public ActionResult Post(Autor autor)
        {
            if(!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            context.Autores.Add(autor);
            context.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] Autor autor)
        {

            if (id != autor.AutorId)
            { 

                return BadRequest();

            }

            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {

            var autor = (from a in context.Autores
                         where a.AutorId == id
                         select a
                ).SingleOrDefault();

            if(autor == null)
            {

                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();

            return Ok();
        }
    }
}
