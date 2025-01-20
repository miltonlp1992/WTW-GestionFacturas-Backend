using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTWGestionFacturasAPI.Domain.Entities;

public class DetalleFactura
{
    public int Id { get; set; }
    public int IdFactura { get; set; }
    public int IdProducto { get; set; }
    public int CantidadDeProducto { get; set; }
    public decimal PrecioUnitarioProducto { get; set; }
    public decimal SubtotalProducto { get; set; }
    public string? Notas { get; set; }
}
