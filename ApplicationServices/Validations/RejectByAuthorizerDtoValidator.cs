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
    public class RejectByAuthorizerDtoValidator : AbstractValidator<RejectTSAByAuthorizerDto>
    {
        public RejectByAuthorizerDtoValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Rejectedby)
                .NotEmpty()
                .WithMessage("{Rejectedby} is required.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{Id} is required.");

            RuleFor(x => x.AuthorizerComment)
                .NotEmpty()
                .WithMessage("{AuthorizerComment} is required.");
        }
    }
}
