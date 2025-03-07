using System;
using System.Collections.Generic;

namespace Xnacion1.Repository;

public partial class TProducto
{
    public int IdProducto { get; set; }

    public string NProducto { get; set; } = null!;

    public double Precio { get; set; }

    public virtual ICollection<TDetallesEnvio> TDetallesEnvios { get; set; } = new List<TDetallesEnvio>();
}
