using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Entities;
using MyProject.Services.Features.Productos;
// using MyProject.Services.Features.Carrito;



namespace MyProject.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase
    {
        ///IMPLEMENTAR LOGICA PARA NUESTRO CARRITO DE COMPRAS
        ///
        private readonly Carrito? _carritoService;

        public CarritoController(Carrito carritoservice)
        {
            _carritoService = carritoservice;
        }

        // [HttpGet]

      

        //PENDIENTE 

    }
}