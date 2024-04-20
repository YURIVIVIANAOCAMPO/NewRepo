using System;
using System.Collections.Generic;

namespace AlquilerVehiculos.Models;

public partial class Carro
{
    public int IdCarro { get; set; }

    public string? Placa { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public decimal? Costo { get; set; }

    public string? Disponible { get; set; }

    public virtual ICollection<Alquiler> Alquilers { get; } = new List<Alquiler>();
}
