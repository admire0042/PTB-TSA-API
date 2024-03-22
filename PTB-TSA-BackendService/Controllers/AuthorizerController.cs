using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PTB_TSA_BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizerController : ControllerBase
    {
        private IAuthorizerService _authorizer;

        public AuthorizerController(IAuthorizerService authorizer)
        {
            _authorizer = authorizer;
        }

        [HttpPut]
        [Route("ApproveTSA")]
        public async Task<IActionResult> ApproveTSA(ApproveTSAByAuthorizerDto tSAReportDto, CancellationToken cancellationToken)
        {
            var response = await _authorizer.ApproveTsaReport(tSAReportDto, cancellationToken);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpPut]
        [Route("RejectTSA")]
        public async Task<IActionResult> RejectTSA(RejectTSAByAuthorizerDto tSAReportDto, CancellationToken cancellationToken)
        {
            var response = await _authorizer.RejectTsaReport(tSAReportDto, cancellationToken);

            if (response != null)
                return Ok(response);
            return NoContent();
        }
    }
}
