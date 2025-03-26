using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class ReservaService : IReservaService
{
    private readonly IReservaRepository _reservaRepository;

    public ReservaService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public async Task<List<Reserva>> ObtenerReservasAsync()
    {
        return await _reservaRepository.ObtenerReservasAsync();
    }

    public async Task<bool> CrearReservaAsync(Reserva nuevaReserva)
    {
        return await _reservaRepository.CrearReservaAsync(nuevaReserva);
    }
}