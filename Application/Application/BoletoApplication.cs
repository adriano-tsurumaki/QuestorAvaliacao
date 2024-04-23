using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface.Application;
using Domain.Interface.Repository;

namespace Application.Application;

public class BoletoApplication(IBoletoRepository boletoRepository, IBancoRepository bancoRepository, IMapper mapper) : IBoletoApplication
{
    private readonly IBoletoRepository _boletoRepository = boletoRepository;
    private readonly IBancoRepository _bancoRepository = bancoRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Cadastrar(BoletoDto boletoDto)
    {
        var boleto = _mapper.Map<Boleto>(boletoDto);

        var id = await _boletoRepository.Cadastrar(boleto);

        return id > 0;
    }

    public async Task<BoletoDto> Buscar(int codigoBoleto)
    {
        var boleto = await _boletoRepository.Buscar(codigoBoleto);

        if (boleto is null)
        {
            return null;
        }

        var percentualJuros = (await _bancoRepository.Buscar(boleto.BancoId)).PercentualJuros;

        if (boleto.DataVencimento > DateTime.Now)
        {
            boleto.Valor += boleto.Valor * percentualJuros;
        }

        return _mapper.Map<BoletoDto>(boleto);
    }
}
