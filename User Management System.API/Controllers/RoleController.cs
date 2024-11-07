using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Management_System.Data.Contracts;
using User_Management_System.Entities.User;

namespace User_Management_System.API.Controllers
{
    [Route("Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IGenericRepository<Role> _repository;

        public RoleController(IGenericRepository<Role> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(_repository.GetAll());
        }
    }
}
