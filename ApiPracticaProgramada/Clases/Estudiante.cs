using System.ComponentModel.DataAnnotations;

namespace ApiPracticaProgramada.Clases
{
    /// <summary>
    /// Representa un estudiante.
    /// </summary>
    public class Estudiante
    {
        /// <summary>
        /// Identificador único del estudiante.
        /// </summary>
        public int Id { get; set; }

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
        [Required(ErrorMessage = "Correo requerido")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string Correo { get; set; }

        // ✅ Constructor vacío (IMPORTANTE)
        public Estudiante() { }

        // ✅ Constructor completo
        public Estudiante(int id, string nombre, string apellido, int edad, string correo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Correo = correo;
        }
    }
}