using System;
using CodingChallenge.Core;

namespace CodingChallenge.Application
{
    public class CreditLineCalculator : ICreditLineCalculator
    {
        public decimal GetRecommendedCreditLine(CreditLine creditLine)
        {
            if (creditLine.FoundingType == FoundingType.SME)
            {
                return creditLine.MonthlyRevenue / 5;
            }

            if (creditLine.FoundingType == FoundingType.Startup)
            {
                var monthlyCreditLine = creditLine.MonthlyRevenue / 5;
                var cashBalanceCreditLine = creditLine.MonthlyRevenue / 3;

                return Math.Max(monthlyCreditLine, cashBalanceCreditLine);
            }

            return 0;
        }
    }
}