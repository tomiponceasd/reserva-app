using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Reserva
{
    public int Id { get; set; }

    [Required]
    public string Cliente { get; set; } = string.Empty;

    [Required]
    public DateTime FechaHora { get; set; }

    [Required]
    public int ServicioId { get; set; }
}