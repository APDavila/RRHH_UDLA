namespace RecursosHumanos.API.Models
{
    public class Person
    {
        public int Id { get; set; } // Clave primaria
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        // Códigos de Gender y Status
        public string GenderCode { get; set; }
        public string StatusCode { get; set; }

        // Propiedades de navegación (opcional, para acceder a los objetos completos)
        public Gender? Gender { get; set; }
        public Status? Status { get; set; }
    }
}
