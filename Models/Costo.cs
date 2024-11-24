using System;
using System.Collections.Generic;

namespace RazonesFinancieras.Models;

public partial class Costo
{
    public int IdCosto { get; set; }

    public string NombreCuenta { get; set; } = null!;

    public string Clasificacion { get; set; } = null!;

    public decimal Valor { get; set; }
}
