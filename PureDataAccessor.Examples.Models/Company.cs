using PureDataAccessor.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PureDataAccessor.Examples.Models
{
    [Table("Companies")]
    public class Company : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
