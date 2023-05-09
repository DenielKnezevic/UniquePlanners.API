using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.UserDto;
using UniquePlanners.Application.Services.UserService.Dto;

namespace UniquePlanners.Application.Validators
{
    public class UserUpdatetRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdatetRequestValidator()
        {
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password's minimum length is 2");
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\+\d+$").WithMessage("Phone number must start with a + (ie. +300000000");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is a required property");
        }
    }
}
