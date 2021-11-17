using System;
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

            await _repository.CreateAsync(creditLineRequest);

            return creditLineRequest;
        }

        public Task<CreditLineRequest> GetCreditLine(Guid id)
        {
            return _repository.GetAsync(id);
        }
    }
}