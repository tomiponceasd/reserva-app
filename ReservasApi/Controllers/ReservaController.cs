using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReservasApi.Controllers
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        private readonly ReservaDbContext _context;

        public ReservaController(IReservaService reservaService, ReservaDbContext context)
        {
            _reservaService = reservaService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservas()
        {
            var reservas = await _reservaService.ObtenerReservasAsync();

            if (reservas == null || !reservas.Any())
                return NotFound(new { message = "No hay reservas disponibles." });

            var servicios = await _context.Servicios.ToListAsync();

            var reservasConNombre = reservas.Select(r => new
            {
                r.Id,
                r.Cliente,
                r.FechaHora,
                r.ServicioId,
                ServicioNombre = servicios.FirstOrDefault(s => s.Id == r.ServicioId)?.Nombre ?? "Desconocido"
            });

            return Ok(reservasConNombre);
        }

        [HttpPost]
        public async Task<IActionResult> PostReserva([FromBody] Reserva reserva)
        {
            if (reserva == null)
                return BadRequest(new { message = "La reserva no puede ser nula." });

            if (string.IsNullOrWhiteSpace(reserva.Cliente) || reserva.ServicioId <= 0)
                return BadRequest(new { message = "Todos los campos son obligatorios y ServicioId debe ser válido." });

            var servicio = await _context.Servicios.FindAsync(reserva.ServicioId);
            if (servicio == null)
                return BadRequest(new { message = "El servicio seleccionado no existe." });

            try
            {
                bool resultado = await _reservaService.CrearReservaAsync(reserva);
                if (!resultado)
                    return BadRequest(new { message = "La reserva no se pudo realizar. Verifica los datos." });

                return Ok(new { message = "Reserva creada con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor.", error = ex.Message });
            }
        }
    }
}