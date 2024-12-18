﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IClienteService
    {
        Task<int> Create(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> Get(int idCliente);
        Task<Cliente> Edit(Cliente cliente);
    }
}
