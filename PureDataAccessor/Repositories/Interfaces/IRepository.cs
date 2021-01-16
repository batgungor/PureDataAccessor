using PureDataAccessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PureDataAccessor.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        List<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        T GetById(int Id);

        void Add(T entity);
        void Update(T entity);
        void Delete(int Id);
        void Delete(T entity);
    }
}
