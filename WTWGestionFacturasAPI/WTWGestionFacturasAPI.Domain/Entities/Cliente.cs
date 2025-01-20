using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTWGestionFacturasAPI.Domain.Entities;

public class Cliente
{    
    public int Id { get; set; } 
    public string RazonSocial { get; set; } = string.Empty;
    public string RFC { get; set; } = string.Empty;

    public int IdTipoCliente { get; set; }  
    public TipoCliente? TipoCliente { get; set; }
    public string FechaCreacion { get; set; } = string.Empty;   
}
