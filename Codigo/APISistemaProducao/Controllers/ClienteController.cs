using APISistemaProducao.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISistemaProducao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IClienteService _clienteService;
        readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }


        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            
            var clientes = await _clienteService.GetAll();
            var  model = _mapper.Map<List<ClienteModel>>(clientes);

            return Ok(model);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public  async Task<ActionResult> Get(int id)
        {
            var cliente = await _clienteService.Get(id);
            var model = _mapper.Map<ClienteModel>(cliente);

            return Ok(model);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteModel clienteModel)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteModel);
            await _clienteService.Create(cliente);
            return Ok(cliente);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put (int id, [FromBody] ClienteModel clienteModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteModel);

            cliente = await _clienteService.Edit(cliente);

            return Ok(cliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
