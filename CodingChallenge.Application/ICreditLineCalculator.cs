using CodingChallenge.Core;

namespace CodingChallenge.Application
{
    public interface ICreditLineCalculator
    {
        decimal GetRecommendedCreditLine(CreditLine creditLine);
    }
}