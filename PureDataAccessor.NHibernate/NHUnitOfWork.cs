using NHibernate;
using PureDataAccessor.Extensions;
using PureDataAccessor.Models;
using PureDataAccessor.Repositories;
using PureDataAccessor.UnitOfWork;
using System;

namespace PureDataAccessor.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private bool _isDisposed = false; 
        private readonly ITransaction _transaction;
        private readonly ISession _session;
        private readonly RepositoryList _repositories;
        public NHUnitOfWork(ISession session)
        {
            _session = session;
            _transaction = session.BeginTransaction();
            _repositories = new RepositoryList();
        }

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            var repositoryListItem = _repositories.GetRepository<T>();
            NHRepository<T> repository;
            if (repositoryListItem == null)
            {
                repository = new NHRepository<T>(_session);
                _repositories.Add<T>(repository);
            }
            else
            {
                repository = (NHRepository<T>)repositoryListItem.Repository;
            }
            return repository;
        }

        public int SaveChanges()
        {
            _transaction.Commit();
            return 0;
        }

        public virtual void Dispose(bool disposing)
        {
            if (this._isDisposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                }
            }
            this._isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
