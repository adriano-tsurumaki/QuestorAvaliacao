using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface.Repository;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task<IList<T>> GetAll();
    Task<T> GetById(int key);
}
