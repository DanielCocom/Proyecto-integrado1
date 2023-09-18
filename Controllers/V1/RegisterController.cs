using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Entities;

namespace MyProject.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        // Esta lista lo que va a hacer por ahora es simular una base de datos por ahora

        private static readonly List<ClienteInfo> usuariosRegistrados = new List<ClienteInfo>();

        [HttpPost]
        [Route("RegistrarUsuario")]
        public IActionResult RegistrarUsuario([FromBody] ClienteInfo nuevoUsuario)
        {
            try
            {
                // Validar si el usuario ya existe en la base de datos (simulada) por su dirección de correo electrónico 
                //Esto se puede sustiruir talvez con un token o un id espeficico de cada usuario
                // puede ser el id unico del carrito de compras
                if (usuariosRegistrados.Any(u => u.Email == nuevoUsuario.Email))
                {
                    return Conflict("El usuario ya existe.");
                }

                // Asignar un identificador único al nuevo usuario (simulación)
                //asiganmos el identificador al nuevo usuario de forma automatica , el identificador es el numero de usuarios registrados + 1
                nuevoUsuario.Identificador = usuariosRegistrados.Count + 1;

                // Agregar el nuevo usuario a la base de datos (lista)
                usuariosRegistrados.Add(nuevoUsuario);

                return Ok("Registro exitoso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}