using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PureDataAccessor.Examples.Models.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User's Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "User's Surname is required")]
        public string Surname { get; set; }

        public int? CompanyId { get; set; }
    }
}
