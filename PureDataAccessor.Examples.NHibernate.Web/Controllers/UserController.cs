using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PureDataAccessor.Examples.Models;
using PureDataAccessor.UnitOfWork;

namespace PureDataAccessor.Examples.NHibernate.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : PureDataAccessor.Examples.Base.Controllers.UserController
    {
        public UserController(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}