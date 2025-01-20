﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Domain.Entities;

namespace WTWGestionFacturasAPI.Application.Services.Interfaces;

public  interface IProductoService
{
    Task<IEnumerable<Producto>> getProductosAll();
}
