
using System.Data;

namespace WTWGestionFacturasAPI.Infraestructure.Persistence.Interfaces;

public interface IDbContext
{   
    IDbConnection CreateConnection();
}
