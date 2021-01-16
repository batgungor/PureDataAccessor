using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Extensions;
using PureDataAccessor.Models;
using PureDataAccessor.Repositories;
using PureDataAccessor.UnitOfWork;
using System;

namespace PureDataAccessor.EntityFrameworkCore
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool _isDisposed = false;
        private readonly DbContext _context;
        private readonly RepositoryList _repositories;
        public EFUnitOfWork(IDbContext context)
        {
            _context = (DbContext)context;
            _repositories = new RepositoryList();
        }

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            var repositoryListItem = _repositories.GetRepository<T>();
            EFRepository<T> repository;
            if (repositoryListItem == null)
            {
                repository = new EFRepository<T>(_context);
                _repositories.Add<T>(repository);
            }
            else
            {
                repository = (EFRepository<T>)repositoryListItem.Repository;
            }
            return repository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (this._isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
