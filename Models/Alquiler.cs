using System;
using System.Collections.Generic;

namespace AlquilerVehiculos.Models;

public partial class Alquiler
{
    public int IdAlquiler { get; set; }

    public int? IdCarro { get; set; }

    public int? IdCliente { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Tiempo { get; set; }

    public decimal? ValorTotal { get; set; }

    public decimal? Saldo { get; set; }

    public decimal? AbonoInicial { get; set; }

    public string? Devuelto { get; set; }

    public virtual Carro? IdCarroNavigation { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; } = new List<Pago>();
}
