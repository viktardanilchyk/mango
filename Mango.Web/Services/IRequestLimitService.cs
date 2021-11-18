using System.Threading.Tasks;

namespace Mango.Services
{
    public interface IRequestLimitService
    {
        Task<string> GetErrorMessage(string ip);
    }
}