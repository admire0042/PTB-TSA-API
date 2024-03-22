using ApplicationServices.DTOs;
using ApplicationServices.Enum;
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class AuthorizerService : IAuthorizerService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<AuthorizerService> _logger;
        private readonly IValidator<ApproveTSAByAuthorizerDto> _validator;
        private readonly IValidator<RejectTSAByAuthorizerDto> _rejectValidator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthorizerService(IAppDbContext appContext, ILogger<AuthorizerService> logger, IValidator<ApproveTSAByAuthorizerDto> validator, IMapper mapper, IConfiguration configuration, IValidator<RejectTSAByAuthorizerDto> rejectValidator)
        {
            _appDbContext = appContext;
            _logger = logger;
            _validator = validator;
            _mapper = mapper;
            _configuration = configuration;
            _rejectValidator = rejectValidator;
        }



        public async Task<Result> ApproveTsaReport(ApproveTSAByAuthorizerDto model, CancellationToken cancellation)
        {
            _logger.LogInformation("Create TSA Report request initiated...");
            await _validator.ValidateAndThrowAsync(model, cancellation);

            var entityFromDb =  _appDbContext.TSAReports.Where(x => x.Id == model.Id).FirstOrDefault();

           
            if (entityFromDb == null)
            {
                _logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }

            var entity = _mapper.Map(model, entityFromDb);
            var status = await _appDbContext.SaveChangesAsync();

            if (status < 1)
            {
                _logger.LogWarning("Error occurred, could not approve report", 500);
                return Result.Fail("TSA Report not approved.");
            }

            _logger.LogInformation("Successfully Approved TSA Report");
            return Result.Ok("Successfully Approved TSA Report");
        }

        public async Task<Result> RejectTsaReport(RejectTSAByAuthorizerDto model, CancellationToken cancellation)
        {
            _logger.LogInformation("Create TSA Report request initiated...");
            await _rejectValidator.ValidateAndThrowAsync(model, cancellation);

            var entityFromDb = _appDbContext.TSAReports.Where(x => x.Id == model.Id).FirstOrDefault();


            if (entityFromDb == null)
            {
                _logger.LogWarning("TSA report not found", 500);
                return Result.Fail("TSA Report not found.");
            }

            var entity = _mapper.Map(model, entityFromDb);
            var status = await _appDbContext.SaveChangesAsync();

            if (status < 1)
            {
                _logger.LogWarning("Error occurred, could not reject report", 500);
                return Result.Fail("TSA rejection failed.");
            }

            _logger.LogInformation("Successfully Rejected TSA Report");
            return Result.Ok("Successfully Rejected TSA Report");
        }

        public async Task<Result> DeleteProduct(Guid Id)
        {
            _logger.LogInformation("Deleting TSA Report request initiated...");

            var entityFromDb = await _appDbContext.TSAReports.FirstOrDefaultAsync(x => x.Id == Id);

            //var newReport = TSAReport.Create(entity);
            if (entityFromDb == null)
            {
                _logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }
            entityFromDb.IsDeleted = true;

            _appDbContext.TSAReports.Update(entityFromDb);
            var status = await _appDbContext.SaveChangesAsync();

            if (status < 1)
            {
                _logger.LogWarning("Error occurred, could not delete report", 500);
                return Result.Fail("TSA Report not deleted.");
            }

            _logger.LogInformation("Successfully deleted TSA Report");
            return Result.Ok("Successfully deleted TSA Report");
        }

        public async Task<Result> EditTsaReport(Guid Id, EditTSAReportDto model)
        {
            _logger.LogInformation("Editing TSA Report request initiated...");

            var entityFromDb = await _appDbContext.TSAReports.FirstOrDefaultAsync(x => x.Id == Id);

            //var newReport = TSAReport.Create(entity);
            if (entityFromDb == null)
            {
                _logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }
            var entity = _mapper.Map<TSAReport>(model);

            _appDbContext.TSAReports.Update(entity);
            var status = await _appDbContext.SaveChangesAsync();

            if (status < 1)
            {
                _logger.LogWarning("Error occurred, could not delete report", 500);
                return Result.Fail("TSA Report not deleted.");
            }

            _logger.LogInformation("Successfully deleted TSA Report");
            return Result.Ok("Successfully deleted TSA Report");
        }
    }
}
