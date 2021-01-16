using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PureDataAccessor.Examples.EntityFramework.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User's Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "User's Surname is required")]
        public string Surname { get; set; }
    }
}
