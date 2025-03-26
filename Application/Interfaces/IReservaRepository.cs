using Domain.Entities;

namespace Application.Interfaces;

public interface IReservaRepository
{
    Task<List<Reserva>> ObtenerReservasAsync();

    Task<bool> CrearReservaAsync(Reserva nuevaReserva);
}