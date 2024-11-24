using System;
using System.Collections.Generic;

namespace RazonesFinancieras.Models;

public partial class Gasto
{
    public int IdGasto { get; set; }

    public string NombreCuenta { get; set; } = null!;

    public string Clasificacion { get; set; } = null!;

    public decimal Valor { get; set; }
}
