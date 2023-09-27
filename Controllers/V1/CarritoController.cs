using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Entities;
using MyProject.Services.Features.Productos;
using MyProject.Services.Features.CaSer;

using MyProject.Infrastructure.Repositories.c;
using AutoMapper;
using MyProject.Domain.Dtos;

namespace Proyecto_webApi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase
    {

        private readonly CarritoServices _carritoServices;
        private readonly ProductoServices _productoServices;
        private readonly IMapper _mapper;

        public CarritoController(CarritoServices carritoServices, ProductoServices productoServices, IMapper mapper )
        {
            _carritoServices = carritoServices;
            _productoServices = productoServices;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var carrito = _carritoServices.GetCarritoById(id);
            if (carrito == null)
            {
                return NotFound();
            }
            var CarritoDto = _mapper.Map<CarritoDto>(carrito);
            return Ok(CarritoDto);
        }

        [HttpPost]
        public IActionResult Post(Carrito carrito)
        {
            _carritoServices.AddCarrito(carrito);
            return CreatedAtAction(nameof(Get), new { id = carrito.Codigo }, carrito);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var carrito = _carritoServices.GetCarritoById(id);
            if (carrito == null)
            {
                return NotFound();
            }
            _carritoServices.DeleteCarrito(id);
            return NoContent();
        }
        [HttpPost("{carritoId}/agregarproducto/{productoId}")]
        public IActionResult AgregarProducto(int carritoId, int productoId)
        {
            var carrito = _carritoServices.GetCarritoById(carritoId);
            var producto = _productoServices.GetById(productoId);

            if (carrito == null || producto == null)
            {
                return NotFound();
            }

            _carritoServices.AgregarProductoACarrito(carritoId, producto);

            // Mapea la entidad Carrito a su DTO correspondiente
            var carritoDto = _mapper.Map<CarritoDto>(carrito);

            return Ok(carritoDto);
        }

        [HttpDelete("{carritoId}/borrarProducto/{productoId}")]
        public IActionResult BorrarProductoCarrito(int carritoId, int productoId)
        {
            var carrito = _carritoServices.GetCarritoById(carritoId);
            var producto = _productoServices.GetById(productoId);
            if (carrito == null || producto == null)
            {
                return NotFound();
            }
            _carritoServices.EliminarProductoDeCarrito(carritoId, productoId);
            var carritoDto = _mapper.Map<CarritoDto>(carrito);
            return Ok(carritoDto);
        }
    }
}

