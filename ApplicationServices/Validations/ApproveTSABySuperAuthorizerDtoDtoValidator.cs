using ApplicationServices.DTOs;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Validations
{
    public class ApproveTSABySuperAuthorizerDtoDtoValidator : AbstractValidator<ApproveBySupperAuthorizerDto>
    {
        public ApproveTSABySuperAuthorizerDtoDtoValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.SuperAuthorizerComment)
                 .NotEmpty()
                 .WithMessage("{SuperAuthorizerComment} is required.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{Id} is required.");

            RuleFor(x => x.SuperAuthorizedby)
                .NotEmpty()
                .WithMessage("{SuperAuthorizedby} is required.");
        }
    }
}
