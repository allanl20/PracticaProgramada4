using ApiPracticaProgramada.Clases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace ApiPracticaProgramada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private static List<Estudiante> estudiantes = new List<Estudiante>()
        {
            new Estudiante("Juan", "Perez", 30, "juan@gmail.com"),
            new Estudiante("Maria", "Gomez", 25, "maria@gmail.com"),
            new Estudiante("Carlos", "Lopez", 40, "carlos@gmail.com")
        };

        /// <summary>
        /// Get all personas.
        /// </summary>
        [HttpGet(Name = "GetEstudiantes")] //El name no es diferenciador
        [ProducesResponseType(typeof(IEnumerable<Estudiante>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiante() //Herencia
        {
            return Ok(estudiantes);

        }

        [HttpGet("{posicion}", Name = "GetEstudiante")] //El name no es diferenciador
        public ActionResult GetEstudiante(int posicion)
        {
            return Ok(estudiantes[posicion]);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(Estudiante), typeof(ApiPracticaProgramada.OpenApiExamples.EstudianteExample))]
        [ProducesResponseType(typeof(Estudiante), StatusCodes.Status201Created)]
        public ActionResult PostEstudiante(Estudiante estudiante) //la entidad viaje en el body de la peticion
        {
            estudiantes.Add(estudiante);
            return Ok(estudiante);
        }


        [HttpPut("{posicion}")] //Parametro obligatorio 
        public ActionResult PutEstudiante(int posicion, Estudiante estudiante)
        {
            estudiantes[posicion] = estudiante;
            return Ok(estudiante);
        }

        [HttpDelete("{posicion}")]
        public ActionResult DeleteEstudiante(int posicion) //usar parametro obligatiorio para eliminar un registro, no es recomendable eliminar por nombre o apellido porque puede haber repetidos
        {
            estudiantes.RemoveAt(posicion);
            return Ok();
        }

    }
}
