using CodingChallenge.Application.CreditLineCalculator;
using CodingChallenge.Core;

namespace CodingChallenge.Application.CreditLineService
{
    public class CreditLineService
    {
        public void ProcessCreditLine(CreditLine creditLine)
        {
            var creditLineRequest = new CreditLineRequest();
            var recommendedCreditLine = CreditLineFactory
                .GetCreditLineCalculator(creditLine.FoundingType)
                .GetRecommendedCreditLine(creditLine);

            creditLineRequest.CreditLine = creditLine;
            creditLineRequest.IsApproved = recommendedCreditLine >= creditLine.RequestedCreditLine;
        }
    }
}