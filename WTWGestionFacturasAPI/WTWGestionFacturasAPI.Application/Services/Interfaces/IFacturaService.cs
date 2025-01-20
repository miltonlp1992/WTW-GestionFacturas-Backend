using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Domain.Entities;

namespace WTWGestionFacturasAPI.Application.Services.Interfaces;

public interface IFacturaService
{
    Task<Factura> getFacturaPorNumero(int numeroFactura);
    Task<IEnumerable<Factura>> getFacturasPorIdCliente(int idCliente);
    Task CrearFactura(Factura factura);    
}
