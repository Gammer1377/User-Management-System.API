using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Management_System.Data.Contracts;
using User_Management_System.Data.Repositories;
using User_Management_System.Entities.DTOs.User;
using User_Management_System.Entities.User;

namespace User_Management_System.API.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
       IGenericRepository<User> _repository;

       public UserController(IGenericRepository<User> repository)
       {
           _repository = repository;
       }
       [HttpGet]
        public  IActionResult GetUsers()
        {
            var Result = _repository.GetAll();
            return Ok(Result);
        }

    }
}
