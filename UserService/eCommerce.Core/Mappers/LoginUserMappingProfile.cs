using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class LoginUserMappingProfile : Profile
{
    
    public LoginUserMappingProfile()
    {
        CreateMap<LoginRequest, ApplicationUser>()
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(x => x.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(x => x.UserID, opt => opt.Ignore());
    }  
}