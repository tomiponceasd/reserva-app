using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReservasApi.Controllers;

[ApiController]
[Route("api/servicios")]
public class ServicioController : ControllerBase
{
    private readonly ReservaDbContext _context;

    public ServicioController(ReservaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetServicios()
    {
        var servicios = await _context.Servicios.ToListAsync();
        return Ok(servicios);
    }
}