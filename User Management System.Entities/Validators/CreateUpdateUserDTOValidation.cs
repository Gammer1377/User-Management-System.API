using FluentValidation;
using User_Management_System.Entities.DTOs.User;

namespace User_Management_System.Entities.Validators;

public class CreateUpdateUserDTOValidation : AbstractValidator<CreateUpdateUserDTO>
{
    public CreateUpdateUserDTOValidation()
    {
        RuleFor(p => p.Email).EmailAddress().WithMessage("Please Enter Valid Email").NotEmpty()
            .WithMessage("Email Address Cant Be Empty");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Please Enter Your Password");
        RuleFor(p => p.UserName).NotEmpty().WithMessage("Please Enter Your Username");
    }
}