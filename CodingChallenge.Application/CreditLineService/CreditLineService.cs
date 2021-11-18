using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingChallenge.Application.CreditLineCalculator;
using CodingChallenge.Core;
using CodingChallenge.Persistence.Repositories;

namespace CodingChallenge.Application.CreditLineService
{
    public class CreditLineService : ICreditLineService
    {
        private readonly ICreditLineRepository _repository;

        public CreditLineService(ICreditLineRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreditLineRequest> ProcessCreditLine(CreditLine creditLine, string ip)
        {
            var creditLineRequest = new CreditLineRequest();
            var recommendedCreditLine = CreditLineFactory
                .GetCreditLineCalculator(creditLine.FoundingType)
                .GetRecommendedCreditLine(creditLine);

            creditLineRequest.CreditLine = creditLine;
            creditLineRequest.IsApproved = recommendedCreditLine >= creditLine.RequestedCreditLine;
            creditLineRequest.ClientIp = ip;
            creditLineRequest.ProcessDateTime = DateTime.UtcNow;

            await _repository.CreateAsync(creditLineRequest);

            return creditLineRequest;
        }

        public Task<CreditLineRequest> GetCreditLine(Guid id)
        {
            return _repository.GetAsync(id);
        }
        
        public Task<int> GetApprovedCreditLinesCountWithinMilliseconds(int milliseconds, string ip)
        {
            return _repository.GetApprovedCreditLinesCountWithinMilliseconds(milliseconds, ip);
        }

        public Task<CreditLineRequest> GetLatestCreditLine(string ip)
        {
            return _repository.GetLatestCreditLine(ip);
        }

        public Task<IList<CreditLineRequest>> GetLatestCreditLines(string ip, int limit)
        {
            return _repository.GetLatestCreditLines(ip, limit);
        }
    }
}