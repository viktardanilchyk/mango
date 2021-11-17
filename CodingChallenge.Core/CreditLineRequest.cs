using System;

namespace CodingChallenge.Core
{
    public class CreditLineRequest
    {
        public CreditLine CreditLine { get; set; }
        
        public DateTime ProcessDateTime { get; set; }
        
        public bool IsApproved { get; set; }
    }
}