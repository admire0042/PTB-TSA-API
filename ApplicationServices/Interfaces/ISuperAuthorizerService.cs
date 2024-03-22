using ApplicationServices.DTOs;
using Shared.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface ISuperAuthorizerService
    {
        Task<Result> ApproveTsaReport(ApproveBySupperAuthorizerDto model, CancellationToken cancellation);
        Task<Result> RejectTsaReport(RejectedBySupperAuthorizerDto model, CancellationToken cancellation);
    }
}
