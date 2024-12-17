using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetAll();
        Task<Produto> Get(int id);
        Task<int> Create(Produto produto);
        Task<Produto> Edit(Produto produto);
    }
}
