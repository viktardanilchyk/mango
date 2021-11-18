using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Core;

namespace Mango.Application.CreditLineService
{
    public interface ICreditLineService
    {
        Task<CreditLineRequest> ProcessCreditLine(CreditLine creditLine, string ip);
        
        Task<CreditLineRequest> GetCreditLine(Guid id);
        
        Task<int> GetApprovedCreditLinesCountWithinMilliseconds(int milliseconds, string ip);
        
        Task<CreditLineRequest> GetLatestCreditLine(string ip);
        
        Task<IList<CreditLineRequest>> GetLatestCreditLines(string ip, int limit);
    }
}