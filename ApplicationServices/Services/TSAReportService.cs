using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class TSAReportService : ITSAReport
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<TSAReportService> logger;
        private readonly IValidator<NewTSAReportDto> validator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TSAReportService(IAppDbContext appDbContext, ILogger<TSAReportService> logger, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            this.logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<Result> GetAllTsaReport(int pageNum, int pageSize)
        {
            int skip = (pageNum - 1) * pageSize;
            var query = _appDbContext.TSAReports.AsNoTracking()
            .OrderByDescending(c => c.DateAdded).Skip(skip)
            .Take(pageSize)
            .ToList();

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

        public async Task<Result> GetTsaReportByStatusCode(string statusCode, string branchCode)
        {
            var query = _appDbContext.TSAReports.AsNoTracking()
            .Where(c => c.StatusCode.Contains(statusCode)|| c.StatusCode.Contains(branchCode))
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

        public async Task<Result> GetTsaReportByNibbsStatus(string nibbsStatus)
        {
            var query = _appDbContext.TSAReports.AsNoTracking()
            .Where(c => c.NibbsStatus.Contains(nibbsStatus))
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

        public async Task<Result> DeleteProduct(Guid Id, string deleteBy)
        {
            logger.LogInformation("Deleting TSA Report request initiated...");

            var entityFromDb = await _appDbContext.TSAReports.FirstOrDefaultAsync(x => x.Id == Id);

            //var newReport = TSAReport.Create(entity);
            if (entityFromDb == null)
            {
                logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }
            entityFromDb.IsDeleted = true;
            entityFromDb.DeletedBy = deleteBy;
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
    }
}
