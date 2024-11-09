using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;
using User_Management_System.Entities.DTOs.User;
using User_Management_System.Entities.User;
using User_Management_System.Entities.Validators;

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

        [HttpGet(nameof(id))]
        public IActionResult GetRoleById(int id)
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
        public IActionResult AddRole(CreateRoleDTO roleDto)
        {
            Entities.User.Role Role = new Entities.User.Role();
            CreateRoleDTOValidation CV = new CreateRoleDTOValidation();
            Role.Name=roleDto.Name;
            Role.CreateDate=DateTime.Now;
            Role.LastUpdateDate=DateTime.Now;
            var validationResult = CV.Validate(roleDto);
            if (validationResult.IsValid)
            {
                _repository.Insert(Role);
                return Created();
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors);
            }
        }
        [HttpDelete(nameof(id))]
        public IActionResult DeleteRole(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRole(int id, UpdateRoleDTO updateRoleDto)
        {
            UpdateRoleDTOValidation CV = new UpdateRoleDTOValidation();
            var validationResult = CV.Validate(updateRoleDto);
            var role = _repository.GetByID(id);
            if (role == null)
            {
                return NotFound();
            }
            else if (validationResult.IsValid)
            {
                role.Name = updateRoleDto.Name;
                role.LastUpdateDate = DateTime.Now;
                _repository.Update(role);
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors);
            }
        }
    }
}
