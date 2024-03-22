using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using AutoMapper;
using FluentValidation;
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
    public class SuperAuthorizerService: ISuperAuthorizerService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<SuperAuthorizerService> _logger;
        private readonly IValidator<ApproveBySupperAuthorizerDto> _approvevalidator;
        private readonly IValidator<RejectedBySupperAuthorizerDto> _rejectValidator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public SuperAuthorizerService(IAppDbContext appContext, ILogger<SuperAuthorizerService> logger, IValidator<ApproveBySupperAuthorizerDto> approvevalidator, IValidator<RejectedBySupperAuthorizerDto> rejectValidator, IMapper mapper)
        {
            _appDbContext = appContext;
            _logger = logger;
            _approvevalidator = approvevalidator;
            _rejectValidator = rejectValidator;
            _mapper = mapper;
        }

        public async Task<Result> ApproveTsaReport(ApproveBySupperAuthorizerDto model, CancellationToken cancellation)
        {
            _logger.LogInformation("Approve TSA Report by super authorizer request initiated...");
            await _approvevalidator.ValidateAndThrowAsync(model, cancellation);

            var entityFromDb = _appDbContext.TSAReports.Where(x => x.Id == model.Id).FirstOrDefault();

            

            if (entityFromDb == null)
            {
                _logger.LogWarning("TSA not found", 500);
                return Result.Fail("TSA Report not found.");
            }

            var respFromNibbs = "";

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

        public async Task<Result> RejectTsaReport(RejectedBySupperAuthorizerDto model, CancellationToken cancellation)
        {
            _logger.LogInformation("Rejectm TSA Report request initiated...");
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
    }
}
