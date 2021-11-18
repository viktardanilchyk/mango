using Mango.Core;

namespace Mango.Application.CreditLineCalculator
{
    public interface ICreditLineCalculator
    {
        decimal GetRecommendedCreditLine(CreditLine creditLine);
    }
}