using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.PlannerDto;

namespace UniquePlanners.Application.Validators
{
    public class PlannerUpsertRequestValidator : AbstractValidator<PlannerUpsertRequest>
    {
        public PlannerUpsertRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("UserId must be greater than 0");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is a required property");
            RuleFor(x => x.Price).NotNull().GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
