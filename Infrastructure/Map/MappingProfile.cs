using AutoMapper;
using Domain.DTO;
using Domain.Entity;

namespace Infrastructure.Map;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Banco, BancoDto>().ReverseMap();
        CreateMap<Boleto, BoletoDto>().ReverseMap();
    }
}
