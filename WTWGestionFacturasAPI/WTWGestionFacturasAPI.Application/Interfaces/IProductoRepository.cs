using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Domain.Entities;

namespace WTWGestionFacturasAPI.Application.Interfaces;
public interface IProductoRepository
{
    Task<IEnumerable<Producto>> getProductosAll();
}
