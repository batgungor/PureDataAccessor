using NHibernate;
using PureDataAccessor.Models;
using PureDataAccessor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PureDataAccessor.NHibernate
{
    public class NHRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ISession _session;
        private readonly IQueryable<T> query;
        public NHRepository(ISession session)
        {
            _session = session;
            query = _session.Query<T>();
        }
        public void Add(T entity)
        {
            _session.Save(entity);
            _session.Flush();
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
            _session.Delete(entity);
            _session.Flush();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            var result = query;
            if (predicate != null)
            { 
                result = query.Where(predicate);
            }
            return result;
        }

        public List<T> GetAll()
        {
            return Get().ToList();
        }

        public T GetById(int Id)
        {
            var result = _session.Get<T>(Id);
            return result;
        }

        public void Update(T entity)
        {
            _session.Update(entity);
            _session.Flush();
        }
    }
}
