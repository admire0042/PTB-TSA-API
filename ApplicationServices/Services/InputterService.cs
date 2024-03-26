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
            string uniqueReference = "SYS"+CodeFramework.GenerateNumericTransactionCodes(17);
            string batchId = "SYS" + CodeFramework.GenerateNumericTransactionCodes(17);
            string bankBranchId = cbnCode + CodeFramework.GenerateNumericTransactionCodes(7);
            string bankId = cbnCode;

            var entity = _mapper.Map<TSAReport>(model);

            //var newReport = TSAReport.Create(entity);
            entity.UniqueReference = uniqueReference;
            entity.BatchId = batchId;
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


        public async Task<Result> DeleteProduct(Guid Id)
        {
            logger.LogInformation("Deleting TSA Report request initiated...");
          
            var entityFromDb = await _appDbContext.TSAReports.FirstOrDefaultAsync(x => x.Id == Id);

            //var newReport = TSAReport.Create(entity);
            if(entityFromDb == null)
            {
                logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }
            entityFromDb.IsDeleted = true;

             _appDbContext.TSAReports.Update(entityFromDb);
            var status = await _appDbContext.SaveChangesAsync();

            if (status < 1)
            {
                logger.LogWarning("Error occurred, could not delete report", 500);
                return Result.Fail("TSA Report not deleted.");
            }

            logger.LogInformation("Successfully deleted TSA Report");
            return Result.Ok("Successfully deleted TSA Report");
        }

        public async Task<Result> EditTsaReport(Guid Id, EditTSAReportDto model)
        {
            logger.LogInformation("Editing TSA Report request initiated...");

            var entityFromDb = await _appDbContext.TSAReports.FirstOrDefaultAsync(x => x.Id == Id);

            //var newReport = TSAReport.Create(entity);
            if (entityFromDb == null)
            {
                logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }
            var entity = _mapper.Map<TSAReport>(model);

            _appDbContext.TSAReports.Update(entity);
            var status = await _appDbContext.SaveChangesAsync();

            if (status < 1)
            {
                logger.LogWarning("Error occurred, could not delete report", 500);
                return Result.Fail("TSA Report not deleted.");
            }

            logger.LogInformation("Successfully deleted TSA Report");
            return Result.Ok("Successfully deleted TSA Report");
        }

        public async Task<Result> GetTsaReportByDateRange(DateTime fromDate, DateTime toDate)
        {
            var dd = fromDate.Date;
            var query = _appDbContext.TSAReports.AsNoTracking()
            .Where(c => !c.IsDeleted && c.DateAdded.Date >= fromDate.Date && c.DateAdded.Date <= toDate.Date)
            .OrderByDescending(c => c.DateAdded).ToList();

            var entity = _mapper.Map<List<GetTSADto>>(query);
            //var newReport = TSAReport.Create(entity);
            if (entity.Count == 0)
            {
                logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }

            logger.LogInformation("Successfully retrieved TSA Report");
            return Result.Ok(entity, "Successfully retrieved TSA Report");
        }

        public async Task<Result> GetTsaReportByStatusCode(string statusCode)
        {
            var query = _appDbContext.TSAReports.AsNoTracking()
            .Where(c => statusCode.Contains(c.StatusCode))
            .OrderByDescending(c => c.DateAdded).ToList();

            var entity = _mapper.Map<List<GetTSADto>>(query);
            //var newReport = TSAReport.Create(entity);
            if (entity.Count == 0)
            {
                logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }

            logger.LogInformation("Successfully retrieved TSA Report");
            return Result.Ok(entity, "Successfully retrieved TSA Report");
        }
    }

   .

}
