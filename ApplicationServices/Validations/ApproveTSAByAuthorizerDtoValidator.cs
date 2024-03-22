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
    public class ApproveTSAByAuthorizerDtoValidator : AbstractValidator<ApproveTSAByAuthorizerDto>
    {
        public ApproveTSAByAuthorizerDtoValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Authorizedby)
                .NotEmpty()
                .WithMessage("{Authorizedby} is required.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{Id} is required.");

            RuleFor(x => x.AuthorizerComment)
                .NotEmpty()
                .WithMessage("{AuthorizerComment} is required.");
        }
    }
}
