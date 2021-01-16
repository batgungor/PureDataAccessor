using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PureDataAccessor.Examples.Models;
using PureDataAccessor.UnitOfWork;

namespace PureDataAccessor.Examples.EntityFramework.Web.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : PureDataAccessor.Examples.Base.Controllers.CompanyController
    {
        public CompanyController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}