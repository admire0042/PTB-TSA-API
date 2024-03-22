using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PTB_TSA_BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputterController : ControllerBase
    {
        private IInputterService _inputter;

        public InputterController(IInputterService inputter)
        {
            _inputter = inputter;
        }

        // [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Route("createTSA")]
        public async Task<IActionResult> CreateProduct(NewTSAReportDto newTSAReport, CancellationToken cancellation)
        {
            var response = await _inputter.CreateProduct(newTSAReport, cancellation);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateTSA/{Id}")]
        public async Task<IActionResult> UpdateTSA(string Id,EditTSAReportDto tSAReportDto)
        {
            var response = await _inputter.EditTsaReport(Guid.Parse(Id), tSAReportDto);

            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpDelete]
        [Route("deleteTSA/{Id}")]
        public async Task<IActionResult> DeleteProduct(string Id)
        {
            var response = await _inputter.DeleteProduct(Guid.Parse(Id));

            if (response != null)
                return Ok(response);
            return NoContent();
        }
    }
}
