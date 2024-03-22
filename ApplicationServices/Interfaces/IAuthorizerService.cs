using ApplicationServices.DTOs;
using Shared.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IAuthorizerService
    {
        Task<Result> ApproveTsaReport(ApproveTSAByAuthorizerDto model, CancellationToken cancellation);
        Task<Result> RejectTsaReport(RejectTSAByAuthorizerDto model, CancellationToken cancellation);
    }
}
