using AutoMapper;
using TechChallenge.Application.Dtos;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings;

public class DtoToEntity : Profile
{
    public DtoToEntity()
    {
        CreateMap<CriarContatoDto, Contato>().ReverseMap();
        CreateMap<AtualizarContatoDto, Contato>().ReverseMap();
        CreateMap<RemoverContatoDto, Contato>().ReverseMap();
    }
}