using CodingChallenge.Application.CreditLineCalculator;
using CodingChallenge.Core;
using NUnit.Framework;

namespace CodingChallenge.Tests
{
    public class StartupCreditLineCalculatorTests
    {
        private ICreditLineCalculator _calculator;
        
        [SetUp]
        public void Setup()
        {
            _calculator = new StartupCreditLineCalculator();
        }

        [TestCase(0, 0, 0)]
        [TestCase(1000.0, 100.0, 333.33)]
        [TestCase(34.0, 87.0, 17.40)]
        [TestCase(11290.0, 11.0, 3763.33)]
        [TestCase(100.0, 11290.0, 2258.00)]
        public void GetRecommendedCreditLine_ReturnsRecommendedValue(decimal cashBalance, decimal monthlyPayment, decimal expected)
        {
            var creditLine = new CreditLine
            {
                CashBalance = cashBalance,
                MonthlyRevenue = monthlyPayment
            };

            var result = _calculator.GetRecommendedCreditLine(creditLine);

            Assert.AreEqual(expected, result);
        }
    }
}