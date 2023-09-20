using System.ComponentModel.DataAnnotations;

namespace MyProject.Domain.Entities
{
    public class Producto
    {
       public int Codigo { get; set; }
        [Required] // Corregir aquí
        public string? Nombre { get; set; }
        [Required] // Corregir aquí
        public double Precio { get; set; }
        
    }
}
