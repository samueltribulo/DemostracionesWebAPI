using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly DBLibrosContext context;

        public LibroController(DBLibrosContext context)
        {

            this.context = context;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }


        [HttpGet("{id}")]

        public ActionResult<Libro> Get(int id)
        {
            var libro = context.Libros.Include(l => l.Autor).SingleOrDefault(l => l.LibroId == id);

            return libro;
        }

        [HttpGet("autor/{AutorId}")]
        public ActionResult<List<Libro>> GetByAutorId(int AutorId) {

            var libros = (from l in context.Libros
                          where l.Autor_Id == AutorId
                          select l
               ).ToList();

            return libros;
        }

        [HttpPost]

        public ActionResult<Libro> Post(Libro libro) {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            context.Libros.Add(libro);
            context.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro)
        {

            if (id != libro.LibroId)
            {

                return BadRequest();

            }

            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {

            var libro = (from l in context.Libros
                         where l.LibroId == id
                         select l
                ).SingleOrDefault();

            if (libro == null)
            {

                return NotFound();
            }

            context.Libros.Remove(libro);
            context.SaveChanges();

            return Ok();
        }



    }
}
