using System;
using System.Collections.Generic;

namespace AlquilerVehiculos.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? IdAlquiler { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Valor { get; set; }

    public virtual Alquiler? IdAlquilerNavigation { get; set; }
}
