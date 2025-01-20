using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Application.Interfaces;
using WTWGestionFacturasAPI.Domain.Entities;
using WTWGestionFacturasAPI.Infraestructure.Persistence.Interfaces;

namespace WTWGestionFacturasAPI.Infraestructure.Persistence;

public class ClienteRepository : IClienteRepository
{

    private readonly IDbContext _dbContext;

    public ClienteRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Cliente>> getClientesAll()
    {
        using (var connection = _dbContext.CreateConnection())
        {
            //var clientes = await connection.QueryAsync<Cliente>("getClientesAll",commandType: CommandType.StoredProcedure);
            
            var clientes = await connection.QueryAsync<Cliente, TipoCliente, Cliente>(
                    "getClientesAll",
                    (cliente, tipoCliente) =>
                    {
                        cliente.TipoCliente = tipoCliente;
                        return cliente;
                    },
                    splitOn: "IdTipoCliente",
                    commandType: CommandType.StoredProcedure
                );


            return clientes;
        }

        
    }
}
