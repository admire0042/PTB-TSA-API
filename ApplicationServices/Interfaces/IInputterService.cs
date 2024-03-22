using ApplicationServices.DTOs;
using Shared.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IInputterService
    {
        Task<Result> CreateProduct(NewTSAReportDto model, CancellationToken cancellation);
        Task<Result> EditTsaReport(Guid Id, EditTSAReportDto model);
        Task<Result> DeleteProduct(Guid Id);
    }
}
