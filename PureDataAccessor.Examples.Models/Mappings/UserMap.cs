using FluentNHibernate.Mapping;
using PureDataAccessor.NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PureDataAccessor.Examples.Models.Mappings
{

    public class UserMap : PDANHibernateClassMapper<User>
    {
        public UserMap()
        { 
            Map(p => p.Name).Nullable();
            Map(p => p.Surname).Nullable();
            Map(p => p.CompanyId).Nullable();
            HasOne(m => m.Company).ForeignKey("CompanyId").LazyLoad();
        }
    }
}