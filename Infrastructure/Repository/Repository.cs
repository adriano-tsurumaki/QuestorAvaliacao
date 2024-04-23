using System.Linq.Expressions;
using Domain.Interface.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class Repository<T>(BancoContext context) : IRepository<T> where T : class
{
    public readonly BancoContext _context = context;

    public async Task AddAsync(T entity) => 
        await _context.Set<T>().AddAsync(entity);

    public async Task AddRangeAsync(IList<T> entity) => 
        await _context.Set<T>().AddRangeAsync(entity);

    public async Task DeleteAsync(T entity) => 
        await Task.Run(() => { _context.Set<T>().Remove(entity); });

    public async Task DeleteRangeAsync(IList<T> entity) => 
        await Task.Run(() => { _context.Set<T>().RemoveRange(entity); });

    public async Task UpdateAsync(T entity) => 
        await Task.Run(() => { _context.Set<T>().Update(entity); });

    public async Task UpdateRangeAsync(IList<T> entity) => 
        await Task.Run(() => { _context.Set<T>().UpdateRange(entity); });

    public async Task<T> Get(Expression<Func<T, bool>> expression) =>
        await _context.Set<T>().Where(expression).FirstOrDefaultAsync();

    public async Task<IEnumerable<T>> GetAll() =>
        await _context.Set<T>().ToListAsync();

    public async Task<T?> GetById(int key) =>
        await _context.Set<T>().FindAsync(key);
}
