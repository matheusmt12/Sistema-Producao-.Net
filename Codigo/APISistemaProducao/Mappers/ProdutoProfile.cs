using APISistemaProducao.Models;
using AutoMapper;
using Core;
using Core.Service;

namespace APISistemaProducao.Mappers
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoModel, Produto>().ReverseMap();
        }

    }
}
