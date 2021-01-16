using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PureDataAccessor.UnitOfWork;

namespace PureDataAccessor.EntityFrameworkCore.Implementation
{
    public static class ServiceImplementer
    {
        public static void AddEFPureDataAccessor<T>(this IServiceCollection services) where T : DbContext, IDbContext
        {
            services.AddDbContext<T>();
            services.AddTransient<IDbContext, T>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
