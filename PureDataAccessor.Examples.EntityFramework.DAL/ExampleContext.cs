using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PureDataAccessor;
using PureDataAccessor.EntityFrameworkCore;
using PureDataAccessor.Examples.Models;
using System;

namespace PureDataAccessor.Examples.EntityFramework.DAL
{
    public class ExampleContext<T> : PDAContext<T>
    {
        public ExampleContext(DbContextOptions<PDAContext<T>> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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
