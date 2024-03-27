using ApplicationServices.DTOs;
using Shared.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface ITSAReport
    {
        Task<Result> GetTsaReportByDateRange(DateTime fromDate, DateTime toDate);
        Task<Result> GetTsaReportByStatusCode(string statusCode, string branchCode);
        Task<Result> GetAllTsaReport(int pageNum, int pageSize);
        Task<Result> GetTsaReportByNibbsStatus(string nibbsStatus);
        Task<Result> DeleteProduct(Guid Id, string deleteBy);
        Task<Result> EditTsaReport(Guid Id, EditTSAReportDto model);
    }
}
