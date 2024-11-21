using FluentValidation;
using User_Management_System.Entities.DTOs.User;

namespace User_Management_System.Entities.Validators;

public class CreateUpdateRoleDTOValidation : AbstractValidator<CreateUpdateRoleDTO>
{
    public CreateUpdateRoleDTOValidation()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Please Eneter Role Nmae");
    }
}