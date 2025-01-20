using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTWGestionFacturasAPI.Application.Interfaces;
using WTWGestionFacturasAPI.Application.Services.Interfaces;
using WTWGestionFacturasAPI.Domain.Entities;

namespace WTWGestionFacturasAPI.Application.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> getClientesAll()
        {
            return await _clienteRepository.getClientesAll();
        }
    }
}
