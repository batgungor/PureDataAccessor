using FluentNHibernate.Mapping;
using PureDataAccessor.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PureDataAccessor.Examples.Models.Mappings
{

    public class CompanyMap : PDANHibernateClassMapper<Company>
    {
        public CompanyMap()
        {
            Map(p => p.Name).Nullable();
        }
    }
}