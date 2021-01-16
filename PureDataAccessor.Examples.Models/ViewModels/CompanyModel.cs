using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PureDataAccessor.Examples.Models.ViewModels
{
    public class CompanyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Company's Name is required")]
        public string Name { get; set; }
    }
}
