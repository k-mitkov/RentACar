using AutoMapper;

namespace RentACarAPI.Profiles
{
    public class PeriodProfile : Profile
    {
        public PeriodProfile()
        {
            CreateMap<DataBase.Models.Period, Models.PeriodDTO>();
        }
    }
}
