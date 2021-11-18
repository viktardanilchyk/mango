using System;

namespace Mango.Core
{
    public class CreditLine
    {
        public Guid Id { get; set; }

        // Business type
        public FoundingType FoundingType { get; set; }
        
        // The customer's bank account balance
        public decimal CashBalance { get; set; }
        
        // The total sales revenue for the month
        public decimal MonthlyRevenue { get; set; }
        
        public int RequestedCreditLine { get; set; }
        
        // Represents when request was made
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
    }
}