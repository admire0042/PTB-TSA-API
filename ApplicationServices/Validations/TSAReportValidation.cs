using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Validations
{
   
    public class TSAReportValidation : AbstractValidator<TSAReport>
    {
        public TSAReportValidation()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.checkerConfig.InitiatorBranch)
                .NotEmpty()
                .WithMessage("{InitiatorBranch} is required.");

            RuleFor(x => x.checkerConfig.StatusCode)
                .NotEmpty()
                .WithMessage("{StatusCode} is required.");
     

            RuleFor(x => x.Channel)
               .NotEmpty()
               .WithMessage("{Channel} is required.")
               .MaximumLength(10)
               .WithMessage("{Channel} has minimum range.");
        }
    }
}
