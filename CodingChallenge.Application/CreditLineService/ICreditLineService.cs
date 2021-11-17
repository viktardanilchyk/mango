using System;
using System.Threading.Tasks;
using CodingChallenge.Core;

namespace CodingChallenge.Application.CreditLineService
{
    public interface ICreditLineService
    {
        Task<CreditLineRequest> ProcessCreditLine(CreditLine creditLine);
        Task<CreditLineRequest> GetCreditLine(Guid id);
    }
}