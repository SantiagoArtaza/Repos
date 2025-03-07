using System;
using System.Collections.Generic;

namespace Xnacion1.Repository;

public partial class TDetallesEnvio
{
    public int IdEnvio { get; set; }

    public int Detalle { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public string? Comentario { get; set; }

    public virtual TEnvio IdEnvioNavigation { get; set; } = null!;

    public virtual TProducto IdProductoNavigation { get; set; } = null!;
}
