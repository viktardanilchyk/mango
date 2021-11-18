using System.Threading.Tasks;

namespace CodingChallenge.Services
{
    public interface IRequestLimitService
    {
        Task<string> GetErrorMessage(string ip);
    }
}