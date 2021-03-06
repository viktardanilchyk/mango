using System;
using Mango.Core;

namespace Mango.Application.CreditLineCalculator
{
    public class StartupCreditLineCalculator : ICreditLineCalculator
    {
        // One third of the cash balance (3:1 ratio)
        // One fifth of the monthly revenue (5:1 ratio)
        public decimal GetRecommendedCreditLine(CreditLine creditLine)
        {
            var monthlyCreditLine = creditLine.MonthlyRevenue / Constants.MonthlyRevenueRatio;
            var cashBalanceCreditLine = creditLine.CashBalance / Constants.CashBalanceRatio;

            return decimal.Round(Math.Max(monthlyCreditLine, cashBalanceCreditLine), 2);
        }
    }
}