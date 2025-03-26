using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Servicio
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;
}