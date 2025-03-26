using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReservaRepository : IReservaRepository
{
    private readonly ReservaDbContext _context;

    public ReservaRepository(ReservaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reserva>> ObtenerReservasAsync()
    {
        return await _context.Reservas.ToListAsync();
    }

    public async Task<bool> CrearReservaAsync(Reserva nuevaReserva)
    {
        if (_context.Reservas.Any(r => r.FechaHora == nuevaReserva.FechaHora))
            return false;

        _context.Reservas.Add(nuevaReserva);
        await _context.SaveChangesAsync();
        return true;
    }
}