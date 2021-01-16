using PureDataAccessor.Models;
using PureDataAccessor.Repositories;
using System;

namespace PureDataAccessor.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : Entity;
        int SaveChanges();
    }
}
