using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Entities
{
    public class Carrito
    {
        public int Codigo { get; set; }
        public int CantidaProductos{
            get{
                int cantidad = Productos.Count();
                return cantidad;
            }
        }
        public double subtotal
        {
            get
            {
                double total = Productos.Sum(Producto => Producto.Precio);
                return Math.Round(total, 2);
           }
        }
        public List<Producto> Productos { get; set; } = new List<Producto>();


        // public Cliente cliente  pobriamos agregar un cliente

        // Con el siguiente metodo lo que hacemos es agregar un prodcuto a el carrito
    }
}