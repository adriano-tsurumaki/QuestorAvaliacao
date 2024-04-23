using Domain.DTO;
using System.Threading.Tasks;

namespace Domain.Interface.Application;

public interface IBoletoApplication
{
    Task<bool> Cadastrar(BoletoDto bancoDto);
    Task<BoletoDto> Buscar(int codigoBoleto);
}
