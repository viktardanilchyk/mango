using System;
using System.Threading.Tasks;
using CodingChallenge.Core;

namespace CodingChallenge.Persistence.Repositories
{
    public interface ICreditLineRepository
    {
        Task<CreditLineRequest> CreateAsync(CreditLineRequest entity);
        
        Task<CreditLineRequest> GetAsync(Guid id);
    }
}