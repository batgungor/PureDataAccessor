using PureDataAccessor.Examples.EntityFramework.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PureDataAccessor.EntityFrameworkCore.Implementation;
using PureDataAccessor.EntityFrameworkCore;
using PureDataAccessor.Examples.Models;

namespace PureDataAccessor.Examples.EntityFramework.Web
{
    public class Startup
    {
        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnectionString");
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            /*
             implementation examples : 
             1-)Use custom DBcontext
                example 1 ->Use default PDAconnectionstring: You should add "PDAConnectionString" to your appconfig -> connection strings
                            services.AddEFPureDataAccessor<ExampleContext<User>>(_configuration);
                example 2 ->Use custom named connectionString:
                            services.AddEFPureDataAccessor<ExampleContext<User>>(_configuration,"connectionStringName");
                example 3 ->Use connection string directly
                            services.AddEFPureDataAccessor<ExampleContext<User>>("Server=servername;Database=dbname;Trusted_Connection=True;");
             2-)Use default PDAContext
                example 1 ->Use default PDAconnectionstring: You should add "PDAConnectionString" to your appconfig -> connection strings
                            services.AddEFPureDataAccessor<PDAContext<User>>(_configuration);
                example 2 ->Use custom named connectionString:
                            services.AddEFPureDataAccessor<PDAContext<User>>(_configuration,"connectionStringName");
                example 3 ->Use connection string directly
                            services.AddEFPureDataAccessor<PDAContext<User>>("Server=servername;Database=dbname;Trusted_Connection=True;");
             */

            services.AddEFPureDataAccessor<ExampleContext<User>>(connectionString);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
