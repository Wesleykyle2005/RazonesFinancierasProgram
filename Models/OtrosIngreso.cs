using System;
using System.Collections.Generic;

namespace RazonesFinancieras.Models;

public partial class OtrosIngreso
{
    public int Id { get; set; }

    public string? NombreCuenta { get; set; }

    public string? Clasificacion { get; set; }

    public decimal? Valor { get; set; }
}
