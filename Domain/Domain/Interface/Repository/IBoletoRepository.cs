using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entity;

namespace Domain.Interface.Repository
{
    public interface IBoletoRepository
    {
        Task<int> Cadastrar(Boleto banco);
        Task<Boleto> Buscar(int codigoBoleto);
    }
}
