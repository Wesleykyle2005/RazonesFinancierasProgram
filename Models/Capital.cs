using System;
using System.Collections.Generic;

namespace RazonesFinancieras.Models;

public partial class Capital
{
    public int IdCapital { get; set; }

    public string NombreCuenta { get; set; } = null!;

    public string Clasificacion { get; set; } = null!;

    public decimal Valor { get; set; }
}
