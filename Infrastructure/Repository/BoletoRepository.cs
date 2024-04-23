using Domain.Entity;
using Domain.Interface.Repository;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class BoletoRepository(BancoContext context) : Repository<Boleto>(context), IBoletoRepository
    {
        public async Task<int> Cadastrar(Boleto boleto)
        {
            await AddAsync(boleto);

            return _context.SaveChanges();
        }

        public async Task<Boleto> Buscar(int codigoBoleto)
        {
            var boleto = await GetById(codigoBoleto);

            if (boleto is null)
            {
                return new();
            }

            return boleto;
        }
    }
}
