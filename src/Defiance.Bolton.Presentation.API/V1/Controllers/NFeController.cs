using Defiance.Bolton.Domain.Aggregates;
using Defiance.Bolton.Domain.Interfaces.Services;
using Defiance.Bolton.Presentation.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Defiance.Bolton.Presentation.API.V1.Controllers
{
    [ApiController, ApiVersion("1.0"), Route("v{version:apiVersion}/[controller]")]
    public class NFeController : BaseController
    {
        private readonly IEletronicTaxInvoiceAppService _eletronicTaxInvoiceAppService;

        public NFeController(IEletronicTaxInvoiceAppService eletronicTaxInvoiceAppService)
        {
            _eletronicTaxInvoiceAppService = eletronicTaxInvoiceAppService;
        }

        [HttpGet("{accessKey}")]
        [SwaggerOperation(Summary = "Get NFe by accessKey")]
        [SwaggerResponse(200, "Success, response object NFe", typeof(NFe))]
        public async Task<IActionResult> GetNFeByAccessKey(string accessKey)
        {
            if (string.IsNullOrEmpty(accessKey))
                return BadRequest();

            try
            {
                var response = await _eletronicTaxInvoiceAppService.GetByAccessKeyAsync(accessKey);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
