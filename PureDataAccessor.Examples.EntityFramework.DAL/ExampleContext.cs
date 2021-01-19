using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PureDataAccessor;
using PureDataAccessor.EntityFrameworkCore;
using PureDataAccessor.Examples.Models;
using System;

namespace PureDataAccessor.Examples.EntityFramework.DAL
{
    public class ExampleContext : PDAContext
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public ExampleContext(IConfiguration configuration) : base(typeof(User).Assembly)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnectionString");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
        /*
         * if you use "base(typeof(User).Assembly)" entities will map automatically based on your referenced assembly,  
         * but if you want, you can create your own db set mapping on here
         * like that : 
         * public DbSet<User> Users { get; set; }
         * public DbSet<Company> Companies { get; set; }
         * 
         * You should be sure about you did the table name mapping for entity models
        */
    }
}
