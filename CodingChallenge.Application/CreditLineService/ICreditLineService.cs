using System;
using System.Threading.Tasks;
using CodingChallenge.Core;

namespace CodingChallenge.Application.CreditLineService
{
    public interface ICreditLineService
    {
        Task<CreditLineRequest> ProcessCreditLine(CreditLine creditLine, string ip);
        Task<CreditLineRequest> GetCreditLine(Guid id);
    }
}