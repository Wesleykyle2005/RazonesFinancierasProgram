using System;
using System.Collections.Generic;

namespace RazonesFinancieras.Models;

public partial class Pasivo
{
    public int IdPasivo { get; set; }

    public string NombreCuenta { get; set; } = null!;

    public string Clasificacion { get; set; } = null!;

    public decimal Valor { get; set; }
}
