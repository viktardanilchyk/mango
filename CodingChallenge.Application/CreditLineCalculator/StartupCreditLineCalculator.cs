using System;
using CodingChallenge.Core;

namespace CodingChallenge.Application.CreditLineCalculator
{
    public class StartupCreditLineCalculator : ICreditLineCalculator
    {
        // One third of the cash balance (3:1 ratio)
        // One fifth of the monthly revenue (5:1 ratio)
        public decimal GetRecommendedCreditLine(CreditLine creditLine)
        {
            var monthlyCreditLine = creditLine.MonthlyRevenue / Constants.MonthlyRevenueRatio;
            var cashBalanceCreditLine = creditLine.CashBalance / Constants.CashBalanceRatio;

            return Math.Max(monthlyCreditLine, cashBalanceCreditLine);
        }
    }
}