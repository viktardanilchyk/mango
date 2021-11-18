using AutoMapper;
using Mango.Core;
using Mango.ViewModels;

namespace Mango.Profiles
{
    public class CreditLineProfile : Profile
    {
        public CreditLineProfile()
        {
            CreateMap<ApplyCreditLineRequest, CreditLine>(MemberList.Destination);
            CreateMap<CreditLineRequest, ApplyCreditLineResponse>(MemberList.Destination);
        }
    }
}