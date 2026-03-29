using ApiPracticaProgramada.Clases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.Linq;

namespace ApiPracticaProgramada.Controllers
{
    [ApiController]
    [Route("api/estudiantes")]
    public class EstudianteController : ControllerBase
    {
        private static List<Estudiante> estudiantes = new List<Estudiante>()
        {
            new Estudiante(1, "Juan", "Perez", 30, "juan@gmail.com"),
            new Estudiante(2, "Maria", "Gomez", 25, "maria@gmail.com"),
            new Estudiante(3, "Carlos", "Lopez", 40, "carlos@gmail.com")
        };

        // GET: api/estudiantes
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Estudiante>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiantes()
        {
            return Ok(estudiantes);
        }

        // GET: api/estudiantes/1
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Estudiante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetEstudiante(int id)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);

            if (estudiante == null)
                return NotFound();

            return Ok(estudiante);
        }

        // POST: api/estudiantes
        [HttpPost]
        [SwaggerRequestExample(typeof(Estudiante), typeof(ApiPracticaProgramada.OpenApiExamples.EstudianteExample))]
        [ProducesResponseType(typeof(Estudiante), StatusCodes.Status201Created)]
        public ActionResult PostEstudiante([FromBody] Estudiante estudiante)
        {
            if (estudiante == null)
                return BadRequest();

            estudiante.Id = estudiantes.Any() ? estudiantes.Max(e => e.Id) + 1 : 1;

            estudiantes.Add(estudiante);

            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.Id }, estudiante);
        }

        // PUT: api/estudiantes/1
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Estudiante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PutEstudiante(int id, [FromBody] Estudiante estudianteActualizado)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);

            if (estudiante == null)
                return NotFound();

            estudiante.Nombre = estudianteActualizado.Nombre;
            estudiante.Apellido = estudianteActualizado.Apellido;
            estudiante.Edad = estudianteActualizado.Edad;
            estudiante.Correo = estudianteActualizado.Correo;

            return Ok(estudiante);
        }

        // DELETE: api/estudiantes/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteEstudiante(int id)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);

            if (estudiante == null)
                return NotFound();

            estudiantes.Remove(estudiante);

            return Ok();
        }
    }
}