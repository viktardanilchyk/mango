using Mango.Core;

namespace Mango.ViewModels
{
    public class ApplyCreditLineRequest
    {
        public FoundingType FoundingType { get; set; }
        
        public decimal CashBalance { get; set; }
        
        public decimal MonthlyRevenue { get; set; }
        
        public int RequestedCreditLine { get; set; }
    }
}