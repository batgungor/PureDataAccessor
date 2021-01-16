using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PureDataAccessor.Examples.NHibernate.Web.Models;
using PureDataAccessor.Examples.Models;
using PureDataAccessor.UnitOfWork;

namespace PureDataAccessor.Examples.NHibernate.Web.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var companyRepo = _unitOfWork.GetRepository<Company>();
            var companies = companyRepo.GetAll();
            return Ok(companies);
        }

    }
}