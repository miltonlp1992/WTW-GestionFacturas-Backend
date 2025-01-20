using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Application.Interfaces;
using WTWGestionFacturasAPI.Domain.Entities;

namespace WTWGestionFacturasAPI.Application.Services.Interfaces;

public class FacturaService : IFacturaService
{
    private readonly IFacturaRepository _facturaRepository;
    public FacturaService(IFacturaRepository facturaRepository)
    {
        _facturaRepository = facturaRepository;
    }

    public async Task CrearFactura(Factura factura)
    {   
        await _facturaRepository.CrearFactura(factura);
    }

    public async Task<Factura> getFacturaPorNumero(int numeroFactura)
    {
        return await _facturaRepository.getFacturaPorNumero(numeroFactura);
    }

    public async Task<IEnumerable<Factura>> getFacturasPorIdCliente(int idCliente)
    {
        return await _facturaRepository.getFacturasPorIdCliente(idCliente);
    }

}
