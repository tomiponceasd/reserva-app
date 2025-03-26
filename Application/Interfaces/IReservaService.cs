using Domain.Entities;

namespace Application.Interfaces;

public interface IReservaService
{
    Task<List<Reserva>> ObtenerReservasAsync();

    Task<bool> CrearReservaAsync(Reserva nuevaReserva);
}