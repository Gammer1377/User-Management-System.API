using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Management_System.Data.Context;
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
        public UserController(IGenericRepository<User> repository, ApplicationDbContext context)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet(nameof(id))]
        public IActionResult GetUserById(int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_repository.GetByID(id));
            }
        }

        [HttpPost]
        public void AddUser(CreateUserDTO userDto)
        {
            Entities.User.User user = new Entities.User.User();
            user.UserName = userDto.UserName;
            user.Password = userDto.Password;
            user.Email = userDto.Email;
            user.CreateDate = DateTime.Now;
            user.LastUpdateDate = DateTime.Now;
            _repository.Insert(user);
        }

        [HttpDelete(nameof(id))]
        public IActionResult DeleteUser(int id)
        {
           _repository.Delete(id);
            return Ok();
        }

        [HttpPut(nameof(id))]
        public IActionResult UpdateUser(int id, UpdateUserDTO updateUserDto)
        {
            var user = _repository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.UserName = updateUserDto.UserName;
                user.Password = updateUserDto.Password;
                user.Email = updateUserDto.Email;
                user.LastUpdateDate = DateTime.Now;
                _repository.Update(user);
                return Ok();
            }
        }

    }
}
