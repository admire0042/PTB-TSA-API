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
    public class TSAReportService
    {
        public class InputterService : IInputterService
        {
            private readonly IAppDbContext _appDbContext;
            private readonly ILogger<InputterService> _logger;
            private readonly IValidator<NewTSAReportDto> _validator;

            public InputterService(IAppDbContext appContext, ILogger<InputterService> logger, IValidator<NewTSAReportDto> validator)
            {
                _appDbContext = appContext;
                _logger = logger;
                _validator = validator;
            }
        }
    }
}
