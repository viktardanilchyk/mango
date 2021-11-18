using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Mango.Persistence.Repositories
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
        
        public virtual async Task<int> GetApprovedCreditLinesCountWithinMilliseconds(int milliseconds, string ip)
        {
            try
            {
                var currentTime = DateTime.UtcNow;
                
                var creditLineRequest = await _context
                    .CreditLineRequests
                    .OrderByDescending(x => x.ProcessDateTime)
                    .Where(x => x.ClientIp == ip)
                    .Where(x => x.IsApproved)
                    .Where(x => currentTime.Subtract(x.ProcessDateTime).TotalMilliseconds < milliseconds)
                    .CountAsync();

                return creditLineRequest;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }
        
        public virtual async Task<CreditLineRequest> GetLatestCreditLine(string ip)
        {
            try
            {
                var creditLineRequest = await _context
                    .CreditLineRequests
                    .OrderByDescending(x => x.ProcessDateTime)
                    .Where(x => x.ClientIp == ip)
                    .FirstOrDefaultAsync();

                return creditLineRequest;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }
        
        public virtual async Task<IList<CreditLineRequest>> GetLatestCreditLines(string ip, int limit)
        {
            try
            {
                var creditLineRequests = await _context
                    .CreditLineRequests
                    .OrderByDescending(x => x.ProcessDateTime)
                    .Where(x => x.ClientIp == ip)
                    .Take(limit)
                    .ToListAsync();

                return creditLineRequests;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }
    }
}