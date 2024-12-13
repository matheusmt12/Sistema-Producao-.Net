using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;

namespace Service
{
    public class ClienteService : IClienteService
    {
        readonly SistemaProducaoContext _context;

        public ClienteService(SistemaProducaoContext context)
        {
            _context = context; 
        }
        public async Task<int> Create(Cliente cliente)
        {
           await _context.AddAsync(cliente);
           await _context.SaveChangesAsync();
           return cliente.IdCliente;
        }
    }
}
