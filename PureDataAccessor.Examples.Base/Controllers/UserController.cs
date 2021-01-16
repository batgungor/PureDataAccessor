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
    public class UserController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var users = userRepo.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = userRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors)
                                              .Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = new User()
            {
                Name = model.Name,
                Surname = model.Surname,
                CompanyId = model.CompanyId
            };
            userRepo.Add(user);
            _unitOfWork.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors)
                                              .Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = userRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = model.Name;
            user.Surname = model.Surname;
            userRepo.Update(user);
            _unitOfWork.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = userRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            userRepo.Delete(id);
            _unitOfWork.SaveChanges();
            return Ok("User Deleted");
        }
    }
}