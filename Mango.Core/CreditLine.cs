using System;

namespace Mango.Core
{
    public class CreditLine
    {
        public Guid Id { get; set; }

        public FoundingType FoundingType { get; set; }
        
        public decimal CashBalance { get; set; }
        
        public decimal MonthlyRevenue { get; set; }
        
        public int RequestedCreditLine { get; set; }
        
        public DateTime RequestedDate { get; set; }
    }
}