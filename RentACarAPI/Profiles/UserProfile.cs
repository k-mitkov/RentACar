using AutoMapper;
using DataBase.Models;

namespace RentACarAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Models.UserLoginDTO, User>();
            CreateMap<Models.UserRegistrationDTO, User>();
        }
    }
}
