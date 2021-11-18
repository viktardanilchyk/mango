using Mango.Core;

namespace Mango.Application.CreditLineCalculator
{
    public class SMECreditLineCalculator : ICreditLineCalculator
    {
        // One fifth of the monthly revenue (5:1 ratio)
        public decimal GetRecommendedCreditLine(CreditLine creditLine)
        {
            return decimal.Round(creditLine.MonthlyRevenue / Constants.MonthlyRevenueRatio);
        }
    }
}