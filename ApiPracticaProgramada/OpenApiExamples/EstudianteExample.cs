using Swashbuckle.AspNetCore.Filters;
using ApiPracticaProgramada.Clases;
namespace ApiPracticaProgramada.OpenApiExamples
{
    public class EstudianteExample : IExamplesProvider<Estudiante>
    {
        public Estudiante GetExamples()
        {
            return new Estudiante(1,"Juan", "Perez", 30, "juan@gmail.com");
        }
    }
}
