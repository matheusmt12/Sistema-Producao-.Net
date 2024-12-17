using APISistemaProducao.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APISistemaProducao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        readonly IProdutoService _produtoService;
        readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var produtos =await _produtoService.GetAll();
            var model = _mapper.Map<List<ProdutoModel>>(produtos);
            return Ok(model); 
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var produto = await _produtoService.Get(id);
            var model = _mapper.Map<ProdutoModel>(produto);

            return Ok(model);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoModel produtoModel)
        {
            var produto = _mapper.Map<Produto>(produtoModel);

            return Ok(await _produtoService.Create(produto));

        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public  async Task<ActionResult> Put(int id, [FromBody] ProdutoModel produtoModel)
        {
            var clienteUpdate = _mapper.Map<Produto>(produtoModel);

            clienteUpdate = await _produtoService.Edit(clienteUpdate);
            return Ok(clienteUpdate);
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
