using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WSAlumnos.Models;
using System.Linq;

namespace WSAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {

        private List<Alumno> Listado()
        {
            List<Alumno> alumnos = new List<Alumno>()
            {
                new Alumno() { Apellido = "Tribulo", Nombre = "Samuel", Id = 1},
                new Alumno() { Apellido = "Rodriguez", Nombre = "Eduardo", Id = 2},
                new Alumno() { Apellido = "Lopez", Nombre = "Ricrdo", Id = 3}

            };
            return alumnos;
        }

        //GET API/Alumno
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {

            return Listado();
        }

        [HttpGet("{id}")]
        public ActionResult<Alumno> GetById(int id)
        {
            var resultado = (from a in Listado()
                             where a.Id == id
                             select a
                             ).Single();
                 

            return resultado;
        }

    }
}
