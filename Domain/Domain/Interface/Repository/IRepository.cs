using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface.Repository;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);

    Task AddRangeAsync(IList<T> entity);

    Task UpdateAsync(T entity);

    Task UpdateRangeAsync(IList<T> entity);

    Task DeleteAsync(T entity);

    Task DeleteRangeAsync(IList<T> entity);

    Task<T> Get(Expression<Func<T, bool>> expression);

    Task<T> GetById(int key);
}
