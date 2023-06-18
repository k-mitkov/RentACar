using AutoMapper;

namespace RentACarAPI.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile() {
            CreateMap<Models.VehicleCreateDTO, DataBase.Models.Car>();
            CreateMap<DataBase.Models.Car, Models.VehicleDTO>();
        }
    }
}
