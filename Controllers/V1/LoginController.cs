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
    public class LoginController : ControllerBase
    {
        private static readonly ClienteInfo[] usuariosRegistrados = new ClienteInfo[]
        
        {//
            new ClienteInfo { Identificador = 1, Nombres = "Julian Emmanuel", Apellido = "Uitz", Email = "usuario@example.com", password = "contraseña123" }

        };

        [HttpPost]
        [Route("IniciarSesion")]
        public IActionResult IniciarSesion([FromBody] ClienteInfo cliente)
        {
            try
            {
                // Buscar al usuario en la base de datos (simulada)
                //Aqui lo que hce FirstOrDefault es buscar el primer elemento que cumpla con la condicion
                var usuario = usuariosRegistrados.FirstOrDefault(u => u.Email == cliente.Email && u.password == cliente.password);
                //var es una tipo de variable por inferencia es decir que el compilador determina el tipo de variable
                //le asignamos como usuario a la busqueda de la lista de usuarios registrados

                if (usuario == null)
                {
                    return Unauthorized("Credenciales inválidas");
                }

                
                // Por simplicidad, aquí solo devolvemos un mensaje de éxito
                return Ok("Inicio de sesión exitoso");
            }
            catch (Exception ex)
            {
                //en el caso que yengamos algun error en el servidor
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}