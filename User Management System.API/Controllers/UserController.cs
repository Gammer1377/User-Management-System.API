using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;
using User_Management_System.Entities.DTOs.User;
using User_Management_System.Entities.User;
using User_Management_System.Entities.Validators;

namespace User_Management_System.API.Controllers;

[Route("User")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
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
            return BadRequest();
        return Ok(_repository.GetByID(id));
    }

    [HttpPost]
    public IActionResult AddUser(CreateUpdateUserDTO userDto)
    {
        var user = new User();
        var CV = new CreateUpdateUserDTOValidation();
        user.UserName = userDto.UserName;
        user.Password = userDto.Password;
        user.Email = userDto.Email;
        user.CreateDate = DateTime.Now;
        user.LastUpdateDate = DateTime.Now;
        var validationResult = CV.Validate(userDto);
        if (validationResult.IsValid)
        {
            _repository.Insert(user);
            return Created();
        }

        return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors);
    }

    [HttpDelete(nameof(id))]
    public IActionResult DeleteUser(int id)
    {
        var user=_repository.GetByID(id);
        _repository.DeleteAsync(user);
        return Ok();
    }

    [HttpPut(nameof(id))]
    public IActionResult UpdateUser(int id, CreateUpdateUserDTO updateUserDto)
    {
        var CV = new CreateUpdateUserDTOValidation();
        var validationResult = CV.Validate(updateUserDto);
        var user = _repository.GetByID(id);
        if (user == null) return NotFound();

        if (validationResult.IsValid)
        {
            user.UserName = updateUserDto.UserName;
            user.Password = updateUserDto.Password;
            user.Email = updateUserDto.Email;
            user.LastUpdateDate = DateTime.Now;
            _repository.Update(user);
            return Ok();
        }
        return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors);
    }
}