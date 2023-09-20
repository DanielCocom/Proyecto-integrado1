using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Entities;

namespace MyProject.Controllers.V1;
[ApiController]
[Route("api/[controller]")]
public class PagoController : ControllerBase
{
    private readonly PagosService _pagoService;

    public PagoController(PagosService pagoService)
    {
        this._pagoService = pagoService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_pagoService.GetAll());
    }


}