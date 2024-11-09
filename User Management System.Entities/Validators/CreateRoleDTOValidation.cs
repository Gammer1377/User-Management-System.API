using FluentValidation;
using User_Management_System.Entities.DTOs.User;

namespace User_Management_System.Entities.Validators;

public class CreateRoleDTOValidation : AbstractValidator<CreateRoleDTO>
{
    public CreateRoleDTOValidation()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Please Eneter Role Nmae");
    }
}