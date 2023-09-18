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
    public class ProductController : ControllerBase
    {
        private readonly ProductoServices _productoServices;

        public ProductController(ProductoServices productoServices)
        {
            _productoServices = productoServices;
        }
        

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productoServices.GetAll());
        }

        [HttpGet("{Codigo}")]
        public IActionResult GetProductoByID(int Codigo)
        {
            var producto = _productoServices.GetProductoByID(Codigo);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Add(Producto producto)
        {
            _productoServices.Add(producto);
            return CreatedAtAction(nameof(GetProductoByID), new { Codigo = producto.Codigo }, producto);
        }

        [HttpPut("{Codigo}")]
        public IActionResult Update(int Codigo, Producto producto)
        {
            if (Codigo != producto.Codigo)
            {
                return BadRequest();
            }
            var productoExiste = _productoServices.GetProductoByID(Codigo);
            if (productoExiste == null)
            {
                return NotFound();
            }
            _productoServices.Update(producto);
            return NoContent();
        }

        [HttpDelete("{Codigo}")]
        public IActionResult Delete(int Codigo)
        {
            var producto = _productoServices.GetProductoByID(Codigo);
            if (producto == null)
            {
                return NotFound();
            }
            _productoServices.Delete(Codigo);
            return NoContent();
        }
    }
}
