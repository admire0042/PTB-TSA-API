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
    public class NewTSAReportDtoValidator : AbstractValidator<NewTSAReportDto>
    {
        public NewTSAReportDtoValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.InitiatorBranch)
                .NotEmpty()
                .WithMessage("{InitiatorBranch} is required.");

            RuleFor(x => x.Channel)
               .NotEmpty()
               .WithMessage("{Channel} is required.")
               .MaximumLength(10)
               .WithMessage("{Channel} has minimum range.");

            RuleFor(x => x.Bvn)
                  .MinimumLength(11)
                  .WithMessage("{Bvn} has minimum range of 11.")
                  .MaximumLength(11)
                  .WithMessage("{Bvn} has maximum range 11.");

            RuleFor(x => x.CollectedAmount)
                .NotEmpty()
                .WithMessage("{CollectedAmount} is required.");


           

            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("{CustomerName} is required.");

            RuleFor(x => x.Fee)
               .NotEmpty()
               .WithMessage("{Fee} is required.");

            //RuleFor(x => x.FeedType)
            //    .NotEmpty()
            //    .WithMessage("{FeedType} is required.");

            RuleFor(x => x.MdaCode)
              .NotEmpty()
              .WithMessage("{MdaCode} is required.");

            RuleFor(x => x.MdaName)
                .NotEmpty()
                .WithMessage("{MdaName} is required.");

            RuleFor(x => x.NarrationDescription)
               .NotEmpty()
               .WithMessage("{NarrationDescription} is required.");

            RuleFor(x => x.PsspCode)
                .NotEmpty()
                .WithMessage("{PsspCode} is required.");

            RuleFor(x => x.RemittedAmount)
              .NotEmpty()
              .WithMessage("{RemittedAmount} is required.");

           

            RuleFor(x => x.TsaPcCodename)
               .NotEmpty()
               .WithMessage("{TsaPcCodename} is required.");

            RuleFor(x => x.TsaPcCoderef)
                .NotEmpty()
                .WithMessage("{TsaPcCoderef} is required.");

            RuleFor(x => x.ValueDate)
              .NotEmpty()
              .WithMessage("{ValueDate} is required.");

            RuleFor(x => x.Payer)
                .NotEmpty()
                .WithMessage("{Payer} is required.");

        }
    }
}
