using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class RegisterUserMappingProfile : Profile
{
   public RegisterUserMappingProfile()
   {
       CreateMap<RegisterRequest, ApplicationUser>()
           .ForMember(x => x.Gender, opt => opt.MapFrom(src => src.Gender))
           .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(x => x.UserID, opt => opt.Ignore())
           .ForMember(x => x.PersonName, opt => opt.MapFrom(src => src.PersonName))
           .ForMember(x => x.Password, opt => opt.MapFrom(src => src.Password));
   }  
}