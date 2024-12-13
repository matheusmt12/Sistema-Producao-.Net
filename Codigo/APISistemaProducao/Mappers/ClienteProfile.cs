using APISistemaProducao.Models;
using AutoMapper;
using Core;

namespace APISistemaProducao.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteModel,Cliente>().ReverseMap();
        }
    }
}
