using PureDataAccessor.Models;
using System.Collections.Generic;
using System.Linq;

namespace PureDataAccessor.Extensions
{
    public class RepositoryList
    {
        private readonly List<RepositoryListItem> _repositories;
        public RepositoryList()
        {
            _repositories = new List<RepositoryListItem>();
        }

        public RepositoryListItem GetRepository<T>() where T : Entity
        {
            return _repositories.Where(q => q.Type == typeof(T)).FirstOrDefault();
        }
        public void Add<T>(object repository) where T : Entity
        {
            if (!_repositories.Where(q => q.Type == typeof(T)).Any())
            {
                _repositories.Add(new RepositoryListItem()
                {
                    Repository = repository,
                    Type = typeof(T)
                });
            }
        }
    }
}
