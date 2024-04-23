using Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Application;

public interface IBancoApplication
{
    Task<bool> Cadastrar(BancoDto bancoDto);
    Task<IList<BancoDto>> ListarTodos();
    Task<BancoDto> Buscar(int codigoBanco);
}
