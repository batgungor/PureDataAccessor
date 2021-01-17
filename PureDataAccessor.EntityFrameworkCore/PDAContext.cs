﻿using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Models;
using System;
using System.Linq;
using System.Reflection;
namespace PureDataAccessor.EntityFrameworkCore
{
    public class PDAContext<T> : DbContext, IDbContext
    {
        private readonly Assembly _entityAssembly;
        public PDAContext(DbContextOptions<PDAContext<T>> options) : base(options)
        {
            _entityAssembly = typeof(T).Assembly;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_entityAssembly != null)
            {
                var types = _entityAssembly.GetTypes().ToList();
                types = types.Where(q => q.BaseType == typeof(Entity)).ToList();
                foreach (Type type in types)
                {
                    UseAsEntity(modelBuilder, type);
                }
            }
        }

        public void UseAsEntity(ModelBuilder modelBuilder, Type type)
        {
            modelBuilder.Entity(type);
        }
    }
}
