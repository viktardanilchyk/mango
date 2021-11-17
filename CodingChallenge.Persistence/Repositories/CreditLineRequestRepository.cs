using System;
using System.Linq;
using System.Threading.Tasks;
using CodingChallenge.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodingChallenge.Persistence.Repositories
{
    public class CreditLineRequestRepository : ICreditLineRepository
    {
        private readonly CreditLineDbContext _context;
        
        private readonly ILogger<CreditLineRequestRepository> _logger;

        public CreditLineRequestRepository(CreditLineDbContext context, ILogger<CreditLineRequestRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public virtual async Task<CreditLineRequest> CreateAsync(CreditLineRequest entity)
        {
            try
            {
                await _context.CreditLineRequests.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }
        
        public virtual async Task<CreditLineRequest> GetAsync(Guid id)
        {
            try
            {
                var creditLineRequest = await _context
                    .CreditLineRequests
                    .Where(x => x.Id == id)
                    .Include(x => x.CreditLine)
                    .FirstOrDefaultAsync();
                

                return creditLineRequest;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }
    }
}