using ApplicationServices.Const;
using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared.BaseResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApplicationServices.Services
{
    public class InputterService: IInputterService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<InputterService> logger;
        private readonly IValidator<NewTSAReportDto> validator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public InputterService(IAppDbContext appContext, ILogger<InputterService> _logger, IValidator<NewTSAReportDto> _validator, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appContext;
            logger = _logger;
            validator = _validator;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<Result> CreateProduct(NewTSAReportDto model, CancellationToken cancellation)
        {
            logger.LogInformation("Create TSA Report request initiated...");
            await validator.ValidateAndThrowAsync(model, cancellation);
            var cbnCode = _configuration["CbnCode"];
            var feedType = _configuration["FeedType"];
            var cbnAcct = _configuration["cbnAcct"];
            var channel = _configuration["channel"];
            var currency = _configuration["currency"];
            string bankBranchId = cbnCode + CodeFramework.GenerateNumericTransactionCodes(7);
            string bankId = cbnCode;

            var entity = _mapper.Map<TSAReport>(model);

            DateTime startTimeRange1 = DateTime.Today.AddHours(11);
            DateTime endTimeRange1 = DateTime.Today.AddHours(16).AddMinutes(59).AddSeconds(59);
            DateTime startTimeRange2 = DateTime.Today.AddHours(17);
            DateTime endTimeRange2 = DateTime.Today.AddDays(1).AddHours(10).AddMinutes(59).AddSeconds(59);


            DateTime currentTime = DateTime.Now;

            if ((currentTime >= startTimeRange1 && currentTime <= endTimeRange1) ||
                (currentTime >= startTimeRange2 || currentTime <= endTimeRange2))
            {
                if (currentTime >= startTimeRange1 && currentTime <= endTimeRange1)
                    entity.SessionId = 0;
                else
                    entity.SessionId = 1;
            }
            entity.CbnAcct = cbnAcct;
            entity.Channel = channel;
            entity.Currency = currency;

            entity.BankBranchId = bankBranchId;
            entity.BankId = bankId;
            entity.FeedType = feedType;
            entity.InitiatedDate = DateTime.Now;

            await _appDbContext.TSAReports.AddAsync(entity, cancellation);
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
