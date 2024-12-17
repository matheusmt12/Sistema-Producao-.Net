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
    public class ProdutoService : IProdutoService
    {
        readonly SistemaProducaoContext _context;
        public ProdutoService(SistemaProducaoContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Produto produto)
        {
            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto.IdProduto;
        }

        public async Task<Produto> Edit(Produto produto)
        {
            _context.Update(produto);

            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> Get(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }
    }
}
