using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.PlannerCoversDto;
using UniquePlanners.Application.Dto.PlannerDto;

namespace UniquePlanners.Application.Validators
{
    public class PlannerCoversUpsertRequestValidator : AbstractValidator<PlannerCoversUpsertRequest>
    {
        public PlannerCoversUpsertRequestValidator()
        {
            RuleFor(x => x.PlannerId).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("PlannerId must be greater than 0");
            RuleFor(x => x.Cover).NotEmpty().WithMessage("Cover is a required property");
        }
    }
}
