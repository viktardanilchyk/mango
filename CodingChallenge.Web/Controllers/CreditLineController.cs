using System.Threading.Tasks;
using AutoMapper;
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

        public CreditLineController(ILogger<CreditLineController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCreditLine(ApplyCreditLineRequest creditLineRequest)
        {
            var ip = HttpContext.GetRequestIp();
            var creditLine = _mapper.Map<CreditLine>(creditLineRequest);
            return Ok();
        }
    }
}