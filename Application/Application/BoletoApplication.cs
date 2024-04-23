using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface.Application;
using Domain.Interface.Repository;
using Domain.Validation.Entity;
using Domain.Exceptions;
using System.Text;

namespace Application.Application;

public class BoletoApplication(IBoletoRepository boletoRepository, IBancoRepository bancoRepository, IMapper mapper) : IBoletoApplication
{
    private readonly IBoletoRepository _boletoRepository = boletoRepository;
    private readonly IBancoRepository _bancoRepository = bancoRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Cadastrar(BoletoDto boletoDto)
    {
        var boleto = _mapper.Map<Boleto>(boletoDto);

        if (boleto.CpfCnpjBeneficiario.Formatado == string.Empty)
        {
            boleto.CpfCnpjBeneficiario = boletoDto.CpfCnpjBeneficiario;
        }

        if (boleto.CpfCnpjPagador.Formatado == string.Empty)
        {
            boleto.CpfCnpjPagador = boletoDto.CpfCnpjPagador;
        }

        var validacao = new BoletoValidation();
        var resultadoValidacao = validacao.Validate(boleto);

        if (!resultadoValidacao.IsValid)
        {
            var erros = new StringBuilder();

            foreach (var erro in resultadoValidacao.Errors)
            {
                erros.AppendLine(erro.ErrorMessage);
            }

            throw new FluentValidationException(erros.ToString());
        }

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
