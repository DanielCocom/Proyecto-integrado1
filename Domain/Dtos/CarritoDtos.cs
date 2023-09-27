namespace MyProject.Domain.Dtos
{
    public class CarritoDto
    {
        public int Codigo { get; set; }
        public double Subtotal { get; set; }
        public int CantidaProductos {get; set;}
        public List<ProductoDto> Productos { get; set; } = new List<ProductoDto>();
    }
}
