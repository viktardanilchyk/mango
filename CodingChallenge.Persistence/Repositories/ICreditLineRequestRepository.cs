using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingChallenge.Core;

namespace CodingChallenge.Persistence.Repositories
{
    public interface ICreditLineRepository
    {
        Task<CreditLineRequest> CreateAsync(CreditLineRequest entity);
        
        Task<CreditLineRequest> GetAsync(Guid id);
        
        Task<int> GetApprovedCreditLinesCountWithinMilliseconds(int milliseconds, string ip);
        
        Task<CreditLineRequest> GetLatestCreditLine(string ip);
        
        Task<IList<CreditLineRequest>> GetLatestCreditLines(string ip, int limit);
    }
}