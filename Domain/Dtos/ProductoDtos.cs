namespace MyProject.Domain.Dtos{
    public class ProductoDto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public double Precio { get; set; }
    }
}