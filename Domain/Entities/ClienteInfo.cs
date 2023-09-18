using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class ClienteInfo
    {
        public int Identificador { get; set; }
        public string? Nombres { get; set; }
        [Required]
        public string? Apellido { get; set; }
        [Required] // C // Corregir aquí
        public string? Email { get; set; }
        [Required] // Corregir aquí
        public string? password { get; set; }

    }
}