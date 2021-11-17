using CodingChallenge.Core;

namespace CodingChallenge.Application.CreditLineCalculator
{
    public class SMECreditLineCalculator : ICreditLineCalculator
    {
        // One fifth of the monthly revenue (5:1 ratio)
        public decimal GetRecommendedCreditLine(CreditLine creditLine)
        {
            return creditLine.MonthlyRevenue / Constants.MonthlyRevenueRatio;
        }
    }
}