using System;
using CodingChallenge.Core;

namespace CodingChallenge.Application.CreditLineCalculator
{
    public static class CreditLineFactory
    {
        public static ICreditLineCalculator GetCreditLineCalculator(FoundingType type)
        {
            return type switch
            {
                FoundingType.Startup => new StartupCreditLineCalculator(),
                FoundingType.SME => new SMECreditLineCalculator(),
                _ => throw new Exception()
            };
        }
    }
}