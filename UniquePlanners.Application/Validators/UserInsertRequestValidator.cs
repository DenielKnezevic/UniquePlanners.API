using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.UserDto;

namespace UniquePlanners.Application.Validators
{
    public class UserInsertRequestValidator : AbstractValidator<UserInsertRequest>
    {
        public UserInsertRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2).WithMessage("First name's minimum length is 2");
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(2).WithMessage("Last name's minimum length is 2");
            RuleFor(x => x.Username).NotEmpty().MinimumLength(4).WithMessage("Username's minimum length is 4");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is a required property");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password's minimum length is 2");
            RuleFor(x => x.DayOfBirth).NotNull().Must(x => x < DateTime.Now).WithMessage("Day of birth must be lower than the current date");
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\+\d+$").WithMessage("Phone number must start with a + (ie. +300000000");
        }
    }
}
