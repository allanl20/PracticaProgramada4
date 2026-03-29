using System.ComponentModel.DataAnnotations;

namespace ApiPracticaProgramada.Clases
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Representa un estudiante.
    /// </summary>
    public class Estudiante
    {
        

        /// <summary>
        /// Nombre del estudiante.
        /// </summary>
        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del estudiante.
        /// </summary>
        [Required(ErrorMessage = "Apellido requerido")]
        public string Apellido { get; set; }

        /// <summary>
        /// Edad del estudiante (mayor que 0).
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Edad debe ser mayor que 0")]
        public int Edad { get; set; }

        /// <summary>
        /// Correo electrónico del estudiante.
        /// </summary>
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string Correo { get; set; }

        public Estudiante(string nombre, string apellido, int edad, string correo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Correo = correo;
        }
    }
}
