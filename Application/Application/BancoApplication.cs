using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface.Application;
using Domain.Interface.Repository;

namespace Application.Application;

public class BancoApplication(IBancoRepository bancoRepository, IMapper mapper) : IBancoApplication
{
    private readonly IBancoRepository _bancoRepository = bancoRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Cadastrar(BancoDto bancoDto)
    {
        var banco = _mapper.Map<Banco>(bancoDto);

        var id = await _bancoRepository.Cadastrar(banco);

        return id > 0;
    }

    public async Task<IList<BancoDto>> ListarTodos()
    {
        var lista = await _bancoRepository.ListarTodos();

        var resultado = new List<BancoDto>();

        foreach (var item in lista)
        {
            resultado.Add(_mapper.Map<BancoDto>(item));
        }

        return resultado;
    }

    public async Task<BancoDto> Buscar(int codigoBanco)
    {
        var banco = await _bancoRepository.Buscar(codigoBanco);

        return _mapper.Map<BancoDto>(banco);
    }
}
