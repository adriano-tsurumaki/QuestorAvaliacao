using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Domain.ValueObject;

namespace Infrastructure.Map;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Banco, BancoDto>().ReverseMap();
        CreateMap<Boleto, BoletoDto>()
            .ForPath(dest => dest.CpfCnpjBeneficiario, opt => opt.MapFrom(src => src.CpfCnpjBeneficiario.Formatado))
            .ForPath(dest => dest.CpfCnpjPagador, opt => opt.MapFrom(src => src.CpfCnpjPagador.Formatado))
            .ReverseMap()
            .ForPath(dest => dest.CpfCnpjBeneficiario.Formatado, opt => opt.MapFrom(src => new CpfCnpj(src.CpfCnpjBeneficiario)))
            .ForPath(dest => dest.CpfCnpjPagador.Formatado, opt => opt.MapFrom(src => new CpfCnpj(src.CpfCnpjPagador)));
    }
}
