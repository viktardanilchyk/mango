using System;
using System.Linq;
using System.Threading.Tasks;
using CodingChallenge.Application.CreditLineService;
using CodingChallenge.Configuration;
using Microsoft.Extensions.Options;

namespace CodingChallenge.Services
{
    public class RequestLimitService : IRequestLimitService
    {
        private readonly ICreditLineService _creditLineService;
        private readonly RequestLimitOptions _options;

        public RequestLimitService(ICreditLineService creditLineService, IOptions<RequestLimitOptions> options)
        {
            _creditLineService = creditLineService;
            _options = options.Value;
        }

        public async Task<string> GetErrorMessage(string ip)
        {
            var latestCreditLine = await _creditLineService.GetLatestCreditLine(ip);

            if (latestCreditLine == null)
            {
                return null;
            }
            
            if (latestCreditLine.IsApproved)
            {
                var creditLines =
                    await _creditLineService.GetApprovedCreditLinesCountWithinMilliseconds(
                        _options.ApprovedRequestLimitInMilliseconds,
                        ip);

                if (creditLines > _options.ApprovedRequestLimitCount)
                {
                    return "Too many requests";
                }
            }
            else
            {
                var currentTime = DateTime.UtcNow;
                if (currentTime.Subtract(latestCreditLine.ProcessDateTime).TotalMilliseconds < _options.DeclinedRequestLimitInMilliseconds)
                {
                    return "Too many requests";
                }

                var latestCreditLines =
                    await _creditLineService.GetLatestCreditLines(ip, _options.DeclinedRequestLimitCount);

                if (latestCreditLines.Count(x => !x.IsApproved) == _options.DeclinedRequestLimitCount)
                {
                    return "A sales agent will contact you";
                }
            }

            return null;
        }
    }
}