using Domain.Entity;
using Domain.Interface.Repository;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class BancoRepository(BancoContext context) : Repository<Banco>(context), IBancoRepository
    {
        public async Task<int> Cadastrar(Banco banco)
        {
            await AddAsync(banco);

            return _context.SaveChanges();
        }

        public async Task<IList<Banco>> ListarTodos()
        {
            var listaDeBancos = await GetAll();

            return listaDeBancos.ToList();
        }

        public async Task<Banco> Buscar(int codigoBanco)
        {
            var banco = await GetById(codigoBanco);

            if (banco is null)
            {
                return new();
            }

            return banco;
        }
    }
}
