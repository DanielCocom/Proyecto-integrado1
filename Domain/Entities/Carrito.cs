using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Entities
{
    public class Carrito
    {
        public int id {get; set;}
        public Producto? producto {get; set;}

        // public Cliente cliente  pobriamos agregar un cliente
    }
}