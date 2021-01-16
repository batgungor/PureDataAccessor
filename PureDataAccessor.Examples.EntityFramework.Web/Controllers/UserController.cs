using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Examples.Models;
using PureDataAccessor.Examples.Models.ViewModels;
using PureDataAccessor.UnitOfWork;

namespace PureDataAccessor.Examples.EntityFramework.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : PureDataAccessor.Examples.Base.Controllers.UserController
    {
        public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}