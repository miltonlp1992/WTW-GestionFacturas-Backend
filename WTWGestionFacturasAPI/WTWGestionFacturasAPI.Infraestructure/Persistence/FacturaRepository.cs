using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Application.Interfaces;
using WTWGestionFacturasAPI.Domain.Entities;
using WTWGestionFacturasAPI.Infraestructure.Persistence.Interfaces;

namespace WTWGestionFacturasAPI.Infraestructure.Persistence;

public class FacturaRepository : IFacturaRepository
{
    private readonly IDbContext _dbContext;

    public FacturaRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CrearFactura(Factura factura)
    {
        /*
         *  public DateTime FechaEmisionFactura { get; set; }
            public int IdCliente { get; set; }
            public int NumeroFactura { get; set; }
            public int NumeroTotalArticulos { get; set; }
            public decimal SubTotalFacturas { get; set; }
            public decimal TotalImpuestos { get; set; }
            public decimal TotalFactura { get; set; }
         * */

        using (var connection = _dbContext.CreateConnection())
        {
            var parameters = new 
            {  FechaEmisionFactura = factura.FechaEmisionFactura,
                IdCliente = factura.IdCliente,
                NumeroFactura = factura.NumeroFactura,
                NumeroTotalArticulos = factura.NumeroTotalArticulos,
                SubTotalFacturas = factura.SubTotalFacturas,
                TotalImpuestos = factura.TotalImpuestos,
                TotalFactura = factura.TotalFactura,
                Detalles = JsonSerializer.Serialize(factura.Detalles)
            };
            await connection.ExecuteAsync("CrearFactura", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<Factura> getFacturaPorNumero(int numeroFactura)
    {
        using (var connection = _dbContext.CreateConnection())
        {
            var parameters = new { NumeroFactura = numeroFactura };
            var factura = await connection.QueryFirstAsync<Factura>("getFacturaPorNumeroFactura", parameters, commandType: CommandType.StoredProcedure);

            return factura;
        }
    }

    public async Task<IEnumerable<Factura>> getFacturasPorIdCliente(int idCliente)
    {
        using (var connection = _dbContext.CreateConnection())
        {
            var parameters = new { IdCliente = idCliente };
            var facturas = await connection.QueryAsync<Factura>("getFacturasPorCliente", parameters, commandType: CommandType.StoredProcedure);

            return facturas;
        }
    }
}
