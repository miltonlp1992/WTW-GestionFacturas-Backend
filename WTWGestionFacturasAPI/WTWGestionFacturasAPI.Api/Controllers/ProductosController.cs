using Microsoft.AspNetCore.Mvc;
using WTWGestionFacturasAPI.Application.Services;
using WTWGestionFacturasAPI.Application.Services.Interfaces;
using WTWGestionFacturasAPI.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WTWGestionFacturasAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/<ProductosController>        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesAll()
        {
            var result = await _productoService.getProductosAll();
            return Ok(result);
        }
    }
}
