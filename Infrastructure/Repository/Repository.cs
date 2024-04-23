using Domain.Interface.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class Repository<T>(FaturaContext context) : IRepository<T> where T : class
{
    public readonly FaturaContext _context = context;

    public async Task AddAsync(T entity) => 
        await _context.Set<T>().AddAsync(entity);

    public async Task<IList<T>> GetAll() =>
        await _context.Set<T>().ToListAsync();

    public async Task<T> GetById(int key) =>
        await _context.Set<T>().FindAsync(key);
}
