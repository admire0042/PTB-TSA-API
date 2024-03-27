using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PTB_TSA_BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private ITSAReport _tSAReport;
        public GeneralController(ITSAReport tSAReport)
        {
            _tSAReport = tSAReport;
        }

        [HttpGet]
        [Route("GetTSAReport")]
        public async Task<IActionResult> GetTSAByStatusCode([FromQuery] int? pageNum = null, [FromQuery] int? pageSize = null)
        {
            int pageSiz = pageSize ?? 10;
            int pageNumber = pageNum ?? 1;

            var response = await _tSAReport.GetAllTsaReport(pageNumber, pageSiz);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpGet]
        [Route("GetTSAByDate/{fromDate}/{toDate}")]
        public async Task<IActionResult> GetTSAByDateRange(DateTime fromDate, DateTime toDate)
        {
            var response = await _tSAReport.GetTsaReportByDateRange(fromDate, toDate);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpGet]
        [Route("GetTSAByStatusCode")]
        public async Task<IActionResult> GetTSAByStatusCode([FromQuery] string? statusCode = null, [FromQuery] string? branchCode = null)
        {
            var response = await _tSAReport.GetTsaReportByStatusCode(statusCode, branchCode);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpGet]
        [Route("GetTSAByNibbsStatus")]
        public async Task<IActionResult> GetTSAByNibbsStatus([FromQuery] string? nibbsStatus = null)
        {
            var response = await _tSAReport.GetTsaReportByNibbsStatus(nibbsStatus);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpDelete]
        [Route("deleteTSA/{Id}/{deleteBy}")]
        public async Task<IActionResult> DeleteProduct(string Id, string deleteBy)
        {
            var response = await _tSAReport.DeleteProduct(Guid.Parse(Id), deleteBy);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateTSA/{Id}")]
        public async Task<IActionResult> UpdateTSA(string Id, EditTSAReportDto tSAReportDto)
        {
            var response = await _tSAReport.EditTsaReport(Guid.Parse(Id), tSAReportDto);

            if (response != null)
                return Ok(response);
            return NoContent();
        }
    }
}
