using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PureDataAccessor.UnitOfWork;

namespace PureDataAccessor.EntityFrameworkCore.Implementation
{
    public static class ServiceImplementer
    {
        public static void AddEFPureDataAccessor<T>(this IServiceCollection services, string connectionString) where T : DbContext, IDbContext
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString);
            services.ImplementService<T>(builder);
        }

        public static void AddEFPureDataAccessor<T>(this IServiceCollection services, IConfiguration configuration, string connectionStringName) where T : DbContext, IDbContext
        {
            var connectionString = configuration.GetConnectionString("connectionStringName");
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString);
            services.ImplementService<T>(builder);
        }
        public static void AddEFPureDataAccessor<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext, IDbContext
        {
            var connectionString = configuration.GetConnectionString("PDAConnectionString");
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString);
            services.ImplementService<T>(builder);
        }

        private static void ImplementService<T>(this IServiceCollection services, DbContextOptionsBuilder builder) where T : DbContext, IDbContext
        {
            services.AddDbContext<T>(options => options = builder);
            services.AddTransient<IDbContext, T>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
