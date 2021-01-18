# Pure Data Accessor

The "PureDataAccessor" is a data accesing library which only needs a connection and entity modelling structure for all CRUD operation supports on EF and NHibernate. PDA has UOW and Generic Repository patterns. You can manage your data access only with it.

### Implementation
- You can add PureDataAccessor to your project on Nuget packages.
- Modelling : Your entity models should be created from PDA entity like that:
	public class User : Entity
	{
	 public string Name {get; set;}
	}
- Startup.cs -> 
implementation examples : 
1-)Use custom DBcontext
	- example 1 ->Use default PDAconnectionstring: You should add "PDAConnectionString" to your appconfig -> connection strings
			services.AddEFPureDataAccessor<ExampleContext<User>>(_configuration);
	- example 2 ->Use custom named connectionString:
			services.AddEFPureDataAccessor<ExampleContext<User>>(_configuration,"connectionStringName");
	- example 3 ->Use connection string directly
			services.AddEFPureDataAccessor<ExampleContext<User>>("Server=servername;Database=dbname;Trusted_Connection=True;");
2-)Use default PDAContext
	- example 1 ->Use default PDAconnectionstring: You should add "PDAConnectionString" to your appconfig -> connection strings
			services.AddEFPureDataAccessor<PDAContext<User>>(_configuration);
	- example 2 ->Use custom named connectionString:
			services.AddEFPureDataAccessor<PDAContext<User>>(_configuration,"connectionStringName");
	- example 3 ->Use connection string directly
			services.AddEFPureDataAccessor<PDAContext<User>>("Server=servername;Database=dbname;Trusted_Connection=True;");
- Ready to use!

### Using on business layer

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

