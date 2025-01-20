using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Application.Interfaces;
using WTWGestionFacturasAPI.Domain.Entities;
using WTWGestionFacturasAPI.Infraestructure.Persistence.Interfaces;

namespace WTWGestionFacturasAPI.Infraestructure.Persistence;

public class ProductoRepository : IProductoRepository
{
    private readonly IDbContext _dbContext;

    public ProductoRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Producto>> getProductosAll()
    {
        using (var connection = _dbContext.CreateConnection())
        {
            var productos = await connection.QueryAsync<Producto>("GetProductosAll", commandType: CommandType.StoredProcedure);
            return productos;
        }
    }
}
