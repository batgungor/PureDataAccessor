using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Models;
using PureDataAccessor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PureDataAccessor.EntityFrameworkCore
{
    public class EFRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = GetById(Id);
            Delete(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                return;
            }
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            var result = _dbSet.AsQueryable();
            if (predicate != null)
            {
                result = _dbSet.Where(predicate);
            }
            return result;
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
