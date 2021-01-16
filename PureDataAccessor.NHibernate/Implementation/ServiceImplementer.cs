using FluentNHibernate.Cfg;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using PureDataAccessor.Models;
using PureDataAccessor.UnitOfWork;
using System.Linq;
using System.Reflection;

namespace PureDataAccessor.NHibernate.Implementation
{
    public static class ServiceImplementer
    {
        public static void AddNHibernatePureDataAccessor<T>(this IServiceCollection services, string connectionString) where T : Entity
        {
            services.AddSingleton<ISessionFactory>(factory =>
            {
                return Fluently.Configure()
                .Database(
                    () =>
                    {
                        return FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql7
                        .ShowSql()
                        .ConnectionString(connectionString);
                    }
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
                .BuildSessionFactory();
            });

            services.AddSingleton<ISession>(factory => factory.GetServices<ISessionFactory>().First().OpenSession());
            services.AddTransient<IUnitOfWork, NHUnitOfWork>();
        }
    }
}