using PureDataAccessor.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PureDataAccessor.Examples.Models
{
    [Table("Users")]
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual int? CompanyId {get;set;}
        public virtual Company Company { get; set; }
}
}
