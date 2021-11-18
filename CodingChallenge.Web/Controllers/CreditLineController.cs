using System;
using System.Threading.Tasks;
using AutoMapper;
using CodingChallenge.Application.CreditLineService;
using CodingChallenge.Core;
using CodingChallenge.Extensions;
using CodingChallenge.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodingChallenge.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditLine(Guid id)
        {
            var result = await _creditLineService.GetCreditLine(id);
            return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(RequestLimitFilterAttribute))]
        public async Task<ActionResult<ApplyCreditLineResponse>> ApplyCreditLine(ApplyCreditLineRequest creditLineRequest)
        {
            var creditLine = _mapper.Map<CreditLine>(creditLineRequest);
            var result = await _creditLineService.ProcessCreditLine(creditLine, HttpContext.GetRequestIp());
            return Ok(new ApplyCreditLineResponse { IsApproved = result.IsApproved });
        }
    }
}