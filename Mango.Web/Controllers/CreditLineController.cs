using System;
using System.Threading.Tasks;
using AutoMapper;
using Mango.Application.CreditLineService;
using Mango.Attributes;
using Mango.Extensions;
using Mango.Core;
using Mango.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mango.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditLineController : ControllerBase
    {
        private readonly ILogger<CreditLineController> _logger;
        private readonly IMapper _mapper;
        private readonly ICreditLineService _creditLineService;

        public CreditLineController(ILogger<CreditLineController> logger, IMapper mapper, ICreditLineService creditLineService)
        {
            _logger = logger;
            _mapper = mapper;
            _creditLineService = creditLineService;
        }

        /// <summary>
        /// Method for getting credit lines
        /// </summary>
        /// <param name="id">Credit line id</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/CreditLine/{id}
        ///
        /// </remarks>
        /// <returns>Http response</returns>
        /// <response code="200">Returns if request was valid and there were no errors</response>
        /// <response code="404">Returns if there is no credit line</response>
        /// <response code="500">Returns if got unexpected server error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditLine(Guid id)
        {
            var result = await _creditLineService.GetCreditLine(id);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        /// <summary>
        /// Method for applying credit lines
        /// </summary>
        /// <param name="creditLineRequest">Represents credit line</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/CreditLine
        ///
        /// </remarks>
        /// <returns>Http response</returns>
        /// <response code="200">Returns if request was valid and there were no errors</response>
        /// <response code="400">Returns if request was is invalid</response>
        /// <response code="429">Returns if it are too many requests</response>
        /// <response code="500">Returns if got unexpected server error</response>
        [HttpPost]
        [ServiceFilter(typeof(RequestLimitFilterAttribute))]
        [ProducesResponseType(typeof(ApplyCreditLineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApplyCreditLineResponse>> ApplyCreditLine(ApplyCreditLineRequest creditLineRequest)
        {
            var creditLine = _mapper.Map<CreditLine>(creditLineRequest);
            var result = await _creditLineService.ProcessCreditLine(creditLine, HttpContext.GetRequestIp());
            return Ok(_mapper.Map<ApplyCreditLineResponse>(result));
        }
    }
}