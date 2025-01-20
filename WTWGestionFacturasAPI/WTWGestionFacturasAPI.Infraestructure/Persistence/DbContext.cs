using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Infraestructure.Persistence.Interfaces;
using Microsoft.Data.SqlClient;

namespace WTWGestionFacturasAPI.Infraestructure.Persistence;

public class DbContext : IDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}
