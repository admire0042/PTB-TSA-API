using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared.BaseResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class InputterService: IInputterService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<InputterService> logger;
        private readonly IValidator<NewTSAReportDto> validator; 

        public InputterService(IAppDbContext appContext, ILogger<InputterService> _logger, IValidator<NewTSAReportDto> _validator)
        {
            _appDbContext= appContext;
            logger = _logger;
            validator = _validator;
        }


        public async Task<Result> CreateProduct(NewTSAReportDto model, CancellationToken cancellation)
        {
            logger.LogInformation("Create TSA Report request initiated...");
            await validator.ValidateAndThrowAsync(model, cancellation);

            var newReport = TSAReport.Create(model);

            await _appDbContext.TSAReports.AddAsync(newReport, cancellation);
            var status = await _appDbContext.SaveChangesAsync(cancellation);

            if (status < 1)
            {
                logger.LogWarning("Error occurred, could not create report", 500);
                return Result.Fail("TSA Report not created.");
            }

            logger.LogInformation("Successfully created TSA Report");
            return Result.Ok("Successfully created TSA Report");
        }
    }

   

}
