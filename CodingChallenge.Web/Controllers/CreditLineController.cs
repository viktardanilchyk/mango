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
        public async Task<IActionResult> ApplyCreditLine(ApplyCreditLineRequest creditLineRequest)
        {
            var ip = HttpContext.GetRequestIp();
            var creditLine = _mapper.Map<CreditLine>(creditLineRequest);
            var result = await _creditLineService.ProcessCreditLine(creditLine);
            return Ok(result);
        }
    }
}