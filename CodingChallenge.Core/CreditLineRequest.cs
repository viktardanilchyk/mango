using System;

namespace CodingChallenge.Core
{
    public class CreditLineRequest
    {
        public Guid Id { get; set; }
        
        public Guid CreditLineId { get; set; }
        
        public virtual CreditLine CreditLine { get; set; }
        
        public DateTime ProcessDateTime { get; set; }
        
        public bool IsApproved { get; set; }
        
        public string ClientIp { get; set; }
    }
}