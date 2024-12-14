using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Cliente> Edit(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> Get(int idCliente)
        {
            return await  _context.Clientes.FindAsync(idCliente);
            
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
