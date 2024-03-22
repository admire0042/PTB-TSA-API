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
    public class RejectBySuperAuthorizerDtoValidator : AbstractValidator<RejectedBySupperAuthorizerDto>
    {
        public RejectBySuperAuthorizerDtoValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.SuperRejectedby)
                .NotEmpty()
                .WithMessage("{SuperRejectedBy} is required.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{Id} is required.");

            RuleFor(x => x.SuperAuthorizerComment)
                .NotEmpty()
                .WithMessage("{SuperAuthorizerComment} is required.");
        }
    }
}
