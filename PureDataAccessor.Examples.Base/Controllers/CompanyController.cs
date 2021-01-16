using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PureDataAccessor.Examples.Models;
using PureDataAccessor.Examples.Models.ViewModels;
using PureDataAccessor.UnitOfWork;

namespace PureDataAccessor.Examples.Base.Controllers
{
    public class CompanyController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var companyRepo = _unitOfWork.GetRepository<Company>();
            var company = companyRepo.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CompanyModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors)
                                              .Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            var companyRepo = _unitOfWork.GetRepository<Company>();
            var company = new Company()
            {
                Name = model.Name
            };
            companyRepo.Add(company);
            _unitOfWork.SaveChanges();
            return Ok(company);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CompanyModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors)
                                              .Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            var companyRepo = _unitOfWork.GetRepository<Company>();
            var company = companyRepo.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            company.Name = model.Name;
            companyRepo.Update(company);
            _unitOfWork.SaveChanges();
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var companyRepo = _unitOfWork.GetRepository<Company>();
            var company = companyRepo.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            companyRepo.Delete(id);
            _unitOfWork.SaveChanges();
            return Ok("Company Deleted");
        }
    }
}