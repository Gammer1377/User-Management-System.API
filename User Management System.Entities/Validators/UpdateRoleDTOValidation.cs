﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using User_Management_System.Entities.DTOs.User;

namespace User_Management_System.Entities.Validators
{
    public class UpdateRoleDTOValidation:AbstractValidator<UpdateRoleDTO>
    {
        public UpdateRoleDTOValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Please Enter Role Nmae");
        }
    }
}
