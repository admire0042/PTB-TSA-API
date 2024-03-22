using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PTB_TSA_BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAuthorizerController : ControllerBase
    {
        private ISuperAuthorizerService _authorizer;

        public SuperAuthorizerController(ISuperAuthorizerService authorizer)
        {
            _authorizer = authorizer;
        }

        [HttpPut]
        [Route("ApproveTSA")]
        public async Task<IActionResult> ApproveTSA(ApproveBySupperAuthorizerDto tSAReportDto, CancellationToken cancellationToken)
        {
            var response = await _authorizer.ApproveTsaReport(tSAReportDto, cancellationToken);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpPut]
        [Route("RejectTSA")]
        public async Task<IActionResult> RejectTSA(RejectedBySupperAuthorizerDto tSAReportDto, CancellationToken cancellationToken)
        {
            var response = await _authorizer.RejectTsaReport(tSAReportDto, cancellationToken);

            if (response != null)
                return Ok(response);
            return NoContent();
        }
    }
}
