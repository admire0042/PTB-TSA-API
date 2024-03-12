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
    public class AuthorizerService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<AuthorizerService> _logger;
        private readonly IValidator<NewTSAReportDto> _validator;

        public AuthorizerService(IAppDbContext appContext, ILogger<AuthorizerService> logger, IValidator<NewTSAReportDto> validator)
        {
            _appDbContext = appContext;
            _logger = logger;
            _validator = validator;
        }
    }
}
