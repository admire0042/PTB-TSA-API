using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class SuperAuthorizerService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<SuperAuthorizerService> _logger;
        private readonly IValidator<NewTSAReportDto> _validator;

        public SuperAuthorizerService(IAppDbContext appContext, ILogger<SuperAuthorizerService> logger, IValidator<NewTSAReportDto> validator)
        {
            _appDbContext = appContext;
            _logger = logger;
            _validator = validator;
        }
    }
}
