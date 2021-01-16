using FluentNHibernate.Mapping;
using PureDataAccessor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PureDataAccessor.NHibernate
{
    public class PDANHibernateClassMapper<T> : ClassMap<T> where T : Entity
    {
        public PDANHibernateClassMapper()
        {
            var attributes = typeof(T).GetCustomAttributes(true);
            var att = (TableAttribute)attributes.Where(q => q.GetType().Equals(typeof(TableAttribute))).FirstOrDefault();
            if (att != null)
            {
                Table(att.Name);
            }
            Id(e => e.Id).GeneratedBy.Identity();
            var properties = typeof(T).GetProperties().Where(q=> q.Name != "Id");
            
            foreach (var property in properties)
            {

            }
        }
    }
}
