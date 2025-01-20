﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTWGestionFacturasAPI.Domain.Entities;
public class Producto
{
    public int Id { get; set; }
    public string NombreProducto { get; set; } = string.Empty;
    public byte[]? ImagenProducto { get; set; }
    public decimal PrecioUnitario { get; set; }
    public string? Ext { get; set; }
}
