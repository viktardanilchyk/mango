using AutoMapper;
using CodingChallenge.Core;
using CodingChallenge.ViewModels;

namespace CodingChallenge.Profiles
{
    public class CreditLineProfile : Profile
    {
        public CreditLineProfile()
        {
            CreateMap<ApplyCreditLineRequest, CreditLine>(MemberList.Destination);
        }
    }
}