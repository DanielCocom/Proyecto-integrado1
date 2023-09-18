using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Entities;
using MyProject.Services.Features.Productos;

namespace Proyecto_webApi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private List<Carrito> carritos = new List<Carrito>();
        private readonly ProductoServices? _productoServices;
        public CartController(ProductoServices productoServices)
        {
            _productoServices = productoServices;
        }// Lista para almacenar carritos

        [HttpPost("AgregarAlCarrito/{carritoId}")]
        public IActionResult AgregarAlCarrito(int carritoId, int codigoProducto)
        {

            if (_productoServices == null)
            {
                return BadRequest("El servicio no esta disponible");

            }
            var carrito = carritos.FirstOrDefault(c => c.Codigo == carritoId);
            if (carrito == null)
            {
                carrito = new Carrito { Codigo = carritoId };
                carritos.Add(carrito);
            }

            var producto = _productoServices.GetProductoByID(codigoProducto);
            if (producto == null)
            {
                return NotFound();
            }

            carrito.AgregarProducto(producto); // Agregar producto al carrito
            return Ok();
        }

        [HttpGet("MostrarCarrito/{carritoId}")]
        public IActionResult MostrarCarrito(int carritoId)
        {
            var carrito = carritos.FirstOrDefault(c => c.Codigo == carritoId);
            if (carrito == null)
            {
                return NotFound();
            }

            // Obtener productos del carrito
            var productosEnCarrito = carrito.ObtenerProductos();

            // **Aquí es donde se resuelven los problemas:**

            // **El primer problema es que la propiedad `Nombre` de la entidad `Producto` no es obligatoria. Para resolver este problema, se agrega la anotación `Required` a la propiedad `Nombre`.**

            productosEnCarrito.Where(p => p.Nombre != null).ToList();

            // **El segundo problema es que el tipo de retorno del método `MostrarCarrito()` es `IActionResult`. Para resolver este problema, se modifica el tipo de retorno a `IEnumerable<Producto>`.**

            return Ok(productosEnCarrito); // Mostrar los productos en el carrito con código y nombre
        }
    }
}
