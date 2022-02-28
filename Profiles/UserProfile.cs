using AutoMapper;
using SportyApi.Models;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.UserDtos;

namespace SportyApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(u => u.Name, a => a.MapFrom(a => $"{a.FirstName} {a.LastName}"));
            CreateMap<UserDto, UserDtoMinimized>();
            CreateMap<UserForSignUpDto, ApplicationUser>();
            CreateMap<UserCreditCard, CreditCardDto>();
            CreateMap<ApplicationUser, UserForProfileDto>()
                .ForMember(u => u.Name, a => a.MapFrom(a => $"{a.FirstName} {a.LastName}")); ;
        }
    }
}
