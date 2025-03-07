using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Xnacion1.Repository;

public partial class TEnvio
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string DniCliente { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string PalabraSecreta { get; set; } = null!;

    public string Estado { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<TDetallesEnvio> TDetallesEnvios { get; set; } = new List<TDetallesEnvio>();
}
