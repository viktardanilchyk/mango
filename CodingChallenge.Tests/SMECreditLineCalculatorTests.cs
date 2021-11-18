using CodingChallenge.Application.CreditLineCalculator;
using CodingChallenge.Core;
using NUnit.Framework;

namespace CodingChallenge.Tests
{
    public class SMECreditLineCalculatorTests
    {
        private ICreditLineCalculator _calculator;
        
        [SetUp]
        public void Setup()
        {
            _calculator = new SMECreditLineCalculator();
        }

        [TestCase(0, 0)]
        [TestCase(100.0, 20.00)]
        [TestCase(87.0, 17.40)]
        [TestCase(11.0, 2.20)]
        [TestCase(11290.0, 2258.00)]
        public void GetRecommendedCreditLine_ReturnsRecommendedValue(decimal monthlyPayment, decimal expected)
        {
            var creditLine = new CreditLine
            {
                MonthlyRevenue = monthlyPayment
            };

            var result = _calculator.GetRecommendedCreditLine(creditLine);

            Assert.AreEqual(expected, result);
        }
    }
}