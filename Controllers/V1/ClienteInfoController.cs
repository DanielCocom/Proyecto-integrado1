using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Domain.Entities;
using MyProject.Services.Features.Cliente;

namespace MyProject.Controllers.V1
{
    [Route("[controller]")]
    public class ClienteInfoController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteInfoController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable <ClienteInfo>> Get()
        {
            var usuarios = _service.GetAll();
            return Ok(usuarios);

        }

        [HttpGet("{id}")]
        public ActionResult<ClienteInfo> Get(int id)
        {
            var usuario = _service.GetById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
    }
}
