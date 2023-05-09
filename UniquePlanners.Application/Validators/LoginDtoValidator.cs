using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.UserDto;

namespace UniquePlanners.Application.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(4).WithMessage("Username's minimum length is 4");

            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must containt at least 5 characters");
        }
    }
}
