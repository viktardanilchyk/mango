using CodingChallenge.Core;

namespace CodingChallenge.Application.CreditLineCalculator
{
    public interface ICreditLineCalculator
    {
        decimal GetRecommendedCreditLine(CreditLine creditLine);
    }
}