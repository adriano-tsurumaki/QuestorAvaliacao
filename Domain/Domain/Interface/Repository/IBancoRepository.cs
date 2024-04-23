using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interface.Repository;

public interface IBancoRepository
{
    Task<int> Cadastrar(Banco banco);
    Task<IList<Banco>> ListarTodos();
    Task<Banco> Buscar(int codigoBanco);
}
