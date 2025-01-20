using Microsoft.AspNetCore.Mvc;
using WTWGestionFacturasAPI.Application.Services.Interfaces;
using WTWGestionFacturasAPI.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WTWGestionFacturasAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        
        [HttpGet("GetFacturaPorNumero")]
        public async Task<ActionResult<Factura>> GetFacturaPorNumero(int numeroFactura)
        {
            var result = await _facturaService.getFacturaPorNumero(numeroFactura);
            return Ok(result);
        }

        [HttpGet("GetFacturaPorIdCliente")]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturaPorIdCliente(int idCliente)
        {
            var result = await _facturaService.getFacturasPorIdCliente(idCliente);
            return Ok(result);
        }


    }
}
