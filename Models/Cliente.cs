using System;
using System.Collections.Generic;

namespace AlquilerVehiculos.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Cedula { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public virtual ICollection<Alquiler> Alquilers { get; } = new List<Alquiler>();
}
